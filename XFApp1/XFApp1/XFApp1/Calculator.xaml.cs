using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFApp1
{
    public partial class CalculatorPage : ContentPage
    {
        int currentState = 0;
        string mathOperator;
        double firstNumber, secondNumber;

        public CalculatorPage()
        {
            InitializeComponent();

            InitialEventHandlers();

            OnClear(this, null);
        }

        void InitialEventHandlers()
        {
            // OnSelectNumber
            number0.Clicked += OnSelectNumber;
            number1.Clicked += OnSelectNumber;
            number2.Clicked += OnSelectNumber;
            number3.Clicked += OnSelectNumber;
            number4.Clicked += OnSelectNumber;
            number5.Clicked += OnSelectNumber;
            number6.Clicked += OnSelectNumber;
            number7.Clicked += OnSelectNumber;
            number8.Clicked += OnSelectNumber;
            number9.Clicked += OnSelectNumber;
            // OnSelectOperator
            operatorPlus.Clicked += OnSelectOperator;
            operatorSubtract.Clicked += OnSelectOperator;
            operatorMulti.Clicked += OnSelectOperator;
            operatorDivide.Clicked += OnSelectOperator;
            // OnClear
            clearButton.Clicked += OnClear;
            // OnCalculator
            calculatorButton.Clicked += OnCalculator;
        }

        private void OnCalculator(object sender, EventArgs e)
        {
            switch (mathOperator)
            {
                case "+":
                    resultText.Text = Convert.ToString(firstNumber + secondNumber);
                    break;
                case "-":
                    resultText.Text = Convert.ToString(firstNumber - secondNumber);
                    break;
                case "X":
                    resultText.Text = Convert.ToString(firstNumber * secondNumber);
                    break;
                case "/":
                    resultText.Text = Convert.ToString(firstNumber / secondNumber);
                    break;
            }

            if (double.TryParse(resultText.Text, out double result))
            {
                firstNumber = result;
            }
            currentState = 0;
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            currentState = 0;
            mathOperator = "";
            firstNumber = secondNumber = 0;
        }

        private void OnSelectOperator(object sender, EventArgs e)
        {
            mathOperator = ((Button)sender).Text;
            currentState = 2;
        }

        private void OnSelectNumber(object sender, EventArgs e)
        {
            if (currentState == -1 || currentState == 0)
            {
                resultText.Text = "";
                currentState = 1;
            }
            else if (currentState == 2)
            {
                firstNumber = double.Parse(resultText.Text);
                resultText.Text = "";
                currentState = 3;
            }
            resultText.Text += ((Button)sender).Text;
            if (currentState == 1)
            {
                firstNumber = double.Parse(resultText.Text);
            }
            else if (currentState == 3)
            {
                secondNumber = double.Parse(resultText.Text);
            }
        }
    }
}
