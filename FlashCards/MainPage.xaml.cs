using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace FlashCards
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Handle selection changed on ListBox
        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (MainListBox.SelectedIndex == -1)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + MainListBox.SelectedIndex, UriKind.Relative));

            // Reset selected index to -1 (no selection)
            MainListBox.SelectedIndex = -1;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void AddCard_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewCardPage.xaml", UriKind.Relative));
        }

        private void DeleteCard_Click(object sender, EventArgs e)
        {
            MainListBox.SelectedIndex = CardOperations.DeleteCard(MainListBox.SelectedIndex, -1);        
        }

        private void RandomCard_Click(object sender, EventArgs e)
        {
            int index = CardOperations.RandomCard();
            if (index == -1)
                return;
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + index, UriKind.Relative));
        }

        private void AboutClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }
        
        // does this go when I just switch the toggle? let's see.
        private void ToggleRandom_Checked(object sender, RoutedEventArgs e)
        {
            bool val = App.ViewModel.beRandom;
            App.ViewModel.beRandom = !val;
        }
    }
}
