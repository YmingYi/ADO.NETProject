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
using System.IO;

namespace coffee_pos
{
    public partial class frmM09 : Form
    {
        public frmM09()
        {
            InitializeComponent();
        }
        public int pid = 0;
        string myDBConnectionString = "";
        string image_dir = @"images\";
        string image_name = "";
        bool is已修改圖檔 = false;
        private void frmM09_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
        }

        private void btnAllOrder_Click(object sender, EventArgs e)
        {
            frmM10 f10 = new frmM10();
            f10.ShowDialog();
        }

        private void btnAllMember_Click(object sender, EventArgs e)
        {
            frmM11 f11 = new frmM11();
            f11.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "select * from drinksProduct where 品名 like @SearchName;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchName", "%" + txtName.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                lblID.Text = string.Format("{0}", reader["商品id"]);
                txtName.Text = string.Format("{0}", reader["品名"]);
                txtPrice.Text = string.Format("{0}", reader["價格"]);
                image_name = Convert.ToString(reader["pimage"]);
                pbImg.Image = Image.FromFile(image_dir + image_name);




            }
            else
            {
                MessageBox.Show("查無此人");
                lblID.Text = "";
                txtName.Clear();
                txtPrice.Clear();

            }
            reader.Close();
            con.Close();


        }

        private void btnIn_Click(object sender, EventArgs e)
        {

            lblID.Text = "";
            txtName.Clear();
            txtPrice.Clear();
            pbImg.Image = null;


        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();//檔案選取對話框
            f.Filter = "圖檔類型 (*.jpg, *.jpeg, *.png)|*.jpeg;*.jpg;*.png";//Filter過濾檔案副檔名
            DialogResult R = f.ShowDialog();
            //檔案選取對話框回傳值//ShowDialog()獨佔檔案開啟
            if (R == DialogResult.OK)
            {
                pbImg.Image = Image.FromFile(f.FileName);
                string fileExt = System.IO.Path.GetExtension(f.SafeFileName);//抓取副檔名
                Random myRand = new Random();
                image_name = DateTime.Now.ToString("yyyyMMddHHmmss") + myRand.Next(1000, 10000).ToString() + fileExt;
                is已修改圖檔 = true;
                Console.WriteLine(image_name);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtName.Text != "") && (txtPrice.Text != "") && (pbImg.Image != null))
            {
                if (is已修改圖檔)
                {
                    pbImg.Image.Save(image_dir + image_name);
                    is已修改圖檔 = false;
                }

                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "insert into drinksProduct values(@NewName,@NewPrice,@NewImage)";
                SqlCommand cmd = new SqlCommand(strSQL, con);
               
                cmd.Parameters.AddWithValue("@NewName", txtName.Text);
                int intPrice = 0;
                Int32.TryParse(txtPrice.Text, out intPrice);
                cmd.Parameters.AddWithValue("@NewPrice", intPrice);
                cmd.Parameters.AddWithValue("@NewImage", image_name);
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("資料儲存成功,影響" + rows + "筆資料");
            }
            else
            {
                MessageBox.Show("所有欄位都必填");
            }


        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int intID = 0;
            Int32.TryParse(lblID.Text, out intID);

            if (intID > 0)
            {
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "delete from drinksProduct where 商品id = @SearchID ;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchID", intID);
                int rows = cmd.ExecuteNonQuery();
                con.Close();

                lblID.Text = "";
                txtName.Clear();
                txtPrice.Clear();
                pbImg.Image = null;


                MessageBox.Show($"{rows}筆資料刪除成功");
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
