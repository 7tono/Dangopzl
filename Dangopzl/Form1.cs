using System;
using System.Diagnostics.Metrics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Dangopzl
{
    public partial class Form1 : Form
    {
        Graphics g;

        int selx = -50;
        int sely = -50;

        int DANGO = 0;
        int SENTAKU = 1;
        public Form1()
        {
            InitializeComponent();
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //g = Graphics.FromImage(canvas);

            g = pictureBox1.CreateGraphics();
            // g.Dispose();
            pictureBox1.Image = canvas;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            listView1.View = View.Details;
            InitializeListView();

           
        }
        private void InitializeListView()
        {
            listView1.LabelEdit = true;
            listView1.View = View.Details;
            listView1.Columns.Add("順位");

            listView1.Columns.Add("スコア");
            //listView1.Width = -2;
            listView1.FullRowSelect = true;

        }


        string nuwscore = "";
        string scorecounter_str = "";
        int scorecounter = 0;

        //マップ作成
        
        int[,,] dango_map = new int[2, 11, 7]
            {
                {
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 1, 2, 3, 4, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
            },
                {
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                { 0, 0, 0, 0, 0, 0,0},
                }
            };





        private void makemap() //マップ初期化
        {

            for (int r = 0; r < 9; r++)//行
            {
                for (int c = 0; c < 6; c++)//列
                {

                   

                    //
                    if (dango_map[DANGO, r, c] != 0)
                    {
                        dango_map[DANGO, r, c] = 0;
                    }

                    if (dango_map[SENTAKU, r, c] != 0)
                    {
                        dango_map[SENTAKU, r, c] = 0;
                    }


                }
            }


            for (int c = 0; c < 6; c++)//列
            {
                dango_map[DANGO, 10, c] = 9;
                dango_map[SENTAKU, 10, c] = 1;
            }
        }

        bool fastchack = false;

        private void button1_Click(object sender, EventArgs e)
        {
            nuwscore = textBox1.Text;







            if (fastchack == true)
            {
                scorecounter++;
                scorecounter_str = scorecounter.ToString();
                listView1.Items.Add(new ListViewItem(new string[] { scorecounter_str, nuwscore }));
            }


            

            fastchack = true;
            textBox1.Text = "0";
            temoscor1 = 0;
            temoscor2 = 0;
            makemap();
            mapshafull();
        }



        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {




            e.Graphics.FillRectangle(Brushes.Silver, 0, 0, Width, Height);

            //ボーダー線(縦)
            for (int r = 0; r <= 357; r += 51)
            {
                e.Graphics.DrawLine(Pens.Black, r, 0, r, 511);

            }
            //ボーダー線(横) 357
            for (int r = 0; r <= 510; r += 51)
            {
                e.Graphics.DrawLine(Pens.Black, 0, r, 306, r);

            }




            Pen greenPen = new Pen(Color.FromArgb(255, 0, 255, 0), 5);

            for (int r = 0; r <= 9; r++)//行
            {
                for (int c = 0; c <= 5; c++)//列
                {

                    //だんごを出現させる

                   


                    if (dango_map[DANGO, r, c] == 1)
                    {
                        
                        e.Graphics.FillEllipse(Brushes.Gray, c * 51 + 2, r * 51 + 2, 48, 48);

                    }
                    if (dango_map[DANGO, r, c] == 2)
                    {
                       
                        e.Graphics.FillEllipse(Brushes.Yellow, c * 51 + 2, r * 51 + 2, 48, 48);

                    }
                    if (dango_map[DANGO, r, c] == 3)
                    {
                        
                        e.Graphics.FillEllipse(Brushes.Brown, c * 51 + 2, r * 51 + 2, 48, 48);

                    }
                    if (dango_map[DANGO, r, c] == 4)
                    {
                        
                        e.Graphics.FillEllipse(Brushes.Green, c * 51 + 2, r * 51 + 2, 48, 48);

                    }

                    if (dango_map[SENTAKU, r, c] == 2 || dango_map[SENTAKU, r, c] == 1)
                    {

                        e.Graphics.DrawEllipse(greenPen, c * 51 + 2, r * 51 + 2, 49, 49);

                    }


                }
            }

            greenPen.Dispose();
            

        }




        int value1;
        int value2;
        int value3;

        private void mapshafull()
        {
            var rand_num = new Random();



            for (int r = 0; r < 10; r++)//行
            {
                for (int c = 0; c < 6; c++)//列
                {
                    value3 = rand_num.Next(minValue: 1, maxValue: 5);  //だんごの種類数（上のプログラムで出現させる）
                    dango_map[DANGO, r, c] = value3;
                }
            }


            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
      
            pictureBox1.Refresh();

        }


        int downX = 0;
        int downY = 0;
        int temoscor1 = 0;
        int temoscor2 = 0;
        string temoscor_str = "";
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            downX = (e.X / 51) * 51 + 2;
            downY = (e.Y / 51) * 51 + 2;
            int selcount = 0;

            for (int r = 0; r < 10; r++) //行
            {

                for (int c = 0; c < 6; c++)//列
                {
                    if (dango_map[SENTAKU, r, c] == 1)
                    {
                        selcount++;
                    }
                }
            }


            temoscor1 = 0;
            for (int r = 0; r < 10; r++) //行
            {

                for (int c = 0; c < 6; c++)//列
                {
                    if (dango_map[SENTAKU, r, c] == 1 && selcount > 1)
                    {
                        dango_map[SENTAKU, r, c] = 0;
                        dango_map[DANGO, r, c] = 0;

                        temoscor1++;
                    }
                }
            }

            temoscor2 += 10 * temoscor1 + 5 * (temoscor1 - 1);

            temoscor_str = temoscor2 + "";
            textBox1.Text = temoscor_str;
        }



        int SposX = 0; //Serect Position（セレクト状態にいるマスの座標）
        int SposY = 0;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //MouseMoveが動かない　Tickで空白を上のだんごで埋める　10/15
            selx = (e.X / 51) * 51 + 2;
            sely = (e.Y / 51) * 51 + 2;
            int Dango = 0;  //Mouseの位置にあるだんごの種類




            for (int r = 0; r <= 9; r++)//行
            {
                for (int c = 0; c <= 5; c++)//列
                {
                    dango_map[SENTAKU, r, c] = 0;
                }
            }




            if (dango_map[DANGO, sely / 51, selx / 51] != 0)
            {
                if (dango_map[SENTAKU, sely / 51, selx / 51] != 1)
                {
                    dango_map[SENTAKU, sely / 51, selx / 51] = 1;
                    Dango = dango_map[DANGO, sely / 51, selx / 51];
                    SposX = selx / 51;
                    SposY = sely / 51;
                }

            }



            bool dangflg = false;

            while (dangflg == false)
            {
                dangflg = true;

                for (int r = 0; r < 10; r++) //行
                {

                    for (int c = 0; c < 6; c++)//列
                    {
                        int nd = dango_map[DANGO, r, c];


                        if (nd == Dango)
                        {
                            if (r + 1 < 10 && dango_map[SENTAKU, r + 1, c] == 1 && dango_map[SENTAKU, r, c] != 1)
                            {
                                dango_map[SENTAKU, r, c] = 1; dangflg = false;
                            }
                            if (r - 1 > -1 && dango_map[SENTAKU, r - 1, c] == 1 && dango_map[SENTAKU, r, c] != 1)
                            {
                                dango_map[SENTAKU, r, c] = 1; dangflg = false;
                            }
                            if (c + 1 < 6 && dango_map[SENTAKU, r, c + 1] == 1 && dango_map[SENTAKU, r, c] != 1)
                            {
                                dango_map[SENTAKU, r, c] = 1; dangflg = false;
                            }
                            if (c - 1 > -1 && dango_map[SENTAKU, r, c - 1] == 1 && dango_map[SENTAKU, r, c] != 1)
                            {
                                dango_map[SENTAKU, r, c] = 1; dangflg = false;
                            }

                            

                        }


                    }

                }

 
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            bool fallflg = true;

            do
            {
                fallflg = false;
                for (int r = 9; r > -1; r--) //行
                {

                    for (int c = 5; c > -1; c--)//列
                    {
                        if (dango_map[DANGO, r + 1, c] == 0 && dango_map[DANGO, r, c] != 0)
                        {
                            fallflg = true;

                            dango_map[DANGO, r + 1, c] = dango_map[DANGO, r, c];
                            dango_map[DANGO, r, c] = 0;
                        }
                    }
                }
            } while (fallflg);
        }
    }
}