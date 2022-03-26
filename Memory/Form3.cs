using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Label label1 = new Label()
            {
                Text = "&First Name",
                Location = new Point(10, 10),
                TabIndex = 10
            };
            Controls.Add(label1);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
