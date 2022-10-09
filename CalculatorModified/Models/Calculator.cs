using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorModified.Models
{
    static class Calculator
    {
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

        //public static double StringParser(string inputString)
        //{
        //    string strNumber = "";
        //    string operation = "+";
        //    double result = 0;
        //    double nextNumber;
        //    string modifiedInput = "";

        //    //Первичный проход по строке
        //    for (int i = 0; i < inputString.Length; i++)
        //    {
        //        if (Char.IsDigit(inputString[i]) || inputString[i] == ',')
        //        {
        //            strNumber += inputString[i];
        //        }
        //        else
        //        {
        //            nextNumber = Convert.ToDouble(strNumber);
        //            strNumber = "";
        //            result = Operation(result, nextNumber, operation);
        //            operation = Convert.ToString(inputString[i]);
        //        }
        //    }

        //    nextNumber = Convert.ToDouble(strNumber);
        //    strNumber = "";
        //    result = Operation(result, nextNumber, operation);

        //    return result;
        //}
    }
}
