using memory.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace memory.models
{
    public class MemoryGame : INotifyPropertyChanged
    {

        public MemoryGame()
        {
            Cards = new List<Card>();
            for (int i = 1; i < 25; i++)
            {
                Cards.Add(new Card(i));
                Cards.Add(new Card(i));
            }
            //Shuffle();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public bool AcceptMove(Card card)
        {
            if (Frozen)
            {
                return false;
            }
            if (OpenCardCount == 2)
            {
                return false;
            }
            if (card.Status != CardStatus.CLOSED)
            {
                return false;
            }
            return true;
        }

        private bool Frozen { get; set; }
        public void DoMove(Card card)
        {
            card.Status = CardStatus.OPEN;
            if (OpenCardCount == 2)
            {
                Frozen = true;
                Task.Delay(3000).ContinueWith(OnDelayEnded);
            }
        }



        private int OpenCardCount {
            get
            {
                return Cards.FindAll(x => x.Status == CardStatus.OPEN).Count;
            }
        }

        private void OnDelayEnded(Task obj)
        {
            List<Card> openedCards = Cards.FindAll(x => x.Status == CardStatus.OPEN);
            if (openedCards[0].Equals(openedCards[1]))
            {
                openedCards.ForEach(x => x.Status = CardStatus.FOUND);
            }
            Cards.ForEach(x =>
            {
                if (x.Status != CardStatus.FOUND)
                {
                    x.Status = CardStatus.CLOSED;
                }
            });
               
            Frozen = false;
        }
        public List<Card> Cards { get; }

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
