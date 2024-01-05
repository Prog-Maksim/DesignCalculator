using System;
using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    public partial class MainWindow
    {
        private string _theme = "Dark";
        
        public MainWindow()
        {
            InitializeComponent();
            Theme(_theme);
        }
        
        private void Border_MouseDows(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }
        
        private void Border_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2) Close();
        }
        
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                _theme = (_theme == "Dark") ? "Light" : "Dark";
                Theme(_theme);
            }
        }

        private static void Theme(string themeName)
        {
            var uri = new Uri(themeName + ".xaml", UriKind.Relative);
            var resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}