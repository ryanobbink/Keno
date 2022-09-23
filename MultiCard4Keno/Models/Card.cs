using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiCard4Keno.Enums;
using MultiCard4Keno.Interfaces;

namespace MultiCard4Keno.Models
{
    //Composition - Must Have a Card on the Board
    public class Card : ICard
    {
        protected int Spots
        {
            get
            {
                return ICard._spots;
            }
        }
        private readonly CardName _name;

        public Card(CardName cardName) => _name = cardName;

        public CardName Name => _name;
        public List<int> Marked { get; set; } = new List<int>();

        public bool CanDraw
        {
            get
            {
                return Marked.Count >= 2 ? true : false;
            }
        }

        public bool Mark(int n)
        {
            //Valid Number
            if (n < 1 && n > 80) return false;

            //Remove Number
            if (Marked.Contains(n))
            {
                Marked.Remove(n);
                return false;
            }

            //Can We Add a Number?
            if (Marked.Count > 10) return false;

            Marked.Add(n);

            return true;
        }
        public void QuickPick()
        {
            Random rand = new Random();
            Marked = Enumerable.Range(1, 80)
                .OrderBy(x => rand.Next())
                .Take(Marked.Count == 0 ? 10 : Marked.Count)
                .ToList();

        }
        public bool Draw()
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }



    }
}
