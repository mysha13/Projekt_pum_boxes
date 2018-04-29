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
    /// Interaction logic for AddBox.xaml
    /// </summary>
    public partial class AddBox : Window
    {
        CurrentInfo currentuser = new CurrentInfo();
        
        public AddBox()
        {
            InitializeComponent();           
            
        }

        private void btnCancelAddIBox_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOkAddBox_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(currentuser.UserId.ToString());
            using (var database = new BD.BoxesEntities())
            {              
                int iduser=currentuser.UserId;
                
                var boxes = database.Boxes
                    .ToList()
                    .Where(x => x.UserId == iduser)
                    .Select(x => ViewModel.BoxViewModel.Create(x.Name, x.Number, x.Description))//, x.UserId))
                    //.Where()
                    .ToList();

                //datagridBoxes.ItemsSource = boxes;

                //BD.Box newbox = new BD.Box
                //{
                //    Name = tbNameAddBox.Text.Trim(),
                //    Number = int.Parse(tbNumberAddBox.Text.Trim()),
                //    Description = tbDescriptionAddBox.ToString().Trim(),
                //    UserId = iduser
                //};
                //database.Boxes.Add(newbox);  

                BD.Box newbox = new BD.Box
                {
                    Name = tbNameAddBox.Text.Trim(),
                    Number=int.Parse(tbNumberAddBox.Text),
                    Description=tbDescriptionAddBox.Text.Trim(),
                    UserId=iduser,
                    
                    
                };
                MessageBox.Show(tbDescriptionAddBox.Text);
                database.Boxes.Add(newbox);
                //boxes.Add(ViewModel.BoxViewModel.Create(tbNameAddBox.ToString(), int.Parse(tbNumberAddBox.ToString()), tbDescriptionAddBox.ToString(),int.Parse(iduser.ToString())));
                database.SaveChanges();
            }
        }
    }
}
