﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class FrmPrincipal : Form
    {
        double numero1 = 0, numero2 = 0;
        char operador;
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        private void AgregarNumero(object sender, EventArgs e)
        {
            var boton = ((Button)sender);

            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "";
            }
            txtResultado.Text += boton.Text;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            numero2 = Convert.ToDouble(txtResultado.Text);

            if (operador == '+')
            {
                txtResultado.Text = (numero1 + numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);

            }
            else if (operador == '-')
            {
                txtResultado.Text = (numero1 - numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);

            }
            else if (operador == '*')
            {
                txtResultado.Text = (numero1 * numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);

            }
           
            else if (operador == '/')
            {
                if (txtResultado.Text != "0")
                {

                    txtResultado.Text = (numero1 / numero2).ToString();
                    numero1 = Convert.ToDouble(txtResultado.Text);
                }
                else
                {
                    lblMsg.Text = "Não é possível a divisão por ZERO";
                    lblMsg.Visible = true;
                    return;
                }
                lblMsg.Visible = false;


            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length > 1)
            {
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            }
            else { txtResultado.Text = "0"; }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }
        private void btnLimparTodos_Click(object sender, EventArgs e)
        {
            numero1 = 0;
            numero2 = 0;
            operador = '\0';
            txtResultado.Text = "0";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains(","))
            {
                txtResultado.Text += ",";
            }
        }
        private void btnMaisMenos_Click(object sender, EventArgs e)
        {
            numero1 = Convert.ToDouble(txtResultado.Text);
            numero1 *= -1;
            txtResultado.Text = numero1.ToString();
        }

        private void ClickOperador(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            operador = Convert.ToChar(boton.Tag);
            
            numero1 = Convert.ToDouble(txtResultado.Text);

            if (operador == '√')
            {
                numero1 = Math.Sqrt(numero1);
                txtResultado.Text = numero1.ToString();
            }
            else if (operador == '²')
            {
                numero1 = Math.Pow(numero1, 2);
                txtResultado.Text = numero1.ToString();
            }
            else if (operador == '%')
            {
               txtResultado.Text = (numero1 / 100).ToString();

            }

            else
            {
                txtResultado.Text = "";
            }
        }
    }
}
