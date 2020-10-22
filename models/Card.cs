using memory.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memory.models
{
    public class Card
    {
        public Card(int id)
        {
            Id = id;
            Status = CardStatus.OPEN;
        }

        public int Id { get; set; }

        public CardStatus Status{ get; set; }

        public bool Equals(Card card)
        {
            return this.Id == card.Id;
        }

    }
}
