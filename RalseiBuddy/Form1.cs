using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RalseiBuddy
{
    public partial class Form1 : Form
    {
        VBScript vb = new VBScript();
        public Form1()
        {
            InitializeComponent();
        }

        private void draw() => Application.DoEvents();

        private void button1_Click(object sender, EventArgs e)
        {
            vb.Execute($"ralsei.Speak \"{textBox1.Text}\"");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            draw();
            vb.Execute("Set agent = WScript.CreateObject(\"Agent.Control.2\", \"AgentControl_\")");
            vb.Execute("agent.Characters.Load \"Ralsei\", \"Ralsei.acs\"");
            vb.Execute("Set ralsei = agent.Characters(\"Ralsei\")");
            vb.Execute("ralsei.MoveTo 300,300");
            vb.Execute("ralsei.Show");
            button1.Enabled = true;
            draw();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            vb.Execute("ralsei.Hide");
            Hide();
            System.Threading.Thread.Sleep(700);
            vb.Close();
        }
    }
}
