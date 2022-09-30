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
    public partial class frmM03 : Form
    {
        public frmM03()
        {
            InitializeComponent();
        }
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        List<string> listName = new List<string>();
        List<int> listPrice = new List<int>();
        List<int> listID = new List<int>();
        private void frmM03_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();

            讀取資料庫();
        }


        private void pbLogin_Click(object sender, EventArgs e)
        {
            frmM02 f2 = new frmM02();
            f2.ShowDialog();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            frmM06 f6 = new frmM06();
            f6.ShowDialog();
        }
        void 讀取資料庫()
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "select top 100 * from drinksProduct;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            string image_dir = @"images\";
            string image_name = "";
            int i = 0;

            while (reader.Read())
            {
                listID.Add(Convert.ToInt32(reader["商品id"]));
                listName.Add(Convert.ToString(reader["品名"])); 
                listPrice.Add(Convert.ToInt32(reader["價格"]));
                image_name = Convert.ToString(reader["Pimage"]);
                imageList1.Images.Add(Image.FromFile(image_dir + image_name));
                i += 1;
            }
            Console.WriteLine("讀取{0}筆資料", i);
            reader.Close();
            con.Close();
        }

        private void btnPic_Click(object sender, EventArgs e)
        {
            listViewPic();
        }

        void listViewPic()
        {
            listViewProduct.Clear();
            listViewProduct.View = View.LargeIcon;//LargeIcon, SmallICon, List, Tile
            imageList1.ImageSize = new Size(120, 120);
            listViewProduct.LargeImageList = imageList1;//LargeIcon, Tile
            listViewProduct.SmallImageList = imageList1;//SmallIcon, List

            for (int i = 0; i < imageList1.Images.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                item.Font = new Font("微軟正黑體", 14, FontStyle.Regular);
                item.Text = listName[i];
                item.Tag = listID[i];
                listViewProduct.Items.Add(item);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            listViewList();
           
        }
        void listViewList()
        {
            listViewProduct.Clear();
            listViewProduct.LargeImageList = null;
            listViewProduct.SmallImageList = null;
            listViewProduct.View = View.Details;
            listViewProduct.Columns.Add("ID", 100);
            listViewProduct.Columns.Add("商品名稱", 200);
            listViewProduct.Columns.Add("商品價格", 80);
            listViewProduct.FullRowSelect = true;
            listViewProduct.GridLines = true;

            for (int i = 0; i < listID.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.Font = new Font("微軟正黑體", 14, FontStyle.Regular);
                item.Text = listID[i].ToString();
                item.SubItems.Add(listName[i]);
                item.SubItems.Add(listPrice[i].ToString());
                item.Tag = listID[i];

                listViewProduct.Items.Add(item);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            listID.Clear();
            listName.Clear();
            listPrice.Clear();
            imageList1.Images.Clear();
            讀取資料庫();

            if (listViewProduct.View == View.Details)
            {
                listViewList();
            }
            else
            {
                listViewPic();
            }
        }

        private void listViewProduct_ItemActivate(object sender, EventArgs e)
        {
            frmM07 myProduct = new frmM07();
            myProduct.pid = Convert.ToInt32(listViewProduct.SelectedItems[0].Tag);
            myProduct.ShowDialog();
        }

        private void picInform_Click(object sender, EventArgs e)
        {
            frmM06 f6 = new frmM06();
            f6.ShowDialog();
        }

        private void picCart_Click(object sender, EventArgs e)
        {
            frmM08 f8 = new frmM08();
            f8.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmM09 f9 = new frmM09();
            f9.ShowDialog();
        }
    }
    
}
