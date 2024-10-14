using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Dangopzl
{
    public partial class Form1 : Form
    {
        Graphics g;



        public Form1()
        {
            InitializeComponent();
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(canvas);

            //ボーダー線(縦)
            for (int r = 0; r <= 357; r += 51)
            {
                g.DrawLine(Pens.Black, r, 0, r, 511);
                
            }


            //ボーダー線(横) 357
            for (int r = 0; r <= 510; r += 51)
            {
                g.DrawLine(Pens.Black, 0, r, 306, r);
                
            }


            g.Dispose();
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
            listView1.Columns.Add("順位");

            listView1.Columns.Add("スコア");
            //listView1.Width = -2;
            listView1.FullRowSelect = true;

        }


        string nuwscore = "";
        string scorecounter_str = "";
        int scorecounter = 0;

        //マップ作成
        int[,] intValues = new int[10, 6]
            {
                {0, 1, 0, 1, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0, 0},
                {0, 0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0, 0},
                {0, 0, 0, 0, 1, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
            };
        private void makemap()　//マップ初期化
        {
            
            for (int r = 0; r <= 9; r++)//行
            {
                for (int c = 0; c <= 5; c++)//列
                {
                    if (intValues[r, c] == 1)
                    {
                        intValues[r, c] = 0;
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

            for(int r = 0; r <= 9; r++)//行
            {
                for (int c = 0; c <= 5; c++)//列
                {
                    if (intValues[r, c] == 1)
                    {
                        textBox1.Text = "100";
                    }
                }
            }
        }

       

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int r = 0; r <= 9; r++)//行
            {
                for (int c = 0; c <= 5; c++)//列
                {
                    if (intValues[r, c] == 1)
                    {
                        //g.DrawLine(Pens.Red,1, 1, 1, 1);
                        e.Graphics.FillEllipse(Brushes.Red, c*51+2, r*51+2, 48, 48);
                    }
                }
            }
        }




        int value1;
        int value2;
        int value3;


        private void timer1_Tick(object sender, EventArgs e)
        {
            var rand_row = new Random();
            value1 = rand_row.Next(minValue: 0, maxValue:10);
            var rand_colm = new Random();
            value2 = rand_row.Next(minValue: 0, maxValue: 6);
            var rand_num = new Random();
            value3 = rand_row.Next(minValue: 0, maxValue: 2);


            intValues[value1, value2] = value3;


            pictureBox1.Refresh();
        }
    }
}