using Desafio1.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtQuantidade.TextChanged += txtQuantidade_TextChanged;
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtQuantidade.Text, "[^0-9]"))
            {
                MessageBox.Show("Apenas números.");
                txtQuantidade.Text = txtQuantidade.Text.Remove(txtQuantidade.Text.Length - 1);
            }
        }
        
        private async void button1_Click(object sender, EventArgs e)
        {
            Desafio1Controller controller = new Desafio1Controller(this.txtUrl.Text, this.txtToken.Text, this.txtEmail.Text, int.Parse(this.txtQuantidade.Text));
            
            MessageBox.Show(await controller.postResposta(), this.Text.ToString());
        }
    }
}
