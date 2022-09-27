using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keno.Core.Enums;
using Keno.Core.Interfaces;

namespace Keno.Core.Models
{
    //Composition - Must Have a Card on the Board
    public class Card : ICard
    {
        private List<int> _marked = new List<int>();
        private List<int> _drawn = new List<int>();
        protected int Spots
        {
            get => ICard._spots;
        }



        private readonly CardName _name;
        public CardName Name => _name;

        public List<int> Marked
        {
            get => _marked;
            set => _marked = value;
        }

        public List<int> Drawn
        {
            get => _drawn;
            set => _drawn = value;
        }

        public Card(CardName cardName) => _name = cardName;

        public bool CanDraw
        {
            get
            {
                return Marked.Count >= 2 ? true : false;
            }
        }

        public bool Win { get => throw new NotImplementedException(); }

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
            if (Marked.Count >= 10) return false;

            Marked.Add(n);

            return true;
        }
        public void QuickPick()
        {
            //TODO Sort Marked List
            Random rand = new Random();
            Marked = Enumerable.Range(1, 80)
                .OrderBy(x => rand.Next())
                .Take(Marked.Count == 0 ? 10 : Marked.Count)
                .OrderBy(x => x)
                .ToList();
        }
        public bool Draw()
        {
            Drawn.Clear();
            if(!CanDraw) return false;

            Random rand = new Random();
            Drawn = Enumerable.Range(1, 80)
                .OrderBy(x => rand.Next())
                .Take(20)
                .OrderBy(x => x)
                .ToList();

            return true;
        }
        public void Clear()
        {
            Marked.Clear();
        }
    }
}
