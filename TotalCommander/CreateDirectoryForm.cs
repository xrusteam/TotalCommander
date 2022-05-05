using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace TotalCommander
{
    public partial class NewDirectoryForm : Form
    {
        private string path;
        public NewDirectoryForm(string path)
        {
            InitializeComponent();
            this.path = path;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("") && !textBox1.Text.Contains('\\') && !Directory.Exists(path + '\\' + textBox1.Text))
            {
                Directory.CreateDirectory(path + '\\' + textBox1.Text);
                Close();
            }
            else if (Directory.Exists(path + '\\' + textBox1.Text))
            {
                MessageBox.Show("Уже существует такая директория!");
            }
            else
            {
                MessageBox.Show("Неправильнно название директории");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
