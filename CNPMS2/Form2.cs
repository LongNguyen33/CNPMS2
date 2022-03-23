using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CNPMS2
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlConnection conn;
        SqlCommand comm;
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-0TDOLMP;Initial Catalog=BTLCNPM;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void adduser()
        {
            string tk = textBox1.Text;
            command = connection.CreateCommand();
            command.CommandText = "select * from user1 where username = '" + tk + "'";
            adapter.SelectCommand = command;
            SqlDataReader da = command.ExecuteReader();
            if (da.Read() == true)
            {
                MessageBox.Show("Tài khoản đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "insert into user1 values(N'" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + numericUpDown1.Value + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void loaddata()
        {
            comm = conn.CreateCommand();
            comm.CommandText = "select * from User1";
            adapter.SelectCommand = comm;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 18);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 21);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            conn = new SqlConnection(str);
            conn.Open();
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            con = new SqlConnection(str);
            con.Open();
            connection.Open();
            adduser();
            loaddata();
            textBox1.Clear();
            textBox2.Clear();
            numericUpDown1.ResetText();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
