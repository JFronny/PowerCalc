using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using NCalc2;

namespace PowerCalc
{
    public partial class MainForm : Form
    {
        private Point offStart = Point.Empty;
        public decimal offX;
        public decimal offY;

        public MainForm()
        {
            InitializeComponent();
            evalBox_MouseLeave(null, null);
#if DEBUG
            logExpandButton_Click(null, null);
#else
            logCollapseButton_Click(null, null);
#endif
        }

        private void logCollapseButton_Click(object sender, EventArgs e)
        {
            logExpandButton.Visible = true;
            splitContainer.Panel2Collapsed = true;
        }

        private void logExpandButton_Click(object sender, EventArgs e)
        {
            logExpandButton.Visible = false;
            splitContainer.Panel2Collapsed = false;
        }

        private void eval(object sender, EventArgs e) => evalBox.Invalidate();

        private void log(object text)
        {
            logBox.Lines = new[] {text.ToString()}.Concat(logBox.Lines).Where((s, i) => i < 30).ToArray();
#if DEBUG
            Console.WriteLine(text);
#endif
        }

        private void evalBox_Paint(object sender, PaintEventArgs e)
        {
            DateTime start = DateTime.Now;
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.None;
                g.InterpolationMode = InterpolationMode.Low;
                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.PixelOffsetMode = PixelOffsetMode.None;
                g.CompositingMode = CompositingMode.SourceCopy;
                List<Tuple<Color, List<PointF>, Expression>> lines = new List<Tuple<Color, List<PointF>, Expression>>
                {
                    new Tuple<Color, List<PointF>, Expression>(Color.Red, new List<PointF>(),
                        new Expression(calcBox1.Text)),
                    new Tuple<Color, List<PointF>, Expression>(Color.FromArgb(255, 128, 0), new List<PointF>(),
                        new Expression(calcBox2.Text)),
                    new Tuple<Color, List<PointF>, Expression>(Color.FromArgb(0, 192, 0), new List<PointF>(),
                        new Expression(calcBox3.Text)),
                    new Tuple<Color, List<PointF>, Expression>(Color.FromArgb(0, 0, 192), new List<PointF>(),
                        new Expression(calcBox4.Text))
                };
                for (int i = (int) (offX % 10); i < evalBox.Width; i += 10)
                    g.DrawLine(offX - i == 0 ? Pens.Gray : Pens.LightGray, i, 0, i, evalBox.Height);
                for (int i = evalBox.Height + (int) (offY % 10); i > 0; i -= 10)
                    g.DrawLine(evalBox.Height + (offY - i) == 0 ? Pens.Gray : Pens.LightGray, 0, i, evalBox.Width, i);
                lines.ForEach(s =>
                {
                    s.Item3.Parameters.Add("Pi", Math.PI);
                    s.Item3.Parameters.Add("pi", Math.PI);
                    s.Item3.Parameters.Add("PI", Math.PI);
                    s.Item3.Parameters.Add("e", Math.E);
                    s.Item3.Parameters.Add("E", Math.E);
                    for (double i = 0; i < evalBox.Width; i++)
                        try
                        {
                            s.Item3.Parameters["x"] = (i - (double) offX) / 10;
                            double val = -1;
                            object tmp = s.Item3.Evaluate();
                            if (tmp.GetType() == typeof(bool))
                                val = (bool) tmp ? 1 : 0;
                            else if (tmp.GetType() == typeof(byte))
                                val = (byte) tmp;
                            else if (tmp.GetType() == typeof(sbyte))
                                val = (sbyte) tmp;
                            else if (tmp.GetType() == typeof(short))
                                val = (short) tmp;
                            else if (tmp.GetType() == typeof(ushort))
                                val = (ushort) tmp;
                            else if (tmp.GetType() == typeof(int))
                                val = (int) tmp;
                            else if (tmp.GetType() == typeof(uint))
                                val = (uint) tmp;
                            else if (tmp.GetType() == typeof(long))
                                val = (long) tmp;
                            else if (tmp.GetType() == typeof(ulong))
                                val = (ulong) tmp;
                            else if (tmp.GetType() == typeof(float))
                                val = (float) tmp;
                            else if (tmp.GetType() == typeof(double))
                                val = (double) tmp;
                            else if (tmp.GetType() == typeof(decimal))
                                val = (double) (decimal) tmp;
                            else
                                log("Type mismatch! (" + tmp.GetType() + ")");
                            float val1 = Convert.ToSingle(val);
                            float loc = Convert.ToSingle(evalBox.Height - ((val1 * 10) - (float) offY));
                            if (loc >= 0 && loc < evalBox.Height)
                                s.Item2.Add(new PointF(Convert.ToSingle(i), loc));
                        }
                        catch (Exception e1)
                        {
#if DEBUG
                            log("Value error: " + e1);
#else
                            log("Value error: " + e1.Message);
#endif
                            break;
                        }
                    g.DrawLines(new Pen(s.Item1), s.Item2.ToArray());
                });
                g.Flush();
            }
            catch (Exception e1)
            {
                log(e1);
            }
            finally
            {
                log("Eval completed in: " +
                    string.Join(".", (DateTime.Now - start).ToString().Split('.')
                        .Select(s =>
                        {
                            if (!s.Contains(":") && s.Length > 4)
                                s = s.Remove(4, s.Length - 4);
                            return s;
                        })
                    ));
            }
        }

        private void evalBox_MouseMove(object sender, MouseEventArgs e)
        {
            coordLabel.Text = new Point((int) Math.Round((double) (e.X - offX) / 10d),
                (int) Math.Round((double) ((evalBox.Height + offY) - e.Y) / 10d)).ToString();
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                offX += e.X - offStart.X;
                offY += e.Y - offStart.Y;
                offStart = e.Location;
                evalBox.Invalidate();
            }
        }

        private void evalBox_MouseLeave(object sender, EventArgs e) =>
            coordLabel.Text = Point.Empty.ToString().Replace("0", "");

        private void evalBox_MouseDown(object sender, MouseEventArgs e) => offStart = e.Location;

        private void saveButton_Click(object sender, EventArgs e)
        {
            ImageFormat[] formats =
            {
                ImageFormat.Bmp,
                ImageFormat.Emf,
                ImageFormat.Gif,
                ImageFormat.Jpeg,
                ImageFormat.Png,
                ImageFormat.Tiff,
                ImageFormat.Wmf
            };
            SaveFileDialog dlg = new SaveFileDialog
            {
                FileName = "Graph",
                Filter = string.Join("|",
                    formats.Select(s => s + " Image|*." + (s.ToString() == "Jpeg" ? "jpg" : s.ToString().ToLower()))
                        .ToArray())
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(evalBox.Width, evalBox.Height);
                evalBox_Paint(evalBox,
                    new PaintEventArgs(Graphics.FromImage(bmp), new Rectangle(Point.Empty, bmp.Size)));
                bmp.Save(dlg.FileName, formats[dlg.FilterIndex - 1]);
            }
        }
    }
}