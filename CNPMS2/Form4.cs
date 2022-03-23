using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CNPMS2
{
    public partial class Form4 : Form
    {
        static string connString = "Data Source=DESKTOP-0TDOLMP;Initial Catalog=BTLCNPM;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connString);
        private void Xoatextbox()
        {
            textBox1.Clear();
            textBox2.Clear();
            richTextBox1.Clear();
            textBox1.Focus();
            textBox2.Focus();
            richTextBox1.Focus();
        }

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 18);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 18);        
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select * from notification1", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;

            if (conn.State == ConnectionState.Open)
                conn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng không được bỏ trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert into notification1 values(@notification_id,@title,@content,@dateofnotification)", conn);
                    cmd.Parameters.AddWithValue("@notification_id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@title", textBox2.Text);
                    cmd.Parameters.AddWithValue("@content", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@dateofnotification", dateTimePicker1.Value.ToString());
                    cmd.ExecuteNonQuery();
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    Form4_Load(sender, e);
                    Xoatextbox();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thêm được thông báo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng không được bỏ trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa thông báo này không?", "LƯU Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from notification1 where notification_id = '" + textBox1.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    Form4_Load(sender, e);
                    Xoatextbox();
                }
                else
                {
                    MessageBox.Show("Không có thông báo nào bị xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }



        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

