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
using System.Windows.Shapes;

namespace boxitem
{
    /// <summary>
    /// Interaction logic for FindItem.xaml
    /// </summary>
    public partial class FindItem : Window
    {
        public FindItem()
        {
            InitializeComponent();
        }

        private void btnCancelFindItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
