using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace memory.models
{
    class CardPlayer
    {

        public CardPlayer(string name)
        {
            Name = name;
            FoundCards = new ObservableCollection<Card>();
        }

        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ObservableCollection<Card> FoundCards { get; private set; }
        
        public void AddFoundCards(List<Card> cards)
        {
            foreach(Card card in cards)
            {
                FoundCards.Add(card);
            }
            
        }

        public void Reset()
        {
            FoundCards.Clear();
        }
    }
}
