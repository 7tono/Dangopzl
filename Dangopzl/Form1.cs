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

            /*
            int[,] intValues = new int[10, 6] 
            {
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
            };
            */
        }
        private void InitializeListView()
        {
            listView1.LabelEdit = true;
            listView1.View = View.Details;
            listView1.Columns.Add("����");

            listView1.Columns.Add("�X�R�A");
            //listView1.Width = -2;
            listView1.FullRowSelect = true;

        }


        string nuwscore = "";
        string scorecounter_str = "";
        int scorecounter = 0;

        //�}�b�v�쐬
        /*
         * 
        //�񎟌�
        int[,] intValues = new int[11, 7]
            {
                {0, 0, 0, 0, 0, 0,0},
                {0, 0, 0, 0, 0, 0,0},
                {0, 0, 0, 0, 0, 0,0},
                {0, 0, 0, 0, 0, 0,0},
                {0, 1, 2, 3, 4, 0,0},
                {0, 0, 0, 0, 0, 0,0},
                {0, 0, 0, 0, 0, 0,0},
                {0, 0, 0, 0, 0, 0,0},
                {0, 0, 0, 0, 0, 0,0},
                {0, 0, 0, 0, 0, 0,0},
                {0, 0, 0, 0, 0, 0,0},
            };
        */

        //�O����
        int[,,] intValues = new int[2, 11, 7]
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





        private void makemap() //�}�b�v������
        {

            for (int r = 0; r <= 9; r++)//�s
            {
                for (int c = 0; c <= 5; c++)//��
                {

                    //�񎟌�
                    /*
                    if (intValues[r, c] != 0)
                    {
                        intValues[r, c] = 0;
                    }
                    */

                    //�O����
                    if (intValues[0, r, c] != 0)
                    {
                        intValues[0, r, c] = 0;
                    }

                    if (intValues[1, r, c] != 0)
                    {
                        intValues[1, r, c] = 0;
                    }


                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            nuwscore = textBox1.Text;
            scorecounter++;






            //if (listView1.Items.Count <= 19)
            {
                scorecounter_str = scorecounter.ToString();
                listView1.Items.Add(new ListViewItem(new string[] { scorecounter_str, nuwscore }));
            }


            /* �񎟌�
            for (int r = 0; r <= 9; r++)//�s
            {
                for (int c = 0; c <= 5; c++)//��
                {
                    if (intValues[r, c] == 1)
                    {
                        textBox1.Text = "100";
                    }
                }
            }
            */

            makemap();
            mapshafull();
        }



        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {




            e.Graphics.FillRectangle(Brushes.Silver, 0, 0, Width, Height);

            //�{�[�_�[��(�c)
            for (int r = 0; r <= 357; r += 51)
            {
                e.Graphics.DrawLine(Pens.Black, r, 0, r, 511);

            }
            //�{�[�_�[��(��) 357
            for (int r = 0; r <= 510; r += 51)
            {
                e.Graphics.DrawLine(Pens.Black, 0, r, 306, r);

            }






            for (int r = 0; r <= 9; r++)//�s
            {
                for (int c = 0; c <= 5; c++)//��
                {

                    //���񂲂��o��������

                    /* �񎟌�
                    if (intValues[r, c] == 1)
                    {
                        //g.DrawLine(Pens.Red, 1, 1, 1, 1);
                        e.Graphics.FillEllipse(Brushes.Gray, c * 51 + 2, r * 51 + 2, 48, 48);

                    }
                    if (intValues[r, c] == 2)
                    {
                        //g.DrawLine(Pens.Red,1, 1, 1, 1);
                        e.Graphics.FillEllipse(Brushes.Yellow, c * 51 + 2, r * 51 + 2, 48, 48);

                    }
                    if (intValues[r, c] == 3)
                    {
                        //g.DrawLine(Pens.Red,1, 1, 1, 1);
                        e.Graphics.FillEllipse(Brushes.Brown, c * 51 + 2, r * 51 + 2, 48, 48);

                    }
                    if (intValues[r, c] == 4)
                    {
                        //g.DrawLine(Pens.Red,1, 1, 1, 1);
                        e.Graphics.FillEllipse(Brushes.Green, c * 51 + 2, r * 51 + 2, 48, 48);

                    }
                    */

                    //�O����


                    if (intValues[0, r, c] == 1)
                    {
                        //g.DrawLine(Pens.Red, 1, 1, 1, 1);
                        e.Graphics.FillEllipse(Brushes.Gray, c * 51 + 2, r * 51 + 2, 48, 48);

                    }
                    if (intValues[0, r, c] == 2)
                    {
                        //g.DrawLine(Pens.Red,1, 1, 1, 1);
                        e.Graphics.FillEllipse(Brushes.Yellow, c * 51 + 2, r * 51 + 2, 48, 48);

                    }
                    if (intValues[0, r, c] == 3)
                    {
                        //g.DrawLine(Pens.Red,1, 1, 1, 1);
                        e.Graphics.FillEllipse(Brushes.Brown, c * 51 + 2, r * 51 + 2, 48, 48);

                    }
                    if (intValues[0, r, c] == 4)
                    {
                        //g.DrawLine(Pens.Red,1, 1, 1, 1);
                        e.Graphics.FillEllipse(Brushes.Green, c * 51 + 2, r * 51 + 2, 48, 48);

                    }

                    if (intValues[1, r, c] == 1)
                    {
                        e.Graphics.DrawEllipse(Pens.Blue, c * 51 + 2, r * 51 + 2, 49, 49);
                    }


                }
            }


            /*
            //�O����
            if (intValues[0,sely / 51, selx / 51] != 0)
            {
                e.Graphics.DrawEllipse(Pens.Red, selx, sely, 49, 49);
            }
            */



        }




        int value1;
        int value2;
        int value3;

        private void mapshafull()
        {
            var rand_num = new Random();



            for (int r = 0; r <= 9; r++)//�s
            {
                for (int c = 0; c <= 5; c++)//��
                {
                    value3 = rand_num.Next(minValue: 1, maxValue: 5);  //���񂲂̎�ސ��i��̃v���O�����ŏo��������j
                    intValues[0, r, c] = value3;
                }
            }


            /*�񎟌�
            value3 = rand_num.Next(minValue: 1, maxValue: 5);  //���񂲂̎�ސ��i��̃v���O�����ŏo��������j
            intValues[value1, value2] = value3;
            pictureBox1.Refresh();
            */


            //�O����
            value3 = rand_num.Next(minValue: 1, maxValue: 5);  //���񂲂̎�ސ��i��̃v���O�����ŏo��������j
            intValues[0, value1, value2] = value3;
            pictureBox1.Refresh();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
            var rand_row = new Random();
            value1 = rand_row.Next(minValue: 0, maxValue: 10);
            var rand_colm = new Random();
            value2 = rand_colm.Next(minValue: 0, maxValue: 6);
            var rand_num = new Random();
            value3 = rand_num.Next(minValue: 1, maxValue: 5);  //���񂲂̎�ސ��i��̃v���O�����ŏo��������j


            //intValues[value1, value2] = value3;

            */
            pictureBox1.Refresh();

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }


        int SposX = 0; //Serect Position�i�Z���N�g��Ԃɂ���}�X�̍��W�j
        int SposY = 0;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //MouseMove�������Ȃ��@Tick�ŋ󔒂���̂��񂲂Ŗ��߂�@10/15
            selx = (e.X / 51) * 51 + 2;
            sely = (e.Y / 51) * 51 + 2;
            int Dango = 0;  //Mouse�̈ʒu�ɂ��邾�񂲂̍��W




            for (int r = 0; r <= 9; r++)//�s
            {
                for (int c = 0; c <= 5; c++)//��
                {
                    intValues[1, r, c] = 0;
                }
            }




            if (intValues[0, sely / 51, selx / 51] != 0)
            {
                if (intValues[1, sely / 51, selx / 51] == 0)
                {
                    intValues[1, sely / 51, selx / 51] = 1;
                    Dango = intValues[0, sely / 51, selx / 51];
                    SposX = selx / 51;
                    SposY = sely / 51;
                }

            }

            for (int r = 0; r <= 9; r++)//�s
            {
                for (int c = 0; c <= 5; c++)//��
                {
                    if (r == SposX + 1 || r == SposX -1)
                    {
                        if (c == SposY + 1 || c == SposY - 1)
                        {
                            //�z��0�ɑI���t���O�ƑI���ς݃t���O�������ėׂ荇���Ă�����̂�T���@10/16
                        }
                    }
                }
            }


        }
    }
}