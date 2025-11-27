using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Windows.Input;

namespace MauiApp8
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new User();
            InitializeComponent();
        }
    }

    public class User : INotifyPropertyChanged
    {
        private string _FirstName ="John";
        private string _LastName ="Doe";
        private string _Email = "email@gmail.com";
        private int _Age = 30;

        public string FirstName
        {
            get => _FirstName;
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get => _LastName;
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public string Email
        {
            get => _Email;
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public int Age
        {
            get => _Age;
            set
            {
                if (_Age != value)
                {
                    _Age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

      
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
