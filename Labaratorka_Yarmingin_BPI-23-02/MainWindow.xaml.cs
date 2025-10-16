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
}