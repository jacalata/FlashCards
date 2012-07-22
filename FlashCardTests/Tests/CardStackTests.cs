using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlashCardTests.Tests
{
    [TestClass]
    public class CardStackTests : SilverlightTest
    {
        [TestMethod]
        public void AlwaysPass()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void StackExists()
        {
            Assert.IsNotNull(FlashCards.App.ViewModel.Items);
        }

        [TestMethod]
        public void AddCardToStack()
        {
            int count = FlashCards.App.ViewModel.Items.Count;
            FlashCards.ItemViewModel newCard = new FlashCards.ItemViewModel();
            newCard.Answer = "answer";
            newCard.Prompt = "prompt";
            FlashCards.App.ViewModel.Items.Add(newCard);
            int newCount = FlashCards.App.ViewModel.Items.Count;
            Assert.IsTrue(newCount == count + 1);
            FlashCards.App.ViewModel.Items.Remove(newCard);
            newCount = FlashCards.App.ViewModel.Items.Count;
            Assert.IsTrue(newCount == count);
        }

        [TestMethod]
        public void GoToNextCard()
        {
            int count = FlashCards.App.ViewModel.Items.Count;
            FlashCards.ItemViewModel item1 = new FlashCards.ItemViewModel();
            FlashCards.App.ViewModel.Items.Add(item1);
            FlashCards.ItemViewModel item2 = new FlashCards.ItemViewModel();
            FlashCards.App.ViewModel.Items.Add(item2);
            FlashCards.ItemViewModel item3 = new FlashCards.ItemViewModel();
            FlashCards.App.ViewModel.Items.Add(item3);
            int index = FlashCards.App.ViewModel.Items.IndexOf(item1);
            int next = FlashCards.CardOperations.NextCard(index);
            Assert.IsTrue(next == index + 1);
        }
    }
}