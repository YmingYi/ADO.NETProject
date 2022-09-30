using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coffee_pos
{
    public partial class frmM12 : Form
    {
        public frmM12()
        {
            InitializeComponent();
        }
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        private void frmM12_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";//@忽略特殊符號
            scsb.InitialCatalog = "mydb";//InitialCatalogru就是database就是mydb
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
        }

        private void btnsign_Click(object sender, EventArgs e)
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
                if (txtText.Text != "")
                {
                    SqlConnection con = new SqlConnection(myDBConnectionString);
                    con.Open();
                    string strSQL = "select * from memberLogin where 帳號 like @searchNumber;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@searchNumber", "%" + txtText.Text + "%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtText.Text = string.Format("{0}", reader["帳號"]);
                        //txtPwd.Text = string.Format("{0}",reader["密碼"]); 

                    }
                    else
                    {
                        MessageBox.Show("輸入錯誤");
                        txtText.Clear();
                        txtPwd.Clear();

                    }

                    reader.Close();
                    con.Close();
                }
                if (txtPwd.Text != "")
                {
                    SqlConnection con = new SqlConnection(myDBConnectionString);
                    con.Open();
                    string strSQL = "select * from memberLogin where 密碼 like @searchPwd;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@searchPwd", "%" + txtPwd.Text + "%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        //txtText.Text = string.Format("{0}", reader["帳號"]);
                        txtPwd.Text = string.Format("{0}", reader["密碼"]);

                    }
                    else
                    {
                        MessageBox.Show("輸入錯誤");
                        txtText.Clear();
                        txtPwd.Clear();

                    }
                    reader.Close();
                    con.Close();
                }

                MessageBox.Show("登入成功");
                DialogResult = DialogResult.OK;//回傳值到上一個from讓他們一起關閉

                //this.Close();
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
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
