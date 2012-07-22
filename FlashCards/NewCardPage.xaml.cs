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
    public partial class NewCardPage : PhoneApplicationPage
    {
        public NewCardPage()
        {
            InitializeComponent();
        }

        private void SaveNewCardButton_Click(object sender, RoutedEventArgs e)
        {
            ItemViewModel newItem = new ItemViewModel();
            newItem.Answer = textAnswer.Text;
            newItem.Title = textTitle.Text;
            newItem.Prompt = textPrompt.Text;
            newItem.Flag = true;
            App.ViewModel.Items.Add(newItem);

            NavigationService.GoBack();
        }
    }
}