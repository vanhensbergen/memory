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
        private MemoryGame _Game;

        public MainWindowViewModel()
        {
            _Game = new MemoryGame();
            OpenCardCommand = new RelayCommand(CanOpenCard, OpenCard);
        }

        private bool CanOpenCard(object obj)
        {
            if (obj != null)
            {
                Card card = obj as Card;
                Console.WriteLine("in canOpenCard:" + card.Id);
            }
               
            
            return true;
        }

        private void OpenCard(object obj)
        {
            //throw new NotImplementedException();
        }

        public MemoryGame Game
        {
            get { return _Game; }
        }

        public ICommand OpenCardCommand {set; get;}
    }
}
