using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorModified.Models
{
    static class Calculator
    {
        //Метод применяет мат.операцию к паре переменных в зависимости от поступившей строки operation 
        public static double Operation(double num1, double num2, string operation)
        {
            double result = 0;
            switch (operation)
            {
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
            }
            return result;
        }
    }
}
