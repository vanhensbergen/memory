using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using memory.models;

namespace memory.viewmodels
{
    class MainWindowViewModel
    {
        private MemoryGame _Game;

        public MainWindowViewModel()
        {
            _Game = new MemoryGame();
        }

        public MemoryGame Game
        {
            get { return _Game; }
            set { _Game = value; }
        }
    }
}
