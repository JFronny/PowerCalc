using NCalc2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PowerCalc
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();

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

        private void log(string text)
        {
            Invoke((MethodInvoker)delegate () { logBox.Text = text + "\r\n" + logBox.Text; });
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
                List<Tuple<Color, List<PointF>, Expression>> lines = new List<Tuple<Color, List<PointF>, Expression>>
                    {
                        new Tuple<Color, List<PointF>, Expression>(Color.Red, new List<PointF>(), new Expression(calcBox1.Text)),
                        new Tuple<Color, List<PointF>, Expression>(Color.FromArgb(255, 128, 0), new List<PointF>(), new Expression(calcBox2.Text)),
                        new Tuple<Color, List<PointF>, Expression>(Color.FromArgb(0, 192, 0), new List<PointF>(), new Expression(calcBox3.Text)),
                        new Tuple<Color, List<PointF>, Expression>(Color.FromArgb(0, 0, 192), new List<PointF>(), new Expression(calcBox4.Text))
                    };
                for (int i = 0; i < evalBox.Width; i += 10)
                    g.DrawLine(Pens.LightGray, i, 0, i, evalBox.Height);
                for (int i = evalBox.Height; i > 0; i -= 10)
                    g.DrawLine(Pens.LightGray, 0, i, evalBox.Width, i);
                lines.ForEach(s =>
                {
                    s.Item3.Parameters.Add("x", 0);
                    s.Item3.Parameters.Add("Pi", Math.PI);
                    s.Item3.Parameters.Add("pi", Math.PI);
                    s.Item3.Parameters.Add("PI", Math.PI);
                    s.Item3.Parameters.Add("e", Math.E);
                    s.Item3.Parameters.Add("E", Math.E);
                    for (double i = 0; i < evalBox.Width; i++)
                    {
                        try
                        {
                            s.Item3.Parameters["x"] = i / 10;
                            double val = -1;
                            object tmp = s.Item3.Evaluate();
                            if (tmp.GetType() == typeof(bool))
                                val = (bool)tmp ? 1 : 0;
                            else if (tmp.GetType() == typeof(byte))
                                val = (byte)tmp;
                            else if (tmp.GetType() == typeof(sbyte))
                                val = (sbyte)tmp;
                            else if (tmp.GetType() == typeof(short))
                                val = (short)tmp;
                            else if (tmp.GetType() == typeof(ushort))
                                val = (ushort)tmp;
                            else if (tmp.GetType() == typeof(int))
                                val = (int)tmp;
                            else if (tmp.GetType() == typeof(uint))
                                val = (uint)tmp;
                            else if (tmp.GetType() == typeof(long))
                                val = (long)tmp;
                            else if (tmp.GetType() == typeof(ulong))
                                val = (ulong)tmp;
                            else if (tmp.GetType() == typeof(float))
                                val = (float)tmp;
                            else if (tmp.GetType() == typeof(double))
                                val = (double)tmp;
                            else if (tmp.GetType() == typeof(decimal))
                                val = (double)(decimal)tmp;
                            else
                                log("Type mismatch! (" + tmp.GetType().ToString() + ")");
                            float val1 = Convert.ToSingle(val);
                            if (i >= 0 && i < evalBox.Width && val1 >= 0 && val1 < evalBox.Height)
                                s.Item2.Add(new PointF(Convert.ToSingle(i), evalBox.Height - (val1 * 10)));
                        }
                        catch (Exception e1)
                        {
#if DEBUG
                            log("Value error: " + e1.ToString());
#else
                            log("Value error: " + e1.Message);
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
                log("FATAL: " + e1.ToString());
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

        private void evalBox_MouseMove(object sender, MouseEventArgs e) => coordLabel.Text = new Point(e.X, evalBox.Height - e.Y).ToString();

        private void evalBox_MouseLeave(object sender, EventArgs e) => coordLabel.Text = "";
    }
}