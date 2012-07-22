using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace FlashCards
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private string title;
        private string prompt;
        private string answer;
        private bool flag;

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value != title)
                {
                    title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }


        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Prompt
        {
            get
            {
                return prompt;
            }
            set
            {
                if (value != prompt)
                {
                    prompt = value;
                    NotifyPropertyChanged("Prompt");
                }
            }
        }

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Answer
        {
            get
            {
                return answer;
            }
            set
            {
                if (value != answer)
                {
                    answer = value;
                    NotifyPropertyChanged("Answer");
                }
            }
        }


        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public bool Flag
        {
            get
            {
                return flag;
            }
            set
            {
                if (value != flag)
                {
                    flag = value;
                    NotifyPropertyChanged("Flag");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
