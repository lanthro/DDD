using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VSG.Dialogs
{
    public partial class SingleIntegerInputDialog : Form
    {

        public SingleIntegerInputDialog(string description, string caption)
        {
            int buffer = 11;
            InitializeComponent();
            this.Text = caption;
            label1.Text = description;
            textBox1.Top = label1.Bottom + buffer;
            button1.Top = button2.Top = textBox1.Bottom + buffer;
            //this. = button1.Bottom + buffer;
            this.DialogResult = DialogResult.Cancel;
        }

        public DialogResult ShowDialog(out int value)
        {
            DialogResult res;
            value = -1;
            res = this.ShowDialog();
            if (res == DialogResult.Cancel)
                return res;

            value = Convert.ToInt32(textBox1.Text);

            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {//ok
            int value;

            try
            {
                value = Convert.ToInt32(textBox1.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("This dialog requires an integer input.", "Validation Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}