using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        private double resultValue = 0;
        private string operation = "";
        private bool operationPressed = false;

        public Form1()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            // Создаем текстовое поле для отображения результата
            TextBox textBoxResult = new TextBox
            {
                Name = "textBoxResult",
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(280, 40),
                ReadOnly = true,
                Text = "0",
                Font = new System.Drawing.Font("Arial", 24)
            };
            this.Controls.Add(textBoxResult);

            // Создаем кнопки чисел от 0 до 9
            for (int i = 0; i <= 9; i++)
            {
                Button button = new Button
                {
                    Name = $"button{i}",
                    Text = i.ToString(),
                    Size = new System.Drawing.Size(60, 60),
                    Location = new System.Drawing.Point(10 + (i % 3) * 70, 60 + (i / 3) * 70)
                };
                button.Click += (sender, e) => ButtonNumber_Click(sender, e, textBoxResult);
                this.Controls.Add(button);
            }

            // Создаем кнопки операций
            string[] operations = { "+", "-", "×", "÷" };
            for (int i = 0; i < operations.Length; i++)
            {
                Button button = new Button
                {
                    Name = $"button{operations[i]}",
                    Text = operations[i],
                    Size = new System.Drawing.Size(60, 60),
                    Location = new System.Drawing.Point(220, 60 + i * 70)
                };
                button.Click += (sender, e) => ButtonOperator_Click(sender, e, textBoxResult);
                this.Controls.Add(button);
            }

            // Создаем кнопку равенства
            Button buttonEquals = new Button
            {
                Name = "buttonEquals",
                Text = "=",
                Size = new System.Drawing.Size(60, 60),
                Location = new System.Drawing.Point(150, 280)
            };
            buttonEquals.Click += (sender, e) => ButtonEquals_Click(sender, e, textBoxResult);
            this.Controls.Add(buttonEquals);

            // Создаем кнопку очистки
            Button buttonClear = new Button
            {
                Name = "buttonClear",
                Text = "C",
                Size = new System.Drawing.Size(60, 60),
                Location = new System.Drawing.Point(220, 280)
            };
            buttonClear.Click += (sender, e) => ButtonClear_Click(sender, e, textBoxResult);
            this.Controls.Add(buttonClear);
        }

        private void ButtonNumber_Click(object sender, EventArgs e, TextBox textBoxResult)
        {
            if ((textBoxResult.Text == "0") || operationPressed)
                textBoxResult.Clear();

            operationPressed = false;
            Button button = (Button)sender;
            textBoxResult.Text += button.Text;
        }

        private void ButtonOperator_Click(object sender, EventArgs e, TextBox textBoxResult)
        {
            Button button = (Button)sender;
            operation = button.Text;
            resultValue = Double.Parse(textBoxResult.Text);
            operationPressed = true;
        }

        private void ButtonEquals_Click(object sender, EventArgs e, TextBox textBoxResult)
        {
            switch (operation)
            {
                case "+":
                    textBoxResult.Text = (resultValue + Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "-":
                    textBoxResult.Text = (resultValue - Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "×":
                    textBoxResult.Text = (resultValue * Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "÷":
                    textBoxResult.Text = (resultValue / Double.Parse(textBoxResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(textBoxResult.Text);
            operation = "";
        }

        private void ButtonClear_Click(object sender, EventArgs e, TextBox textBoxResult)
        {
            textBoxResult.Text = "0";
            resultValue = 0;
        }
    }
}
