using memory.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;


namespace memory.models
{
    public class MemoryGame:INotifyPropertyChanged
    {
        private const  int DELAY_TIME = 1000;
        private bool _Startable;
        public List<Card> Cards { get; }
        internal List<CardPlayer> Players { get; private set; }
        public MemoryGame()
        {
            Cards = new List<Card>();
            for (int i = 1; i < 25; i++)
            {
                Cards.Add(new Card(i));
                Cards.Add(new Card(i));
            }
            Players = new List<CardPlayer>
            {
                new CardPlayer("player1")
                {
                    IsActive = true
                },
                new CardPlayer("player2")
                {
                    IsActive = false
                }
            };
           // Shuffle();
            Startable = true;
        }

        internal void Start()
        {
            Startable = false;
            OnPropertyChanged("Startable");
            Console.WriteLine("button moet nu disabled worden");
            Cards.ForEach(x => x.Status = CardStatus.CLOSED);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public bool Startable { private set { _Startable = value; OnPropertyChanged("Startable"); } get { return _Startable; } }
        private CardPlayer ActivePlayer
        {
            get { return Players.Find(x => x.IsActive); }
        }

        private void SwapPlayers()
        {
            int k = Players.FindIndex(x=>x==ActivePlayer);
            ActivePlayer.IsActive = false;
            int n = Players.Count;
            Players[(k + 1) % n].IsActive = true;
            Console.WriteLine(ActivePlayer.Name);
        }

        public bool AcceptMove(Card card)
        {
            if (Frozen)
            {
                return false;
            }
            if (Startable) return false;
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
                Task.Delay(DELAY_TIME).ContinueWith(OnDelayEnded);
            }
        }

        public bool GameFinished
        {
            get 
            {
                return Cards.TrueForAll(x => x.Status == CardStatus.FOUND); ;
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
            Frozen = false;
            List<Card> openedCards = Cards.FindAll(x => x.Status == CardStatus.OPEN);
            if (openedCards[0].Equals(openedCards[1]))
            {
                openedCards.ForEach(x => x.Status = CardStatus.FOUND);
                ActivePlayer.AddFoundCards(openedCards);
                bool IsGameFinished = GameFinished;
                if (IsGameFinished)
                {
                    Startable = true;

                    //more todo...
                }
                return;
            }
            openedCards.ForEach(x => x.Status = CardStatus.CLOSED);
            SwapPlayers(); 
        }
        

        public void Shuffle()
        {
            Random rng = new Random();
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int tmp = Cards[k].Id;
                Cards[k].Id = Cards[n].Id;
                Cards[n].Id = tmp;
                
            }
        }
        
    }
}
