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
    public class MemoryGame:INotifyPropertyChanged
    {
        public MemoryGame()
        {
            Cards = new List<Card>();
            for(int i=1; i<25; i++)
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
