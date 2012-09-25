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

namespace WMSLayerListing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WMSParser parser = null;

        public MainWindow()
        {
            InitializeComponent();
            parser = new WMSParser();
        }



        private void btnParse_Click(object sender, RoutedEventArgs e)
        {
            list.Items.Clear();
            var res = parser.getLayers(textURL.Text);
            textStatus.Text = res.Count.ToString() + " Layers Parsed.";
            foreach (String layer in res)
            {
                list.Items.Add(layer);
            }

        }

       
    }
}
