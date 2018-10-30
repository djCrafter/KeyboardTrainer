using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace KeybordTrainer
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Core core;

        List<TeButton> all_buttons = new List<TeButton>();

        bool action = false;

        Brush backBrush = new SolidColorBrush();

        int difficult = 1;

        public MainWindow()
        {
            InitializeComponent();

            ButtonsListSetUp();
            PreviewKeyDown += MainWindow_KeyDown;
            PreviewKeyUp += MainWindow_KeyUp;
            

            TextBoxSetUp();
            
            StopButton.IsEnabled = false;                       
        }


        private void TextBoxSetUp()
        {           
            TextBox1.IsReadOnly = true;
            TextBox1.SelectionBrush = new SolidColorBrush(Colors.Green);            
            TextBox1.SelectionStart = 0;
            TextBox1.SelectionLength = 0;
        }


        private void ButtonsListSetUp()
        {
            all_buttons = new List<TeButton>
            {
                Oem3, D1, D2, D3, D4, D5, D6, D7, D8, D9, D0, OemMinus, OemPlus,
                Q, W, E, R, T, Y, U, I, O, P, OemOpenBrackets, Oem6, Oem5,
                A, S, D, F, G, H, J, K, L, Oem1, OemQuotes,
                Z, X, C, V, B, N, M, OemComma, OemPeriod, OemQuestion,
                Space };


            //buttons.Add(Back);
            //buttons.Add(Tab);       
            //buttons.Add(Capital);          
            //buttons.Add(Return);
            //buttons.Add(LeftShift);           
            //buttons.Add(RightShift);

            foreach (TeButton item in all_buttons)
            {
                item.ChangeRegisterCaps();
                item.SpecialSymbolInit();
            }
        }



        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.Key.ToString());
            TextBox1.Focus();

            bool flag = true;

            switch (e.Key)
            {
                case Key.Capital:
                    foreach(TeButton item in all_buttons)
                    {
                        item.ChangeRegisterCaps();
                    }
                    break;

                case Key.LeftShift:
                case Key.RightShift:
                    foreach (TeButton item in all_buttons)
                    {
                        item.ChangeRegisterUp();
                    }
                    flag = false;
                    break;

                default:
                foreach (TeButton item in all_buttons)
            {
                if (e.Key.ToString() == item.Name)
                {                         
                    item.Press();
                }
            }
                    break;
        }


            if (action)
            {
                string str = e.Key.ToString();

                if (str.Length == 1)
                {
                    char symbol = str[0];

                    if (!Console.CapsLock && flag)
                    {
                        if (core.Check_Сharacter(char.ToLower(symbol)))
                        {
                            TextBox1.SelectionLength++;
                        }
                    }
                    else
                    {
                        if(core.Check_Сharacter(symbol))
                        TextBox1.SelectionLength++;
                    }

                    Label_Fails.Content = "Fails: " + core.GetFails.ToString();
                }
            }
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {             
                case Key.LeftShift:
                case Key.RightShift:
                    foreach (TeButton item in all_buttons)
                    {
                        item.ChangeRegisterDown();
                    }
                    break;

                default:
                    foreach (TeButton item in all_buttons)
                    {
                        if (e.Key.ToString() == item.Name)
                        {
                            item.Unpress();
                        }
                    }
                    break;
                
            }
        }

        private void Start_ButtonClick(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
            Slider1.IsEnabled = false;
            SliderValueLabel.IsEnabled = false;


            core = new Core(difficult);
            TextBox1.Text = core.MainText;
            action = true;


        }

        private void Stop_ButtonClick(object sender, RoutedEventArgs e)
        {
            StopButton.IsEnabled = false;
            StartButton.IsEnabled = true;
            Slider1.IsEnabled = true;
            SliderValueLabel.IsEnabled = true;


            action = false;
            MessageBox.Show("Правильных нажатий: " + core.GetPosition.ToString() + "\n"
                + "Ошибок: " + core.GetFails.ToString(), "Тренинг окончен.", MessageBoxButton.OK, MessageBoxImage.Information);
                

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            difficult = (int)Slider1.Value;
            SliderValueLabel.Content = "Difficult: " + Slider1.Value.ToString();
        }
    }
}
