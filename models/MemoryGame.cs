using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memory.models
{
    public class MemoryGame
    {
        private List<Card> _Cards;
        public MemoryGame()
        {
            _Cards = new List<Card>();
            for(int i=1; i<25; i++)
            {
                _Cards.Add(new Card(i));
                _Cards.Add(new Card(i));
            }
        }
        public List<Card> Cards
        {
            get { return _Cards; }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card tmp = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = tmp;

            }
        }
    }
}
