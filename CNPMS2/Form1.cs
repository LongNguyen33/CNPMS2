using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPMS2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void AddForm(Form f)
        {
            this.panel1.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(f);
            f.Show();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            AddForm(f);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgr f = new backgr();
            AddForm(f); ;

        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgr f = new backgr();
            AddForm(f);

        }

        private void quảnLýThôngTinYTếToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            AddForm(f);
        }

        private void quảnLýThôngBáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            AddForm(f);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình không?", "LƯU Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
