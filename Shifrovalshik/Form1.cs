using System;
using System.Windows.Forms;

namespace Shifrovalshik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = Cypher.EncodePolibiy(inputData.Text);
            if (str == null)
                MessageBox.Show("При кодировании произошла ошибка!");
            else
                outputData.Text = str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = Cypher.DecodePolibiy(inputData.Text);
            if (str == null)
                MessageBox.Show("При декодировании произошла ошибка!");
            else
                outputData.Text = str;
        }
    }
}
