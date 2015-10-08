using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace SchnellMailBlogger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                MailMessage objeto_mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                //client.Port = Convert.ToInt32("465");
                client.Host = "HOSTER";
                client.Timeout = 10000;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("MAILADDRESS", "PASSWORD");
                objeto_mail.From = new MailAddress("FROMMAIL");
                objeto_mail.To.Add(new MailAddress("SECRETMAIL@blogger.com"));
                objeto_mail.Subject = textBox2.Text;
                objeto_mail.Body = textBox1.Text;
                client.Send(objeto_mail);
                if (MessageBox.Show("Sent, Remove?", "Success", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Mail to Blogger 1.0 by Bardo-Konrad";
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Replace it with your blog"); //
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
