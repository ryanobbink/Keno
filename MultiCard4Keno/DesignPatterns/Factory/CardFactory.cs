using MultiCard4Keno.Enums;
using MultiCard4Keno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCard4Keno.Factory
{
    public class CardFactory
    {
        public static Card Create(CardName name)
        {
            return new Card(name);
        }

        public static Card[] Create(CardName[] names)
        {
            Card[] cards = new Card[names.Length];
            foreach(CardName name in names){
                Card card = Create(name);
            }

            return cards;
        }
    }
}
