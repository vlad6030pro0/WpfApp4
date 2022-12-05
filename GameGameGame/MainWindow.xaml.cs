﻿using System;
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
using System.Diagnostics; //Дебаг консоль
using System.Windows.Threading; //для таймеров

namespace GameGameGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // поля 
        private bool bLeft;
        private bool bRight;

        private int speed = 10;
        private int drop = 10;

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(15);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // gravity
            double y = Canvas.GetTop(player);
            Canvas.SetTop(player, y+drop);

            Rect playerCollision = new Rect(Canvas.GetLeft(player), y, player.Width, player.Height);

            Rectangle rectangleForRemove = null;

            foreach (var rect in MyCanvas.Children.OfType<Rectangle>())
            {
                if (rect.Tag != null)
                {
                    Rect rectCollision = new Rect(Canvas.GetLeft(rect), Canvas.GetTop(rect), rect.Width, rect.Height);

                    if (rect.Tag.ToString() == "platform")
                    {
                        if (playerCollision.IntersectsWith(rectCollision))
                        {
                            drop = 0;

                            Canvas.SetTop(player, Canvas.GetTop(rect) - player.Height);
                        }
                        else
                        {
                            drop = 10;
                        }
                    }
                    if (rect.Tag.ToString() == "coin")
                    {
                        if (playerCollision.IntersectsWith(rectCollision))
                        {
                            //rect.Visibility = Visibility.Hidden;

                            rectangleForRemove = rect;
                        }
                    }
                }
            }

            if (rectangleForRemove != null)
            {
                MyCanvas.Children.Remove(rectangleForRemove);
            }


            if (bLeft)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - speed);
            }

            if (bRight)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + speed);
            }
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                bLeft = true;
            }
            else if (e.Key == Key.D)
            {
                bRight = true;  
            }

            Debug.WriteLine("bLeft: "+bLeft+"\n bRight: "+bRight);
        }

        private void Canvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                bLeft = false;
            }
            else if (e.Key == Key.D)
            {
                bRight = false;
            }

            Debug.WriteLine("bLeft: " + bLeft + "\n bRight: " + bRight);
        }
    }
}
  