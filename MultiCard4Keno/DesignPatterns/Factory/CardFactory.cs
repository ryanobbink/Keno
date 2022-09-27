using Keno.Core.Enums;
using Keno.Core.Interfaces;
using Keno.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keno.Core.Factory
{
    public class CardFactory
    {
        public static ICard Create(CardName name)
        {
            return new Card(name);
        }

        public static ICard[] Create(CardName[] names)
        {
            Card[] cards = new Card[names.Length];
            foreach(CardName name in names){
                ICard card = Create(name);
            }

            return cards;
        }
    }
}
