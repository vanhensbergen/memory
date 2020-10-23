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
        private int _Id;
        private CardStatus _Status;
        public Card(int id)
        {
            _Id = id;
            Status = CardStatus.CLOSED;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        
        

        public int Id
        {
            get { return _Id; }
            set { _Id = value; OnPropertyChanged("Id"); }
        }

        public CardStatus Status
        {
            get { return _Status; }
            set { _Status = value; OnPropertyChanged("Status"); }
        }

        public bool Equals(Card card)
        {
            return this.Id == card.Id;
        }

    }
}
