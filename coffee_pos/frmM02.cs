using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coffee_pos
{
    public partial class frmM02 : Form
    {
        public frmM02()
        {
            InitializeComponent();
        }
        

    

        private void btnMember_Click_1(object sender, EventArgs e)
        {
            frmM01 f1 = new frmM01();
            f1.ShowDialog();
            if (f1.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }

            
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            frmM04 f4 = new frmM04();
            f4.ShowDialog();
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            frmM12 f12 = new frmM12();
            f12.ShowDialog();
            if (f12.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
               
                int Role = 1;
                const int Admin = 1;
                pbenter.Visible = Role == Admin ? true : false;
                
            }


        }

        private void pbenter_Click(object sender, EventArgs e)
        {
            frmM09 f9 = new frmM09();
            f9.ShowDialog();
            this.Close();
        }
    }  
}
