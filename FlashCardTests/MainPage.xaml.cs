using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Silverlight.Testing;

namespace FlashCardTests
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_OnLoaded;
        }

        private void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            SystemTray.IsVisible = false;
            // to set ssystem tray viisbility the rootvisual must be a phoneapplicationpage?

            var testPage = (IMobileTestPage)UnitTestSystem.CreateTestPage();
            BackKeyPress += (x, xe) => xe.Cancel = testPage.NavigateBack();
            ((PhoneApplicationFrame)Application.Current.RootVisual).Content = testPage;
        }
    }
}