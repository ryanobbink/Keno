using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiCard4Keno.Models;
using MultiCard4Keno.Enums;
using System.Collections;
using System.Collections.Generic;
using MultiCard4Keno.Factory;
using System.Diagnostics;

namespace MultCard4KenoTest
{
    [TestClass]
    public class CardUnitTest
    {
        [TestMethod]
        public void Card_Create_1CardKeno_True()
        {
            Card card = CardFactory.Create(CardName.CardA);
            Assert.AreEqual(CardName.CardA, card.Name);
        }

        [TestMethod]
        public void Card_Create_4CardKeno_True()
        {
            CardName[] cardstr = { CardName.CardA, CardName.CardB, CardName.CardC, CardName.CardD };
            Card[] cards = CardFactory.Create(cardstr);

            Assert.AreEqual(4, cards.Length);
        }

        [TestMethod]
        public void Card_Mark_2DifferentSpots_Tests()
        {
            Card card = CardFactory.Create(CardName.CardA);

            Assert.IsTrue(card.Mark(1));
            Assert.IsTrue(card.Mark(2));
            Assert.AreEqual(1, card.Marked.Find(x => x == 1));
            Assert.AreEqual(2, card.Marked.Find(x => x == 2));
        }

        [TestMethod]
        public void Card_Mark_2SameSpots_CardRemoveTest()
        {
            Card card = CardFactory.Create(CardName.CardA);
            Assert.IsTrue(card.Mark(18));
            Assert.IsFalse(card.Mark(18));

            Assert.AreNotEqual(18, card.Marked.Find(x => x == 18));
            Assert.AreEqual(0, card.Marked.Count);
        }
        [TestMethod]
        public void Card_QuickPick_NoSpotsMarked_10Spots()
        {
            Card card = CardFactory.Create(CardName.CardA);
            //No Marks

            card.QuickPick();
            Assert.AreEqual(10, card.Marked.Count);
        }

        [TestMethod]
        public void Card_QuickPick_NoDuplicates_10Spots_1000Tests()
        {
            const int runTests = 1000;
            var card = CardFactory.Create(CardName.CardA);
            card.QuickPick();
            for(int i = 0; i < runTests; i++)
            {
                var duplicateSpots = card.Marked
                            .GroupBy(x => x)
                            .Where(x => x.Count() > 1)
                            .Select(x => x.Key);
                Assert.AreEqual(0, duplicateSpots.Count());
            }
        }

        [TestMethod]
        public void Card_QuickPick_2SpotsMarked_2Spots()
        {
            var card = CardFactory.Create(CardName.CardA);
            card.Mark(52);
            card.Mark(43);

            card.QuickPick();
            Assert.AreEqual(2, card.Marked.Count);
        }

        [TestMethod]
        public void Card_QuickPick_5SpotMarked_5Spots()
        {
            var card = CardFactory.Create(CardName.CardC);
            card.Mark(8);
            card.Mark(17);
            card.Mark(19);
            card.Mark(28);
            card.Mark(38);

            card.QuickPick();
            Assert.AreEqual(5, card.Marked.Count);
        }
        [TestMethod]
        public void Card_QuickPick_4Cards_2SpotsMarkedCardA()
        {
            CardName[] cardstr = { CardName.CardA, CardName.CardB, CardName.CardC, CardName.CardD };
            Card[] cards = CardFactory.Create(cardstr);

            //Card A has Two Marked Spots
            cards.Where(x => x.Name == CardName.CardA).First().Mark(18);
            cards.Where(x => x.Name == CardName.CardA).First().Mark(13);

            cards[0].QuickPick();
            cards[1].QuickPick();
            cards[2].QuickPick();
            cards[3].QuickPick();

            Assert.AreEqual(2, cards[0].Marked.Count);
            Assert.AreEqual(2, cards[1].Marked.Count);
            Assert.AreEqual(2, cards[2].Marked.Count);
            Assert.AreEqual(2, cards[3].Marked.Count);
        }

        [TestMethod]
        public void Card_QuickPick_10Spot()
        {

        }

        [TestMethod]
        public void Card_QuickPick_Default()
        {

        }
    }
}