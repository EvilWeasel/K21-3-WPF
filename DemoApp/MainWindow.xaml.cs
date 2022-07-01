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
            //List<Person> Persons = new List<Person>();
            Persons.Add(new Person("Herbert", "Maier", "24", "twehrle@live.de"));
            InitializeComponent();
            listview_persons.ItemsSource = Persons;
        }

        private void btn_save_click(object sender, RoutedEventArgs e)
        {
            string firstname = txb_firstname.Text;
            string lastname = txb_lastname.Text;
            string age = txb_age.Text;
            string email = txb_email.Text;

            Person p1 = new Person(firstname, lastname, age, email);
            Persons.Add(p1);
        }

        private void btn_reset_click(object sender, RoutedEventArgs e)
        {
            txb_firstname.Text = "";
            txb_lastname.Clear();
            txb_age.Text = "";
            txb_email.Text = "";
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
