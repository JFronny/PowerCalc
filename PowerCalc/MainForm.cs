using NCalc2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerCalc
{
    public partial class MainForm : Form
    {
        Thread evalThread;
        public MainForm()
        {
            InitializeComponent();
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

        private void evalButton_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            evalThread = new Thread(() =>
            {
                Bitmap bmp = new Bitmap(evalBox.Width, evalBox.Height);
                Graphics g = Graphics.FromImage(bmp);
                List<Tuple<Color, List<PointF>, Expression>> lines = new List<Tuple<Color, List<PointF>, Expression>>
                {
                    new Tuple<Color, List<PointF>, Expression>(Color.Red, new List<PointF>(), new Expression(calcBox1.Text)),
                    new Tuple<Color, List<PointF>, Expression>(Color.FromArgb(255, 128, 0), new List<PointF>(), new Expression(calcBox2.Text)),
                    new Tuple<Color, List<PointF>, Expression>(Color.FromArgb(0, 192, 0), new List<PointF>(), new Expression(calcBox3.Text)),
                    new Tuple<Color, List<PointF>, Expression>(Color.FromArgb(0, 0, 192), new List<PointF>(), new Expression(calcBox4.Text))
                };
                try
                {
                    lines.ForEach(s =>
                    {
                        for (int i = 0; i < evalBox.Width; i++)
                        {
                            try
                            {
                                s.Item3.Parameters.Clear();
                                s.Item3.Parameters.Add("x", i);
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
                                    s.Item2.Add(new PointF(i, val1));
                            }
                            catch (Exception e1)
                            {
#if DEBUG
                                log(e1.ToString());
#else
                                log(e1.Message);
#endif
                            }
                        }
                        g.DrawLines(new Pen(s.Item1), s.Item2.ToArray());
                    });
                    g.Flush();
                    g.Dispose();
                    evalBox.BackgroundImage = bmp;
                }
                catch (Exception e1)
                {
                    log("FATAL: " + e1.ToString());
                }
                finally
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        FormBorderStyle = FormBorderStyle.Sizable;
                    });
                }
            });
            evalThread.Start();
        }

        void log(string text)
        {
            Invoke((MethodInvoker)delegate () { logBox.Text = text + "\r\n" + logBox.Text; });
#if DEBUG
            Console.WriteLine(text);
#endif
        }
    }
}
