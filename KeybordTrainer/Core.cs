using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeybordTrainer
{
    /// <summary>
    /// Класс генерирующий строку для тренажера клавиатуры.
    /// </summary>
    class Core
    {
        //Test string//
        string newString;

        /// <summary>
        /// Главная строка.
        /// </summary>
        string mainText;

        /// <summary>
        /// Позиция курсора
        /// </summary>
        int position = 0;

        /// <summary>
        /// Кол-во ошибок
        /// </summary>
        int fails = 0;

        /// <summary>
        /// Сложность игры.
        /// </summary>
        int difficult;

        /// <summary>
        /// Свойство возвращает/задает строку
        /// </summary>
        public string MainText
        {
            get { return mainText; }
            set { mainText = value; }
        }

        /// <summary>
        /// Свойство возвращает кол. ошибок.
        /// </summary>
        public int GetFails
        {
            get { return fails; }
        }

        /// <summary>
        /// Свойство возвращает позицию курсора.
        /// </summary>
        public int GetPosition
        {
            get { return position; }
        }

        /// <summary>
        /// Конструктор с параметром сложности.
        /// </summary>
        /// <param name="difficult">Сложность строки.</param>
        public Core(int difficult)
        {
            this.difficult = difficult;
            TextGenerator();
        }
        
        /// <summary>
        /// Метод генератор строки.
        /// </summary>
        private void TextGenerator()
        {
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();

            int min = 0;
            int max = 0;
            int count = 0;
            

            switch (difficult)
            {
                case 1:
                    min = 65;
                    max = 90;
                    count = 50;
                    
                    break;

                case 2:
                    min = 65;
                    max = 122;
                    count = 100;
                    break;
            }



            for (int i = 0; i < count; ++i)
            {
               // if (rand.Next(0, 8) != 6)
                   sb.Append(Convert.ToChar(rand.Next(min, max)));
                //else 
                //   sb.Append(' ');
            }

            mainText = sb.ToString();
        }

        /// <summary>
        /// Проверка на правильность нажатой клавиши.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public bool Check_Сharacter(char symbol)
        {

            if(mainText[position] == symbol)
            {
                position++;
                return true;
            }
            else
            {
                fails++;
                return false;
            }
        }
    }
}
