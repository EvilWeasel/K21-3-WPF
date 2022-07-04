using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    internal class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            FirstName = "Dave";
            MiddleName = "Hackerman";
            LastName = "Jones";
        }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
