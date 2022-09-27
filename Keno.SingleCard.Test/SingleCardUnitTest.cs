using Microsoft.VisualStudio.TestTools.UnitTesting;
using Keno.Core.Enums;
using Keno.Core.Factory;
using Keno.Core.Interfaces;

namespace Keno.SingleCard.Test
{
    [TestClass]
    public class SingleCardUnitTest
    {
        [TestMethod]
        public void Card_Create_1CardKeno_True()
        {
            ICard card = CardFactory.Create(CardName.CardA);
            Assert.AreEqual(CardName.CardA, card.Name);
        }

        [TestMethod]
        public void Card_Mark_2DifferentSpots_Tests()
        {
            ICard card = CardFactory.Create(CardName.CardA);

            Assert.IsTrue(card.Mark(1));
            Assert.IsTrue(card.Mark(2));
            Assert.AreEqual(1, card.Marked.Find(x => x == 1));
            Assert.AreEqual(2, card.Marked.Find(x => x == 2));
        }

        [TestMethod]
        public void Card_Mark_2SameSpots_CardRemoveTest()
        {
            ICard card = CardFactory.Create(CardName.CardA);
            Assert.IsTrue(card.Mark(18));
            Assert.IsFalse(card.Mark(18));

            Assert.AreNotEqual(18, card.Marked.Find(x => x == 18));
            Assert.AreEqual(0, card.Marked.Count);
        }
        [TestMethod]
        public void Card_Mark_10Spots_TryAdd1More()
        {
            ICard card = CardFactory.Create(CardName.CardA);
            Assert.IsTrue(card.Mark(1));
            Assert.IsTrue(card.Mark(2));
            Assert.IsTrue(card.Mark(3));
            Assert.IsTrue(card.Mark(4));
            Assert.IsTrue(card.Mark(5));
            Assert.IsTrue(card.Mark(6));
            Assert.IsTrue(card.Mark(7));
            Assert.IsTrue(card.Mark(8));
            Assert.IsTrue(card.Mark(9));
            Assert.IsTrue(card.Mark(10));

            //No more spots allowed
            Assert.IsFalse(card.Mark(11));
        }
        [TestMethod]
        public void Card_QuickPick_NoSpotsMarked_10Spots()
        {
            ICard card = CardFactory.Create(CardName.CardA);
            //No Marks

            card.QuickPick();
            Assert.AreEqual(10, card.Marked.Count);
        }

        [TestMethod]
        public void Card_QuickPick_NoDuplicates_10Spots_1000Tests()
        {
            const int runTests = 1000;
            ICard card = CardFactory.Create(CardName.CardA);
            card.QuickPick();
            for (int i = 0; i < runTests; i++)
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
            ICard card = CardFactory.Create(CardName.CardA);
            card.Mark(52);
            card.Mark(43);

            card.QuickPick();
            Assert.AreEqual(2, card.Marked.Count);
        }

        [TestMethod]
        public void Card_QuickPick_5SpotMarked_5Spots()
        {
            ICard card = CardFactory.Create(CardName.CardC);
            card.Mark(8);
            card.Mark(17);
            card.Mark(19);
            card.Mark(28);
            card.Mark(38);

            card.QuickPick();
            Assert.AreEqual(5, card.Marked.Count);
        }

        [TestMethod]
        public void Card_QuickPick_10Spot()
        {

        }
        [TestMethod]
        public void Card_QuickPick_Default()
        {

        }

        [TestMethod]
        public void Card_Draw_NoSpotsSelected()
        {
            ICard card = CardFactory.Create(CardName.CardA);

            Assert.IsFalse(card.Draw());
        }

        [TestMethod]
        public void Card_Draw_1SpotSelected()
        {
            ICard card = CardFactory.Create(CardName.CardA);
            card.Mark(35);

            Assert.IsFalse(card.Draw());
        }


        [TestMethod]
        public void Card_Draw_2SpotSelected()
        {
            ICard card = CardFactory.Create(CardName.CardA);
            card.Mark(34);
            card.Mark(36);


            Assert.IsTrue(card.Draw());
            Assert.AreEqual(20, card.Drawn.Count);
        }

        [TestMethod]
        public void Card_Draw_QuickPick_10Spots()
        {
            ICard card = CardFactory.Create(CardName.CardC);
            card.QuickPick();
            card.Draw();

            Assert.AreEqual(10, card.Marked.Count);
            Assert.AreEqual(20, card.Drawn.Count);
        }

        [TestMethod]
        public void Card_Win_10SpotMarkandDraw()
        {
            ICard card = CardFactory.Create(CardName.CardA);

            card.QuickPick();
            card.Draw();

            if (!card.Win)
            {
                card.Draw();
            }

            Assert.AreEqual(true, card.Drawn.Contains(card.Marked[11]));
        }

        [TestMethod]
        public void Card_Clear_RemoveSpots()
        {
            ICard card = CardFactory.Create(CardName.CardA);
            card.Mark(18);
            card.Clear();

            Assert.AreEqual(0, card.Marked.Count);
        }
    }
}