using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


namespace LR10_C121_SavolaynenDmitriy_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<ToyInfo> toys;
        public MainWindow()
        {
            InitializeComponent();

            toys = new ObservableCollection<ToyInfo>();
            toysDataGrid.ItemsSource = toys;
        }
        public List<ToyInfo> Toys = new List<ToyInfo>();
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            string name = toyName.Text;
            string factoryName = fabricName.Text;
            string age = ageCombo.Text;
            decimal price = 0;
            decimal.TryParse(toyPrice.Text, out price);
            string prodDate = dateProd.Text;
            string discount = discountCombo.Text;
            bool isOnStock = OnStockToggle.IsChecked == true;
            ToyInfo toy = new ToyInfo(name, factoryName, age, price, discount, prodDate, isOnStock);

            toys.Add(toy);
            Toys.Add(toy);
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            toyName.Clear();
            fabricName.Clear();

        }

        private void toggle_click(object sender, RoutedEventArgs e)
        {
            if (Switch_theme.IsChecked == true)
            {
                Color textColor = (Color)new ColorConverter().ConvertFrom("#323232");
                Color backColor = (Color)new ColorConverter().ConvertFrom("#D8D8D8");
                this.Resources["LightThemeForegroundButton"] = new SolidColorBrush(textColor);
                this.Resources["LightThemeBackgroundButton"] = new SolidColorBrush(backColor);
            }
            else
            {
                Color textColor = (Color)new ColorConverter().ConvertFrom("#665F52");
                Color backColor = (Color)new ColorConverter().ConvertFrom("#F2E2C2");
                this.Resources["LightThemeForegroundButton"] = new SolidColorBrush(textColor);
                this.Resources["LightThemeBackgroundButton"] = new SolidColorBrush(backColor);
            }
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "json files (*.json)|*.json";
            if (fileDialog.ShowDialog() == true)
            {
                string path = fileDialog.FileName;
                ToysStock.saveToJson(path, Toys);
            }
        }

        private void Button_SaveToWord_Click(object sender, RoutedEventArgs e)
        {
            ToysStock.saveToWord(Toys);
        }

    }
}
