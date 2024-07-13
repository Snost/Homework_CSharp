using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HW_Binding
{

    internal class WeatherViewModels
    {
        private string _weather;
        public string Weather
        {
            get => _weather;
            set => _weather = value;
        }
        public ObservableCollection<int> Tempertaures { get; set; }
        public int Temp { get; set; }
        public ICommand AddTemp {  get; set; }

        public WeatherViewModels()
        {
            Weather = "Sunny";
            Tempertaures = new ObservableCollection<int>();
            AddTemp= new RelayCommand(()=> Tempertaures.Add(Temp));
        }
    }
}
