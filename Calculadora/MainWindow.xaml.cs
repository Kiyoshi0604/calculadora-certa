using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculadora
{
    public partial class MainWindow : Window
    {
        // Construtor da janela principal
        public MainWindow()
        {
            InitializeComponent();
        }


        // Botão 0: adiciona "0" ao final do texto exibido
 
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "0";
        }


        // Botão 1: adiciona "1" ao final do texto exibido

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "1";
        }


        // Botão 2: adiciona "2" ao final do texto exibido

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "2";
        }


        // Botão 3: adiciona "3" ao final do texto exibido

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "3";
        }


        // Botão 4: adiciona "4" ao final do texto exibido

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "4";
        }


        // Botão 5: adiciona "5" ao final do texto exibido

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "5";
        }


        // Botão 6: adiciona "6" ao final do texto exibido

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "6";
        }


        // Botão 7: adiciona "7" ao final do texto exibido

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "7";
        }

        // Botão 8: adiciona "8" ao final do texto exibido

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "8";
        }

  
        // Botão 9: adiciona "9" ao final do texto exibido
  
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "9";
        }


        // Botão de adição: adiciona "+" à expressão

        private void btnmais_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "+";
        }

        // Botão de subtração: adiciona "-" à expressão

        private void btnmenos_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "-";
        }


        // Botão de multiplicação: adiciona "*" à expressão

        private void btnmultiplicacao_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "*";
        }


        // Botão de divisão: adiciona "/" à expressão

        private void btndivisao_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "/";
        }


        // Botão C (Clear): limpa totalmente o display
        // Apaga toda a expressão digitada

        private void btnc_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = string.Empty;
        }


        // Botão CE (Clear Entry): mesma função do C
        // Limpa o display por completo

        private void btnce_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = string.Empty;
        }


        // Botão Delete: remove o último caractere digitado
        // Se o display estiver vazio, não faz nada

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            // Verifica se o texto está vazio ou nulo
            if (string.IsNullOrEmpty(txtDisplay.Text)) return;

            // Remove o último caractere usando Substring
            // Length - 1 pega todos os caracteres menos o último
            txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
        }

        // CALCULAR RESULTADO 
        // Botão de igualdade (=): calcula e exibe o resultado da expressão


        private void btnigual_Click(object sender, RoutedEventArgs e)
        {
            // Obtém a expressão digitada no display
            var expression = txtDisplay.Text;

            // Se a expressão estiver vazia, não faz nada
            if (string.IsNullOrWhiteSpace(expression)) return;

            try
            {
                double result = 0;

                // Verifica se há operador de módulo (%) na expressão
                if (expression.Contains("%"))
                {
                    // Chama método especial para calcular módulo
                    result = EvaluateWithModulo(expression);
                }
                else
                {
                    // DataTable.Compute calcula expressões matemáticas normais
                    // Suporta: +, -, *, /, parênteses e números decimais
                    result = Convert.ToDouble(new DataTable().Compute(expression, null));
                }

                // Converte o resultado para string e exibe no display
                txtDisplay.Text = result.ToString();
            }
            catch (Exception ex)
            {
                // Se houver erro na expressão, exibe mensagem de erro
                MessageBox.Show("Expressão inválida: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                // Limpa o display após o erro
                txtDisplay.Text = string.Empty;
            }
        }

        // Módulo é o resto da divisão

        private double EvaluateWithModulo(string expression)
        {
            // Divide a expressão pelo caractere "%"
            // Exemplo: "10 % 3" vira ["10 ", " 3"]
            string[] parts = expression.Split('%');

            // Se não houver exatamente 2 partes, a expressão é inválida
            if (parts.Length != 2)
            {
                // THROW NEW é usado para validar a expressão
                throw new Exception("Operador % inválido");
            }

            // Calcula o lado esquerdo do módulo e converte para número
            double leftVal = Convert.ToDouble(new DataTable().Compute(parts[0].Trim(), null));

            // Calcula o lado direito do módulo e converte para número
            double rightVal = Convert.ToDouble(new DataTable().Compute(parts[1].Trim(), null));

            // Se o divisor for zero, é erro matemático
            if (rightVal == 0)
            {
                // THROW NEW é usado para validar a expressão
                throw new Exception("Divisão por zero no módulo");
            }

            // Retorna o módulo (resto da divisão)
            return leftVal % rightVal;
        }

        // Botão de raiz quadrada (√): calcula a raiz quadrada do número atual
        private void btn_raiz_Click(object sender, RoutedEventArgs e)
        {
            // Se o display estiver vazio, não faz nada
            if (string.IsNullOrWhiteSpace(txtDisplay.Text)) return;

            try
            {
                // Converte o texto do display para número
                double value = Convert.ToDouble(txtDisplay.Text);

                // Verifica se o número é negativo
                if (value < 0)
                {
                    // Não existe raiz quadrada de número negativo (em números reais)
                    MessageBox.Show("Não é possível calcular a raiz de número negativo.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Calcula a raiz quadrada usando Math.Sqrt
                double result = Math.Sqrt(value);

                // Exibe o resultado no display
                txtDisplay.Text = Convert.ToString(result);
            }
            catch (Exception)
            {
                // Se der erro (expressão inválida, divisão por zero, etc)
                MessageBox.Show("Expressão inválida.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Botão de quadrado (x²): eleva o número atual ao quadrado

        private void btnquadrado_Click(object sender, RoutedEventArgs e)
        {
            // Se o display estiver vazio, não faz nada
            if (string.IsNullOrWhiteSpace(txtDisplay.Text)) return;

            //try = Tenta calcular
            try
            {
                // Converte o texto do display para double
                double value = Convert.ToDouble(txtDisplay.Text);

                // Calcula o quadrado usando Math.Pow(número, expoente)
                double result = Math.Pow(value, 2);

                // Exibe o resultado no display convertendo em string
                txtDisplay.Text = Convert.ToString(result);
            }
            catch (Exception)
            {
                // Se der erro (expressão inválida, divisão por zero, etc)
                MessageBox.Show("Expressão inválida.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Módulo calcula o resto da divisão
        // Exemplo: 10 % 3 = 1

        private void btnmodulo_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "%";
        }

        // Pi = 3.14
        // Usado em cálculos de áreas de círculos, perímetros, etc.

        private void btnpi_Click(object sender, RoutedEventArgs e)
        {
            // Math.PI retorna o valor de Pi em C#
            txtDisplay.Text = txtDisplay.Text + Math.PI.ToString();
        }
    }
}