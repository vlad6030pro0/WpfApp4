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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            //down
            if (e.Key == Key.S && Canvas.GetTop(rectangle) + rectangle.Height < 400)
            {
                Canvas.SetTop(rectangle, Canvas.GetTop(rectangle) + 10);
            }
            //up
            if (e.Key == Key.W && Canvas.GetTop(rectangle) > 0)
            {
                Canvas.SetTop(rectangle, Canvas.GetTop(rectangle) - 10);
            }
            //rigth
            if (e.Key == Key.D && Canvas.GetLeft(rectangle) + rectangle.Height < 400)
            {
                Canvas.SetLeft(rectangle, Canvas.GetLeft (rectangle) + 10);
            }
            //left
            if (e.Key == Key.A && Canvas.GetLeft(rectangle) + rectangle.Height < 400)
            {
                Canvas.SetLeft(rectangle, Canvas.GetLeft(rectangle) - 10);
            }
        }
    }
}
