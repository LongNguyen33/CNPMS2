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
    public partial class Form3 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlConnection con;
        SqlCommand cmd;
        string str = "Data Source=DESKTOP-0TDOLMP;Initial Catalog=BTLCNPM;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        string gt;
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from medicalinformation1";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        void update()
        {
            if (radioButton1.Checked == true)
            {
                gt = "Nam";
            }
            else
            {
                gt = "Nữ";
            }
            if (textBox1.TextLength <= 0)
            {
                MessageBox.Show("Hãy nhập đủ các thông tin trước khi sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (DateTime.TryParse(textBox4.Text, out DateTime Temp) == true)
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "update medicalinformation1 set name = N'" + textBox2.Text + "',class = N'" + textBox3.Text + "',[date of birth] = N'" + textBox4.Text + "'," +
                    "[number of vaccinations] = N'" + textBox5.Text + "',[phone number] = N'" + textBox6.Text + "',height = N'" + textBox7.Text + "'," +
                    "address = N'" + textBox8.Text + "',sex = N'" + gt + "',[health insurance card id] = N'" + textBox9.Text + "'," +
                    "[vaccination date] = N'" + textBox10.Text + "',weight= N'" + textBox11.Text + "' where student_id = '" + textBox1.Text + "' ";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Định dạng ngày không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 18);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 18);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            gt = dataGridView1.Rows[i].Cells[4].Value.ToString();
            if (gt == "Nam")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            textBox8.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            textBox9.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            textBox10.Text = dataGridView1.Rows[i].Cells[11].Value.ToString();
            textBox7.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            textBox11.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            update();
            loaddata();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
