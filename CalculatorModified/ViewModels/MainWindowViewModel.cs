using CalculatorModified.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculatorModified.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            //? - проверка на null, this - ссылка на ViewModel
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private string equation;
        public string Equation
        {
            get => equation;
            set
            {
                equation = value;
                OnPropertyChanged();
            }
        }

        private double result;
        public double Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged();
            }
        }

        //Вспомогательные переменные
        private string firstNumber = "0";
        private string secondNumber = "";
        private string operation = "+";

        //Блок определения команд
        //Команда
        public ICommand AddCommand { get; }
        //метод для подстановки на место Execute из RelayCommand
        private void OnAddCommandExecute(object p)
        {
            //обработка результатов нажатия кнопки
            string buttonContent = p as string;

            //Выделяем численную часть в поступающем наборе символов
            if (Char.IsDigit(buttonContent[0]) || buttonContent[0] == ',')
            {
                secondNumber += buttonContent;
                Equation = Result + operation + secondNumber;
            }
            //Действие при нажатии кнопки "="
            else if (buttonContent == "=")
            {
                Result = Calculator.Operation(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber), operation);
                Equation = firstNumber + operation + secondNumber;
                firstNumber = "0";
                secondNumber = "";
                operation = "+";
            }
            //Действие для очистки окна вычислений
            else if (buttonContent == "C")
            {
                firstNumber = "0";
                secondNumber = "";
                Equation = "";
                Result = 0;
                operation = "+";
            }
            //Обработка нажатия остальных кнопок
            else
            {
                double.TryParse(firstNumber, out double value1);
                double.TryParse(secondNumber, out double value2);
                Result = Calculator.Operation(value1, value2, operation);
                firstNumber = Convert.ToString(result);
                secondNumber = "";
                Equation = Result + operation + secondNumber;
                operation = buttonContent;
            }
        }
        //метод для подстановки на место CanExecute из RelayCommand
        private bool CanAddCommandExecuted(object p)
        {
            //место для условий ограничения доступности выполнения команды
            return true;
        }

        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
        }
    }
}
