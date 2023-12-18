using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiscoPortMigrate
{
    public partial class Form1 : Form
    {
        string[] untagged = new string[48];
        string[] tagged = new string[48];
        string[] cisco = new string[48];
        string[] desc = new string[48];
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                int value = listBox1.SelectedIndex;
                string description = desc[value];
                string untag = untagged[value];
                string cis = cisco[value];
                string tag = tagged[value];
                //if (desc[value] != null)
                //{
                textBox7.Text = description;
                //}
                //if (untagged[value] != null)
                //{
                textBox2.Text = untag;
                //}
                //if (cisco[value] != null)
                //{
                textBox3.Text = cis;
                //}
                //if (tagged[value] != null)
                //{
                textBox4.Text = tag;
                //}
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 47)
            {
                listBox1.SelectedIndex += 1;
            }
            var value = listBox1.SelectedItem.ToString();
            //textBox5.Text = listBox1.SelectedIndex.ToString();
            int[] holdValue = new int[48];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string v1 = textBox2.Text.ToString(); // untagged
            string v2 = textBox3.Text.ToString(); // cisco voip
            string v3 = textBox4.Text.ToString(); // other tagged
            string v5 = textBox7.Text.ToString(); // description
            string v4 = textBox1.Text.ToString(); // switch #

            var hold = listBox1.SelectedIndex;

            untagged[hold] = v1;
            tagged[hold] = v3;
            cisco[hold] = v2;
            desc[hold] = v5;
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            for (int i = 0; i < 48; i++)
            {
                string description = "";
                string untaggedVLAN = "";
                string taggedVLAN = "";
                string ciscoVLAN = "";
                string portFast = "";
                string noNegotiate = "";


                string bc1 = desc[i];
                string bc2 = untagged[i];
                string bc3 = tagged[i];
                string bc4 = cisco[i];

                if (desc[i] == null || desc[i] == "")
                {
                    description = "";
                }
                else
                {
                    description = "\r\n description " + desc[i];
                }
                if (untagged[i] == null || untagged[i] == "")
                {
                    untaggedVLAN = "";
                }
                else
                {
                    untaggedVLAN = "\r\n switchport access vlan " + untagged[i];
                }
                if (tagged[i] == null || tagged[i] == "")
                {
                    taggedVLAN = "";
                }
                else
                {
                    taggedVLAN = "\r\n switchport trunk allowed vlan " + tagged[i];
                }
                if (cisco[i] == null || cisco[i] == "")
                {
                    ciscoVLAN = "";
                }
                else
                {
                    ciscoVLAN = "\r\n switchport voice vlan " + cisco[i];
                }
                if (checkBox1.Checked)
                {
                    portFast = "\r\n spanning-tree portfast bpduguard";
                }
                if(checkBox3.Checked)
                {
                    noNegotiate = "\r\n switchport no negotiate";
                }

                if (taggedVLAN == null || taggedVLAN == "")
                {
                    textBox6.Text += "interface GigabitEthernet" + textBox1.Text.ToString() + "/0/" + (i + 1) + description + untaggedVLAN + ciscoVLAN + taggedVLAN + portFast + noNegotiate + "\r\n";
                }
                else
                {
                    textBox6.Text += "interface GigabitEthernet" + textBox1.Text.ToString() + "/0/" + (i + 1) + description + untaggedVLAN + ciscoVLAN + taggedVLAN + noNegotiate + "\r\n";
                }
                

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;

            if(saveFile.ShowDialog() == DialogResult.OK)
            {
                //System.IO.File.WriteAllText("CiscoInterfaces.log", textBox6.Text);
                System.IO.File.WriteAllText(saveFile.FileName, textBox6.Text);
            }
            System.IO.File.WriteAllText("CiscoInterfaces.log", textBox6.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var m = new Form2();
            m.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var n = new Form3();
            n.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
