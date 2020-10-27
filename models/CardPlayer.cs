using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace memory.models
{
    public class CardPlayer
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
                Card copy = Card.CreateCopy(card);
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => FoundCards.Add(copy)));
            }
            
        }

        public void Reset()
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => FoundCards.Clear()));
        }
    }
}
