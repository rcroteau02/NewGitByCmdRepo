using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;

namespace HelloWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _currentText;

        public MainWindow()
        {
            CurrentText = "Init";
            InitializeComponent();
            DataContext = this;
        }

        public string CurrentText
        {
            get { return _currentText; }
            set
            {
                if (_currentText != value)
                {
                    _currentText = value;
                    OnPropertyChanged(() => CurrentText);
                }
            }
        }

        private void HelloButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentText = "Hello";
        }
        private void HiButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentText = "Hi there!";
        }
        private void WesternButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentText = "Howdy!!";
        }


        #region INotifyPropertyChanged
        protected void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var property = (MemberExpression)expression.Body;
            OnPropertyChanged(property.Member.Name);
        }

        /// <summary>
        /// Internal method used so that the framework can notify a property change on any object
        /// </summary>
        public void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

    }
}
