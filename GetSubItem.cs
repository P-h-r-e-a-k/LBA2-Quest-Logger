using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LBA2_Quest_Logger;
using LBAMemoryModule;

namespace LBA2_Quest_Logger
{
    public partial class GetSubItem : Form
    {
        public LBA2Quest q;
        const uint AREACODE = 0x55C5F;
        public GetSubItem(LBA2Quest q)
        {
            InitializeComponent();
            if(null == q)
            {
                MessageBox.Show("No Quest set");
                return;
            }
            txtQuestName.Text = q.name;
            txtOffset.Text = q.memoryOffset.ToString("X2");
            txtSubquestName.Text = q.subquests[0].name;
            txtValue.Text = q.subquests[0].value.ToString();
            lblAreacodeVal.Text = new Mem().readVal(AREACODE, 2).ToString("X2");
            this.q = q;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ("New" == txtSubquestName.Text) return;
            q.name = txtQuestName.Text;
            q.subquests[0].name = txtSubquestName.Text;
            q.subquests[0].value = ushort.Parse(txtValue.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            q = null;
            this.Close();
        }
    }
}
