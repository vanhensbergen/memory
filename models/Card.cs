using memory.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memory.models
{
    public class Card:INotifyPropertyChanged
    {
        public Card(int id)
        {
            Id = id;
            Status = CardStatus.CLOSED;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        public int Id { get; set; }

        public CardStatus Status{ get; set; }

        public bool Equals(Card card)
        {
            return this.Id == card.Id;
        }

    }
}
