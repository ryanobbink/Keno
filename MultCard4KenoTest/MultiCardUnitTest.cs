using Microsoft.VisualStudio.TestTools.UnitTesting;
using Keno.Core.Models;
using Keno.Core.Enums;
using System.Collections;
using System.Collections.Generic;
using Keno.Core.Factory;
using System.Diagnostics;
using Keno.Core.Interfaces;

namespace Keno.MultiCard4.Test
{
    [TestClass]
    public class MultiCardUnitTest
    {
        [TestMethod]
        public void Card_Create_4CardKeno_True()
        {
            CardName[] cardstr = { CardName.CardA, CardName.CardB, CardName.CardC, CardName.CardD };
            ICard[] cards = CardFactory.Create(cardstr);

            Assert.AreEqual(4, cards.Length);
        }

        [TestMethod]
        public void Card_QuickPick_4Cards_2SpotsMarkedCardA_MarkAllCards2Spot()
        {
            CardName[] cardstr = { CardName.CardA, CardName.CardB, CardName.CardC, CardName.CardD };
            ICard[] cards = CardFactory.Create(cardstr);

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
    }
}