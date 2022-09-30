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
    public partial class frmM08 : Form
    {
        frmM04 f4 = new frmM04();
        public frmM08()
        {
            InitializeComponent();
        }
        
        string myDBConnectionString = "";
        int pid = 0;

        
        
        

        private void frmM08_Load(object sender, EventArgs e)
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
            frmM07 f7 = new frmM07();
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            //string strSQL = "select top(10) * from prductOrder where 姓名   like  '%林%' order by id desc";
            //string strSQL = "select top(10) * from prductOrder where 姓名=@NewName order by id desc";
            string strSQL = "select top(1) * from prductOrder order by id desc";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            //cmd.Parameters.AddWithValue("@NewName",f7.orderName);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

            }
            reader.Close();
            con.Close();


        }
        private void btnOrderSend_Click(object sender, EventArgs e)
        {
            frmM05 f5 = new frmM05();
            f5.ShowDialog();
            if (f5.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();


        }
    }
}
