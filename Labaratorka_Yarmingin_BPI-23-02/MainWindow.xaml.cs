using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labaratorka_Yarmingin_BPI_23_02;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var uri = new Uri(@"Dark.xaml", UriKind.Relative);
        ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
        Application.Current.Resources.Clear();
        Application.Current.Resources.MergedDictionaries.Add(resourceDict);
    }
    private void DarkButton_Click(object sender, RoutedEventArgs e)
    {
        var uri = new Uri(@"Dark.xaml", UriKind.Relative);
        ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
        Application.Current.Resources.Clear();
        Application.Current.Resources.MergedDictionaries.Add(resourceDict);
    }
    private void LightButton_Click(object sender, RoutedEventArgs e)
    {
        var uri = new Uri(@"Light.xaml", UriKind.Relative);
        ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
        Application.Current.Resources.Clear();
        Application.Current.Resources.MergedDictionaries.Add(resourceDict);
    }
    private void CalculateButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(priceTextBox.Text))
            {
                resultText.Text = "Заполните все поля!";
                return;
            }
            string priceText = priceTextBox.Text.Replace('.', ',');

            if (double.TryParse(priceText, out double price))
            {
                Factory factory = new(nameTextBox.Text, price, manufacturerTextBox.Text ?? string.Empty);
                double priceInEuro = factory.Conversion();
                double finalPrice = factory.PriceSamsung();

                if (factory.NameSamsung())
                {
                    resultText.Text = $"{finalPrice:F2} € (+20%)";
                }
                else
                {
                    resultText.Text = $"{priceInEuro:F2} €";
                }
            }
            else
            {
                resultText.Text = "Некорректная цена!";
            }
        }
        catch (Exception ex)
        {
            resultText.Text = $"Ошибка: {ex.Message}";
        }
    }

    private void PriceTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (!char.IsDigit(e.Text, 0) && e.Text != "," && e.Text != ".")
        {
            e.Handled = true;
        }

        if (sender is TextBox textBox && (e.Text == "," || e.Text == ".") && textBox.Text.Contains(','))
        {
            e.Handled = true;
        }
    }

    private void PriceTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Space)
        {
            e.Handled = true;
        }
    }
}