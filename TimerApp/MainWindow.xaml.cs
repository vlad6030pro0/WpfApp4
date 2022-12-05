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

using System.Windows.Threading;  //for timers

namespace TimerApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //поля
        int left = 0;
        int speed = 2;

        public MainWindow()
        {
            InitializeComponent();
            left = (int)ball.Margin.Left;


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;

            timer.Start();
        
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            left += speed;
            ball.Margin = new Thickness(left, 0, 0, 20);
            
            if (ball.Margin.Left > 800 - ball.Width - 20)
            {
                speed = -2;
            }
            if (ball.Margin.Left < 20)
            {
                speed = 2;
            }
        }
    }
}
