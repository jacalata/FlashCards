﻿using System;
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
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }


        private void emailButtonClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Tasks.EmailComposeTask task =
                new Microsoft.Phone.Tasks.EmailComposeTask();
            task.To = "jacalata@live.com";
            task.Subject = "Feedback: FlashCards app";
            task.Show();
        }
    }
}