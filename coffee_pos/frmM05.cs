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
    public partial class frmM05 : Form
    {
        public frmM05()
        {
            InitializeComponent();
        }
        string myDBConnectionString = "";

        private void frmM05_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
            oderShow();

        }
        void oderShow()
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            //string strSQL = "select top(10) * from prductOrder where 姓名   like  '%林%' order by id desc";
            string strSQL = "select top(1) * from prductOrder order by id desc";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                dglShow.DataSource = dt;
            }
           

           
            reader.Close();
            con.Close();

            
            
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
        int intTotalPrice = 0;
        private void bthSend_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "insert into prductOOrder values(@NewMamID, @NewPName , @NewName, @Newprice, @NewCool, @NewHot, @NewCount, @NewNot, @NewTotalPrice)";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            int intManID = Convert.ToInt32(dglShow.Rows[0].Cells[1].Value);
            string strPName = dglShow.Rows[0].Cells[2].Value.ToString();
            string strName = dglShow.Rows[0].Cells[3].Value.ToString();
            int intPrice = Convert.ToInt32(dglShow.Rows[0].Cells[4].Value);
            string strCool = dglShow.Rows[0].Cells[5].Value.ToString();
            string strHot = dglShow.Rows[0].Cells[6].Value.ToString();
            int intCount = Convert.ToInt32(dglShow.Rows[0].Cells[7].Value);
            string strNot = dglShow.Rows[0].Cells[8].Value.ToString();
            intTotalPrice = intPrice * intCount;
            lblTotalPrice.Text = intTotalPrice.ToString();
            intTotalPrice = Convert.ToInt32(lblTotalPrice.Text);


            cmd.Parameters.AddWithValue("@NewMamID", intManID);
            cmd.Parameters.AddWithValue("@NewPName", strPName);
            cmd.Parameters.AddWithValue("@NewName", strName);
            cmd.Parameters.AddWithValue("@Newprice", intPrice);
            cmd.Parameters.AddWithValue("@NewCool", strCool);
            cmd.Parameters.AddWithValue("@NewHot", strHot);
            cmd.Parameters.AddWithValue("@NewCount", intCount);
            cmd.Parameters.AddWithValue("@NewNot", strNot);
            cmd.Parameters.AddWithValue("@NewTotalPrice", intTotalPrice);

            int rows = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show($"({rows}結帳成功)");
            DialogResult = DialogResult.OK;





        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            //string strSQL = "select top(10) * from prductOrder where 姓名   like  '%林%' order by id desc";
            string strSQL = "select top(1) * from prductOrder order by id desc";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int price = Convert.ToInt32(reader["價格"]);
                int count = Convert.ToInt32(reader["數量"]);
                int totalPri = price * count;

                lblTotalPrice.Text = totalPri.ToString();
                
            }
        }
    }
}
