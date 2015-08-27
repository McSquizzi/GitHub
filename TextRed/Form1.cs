using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextRed
{
    public partial class frmTextRedactor : Form
    {
        public frmTextRedactor()
        {
            InitializeComponent();
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fontName.Add(font.Name);

            }
            comboBox1.DataSource = fontName;

            textBox1.Text = Font.Size.ToString();
        }

        //private void button1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    FontDialog dlg = new FontDialog();
        //    if (DialogResult.OK == dlg.ShowDialog())
        //    {
        //       txtbTextSite.Font = dlg.Font;


        //    }
        //}


        private void txtbTextSite_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    FontDialog dlg = new FontDialog();
            //    if (DialogResult.OK == dlg.ShowDialog())                          не реагирует
            //    {
            //        txtbTextSite.SelectionFont = dlg.Font;
            //    }

            //}
        }

        private void txtbTextSite_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                FontDialog dlg = new FontDialog();
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    txtbTextSite.SelectionFont = dlg.Font;
                }

            }
        }



        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtTmp = txtbTextSite.SelectedText;
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            txtTmp = txtbTextSite.SelectedText;
            txtbTextSite.SelectedText = null;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (txtTmp != null)
            {
                txtbTextSite.SelectedText = txtTmp;
                txtTmp = null;
            }
        }
        List<string> fontName = new List<string>();
        private string txtTmp = null;
        private string customPass = null;

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (txtbTextSite.SelectedText != null)
            {
                Font frm = new Font(comboBox1.Text, Font.Size);
                txtbTextSite.SelectionFont = frm;
            }
            else
            {
                Font frm = new Font(comboBox1.Text, Font.Size);
                Font = frm;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                if (textBox1.Text != null && textBox1.Text != "")
                {
                    if (txtbTextSite.SelectedText != null)
                    {
                        Font frm = new Font(Font.FontFamily, float.Parse(textBox1.Text));
                        txtbTextSite.SelectionFont = frm;
                    }
                    else
                    {
                        Font frm = new Font(Font.FontFamily, float.Parse(textBox1.Text));
                        Font = frm;
                    }

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtbTextSite.SelectedText != null)
            {
                if (txtbTextSite.SelectionFont.Bold)
                {
                    txtbTextSite.SelectionFont = new Font(txtbTextSite.SelectionFont, FontStyle.Regular);
                }
                else
                {
                    txtbTextSite.SelectionFont = new Font(txtbTextSite.SelectionFont, FontStyle.Bold);
                }
            }
            else
            {
                if (Font.Bold)
                {
                    Font = new Font(txtbTextSite.SelectionFont, FontStyle.Regular);
                }
                else
                {
                    Font = new Font(txtbTextSite.SelectionFont, FontStyle.Bold);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtbTextSite.SelectedText != null)
            {
                if (txtbTextSite.SelectionFont.Italic)
                {
                    txtbTextSite.SelectionFont = new Font(txtbTextSite.SelectionFont, FontStyle.Regular);
                }
                else
                {
                    txtbTextSite.SelectionFont = new Font(txtbTextSite.SelectionFont, FontStyle.Italic);
                }
            }
            else
            {
                if (Font.Italic)
                {
                    Font = new Font(txtbTextSite.SelectionFont, FontStyle.Regular);
                }
                else
                {
                    Font = new Font(txtbTextSite.SelectionFont, FontStyle.Italic);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtbTextSite.SelectedText != null)
            {
                if (txtbTextSite.SelectionFont.Underline)
                {
                    txtbTextSite.SelectionFont = new Font(txtbTextSite.SelectionFont, FontStyle.Regular);
                }
                else
                {
                    txtbTextSite.SelectionFont = new Font(txtbTextSite.SelectionFont, FontStyle.Underline);
                }
            }
            else
            {
                if (Font.Underline)
                {
                    Font = new Font(txtbTextSite.SelectionFont, FontStyle.Regular);
                }
                else
                {

                    Font = new Font(txtbTextSite.SelectionFont, FontStyle.Underline);

                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (DialogResult.OK == ofd.ShowDialog())
            {
                txtbTextSite.LoadFile(ofd.FileName);
                customPass = ofd.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customPass != null)
            {
                txtbTextSite.SaveFile(customPass);
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (DialogResult.OK == ofd.ShowDialog())
                {
                    txtbTextSite.SaveFile(ofd.FileName);
                }


            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (DialogResult.OK == ofd.ShowDialog())
            {
                txtbTextSite.SaveFile(ofd.FileName);
            }
        }







    }
}
