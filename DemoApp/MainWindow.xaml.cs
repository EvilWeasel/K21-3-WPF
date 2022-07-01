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

namespace DemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Person> Persons = new List<Person>();
        public MainWindow()
        {
            Persons.Add(new Person("Herbert", "Maier", "24", "twehrle@live.de"));
            InitializeComponent();
            btn_save.IsEnabled = false;
            listview_persons.ItemsSource = Persons;
        }

        private void btn_save_click(object sender, RoutedEventArgs e)
        {
            //listview_persons.UnselectAll();
            //string firstname = txb_firstname.Text;
            //string lastname = txb_lastname.Text;
            //string age = txb_age.Text;
            //string email = txb_email.Text;

            if (listview_persons.SelectedItem == null &&
                    txb_firstname.Text != String.Empty &&
                    txb_lastname.Text != String.Empty)
            {
                Person p1 = new Person(txb_firstname.Text, txb_lastname.Text, txb_age.Text, txb_email.Text);
                Persons.Add(p1);
            }
            listview_persons.Items.Refresh();
            btn_reset_click(new Object(), new RoutedEventArgs());
        }

        private void btn_reset_click(object sender, RoutedEventArgs e)
        {
            listview_persons.UnselectAll();
            // listview_persons.Items.Refresh();
            txb_firstname.Clear();
            txb_lastname.Clear();
            txb_age.Clear();
            txb_email.Clear();
        }

        private void txb_firstname_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChangeButtonVisibility();
        }

        private void txb_lastname_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChangeButtonVisibility();
        }
        private void ChangeButtonVisibility()
        {
            if (txb_firstname.Text.Length > 0 &&
                    txb_lastname.Text.Length > 0)
            {
                btn_save.IsEnabled = true;
            }
            else btn_save.IsEnabled = false;
        }
    }

    public class Person
    {
        public Person(string name, string lastName, string age, string email)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Email = email;

        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Name} {LastName}";
        }
    }
}
