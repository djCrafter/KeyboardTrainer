using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace KeybordTrainer
{
    /// <summary>
    /// Класс кнопки клавиатурного тренажера.
    /// </summary>
    class TeButton : Button
    {
        /// <summary>
        /// Цвет кнопки
        /// </summary>
        Brush backBrush = new SolidColorBrush();

        /// <summary>
        /// Цвет кнопки при нажатии на нее.
        /// </summary>
        Brush selectBrush = new SolidColorBrush(Colors.White);


        char specialSymbol;
        char mainSymbol;


        /// <summary>
        /// Словарь регистра символов.
        /// </summary>
        Dictionary<char, char> key_register = new Dictionary<char, char>()
           {
               { '1','!' }, {'2','@'}, {'3','#'}, {'4','$'}, {'5','%'},
               { '6','^' }, {'7','&'}, {'8','*'}, {'9','('}, {'0',')'},
               { '-','_' }, {'=','+'}, {'[','{'}, {']','}'}, {'\\','|'},
               { ';',':' }, {'\'','"'}, {',','<'}, {'.','>'}, {'/','?'},
               { '`','~' }
           };


        /// <summary>
        /// Инициализация кнопок со спецсимволами.
        /// </summary>
        public void SpecialSymbolInit()
        {
            string str = Content.ToString();
            if (!char.IsLetter(str[0]))
            {

                mainSymbol = str[0];
                specialSymbol = key_register[mainSymbol];
            }
        }

        /// <summary>
        /// Метод меняет регистр символа(только буквы) кнопки. Регистр завист от того нажата ли клавиша CapsLook.
        /// </summary>
        public void ChangeRegisterCaps()
        {
            if (Console.CapsLock)
            {
                if (Content != null)
                {
                    string str = Content.ToString();
                    if (char.IsLetter(str[0]) && str.Length == 1)
                    {
                        Content = char.ToUpper(str[0]);
                    }
                }
            }
            else
            {
                if (Content != null)
                {
                    string str = Content.ToString();
                    if (char.IsLetter(str[0]) && str.Length == 1)
                    {
                        Content = char.ToLower(str[0]);
                    }
                }
            }
        }

        /// <summary>
        /// Метод меняет регистр кнопки на верхний.
        /// </summary>
        public void ChangeRegisterUp()
        {
            if (Content != null)
            {
                string str = Content.ToString();
                if (char.IsLetter(str[0]) && str.Length == 1)
                    Content = char.ToUpper(str[0]);
                else if (str.Length == 1)
                {
                    Content = specialSymbol.ToString();
                }
            }
        }

        /// <summary>
        /// Метод меняет регистр кнопки на нижний.
        /// </summary>
        public void ChangeRegisterDown()
        {
            if (Content != null)
            {
                string str = Content.ToString();
                if (char.IsLetter(str[0]) && str.Length == 1)
                    Content = char.ToLower(str[0]);
                else if (str.Length == 1)
                {
                    Content = mainSymbol.ToString();
                }

            }
        }

        /// <summary>
        /// Метод меняет цвет кнопки с выделенного на постоянный.
        /// </summary>
        public void Unpress()
        {
            Background = backBrush;
        }

        /// <summary>
        /// Метод меняет цвет кноки с постоянного на выделенный.
        /// </summary>
        public void Press()
        {
            if (Background != selectBrush)
                backBrush = Background;

            Background = selectBrush;
        }

    }
}
