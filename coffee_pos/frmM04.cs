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
namespace coffee_pos
{
    public partial class frmM04 : Form
    {
       
        
        public frmM04()
        {
            InitializeComponent();
        }
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        private void frmM04_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
        }
        private void btnAddNumber_Click(object sender, EventArgs e)
        {
            if (txtText.Text == "")
            {

                MessageBox.Show("請輸入帳號");
            }
            else if (txtPwd.Text == "")
            {
                MessageBox.Show("請輸入密碼");
            }
            else
            {
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "insert into memberLogin values(@NewName,@NewPwd)";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("NewName", txtText.Text);
                cmd.Parameters.AddWithValue("NewPwd", txtPwd.Text);
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show($"({rows}新增成功)");
            }
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((txtName.Text != "") && (txtPhone.Text != ""))
            {
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "insert into memberDetail values(@NewName,@NewDate,@NewPhone,@NewEmail,@NewAddress)";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewName", txtName.Text);
                cmd.Parameters.AddWithValue("@NewDate", dtpDate.Value);
                cmd.Parameters.AddWithValue("@NewPhone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@NewEmail", txtEmail.Text);
                cmd.Parameters.AddWithValue("NewAddress", txtAddress.Text);
                
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show($"({rows}新增成功)");
                this.Close();
            }
            else
            {
                MessageBox.Show("姓名和電話必填");
            }
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                //此處可填寫各種上文所提的方法
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
