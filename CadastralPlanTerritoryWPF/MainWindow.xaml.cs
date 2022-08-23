using CadastralPlanTerritoryWPF.Models;
using CadastralPlanTerritoryWPF.ViewModels;
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

namespace CadastralPlanTerritoryWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AppViewModel();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //var dataContext = (sender as StackPanel).DataContext;
            var dataContext = (sender as FrameworkElement).DataContext;
            this.ParcelInfo.Visibility = 
                (dataContext is Parcel) ? Visibility.Visible : Visibility.Collapsed;
            this.BuildInfo.Visibility = 
                (dataContext is Build) ? Visibility.Visible : Visibility.Collapsed;
            this.ConstructionInfo.Visibility = 
                (dataContext is Construction) ? Visibility.Visible : Visibility.Collapsed;
            this.SpatialDataEntityInfo.Visibility = 
                (dataContext is SpatialDataEntity) ? Visibility.Visible : Visibility.Collapsed;
            this.BoundInfo.Visibility = 
                (dataContext is Bound) ? Visibility.Visible : Visibility.Collapsed;
            this.ZoneInfo.Visibility = 
                (dataContext is Zone) ? Visibility.Visible : Visibility.Collapsed;            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var dataContext = (sender as FrameworkElement).DataContext;
            (this.DataContext as AppViewModel).AddCheckedItemInList(dataContext);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var dataContext = (sender as FrameworkElement).DataContext;
            (this.DataContext as AppViewModel).RemoveCheckedItemFromList(dataContext);
        }
    }
}
