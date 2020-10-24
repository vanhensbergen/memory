using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using memory.commands;
using memory.models;

namespace memory.viewmodels
{
    class MainWindowViewModel
    {
        private readonly MemoryGame _Game;

        public MainWindowViewModel()
        {
            _Game = new MemoryGame();
            OpenCardCommand = new RelayCommand(CanOpenCard, DoOpenCard);
            StartCommand = new RelayCommand(CanStart, DoStart);

        }

        private bool CanStart(object obj)
        {
            // return Game.Startable;
            return true;
        }

        private void DoStart(object obj)
        {
            Game.Start();
        }

        private bool CanOpenCard(object obj)
        {
            if (obj != null)
            {
                Card card = obj as Card;
                return Game.AcceptMove(card);
            }
            return false; 
            
            
        }
        public ICommand StartCommand { set; get; }
      
        private void DoOpenCard(object obj)
        {
            Card card = obj as Card;
            Game.DoMove(card);
        }
        
        public MemoryGame Game
        {
            get { return _Game; }
        }

        public ICommand OpenCardCommand {set; get;}
    }
}
