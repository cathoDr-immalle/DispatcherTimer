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
using System.Windows.Threading;

namespace H6_DispatcherTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random Randomnummer = new Random();
        private double x, y, size;
        private SolidColorBrush brush;
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            GapLabel.Content = Convert.ToString(GapSlider.Value);
            brush = new SolidColorBrush(Colors.Blue);
            timer.Interval = TimeSpan.FromMilliseconds(GapSlider.Value);
            timer.Tick += timer_Tick;
        }

        private void StartKnop_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
        private void StopKnop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void ClearKnop_Click(object sender, RoutedEventArgs e)
        {
            MijnCanvas.Children.Clear();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            x = Randomnummer.Next(0, Convert.ToInt32(MijnCanvas.Width));
            y = Randomnummer.Next(0, Convert.ToInt32(MijnCanvas.Height));
            size = Randomnummer.Next(1, 40);

            Ellipse ellipse = new Ellipse();
            ellipse.Width = size;
            ellipse.Height = size;
            ellipse.Stroke = brush;
            ellipse.Fill = brush;
            ellipse.Margin = new Thickness(x, y, 0, 0);
            MijnCanvas.Children.Add(ellipse);

            timer.Stop();
            int ms = Randomnummer.Next(1, Convert.ToInt32(GapSlider.Value));
            timer.Interval = TimeSpan.FromMilliseconds(ms);
            timer.Start();
        }

        private void GapSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int timeGap = Convert.ToInt32(GapSlider.Value);
            GapLabel.Content = Convert.ToString(timeGap);
        }

    }
}
