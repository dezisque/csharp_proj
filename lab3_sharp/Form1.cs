using System;
using System.IO;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3_sharp
{
    public partial class Form1 : Form
    {
        int m_Mode;
        Bitmap m_MainBmp;
        Bitmap m_ProcessBmp;
        Graphics m_ProcessGraphics;
        int m_pw, m_ph, m_px, m_py;
        int m_NumIterations = 0;
        Random m_random;
        
        private void OnDrawModeChanged(object sender, EventArgs e)
        {
            m_Mode = cmbDrawMode.SelectedIndex;
        }

        private void onButFolderClick(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialod = new FolderBrowserDialog();
            folderBrowserDialod.Description = "Выберите директорию с изображениями.";
            folderBrowserDialod.SelectedPath = Directory.GetCurrentDirectory();

            if (folderBrowserDialod.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo di = new DirectoryInfo(folderBrowserDialod.SelectedPath);

                foreach (FileInfo fi in di.GetFiles())
                {
                    if ((fi.Extension == ".png") || (fi.Extension == ".PNG") || (fi.Extension == ".jpg") || (fi.Extension == ".JPG") || (fi.Extension == ".gif") || (fi.Extension == ".GIF") || (fi.Extension == ".bmp") || (fi.Extension == ".BMP"))
                    {
                        listFiles.Items.Add(fi.Name);
                    }
                }
                if (listFiles.Items.Count == 0)
                {
                    MessageBox.Show("В папке '" + di.FullName + "' нет изображени", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    m_baseFolder = di.FullName;
                    labFolder.Text = m_baseFolder;
                }
                
            }
        }

        private void UpdateImage()
        {
            switch (m_Mode)
            {
                case 0:
                    m_px = 0;
                    m_py = 0;
                    m_pw = m_MainBmp.Width;
                    m_ph = m_MainBmp.Height;
                    m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(m_px, m_py, m_pw, m_ph), new Rectangle(m_px, m_py, m_pw, m_ph), GraphicsUnit.Pixel);
                    picMainPicture.Image = m_ProcessBmp;
                    timer1.Enabled = false;
                    listFiles.Enabled = true;
                    cmbDrawMode.Enabled = true;
                    butPrev.Enabled = true;
                    butNext.Enabled = true;
                    break;
                case 1:
                    for (int i = 1; i < 10; i++){
                        m_px = m_random.Next(0, m_MainBmp.Width);
                        m_py = 0;
                        m_pw = 1;
                        m_ph = m_MainBmp.Height;
                        m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(m_px, m_py, m_pw, m_ph), new Rectangle(m_px, m_py, m_pw, m_ph), GraphicsUnit.Pixel);
                        picMainPicture.Image = m_ProcessBmp;
                        m_NumIterations++;
                        if (m_NumIterations > 2.0 * m_MainBmp.Width)
                        {
                            timer1.Enabled = false;
                            listFiles.Enabled = true;
                            cmbDrawMode.Enabled = true;
                            butPrev.Enabled = true;
                            butNext.Enabled = true;

                            picMainPicture.Image = m_MainBmp;
                            break;
                        }
                    }
                    break;
                case 2:
                    double r;
                    Region reg;
                    GraphicsPath gp = new GraphicsPath();
                    m_R += 5;
                    r = m_R / 2;
                    int n = 50;
                    double alpha = 0;
                    double x0 = m_MainBmp.Width / 2, y0 = m_MainBmp.Height / 2;

                    PointF[] points = new PointF[2 * n + 1];
                    double a = alpha, da = Math.PI / n, l;
                    for (int k = 0; k < 2 * n + 1; k++)
                    {
                        if (k % 2 == 0)
                            l = r;
                        else
                            l = m_R;
                        points[k] = new PointF((float)(x0 + l * Math.Cos(a)), (float)(y0 + l * Math.Sin(a)));
                        a += da;
                    }
                    gp.AddLines(points);
                    reg = new Region(gp);
                    m_ProcessGraphics.Clip = reg;

                    m_px = 0;
                    m_py = 0;
                    m_pw = m_MainBmp.Width;
                    m_ph = m_MainBmp.Height;
                    m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(m_px, m_py, m_pw, m_ph), new Rectangle(m_px, m_py, m_pw, m_ph), GraphicsUnit.Pixel);
                    picMainPicture.Image = m_ProcessBmp;
                    
                    if (m_R > 1.2 * m_MainBmp.Width)
                    {
                        timer1.Enabled = false;
                        listFiles.Enabled = true;
                        cmbDrawMode.Enabled = true;
                        butPrev.Enabled = true;
                        butNext.Enabled = true;

                        picMainPicture.Image = m_MainBmp;
                        break;
                    }
                    break;
                case 3:
                    m_pw+=10;
                    if (m_pw >= m_MainBmp.Width)
                    {   
                        m_py+=10;
                        m_pw = 0;
                    }
                    for (int i = 1; i < 5; i++)
                    {
                        m_px = 0;
                        m_ph = 10;
                        m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(m_px, m_py, m_pw, m_ph), new Rectangle(m_px, m_py, m_pw, m_ph), GraphicsUnit.Pixel);
                        picMainPicture.Image = m_ProcessBmp;
                        m_NumIterations++;
                        
                        if (m_NumIterations > 10.0 * m_MainBmp.Height)
                        {
                            timer1.Enabled = false;
                            listFiles.Enabled = true;
                            cmbDrawMode.Enabled = true;
                            butPrev.Enabled = true;
                            butNext.Enabled = true;

                            picMainPicture.Image = m_MainBmp;
                            break;
                        }
                    }
                    break;
                case 4:
                    for (int i = 1; i < 5; i++)
                    {
                        m_px = 0;
                        m_py = m_random.Next(0, m_MainBmp.Height);
                        m_pw = m_MainBmp.Width;
                        m_ph = 1;
                        m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(m_px, m_py, m_pw, m_ph), new Rectangle(m_px, m_py, m_pw, m_ph), GraphicsUnit.Pixel);
                        picMainPicture.Image = m_ProcessBmp;
                        m_NumIterations++;
                        if (m_NumIterations > 2.0 * m_MainBmp.Height)
                        {
                            timer1.Enabled = false;
                            listFiles.Enabled = true;
                            cmbDrawMode.Enabled = true;
                            butPrev.Enabled = true;
                            butNext.Enabled = true;

                            picMainPicture.Image = m_MainBmp;
                            break;
                        }
                    }
                    break;
                case 5:
                    for (int i = 1; i < 5; i++)
                    {
                        m_px = m_random.Next(0, m_MainBmp.Width);
                        m_py = m_random.Next(0, m_MainBmp.Height);
                        m_pw = 10;
                        m_ph = 10;
                        m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(m_px, m_py, m_pw, m_ph), new Rectangle(m_px, m_py, m_pw, m_ph), GraphicsUnit.Pixel);
                        picMainPicture.Image = m_ProcessBmp;
                        m_NumIterations++;
                        if (m_NumIterations > 5.0 * m_MainBmp.Width)
                        {
                            timer1.Enabled = false;
                            listFiles.Enabled = true;
                            cmbDrawMode.Enabled = true;
                            butPrev.Enabled = true;
                            butNext.Enabled = true;

                            picMainPicture.Image = m_MainBmp;
                            break;
                        }
                    }
                    break;
                case 6:

                    for (int i = 1; i < 5; i++)
                    {
                        m_px = m_random.Next(0, m_MainBmp.Width);
                        m_py = m_random.Next(0, m_MainBmp.Height);
                        m_pw = 10;
                        m_ph = 10;

                        GraphicsPath p = new GraphicsPath();
                        p.AddPolygon(new Point[] {
                            new Point(m_px, m_py),
                            new Point(m_px, m_py + 10),
                            new Point(5 + m_px, 5 + m_py) });
                        m_ProcessGraphics.SetClip(p);

                        m_ProcessGraphics.DrawImage(m_MainBmp, new Point(0, 0));
                        picMainPicture.Image = m_ProcessBmp;
                        m_NumIterations++;
                        if (m_NumIterations > 10.0 * m_MainBmp.Width)
                        {
                            timer1.Enabled = false;
                            listFiles.Enabled = true;
                            cmbDrawMode.Enabled = true;
                            butPrev.Enabled = true;
                            butNext.Enabled = true;

                            picMainPicture.Image = m_MainBmp;
                            break;
                        }
                    }
                    break;
                case 7:
                    m_ph += 10;
                    if (m_ph >= m_MainBmp.Height)
                    {
                        m_px += 10;
                        m_ph = 0;
                    }
                    for (int i = 1; i < 5; i++)
                    {
                        m_py = 0;
                        m_pw = 10;
                        m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(m_px, m_py, m_pw, m_ph), new Rectangle(m_px, m_py, m_pw, m_ph), GraphicsUnit.Pixel);
                        picMainPicture.Image = m_ProcessBmp;
                        m_NumIterations++;

                        if (m_NumIterations > 10.0 * m_MainBmp.Width)
                        {
                            timer1.Enabled = false;
                            listFiles.Enabled = true;
                            cmbDrawMode.Enabled = true;
                            butPrev.Enabled = true;
                            butNext.Enabled = true;

                            picMainPicture.Image = m_MainBmp;
                            break;
                        }
                    }
                    break;
                case 8:
                    for (int i = 1; i < 5; i++)
                    {
                        m_px = m_random.Next(0, m_MainBmp.Width);
                        m_py = m_random.Next(0, m_MainBmp.Height);
                        m_pw = 10;
                        m_ph = 10;

                        GraphicsPath p = new GraphicsPath();
                        p.AddEllipse(m_px, m_py, 10, 10);
                        m_ProcessGraphics.SetClip(p);

                        m_ProcessGraphics.DrawImage(m_MainBmp, new Point(0, 0));
                        picMainPicture.Image = m_ProcessBmp;
                        m_NumIterations++;
                        if (m_NumIterations > 10.0 * m_MainBmp.Width)
                        {
                            timer1.Enabled = false;
                            listFiles.Enabled = true;
                            cmbDrawMode.Enabled = true;
                            butPrev.Enabled = true;
                            butNext.Enabled = true;

                            picMainPicture.Image = m_MainBmp;
                            break;
                        }
                    }
                    break;
                case 9:
                    for (int i = 1; i < 5; i++)
                    {
                        m_px = 0;
                        m_py = m_random.Next(0, m_MainBmp.Height);
                        m_pw = m_MainBmp.Width;
                        m_ph = 1;
                        m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(m_px, m_py, m_pw, m_ph), new Rectangle(m_px, m_py, m_pw, m_ph), GraphicsUnit.Pixel);
                        picMainPicture.Image = m_ProcessBmp;
                        m_NumIterations++;
                        if (m_NumIterations > 2.0 * m_MainBmp.Height)
                        {
                            timer1.Enabled = false;
                            listFiles.Enabled = true;
                            cmbDrawMode.Enabled = true;
                            butPrev.Enabled = true;
                            butNext.Enabled = true;

                            picMainPicture.Image = m_MainBmp;
                            break;
                        }
                    }
                    break;
                case 10:
                    int rand = m_random.Next(0, 4);
                    for (int i = 1; i < 5; i++)
                    {
                        m_px = m_random.Next(0, m_MainBmp.Width);
                        m_py = m_random.Next(0, m_MainBmp.Height);
                        m_pw = 10;
                        m_ph = 10;

                        switch (rand)
                        {
                            case 1:
                                GraphicsPath p = new GraphicsPath();
                                p.AddPolygon(new Point[] {
                                new Point(m_px, m_py),
                                new Point(m_px, m_py + 10),
                                new Point(5 + m_px, 5 + m_py) });
                                m_ProcessGraphics.SetClip(p);
                                break;
                            case 2:
                                GraphicsPath p2 = new GraphicsPath();
                                p2.AddEllipse(m_px, m_py, 10, 10);
                                m_ProcessGraphics.SetClip(p2);
                                break;
                        }

                        m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(m_px, m_py, m_pw, m_ph), new Rectangle(m_px, m_py, m_pw, m_ph), GraphicsUnit.Pixel);
                        picMainPicture.Image = m_ProcessBmp;
                        m_NumIterations++;
                        if (m_NumIterations > 10.0 * m_MainBmp.Width)
                        {
                            timer1.Enabled = false;
                            listFiles.Enabled = true;
                            cmbDrawMode.Enabled = true;
                            butPrev.Enabled = true;
                            butNext.Enabled = true;

                            picMainPicture.Image = m_MainBmp;
                            break;
                        }
                    }
                    break;

                case 11:
                    for (int i = 1; i < 5; i++)
                    {
                        m_ph = 5;
                        m_pw = 5;

                        m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(m_px, 0, m_pw, m_MainBmp.Height), new Rectangle(m_px, 0, m_pw, m_MainBmp.Height), GraphicsUnit.Pixel);
                        m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(m_MainBmp.Width - m_px, 0, -5, m_MainBmp.Height), new Rectangle(m_MainBmp.Width - m_px, 0, -5, m_MainBmp.Height), GraphicsUnit.Pixel);
                        m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(0, m_py, m_MainBmp.Width, 5), new Rectangle(0, m_py, m_MainBmp.Width, 5), GraphicsUnit.Pixel);
                        m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(0, m_MainBmp.Height - m_py, m_MainBmp.Width, -5), new Rectangle(0, m_MainBmp.Height - m_py, m_MainBmp.Width, -5), GraphicsUnit.Pixel);

                        picMainPicture.Image = m_ProcessBmp;
                        m_NumIterations++;
                        if (m_MainBmp.Width > m_MainBmp.Height)
                        {
                            if (m_NumIterations > m_MainBmp.Width)
                            {
                                timer1.Enabled = false;
                                listFiles.Enabled = true;
                                cmbDrawMode.Enabled = true;
                                butPrev.Enabled = true;
                                butNext.Enabled = true;

                                picMainPicture.Image = m_MainBmp;
                                break;
                            }
                        }
                        else
                        {
                            if (m_NumIterations > m_MainBmp.Height)
                            {
                                timer1.Enabled = false;
                                listFiles.Enabled = true;
                                cmbDrawMode.Enabled = true;
                                butPrev.Enabled = true;
                                butNext.Enabled = true;

                                picMainPicture.Image = m_MainBmp;
                                break;
                            }
                        }
                        
                    }
                    m_py += 5;
                    m_px += 5;
                    break;
                case 12:
                    int fSide = m_random.Next(0, 5);
                    int srandNum = m_random.Next(0, 4);
                    int sSide = (fSide + srandNum) % 4;

                    for (int i = 1; i < 5; i++)
                    {
                        int m_py2 = 0;
                        int m_px2 = 0;
                        switch (fSide) {
                            case 1:
                                m_py = 0;
                                m_px = m_random.Next(0, m_MainBmp.Width);
                                break;
                            case 2:
                                m_px = 0;
                                m_py = m_random.Next(0, m_MainBmp.Height);
                                break;
                            case 3:
                                m_py = m_MainBmp.Height;
                                m_px = m_random.Next(0, m_MainBmp.Width);
                                break;
                            case 4:
                                m_px = m_MainBmp.Width;
                                m_py = m_random.Next(0, m_MainBmp.Height);
                                break;
                        }

                        switch (sSide)
                        {
                            case 1:
                                m_py2 = 0;
                                m_px2 = m_random.Next(0, m_MainBmp.Width);
                                break;
                            case 2:
                                m_px2 = 0;
                                m_py2 = m_random.Next(0, m_MainBmp.Height);
                                break;
                            case 3:
                                m_py2 = m_MainBmp.Height;
                                m_px2 = m_random.Next(0, m_MainBmp.Width);
                                break;
                            case 4:
                                m_px2 = m_MainBmp.Width;
                                m_py2 = m_random.Next(0, m_MainBmp.Height);
                                break;
                        }

                        GraphicsPath p = new GraphicsPath();
                        p.AddPolygon(new Point[] {
                            new Point(m_px, m_py),
                            new Point(m_px + 1, m_py + 1),
                            new Point(m_px2 + 1, m_py2 + 1),
                            new Point(m_px2, m_py2)});

                        m_ProcessGraphics.SetClip(p);

                        m_ProcessGraphics.DrawImage(m_MainBmp, new Point(0, 0));

                        picMainPicture.Image = m_ProcessBmp;
                        m_NumIterations++;
                        if (m_NumIterations > m_MainBmp.Width * 5)
                        {
                            timer1.Enabled = false;
                            listFiles.Enabled = true;
                            cmbDrawMode.Enabled = true;
                            butPrev.Enabled = true;
                            butNext.Enabled = true;

                            picMainPicture.Image = m_MainBmp;
                            break;
                        }

                    }
                    m_py += 5;
                    m_px += 5;
                    break;
                case 13:
                    for (int i = 1; i < 5; i++)
                    {
                        m_px = m_random.Next(0, m_MainBmp.Width);
                        m_py = m_random.Next(0, m_MainBmp.Height);
                        m_pw = m_random.Next(0, 100);
                        m_ph = m_random.Next(0, 100);
                        m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(m_px, m_py, m_pw, m_ph), new Rectangle(m_px, m_py, m_pw, m_ph), GraphicsUnit.Pixel);
                        picMainPicture.Image = m_ProcessBmp;
                        m_NumIterations++;
                        if (m_NumIterations > 5.0 * m_MainBmp.Width)
                        {
                            timer1.Enabled = false;
                            listFiles.Enabled = true;
                            cmbDrawMode.Enabled = true;
                            butPrev.Enabled = true;
                            butNext.Enabled = true;

                            picMainPicture.Image = m_MainBmp;
                            break;
                        }
                    }
                    break;
                case 14:
                    for (int i = 1; i < 5; i++)
                    {
                        m_px = m_random.Next(0, m_MainBmp.Width);
                        m_py = m_random.Next(0, m_MainBmp.Height);
                        m_pw = 1;
                        m_ph = m_random.Next(0, m_MainBmp.Height - m_py);
                        m_ProcessGraphics.DrawImage(m_MainBmp, new Rectangle(m_px, m_py, m_pw, m_ph), new Rectangle(m_px, m_py, m_pw, m_ph), GraphicsUnit.Pixel);
                        picMainPicture.Image = m_ProcessBmp;
                        m_NumIterations++;
                        if (m_NumIterations > 5.0 * m_MainBmp.Width)
                        {
                            timer1.Enabled = false;
                            listFiles.Enabled = true;
                            cmbDrawMode.Enabled = true;
                            butPrev.Enabled = true;
                            butNext.Enabled = true;

                            picMainPicture.Image = m_MainBmp;
                            break;
                        }
                    }
                    break;
            }
        }

        private void OnTimer(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private void OnImageListClick(object sender, EventArgs e)
        {
            String file;
            if (timer1.Enabled) timer1.Enabled = false;
            file = m_baseFolder + "//" + listFiles.Items[listFiles.SelectedIndex].ToString();
            if (m_MainBmp != null) m_MainBmp.Dispose();
            if (m_ProcessBmp != null) m_ProcessBmp.Dispose();
            if (m_ProcessGraphics != null) m_ProcessGraphics.Dispose();

            m_MainBmp = new Bitmap(file);
            m_ProcessBmp = new Bitmap(m_MainBmp.Width, m_MainBmp.Height);
            m_ProcessGraphics = Graphics.FromImage(m_ProcessBmp);
            m_ProcessGraphics.Clear(Color.Black);

            m_NumIterations = 0;
            m_R = 0;
            m_px = m_py = 0;
            m_pw = m_MainBmp.Width / 10;
            m_ph = m_MainBmp.Height / 10;

            timer1.Enabled = true;
            listFiles.Enabled = false;
            cmbDrawMode.Enabled = false;
            butPrev.Enabled = false;
            butNext.Enabled = false;
        }

        private void OnNextClick(object sender, EventArgs e)
        {
            if (listFiles.SelectedIndex >= 0 && listFiles.SelectedIndex < listFiles.Items.Count - 1 )
            {
                listFiles.SelectedIndex++;
            };
            OnImageListClick(null, null);
        }

        private void OnPrevClick(object sender, EventArgs e)
        {
            if (listFiles.SelectedIndex > 0 && listFiles.SelectedIndex < listFiles.Items.Count)
            {
                listFiles.SelectedIndex--;
            };
            OnImageListClick(null, null);
        }

        double m_R = 5;
        String m_baseFolder;

        public Form1()
        {
            InitializeComponent();
            m_random = new Random();
            cmbDrawMode.SelectedIndex = 0;
        }
    }
}
