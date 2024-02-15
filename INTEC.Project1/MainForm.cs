using System;
using System.Windows.Forms;

namespace INTEC.Solution
{
    public partial class MainForm : Form
    {
        string input = string.Empty;
        string operand1 = string.Empty;
        string operand2 = string.Empty;
        char operation;
        double result = 0.0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            AppendDigit("0");
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            AppendDigit("1");
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            AppendDigit("2");
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            AppendDigit("3");
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            AppendDigit("4");
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            AppendDigit("5");
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            AppendDigit("6");
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            AppendDigit("7");
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            AppendDigit("8");
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            AppendDigit("9");
        }

        private void AppendDigit(string digit)
        {
            input += digit;
            txtResult.Text = input;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            SetOperation('+');
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            SetOperation('-');
        }

        private void btnTimes_Click(object sender, EventArgs e)
        {
            SetOperation('*');
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            SetOperation('/');
        }

        private void SetOperation(char op)
        {
            operand1 = input;
            operation = op;
            input = string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnClearPartial_Click(object sender, EventArgs e)
        {
            ClearPartial();
        }

        private void ClearAll()
        {
            txtResult.Text = string.Empty;
            input = string.Empty;
            operand1 = string.Empty;
            operand2 = string.Empty;
            result = 0.0;
        }

        private void ClearPartial()
        {
            txtResult.Text = string.Empty;
            input = string.Empty;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            operand2 = input;
            double num1, num2;

            double.TryParse(operand1, out num1);
            double.TryParse(operand2, out num2);

            if (operation == '+')
            {
                result = num1 + num2;
            }
            else if (operation == '-')
            {
                result = num1 - num2;
            }
            else if (operation == '*')
            {
                result = num1 * num2;
            }
            else if (operation == '/')
            {
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                else
                {
                    txtResult.Text = "Div/Zero";
                    return;
                }
            }

            txtResult.Text = result.ToString();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            // Handle percentage calculation if needed
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (!input.Contains("."))
            {
                input += ".";
                txtResult.Text = input;
            }
        }
    }
}
