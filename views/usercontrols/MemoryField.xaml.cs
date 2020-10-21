using memory.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace memory.views.usercontrols
{
    /// <summary>
    /// Interaction logic for MemoryField.xaml
    /// </summary>
    public partial class MemoryField : UserControl
    {
       
        public MemoryField()
        {
            InitializeComponent();
            Status = CardStatus.CLOSED;
        }

        public string Theme { get; set; }
       
        public CardStatus Status { get; set; }


    }
}
