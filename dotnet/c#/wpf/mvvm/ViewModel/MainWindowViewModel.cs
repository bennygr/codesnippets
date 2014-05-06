using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using mvvm.Model;

namespace mvvm.ViewModel
{
    /// <summary>
    /// The view model of the main window
    /// </summary>
    class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Car> cars = 
            new ObservableCollection<Car>();
        private SolidColorBrush selectedCarColor;
        private Car selectedCar;
        private ICommand addCarCommand;
        private ICommand removeCarCommand;
        
        #endregion

        #region Command Properties

        /// <summary>
        /// Command to add a car
        /// </summary>
        public ICommand AddCar
        {
            get
            {
               if(addCarCommand == null)
                   addCarCommand = new RelayCommand(AddCarInternal);
                return addCarCommand;
            }
        }

        /// <summary>
        /// Command to remove the selected
        /// </summary>
        public ICommand RemoveCar
        {
            get
            {
                if(removeCarCommand == null)
                    removeCarCommand = new RelayCommand(RemoveCarInternal,
                                                        x => selectedCar != null);
                return removeCarCommand;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        ///     The cars 
        /// </summary>
        public ObservableCollection<Car> Cars
        {
            get { return cars; }
        }

        /// <summary>
        /// The current selected car 
        /// </summary>
        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if(selectedCar != value)
                {
                    selectedCar = value;                
                    selectedCarColor = new SolidColorBrush(selectedCar.Color);
                    OnPropertyChanged("SelectedCar");
                    OnPropertyChanged("SelectedCarColor");
                }
            }
        }

        /// <summary>
        /// The color of the selected car 
        /// </summary>        
        public Brush SelectedCarColor
        {
            get
            {                
                return selectedCarColor;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindowViewModel()
        {
            LoadCars();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Internal method to add a car
        /// </summary>        
        /// <param name="obj">Command parameter not used</param>
        private void AddCarInternal(object obj)
        {
            //Just create a random car
            Random random = new Random();
            CarRepository.AddCar(new Car
                                 {
                                     Name = "Some new car",
                                     Color = Colors.Green,
                                     HP = random.Next(55,300),
                                     Price = random.Next(6000,30000),                                     
                                 });
            //reload cars
            LoadCars();
        }


        /// <summary>
        /// Internal method to remove the current car
        /// </summary>
        /// <param name="obj">Command parameter not used</param>
        private void RemoveCarInternal(object obj)
        {
            CarRepository.RemoveCar(SelectedCar);
            LoadCars();
        }

        /// <summary>
        /// Internal method to refresh the list of known cars
        /// </summary>
        private void LoadCars()
        {
            this.cars = new ObservableCollection<Car>(CarRepository.GetAllCars());            
            OnPropertyChanged("Cars");
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
