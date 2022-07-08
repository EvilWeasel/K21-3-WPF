﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_GettingStarted.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private string firstName;
        private string middleName;
        private string lastName;
        // properties with propertychanged-event implemented
        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstName"));
                    // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof (FirstName)));
                    // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullName)));
                    //RaisePropertyChanged("FirstName");
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(FullName));
                }
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string MiddleName 
        { 
            get => middleName;
            set
            {
                if (middleName != value)
                {
                    middleName = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(FullName));
                }
            } 
        }
        public string LastName 
        { 
            get => lastName; 
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(FullName));
                }
            }
        }




        public string FullName => $"{FirstName}, {MiddleName}, {LastName}";
        public MainWindowViewModel()
        {
            FirstName = "Heinz";
            MiddleName = "Hackerman";
            LastName = "Müller";
            // C#
            //String x = "abc";
            // Python
            //x = "abc"
            txb_firstname = "Anita";
        }

    }
}
