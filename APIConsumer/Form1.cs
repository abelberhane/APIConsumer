using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;


namespace APIConsumer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestClient rClient = new RestClient();
            rClient.endPoint = txtURL.Text;

            string strResponse = string.Empty;

            strResponse = rClient.makeRequest();
        }
    }
}
