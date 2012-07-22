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
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace FlashCards
{
    public partial class DetailsPage : PhoneApplicationPage
    {

        private int index = 0;
        private int prevIndex = -1;
        // Constructor
        public DetailsPage()
        {
            InitializeComponent();
        }

        public DetailsPage(int Index)
        {
            this.index = Index;
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                DataContext = App.ViewModel.Items[index];
            }
        }
        
        private void NewCard_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewCardPage.xaml", UriKind.Relative) );
        }

        private void NextCard_Click(object sender, EventArgs e)
        {
            NextCard();
        }

        private void NextCard()
        {
            prevIndex = index;
            if (App.ViewModel.beRandom)
            {
                index = CardOperations.RandomCard();
            }
            else
            {
                index = CardOperations.NextCard(index);
            }
            DataContext = App.ViewModel.Items[index];
        }

        private void ShowAnswer_Click(object sender, RoutedEventArgs e)
        {
            AnswerText.Visibility = Visibility.Visible;
            ResponseValue.Visibility = Visibility.Visible;
        }

        private void GoodAnswer_Click(object sender, RoutedEventArgs e)
        {
            CardOperations.FlagCard(index, false);
            AnswerText.Visibility = Visibility.Collapsed;
            ResponseValue.Visibility = Visibility.Collapsed;
            NextCard();
        }

        private void BadAnswer_Click(object sender, RoutedEventArgs e)
        {
            CardOperations.FlagCard(index, true);
            AnswerText.Visibility = Visibility.Collapsed;
            ResponseValue.Visibility = Visibility.Collapsed;
            NextCard();
        }

        private void DeleteCard_Click(object sender, EventArgs e)
        {
            index = CardOperations.DeleteCard(index, prevIndex);
            if (index == -1)
                NavigationService.GoBack();
            else
                DataContext = App.ViewModel.Items[index];
        }
    }
}
