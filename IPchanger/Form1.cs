using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace IPchanger
{
    public partial class Form1 : Form
    {
        // list of net's names
        List<String> nameConnection = new List<String>();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //fill list of net's names
            foreach (var i in NetworkInterface.GetAllNetworkInterfaces())
            {
                Console.WriteLine("{0} ({1})", i.Name, i.NetworkInterfaceType);
                foreach (var a in i.GetIPProperties().UnicastAddresses)
                {
                    if (!nameConnection.Contains(i.Name))
                    {
                        nameConnection.Add(i.Name);
                    }
                }
            }
            //if searched more one net will enable all buttons
            if (nameConnection.Count > 0)
            {
                comboBox1.Items.AddRange(nameConnection.ToArray());
                comboBox1.SelectedIndex = 0;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
            }
            
        }

        // set ip, mask and gate
        private void button1_Click(object sender, EventArgs e)
        {
            setIP("10.18.20.150 255.255.255.224 10.18.20.129");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setIP("10.18.8.70 255.255.252.128 10.18.8.1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setIP("10.3.8.249 255.255.252.0 10.3.8.2");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setIP("10.128.127.55 255.255.255.0");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setIP("10.18.22.91 255.255.255.0 10.18.22.65");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            setIP("10.128.127.254 255.255.255.0 10.128.127.1");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            setIP("192.168.0.249 255.255.255.0 0.0.0.0");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            setIP("192.168.3.249 255.255.254.0 0.0.0.0");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            setIP("10.18.22.93 255.255.255.0 0.0.0.0");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            setIP("10.18.22.31 255.255.255.192 10.18.22.1");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            setIP("10.18.22.93 255.255.255.224 10.18.22.65");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            setIP("192.168.96.249 255.255.255.0");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            setIP("192.168.97.249 255.255.255.0");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            setIP("192.168.98.249 255.255.255.0");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            setIP("192.168.99.249 255.255.255.0");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            setIP("192.168.95.249 255.255.255.0");
        }

        //set parameters to promt command under admin
        private void setIP (String IP)
        {
            Process.Start(new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = "netsh",
                Arguments = "int ip set address \"" + comboBox1.Text + "\" static " + IP,
                Verb = "runas"
            });
            //show string in promt commant
            label12.Text = "netsh int ip set address \"" + comboBox1.Text + "\" static " + IP;
        }
    }
}
