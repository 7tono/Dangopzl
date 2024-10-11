using System.Windows.Forms;

namespace Dangopzl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(canvas);

            //枠線
            g.DrawLine(Pens.Black, 0, 0, 0, 511);
            g.DrawLine(Pens.Black, 306, 0, 306, 511);
            g.DrawLine(Pens.Black, 0, 0, 306, 0);
            g.DrawLine(Pens.Black, 0, 511, 306, 511);

            //ボーダー線(縦)
            g.DrawLine(Pens.Black, 51, 0, 51, 511);
            g.DrawLine(Pens.Black, 102, 0, 102, 511);
            g.DrawLine(Pens.Black, 153, 0, 153, 511);
            g.DrawLine(Pens.Black, 204, 0, 204, 511);
            g.DrawLine(Pens.Black, 255, 0, 255, 511);
            //ボーダー線(横)
            g.DrawLine(Pens.Black, 0, 51, 306, 51);
            g.DrawLine(Pens.Black, 0, 102, 306, 102);
            g.DrawLine(Pens.Black, 0, 153, 306, 153);
            g.DrawLine(Pens.Black, 0, 204, 306, 204);
            g.DrawLine(Pens.Black, 0, 255, 306, 255);
            g.DrawLine(Pens.Black, 0, 306, 306, 306);
            g.DrawLine(Pens.Black, 0, 357, 306, 357);
            g.DrawLine(Pens.Black, 0, 408, 306, 408);
            g.DrawLine(Pens.Black, 0, 459, 306, 459);
            g.DrawLine(Pens.Black, 0, 510, 306, 510);



            g.Dispose();
            pictureBox1.Image = canvas;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            listView1.View = View.Details;
            InitializeListView();



        }
        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("順位");

            listView1.Columns.Add("スコア");
            //listView1.Width = -2;
            listView1.FullRowSelect = true;

        }


        string nuwscore = "";
        string scorecounter_str = "";
        int scorecounter = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            nuwscore = textBox1.Text;
            scorecounter++;


            if (listView1.Items.Count <= 19)
            {
                scorecounter_str = scorecounter.ToString();
                listView1.Items.Add(new ListViewItem(new string[] { scorecounter_str, nuwscore }));
            }

        }
    }
}