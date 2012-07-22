using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace FlashCards
{
    public static class CardOperations
    {

        private static int index = -1;
        private static Random rand;
        private static int max = 0;
        
        public static int RandomCard()
        {
            max = App.ViewModel.Items.Count;
            if (max == 0)
            {
                return -1;
            }
            rand = new Random();
            index = rand.Next(0, max);
            if (!App.ViewModel.Items[index].Flag)
            {
               index = rand.Next(0, max); //increase the chance of hitting a flagged card
            }
            return index;
        }

        public static void FlagCard(int index)
        {
            FlagCard(index, true);
        }

        public static void FlagCard(int index, bool value)
        {
            App.ViewModel.Items[index].Flag = value;
        }

        public static int NextCard(int index)
        {
            index++;
            if (index >= App.ViewModel.Items.Count)
                index = 0; // wrap around

            return index;
        }

        // returns -1 if it deletes the last card in the list
        public static int DeleteCard(int index, int prevIndex)
        {
            // If selected index is -1 (no selection) do nothing
            if (index == -1)
                return index;
                        
            App.ViewModel.Items.RemoveAt(index);

            // we just deleted the last item in the list - uhoh
            if (App.ViewModel.Items.Count == 0)
                return -1;

            // if we've been moving through the cards, go back to the most recent one
            if ( (prevIndex != -1) && (prevIndex < App.ViewModel.Items.Count) )
                return prevIndex;
            
            // if this was the first card we looked at, just go to the first card in the set
            return 0;
        }
    }
}
