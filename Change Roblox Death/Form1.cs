using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Change_Roblox_Death
{
    public partial class Form1 : Form
    {
        string[] fileDrop = {};
        public Form1()
        {
            InitializeComponent();
            
        }

        public void panel2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        public void window_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        public void panel2_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        public void panel2_DragDrop_1(object sender, DragEventArgs e)
        {
            string[] fileDrop = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (fileDrop[0].Contains(".ogg"))
            {
                try {
                message.Text = fileDrop[0];
                message.BackColor = Color.FromArgb(64, 64, 64);
                message.ForeColor = Color.Black;
                }

                catch {
                    message.Text = "An error ocurred";
                    message.BackColor = Color.Red;
                    message.ForeColor = Color.White;
                }
            }
            else
            {
                message.Text = "Please check if the file is an ogg file or remove the dot on your folder.";
                message.BackColor = Color.Red;
                message.ForeColor = Color.White;
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (message.Text.Contains(".ogg"))
            {
                string oofFile = "/content/sounds/ouch.ogg";
                string robloxPath = "C:/Users/" + Environment.UserName + "/AppData/Local/Roblox/Versions";
                string[] versionList = Directory.GetDirectories(robloxPath);
                for (int i = 0; i < versionList.Length; i++)
                {
                    if (versionList[i].Contains("version-"))
                    {
                        try 
                        {
                            string oofFileDir = Path.Combine(versionList[i] + oofFile);
                            File.Delete(oofFileDir);
                            File.Copy(message.Text, message.Text + "2");
                            File.Move(message.Text, oofFileDir);
                            File.Move(message.Text + "2", message.Text);
                        }
                        catch
                        {
                            message.Text = "An error ocurred while changing the sound";
                            message.BackColor = Color.Red;
                            message.ForeColor = Color.White;
                        }
                    }
                    
                }
                MessageBox.Show("Successfully changed roblox death sound.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void panel2_DragEnter_1(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/Kuzeysvg");
        }
    }
}
