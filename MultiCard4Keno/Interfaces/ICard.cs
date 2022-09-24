using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiCard4Keno.Enums;

namespace MultiCard4Keno.Interfaces
{
    public interface ICard
    {
        public const int _spots = 80;
        public bool CanDraw { get; }

        public CardName Name { get; }
        public List<int> Marked { get; set; }
        public List<int> Drawn { get; }

        public bool Mark(int n);
        public void QuickPick();
        public bool Draw();
        public void Clear();
    }
}   
