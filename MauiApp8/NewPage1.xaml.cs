using Microsoft.Maui.Controls.Platform.Compatibility;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Windows.Input;

namespace MauiApp8
{

	public partial class NewPage1 : ContentPage
	{
		public NewPage1()
		{
			BindingContext = new BmiCalculatorVeiwModel();
			InitializeComponent();
		}
	}

	public class BmiCalculatorVeiwModel : INotifyPropertyChanged
	{
		private double _weight { get; set; }
		private double _height { get; set; }
		private double _bmi { get; }
		private string _bmiCategory { get; }

		public double Weight
		{
			get => _weight;
			set
			{
				if (_weight != value)
				{
					_weight = Math.Round(value,2);
					OnPropertyChanged();
					OnPropertyChanged(nameof(Bmi));
					OnPropertyChanged(nameof(BmiCategory));
                }

            }
		}

		public double Height
		{
			get => _height;
			set
			{
				if (_height != value)
				{
					_height = Math.Round(value, 2);
					OnPropertyChanged();
					OnPropertyChanged(nameof(Bmi));
					OnPropertyChanged(nameof(BmiCategory));
                }

            }
		}

		public double Bmi
		{
			get
			{
				if (_height <= 0) return 0;
				return Math.Round(_weight / (_height * _height),1);
			}
		}


		public string BmiCategory
		{
		
			get
			{
				if (Bmi < 18.5) return "Underweight";
				else if (Bmi >= 18.5 && Bmi < 24.9) return "Normal weight";
				else if (Bmi >= 25 && Bmi < 29.9) return "Overweight";
				else return "Obesity";
            }
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}		