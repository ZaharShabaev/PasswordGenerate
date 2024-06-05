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
using PasswordGenerator.Extensions;

namespace PasswordGenerator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnGenerate_OnClick(object sender, RoutedEventArgs e)
    {
        PasswordGeneratoros generator = new PasswordGeneratoros();

        switch (CbDiff.SelectedIndex)
        {
            case 0:
                TbBox.Text = generator.GeneratePassword(DfPass.Easy, Convert.ToInt32(Tblenght.Text));
                break;
            case 1:
                TbBox.Text = generator.GeneratePassword(DfPass.Medium, Convert.ToInt32(Tblenght.Text));
                break; 
            case 2:
                TbBox.Text = generator.GeneratePassword(DfPass.Hard, Convert.ToInt32(Tblenght.Text));
                break; 
        }
    }
}