using memory.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for CardField.xaml
    /// </summary>
    public partial class CardField : UserControl
    {
       
        public CardField()
        {
            InitializeComponent();
            Status = CardStatus.CLOSED;
        }

        public string Theme { get; set; }


        public CardStatus Status
        {
            get { return (CardStatus)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Status.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(CardStatus), typeof(CardField), new PropertyMetadata(OnStatusChanged));

        private static void OnStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CardField card = d as CardField;
            card.OnStatusChanged(e);
        }

        private void OnStatusChanged(DependencyPropertyChangedEventArgs e)
        {
            switch ((CardStatus)e.NewValue)
            {
                case CardStatus.CLOSED:
                    Console.WriteLine("new Value is CLOSED");
                    
                    break;
                case CardStatus.FOUND:
                    Console.WriteLine("new Value is FOUND");
                    break;
                case CardStatus.OPEN:
                    Console.WriteLine("new value is OPEN");
                    break;
            }
        }


    }
}
