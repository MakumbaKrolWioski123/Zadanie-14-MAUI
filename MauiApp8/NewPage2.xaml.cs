using Microsoft.Maui.Controls.Platform.Compatibility;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Windows.Input;


namespace MauiApp8
{

	public partial class NewPage2 : ContentPage
	{
		public NewPage2()
		{
			BindingContext = new ShoppingListViewModel();
            InitializeComponent();
			
        }
	}

	public class ShoppingItem :INotifyPropertyChanged
	{
		private string _name ="Japki";
		private int _quantity=12;
		private int _price=5;

        public string Name
		{
			get => _name;
			set
			{
				if (_name != value)
				{
					_name = value;
					OnPropertyChanged();
				}
			}
		}
		public int Quantity
		{
			get => _quantity;
			set
			{
				if (_quantity != value)
				{
					_quantity = value;
					OnPropertyChanged();
				}
			}
		}

		public int Price
		{
			get => _price;
			set
			{
				if (_price != value)
				{
					_price = value;
					OnPropertyChanged();
				}
			}
        }

		public int TotalPrice
		{
			get
			{
				return _quantity * _price;
			}
		}

        public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

	public class ShoppingListViewModel : INotifyPropertyChanged
    {
		public ObservableCollection<ShoppingItem> ShoppingItems { get; set; }

		private string _newItemName;
		public string NewItemName
		{
			get => _newItemName;
			set
			{
				_newItemName = value;
				OnPropertyChanged(nameof(NewItemName));
			}
		}

		private int _newItemQuantity;
		public int NewItemQuantity
		{
			get => _newItemQuantity;
			set
			{
				_newItemQuantity = value;
				OnPropertyChanged(nameof(NewItemQuantity));
			}
		}

		private int _newItemPrice;
		public int NewItemPrice
		{
			get => _newItemPrice;
			set
			{
				_newItemPrice = value;
				OnPropertyChanged(nameof(NewItemPrice));
			}
		}

		private int _totalSum;
		public int TotalSum
		{
			get
			{
				_totalSum = 0;
				foreach (var item in ShoppingItems)
				{
					_totalSum += item.TotalPrice;
				}
				return _totalSum;

            }
        }



        public ICommand AddItemCommand { get; }
		public ICommand DeleteItemCommand { get; }
        public ShoppingListViewModel()
		{
			ShoppingItems = new ObservableCollection<ShoppingItem>
			{
				new ShoppingItem { Name = "Japki", Quantity = 2, Price = 3 },
				new ShoppingItem { Name = "Banany", Quantity = 5, Price = 1 },
				new ShoppingItem { Name = "Ananasy", Quantity = 3, Price = 2 }
			};

            AddItemCommand = new Command(AddItem);
			DeleteItemCommand= new Command<ShoppingItem>(DeleteItem);

        }

        private void AddItem()
        {
            if (string.IsNullOrWhiteSpace(NewItemName)) return;

            ShoppingItems.Add(new ShoppingItem
            {
                Name = NewItemName,
                Quantity = NewItemQuantity,
                Price = NewItemPrice
            });

            NewItemName = string.Empty;
            NewItemQuantity = 0;
            NewItemPrice = 0;
        }

		private void DeleteItem(ShoppingItem item)
        {
			if (ShoppingItems.Contains(item))
			{
				ShoppingItems.Remove(item);
			}
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}