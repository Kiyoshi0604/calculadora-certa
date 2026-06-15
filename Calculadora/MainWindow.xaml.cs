using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Digits
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "0";
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "1";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "2";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "3";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "6";
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "9";
        }

        // Decimal point
        private void btnponto_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + ".";
        }

        // Operators
        private void btnmais_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "+";
        }

        private void btnmenos_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "-";
        }

        private void btnmultiplicacao_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "*";
        }

        private void btndivisao_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "/";
        }

        // Parentheses
        private void btnabre_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "(";
        }

        private void btnfecha_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + ")";
        }

        // Clear / Delete
        private void btnc_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = string.Empty;
        }

        private void btnce_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = string.Empty;
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDisplay.Text)) return;
            txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
        }

        // Equals (simple evaluator)
        private void btnigual_Click(object sender, RoutedEventArgs e)
        {
            string expr = txtDisplay.Text;
            if (string.IsNullOrWhiteSpace(expr)) return;
            try
            {
                var dt = new DataTable();
                var value = dt.Compute(expr, null);
                txtDisplay.Text = Convert.ToString(value);
            }
            catch
            {
                txtDisplay.Text = "Error";
            }
        }
    }
}