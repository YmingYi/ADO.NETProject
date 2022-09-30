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
    public partial class frmM07 : Form
    {
        public frmM07()
        {
            InitializeComponent();
        }
        public int pid = 0;
        string myDBConnectionString = "";
        string image_dir = @"images\";
        string image_name = "";
        bool isRevise = false;
        public string orderName = "";
        int orderPrice = 0;
        int orderID = 0;
        string orderPName = "";
        
        
        private void frmM07_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("pid:" + pid);
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
            顯示商品細項資訊();

        }
        void 顯示商品細項資訊()
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            //string strSQL = "select * from drinksProduct where 商品id = @SearchID";
            string strSQL = "select * from drinksProduct as p join memberDetail as m on p.商品id !=m.id where 商品id = @SearchID";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchID", pid);
            SqlDataReader reader = cmd.ExecuteReader();

            int i = 0;
            while (reader.Read())
            {
                
                lblmemberID.Text = reader["id"].ToString();
                orderID =Convert.ToInt32(lblmemberID.Text);
                lblPName.Text = reader["姓名"].ToString();
                orderPName = lblPName.Text;
                txtName.Text = reader["品名"].ToString();
                orderName = txtName.Text;
                txtPrice.Text = reader["價格"].ToString();
                orderPrice = Convert.ToInt32(txtPrice.Text); 
                image_name = reader["Pimage"].ToString();
                picProduct.Image = Image.FromFile(image_dir + image_name);
                i += 1;
            }
            reader.Close();
            con.Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
          
            if (txtCount.Text !="")
            {
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "insert into prductOrder values(@NewMamID, @NewPName , @NewName, @Newprice, @NewCool, @NewHot, @NewCount, @NewNote)";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewMamID", orderID);
                cmd.Parameters.AddWithValue("@NewPName", orderPName);
                cmd.Parameters.AddWithValue("@NewName", orderName);             
                cmd.Parameters.AddWithValue("@Newprice", orderPrice);
                cmd.Parameters.AddWithValue("@NewCool", chkCool.Checked);
                cmd.Parameters.AddWithValue("@NewHot", chkHot.Checked);
                int intCount = 0;
                int.TryParse(txtCount.Text, out intCount);
                cmd.Parameters.AddWithValue("@NewCount", intCount);
                cmd.Parameters.AddWithValue("@NewNote", txtRemark.Text);
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show($"(新增{rows}筆到購物車)");
                this.Close();
                

            }
            else
            {
                MessageBox.Show("請填寫數量");
            }
           



        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            frmM05 f5 = new frmM05();
            f5.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmM08 f8 = new frmM08();
            f8.ShowDialog();
        }
    }
}
