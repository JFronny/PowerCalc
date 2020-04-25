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
        private Point _offStart = Point.Empty;
        private decimal _offX;
        private decimal _offY;

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

        private void Eval(object sender, EventArgs e) => evalBox.Invalidate();

        private void Log(object text)
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
                g.Clear(Color.White);
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
                for (int i = (int) (_offX % 10); i < evalBox.Width; i += 10)
                    g.DrawLine(_offX - i == 0 ? Pens.Gray : Pens.LightGray, i, 0, i, evalBox.Height);
                for (int i = evalBox.Height + (int) (_offY % 10); i > 0; i -= 10)
                    g.DrawLine(evalBox.Height + (_offY - i) == 0 ? Pens.Gray : Pens.LightGray, 0, i, evalBox.Width, i);
                lines.ForEach(s =>
                {
                    s.Item3.Parameters.Add("Pi", Math.PI);
                    s.Item3.Parameters.Add("pi", Math.PI);
                    s.Item3.Parameters.Add("PI", Math.PI);
                    s.Item3.Parameters.Add("e", Math.E);
                    s.Item3.Parameters.Add("E", Math.E);
                    for (double i = 0; i < evalBox.Width; i++)
                    {
                        try
                        {
                            s.Item3.Parameters["x"] = (i - (double) _offX) / 10;
                            double val = -1;
                            object tmp = s.Item3.Evaluate();
                            switch (tmp)
                            {
                                case bool b:
                                    val = b ? 1 : 0;
                                    break;
                                case byte b:
                                    val = b;
                                    break;
                                case sbyte o:
                                    val = o;
                                    break;
                                case short o:
                                    val = o;
                                    break;
                                case ushort o:
                                    val = o;
                                    break;
                                case int o:
                                    val = o;
                                    break;
                                case uint u:
                                    val = u;
                                    break;
                                case long l:
                                    val = l;
                                    break;
                                case ulong o:
                                    val = o;
                                    break;
                                case float f:
                                    val = f;
                                    break;
                                case double d:
                                    val = d;
                                    break;
                                case decimal o:
                                    val = (double) o;
                                    break;
                                default:
                                    Log("Type mismatch! (" + tmp.GetType() + ")");
                                    break;
                            }

                            float val1 = Convert.ToSingle(val);
                            float loc = Convert.ToSingle(evalBox.Height - (val1 * 10 - (float) _offY));
                            PointF tmp2 = new PointF(Convert.ToSingle(i), loc);
                            if (!new[] {tmp2.X, tmp2.Y}.Any(f => float.IsInfinity(f) || float.IsNaN(f)))
                                s.Item2.Add(tmp2);
                        }
                        catch (Exception e1)
                        {
#if DEBUG
                            log("Value error: " + e1);
#else
                            Log("Value error: " + e1.Message);
#endif
                            break;
                        }
                    }

                    g.DrawLines(new Pen(s.Item1), s.Item2.ToArray());
                });
                g.Flush();
            }
            catch (Exception e1)
            {
                Log(e1);
            }
            finally
            {
                Log("Eval completed in: " +
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
            coordLabel.Text = new Point((int) Math.Round((double) (e.X - _offX) / 10d),
                (int) Math.Round((double) (evalBox.Height + _offY - e.Y) / 10d)).ToString();
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                _offX += e.X - _offStart.X;
                _offY += e.Y - _offStart.Y;
                _offStart = e.Location;
                evalBox.Invalidate();
            }
        }

        private void evalBox_MouseLeave(object sender, EventArgs e) =>
            coordLabel.Text = Point.Empty.ToString().Replace("0", "");

        private void evalBox_MouseDown(object sender, MouseEventArgs e) => _offStart = e.Location;

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