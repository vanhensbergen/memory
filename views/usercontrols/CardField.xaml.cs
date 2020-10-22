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
        private static readonly ImageBrush BACKGROUND_BRUSH = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/memory;component/img/cardbackground.png", UriKind.RelativeOrAbsolute)));
        private ImageBrush _CardImageBrush;
        public CardField()
        {
            InitializeComponent();
            Theme = "disney";
        }

        private void Initialize()
        {
            SetCardImageBrush();
            ShowStatus(Status);
        }
        private void SetCardImageBrush()
        {
            _CardImageBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/memory;component/img/" + Theme + "/" + CardId + ".jpg", UriKind.RelativeOrAbsolute)));
            
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
            CardStatus status = (CardStatus)e.NewValue;
            ShowStatus(status);

        }

        private void ShowStatus(CardStatus status)
        {
            switch (status)
            {
                case CardStatus.CLOSED:
                    Console.WriteLine("new Value is CLOSED");
                    canvas.Background = BACKGROUND_BRUSH;
                    break;
                case CardStatus.FOUND:
                    Console.WriteLine("new Value is FOUND");
                    break;
                case CardStatus.OPEN:
                    Console.WriteLine("new value is OPEN");
                    canvas.Background = _CardImageBrush;
                    break;
            }
        }

        public int CardId
        {
            get { return (int)GetValue(CardIdProperty); }
            set { SetValue(CardIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CardId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardIdProperty =
            DependencyProperty.Register("CardId", typeof(int), typeof(CardField), new PropertyMetadata(OnCardIdChanged));

        private static void OnCardIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CardField Control = d as CardField;
            Control.SetCardImageBrush();
        }

       
    }
}
