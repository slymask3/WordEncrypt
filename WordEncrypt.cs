using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace WordEncrypt
{
    public partial class WordEncrypt : Form
    {
        public WordEncrypt()
        {
            InitializeComponent();
        }

        //Encrypt en = new Encrypt("test");

        private void WordEncrypt_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Word Encrypted Files (.wec)|*.wec";
            saveFileDialog1.FilterIndex = 1;

            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                //Encrypt en = new Encrypt(textBoxKeyword.Text);
                
                String text = encrypt(richTextBox1.Text, textBoxKeyword.TextLength);
                File.WriteAllText(saveFileDialog1.FileName, text);
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Word Encrypted Files (.wec)|*.wec";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (File.Exists(openFileDialog1.FileName))
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    String final = sr.ReadToEnd();
                    sr.Close();

                    //Encrypt en = new Encrypt(textBoxKeyword.Text);

                    richTextBox1.Text = decrypt(final, textBoxKeyword.TextLength);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public String encrypt(String text, int amount)
        {
            Encrypt en;

            if(amount <= 0) {
                amount = 1;
                en = new Encrypt("K");
            }
            else
            {
                en = new Encrypt(textBoxKeyword.Text);
            }

            toolStripProgressBar1.Value = 0;
            String newText = text;
            for (int i = 0; i < amount; i++)
            {
                newText = en.encrypt(newText);

                toolStripProgressBar1.Value = ((i + 1) / amount) * 100;
                toolStripStatusLabel1.Text = "Encrypting... " + ((i + 1) / amount) * 100 + "%";
            }

            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Text = "Done";
            return newText;
        }

        public String decrypt(String text, int amount)
        {
            Encrypt en;

            if (amount <= 0)
            {
                amount = 1;
                en = new Encrypt("K");
            }
            else
            {
                en = new Encrypt(textBoxKeyword.Text);
            }

            toolStripProgressBar1.Value = 0;
            String newText = text;
            for (int i = 0; i < amount; i++)
            {
                newText = en.decrypt(newText);

                toolStripProgressBar1.Value = ((i + 1) / amount) * 100;
                toolStripStatusLabel1.Text = "Decrypting... " + ((i + 1) / amount) * 100 + "%";
            }

            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Text = "Done";
            return newText;
        }
    }
}
