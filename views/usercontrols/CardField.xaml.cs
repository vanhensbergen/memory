using memory.utils;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace memory.views.usercontrols
{
    /// <summary>
    /// Interaction logic for CardField.xaml
    /// </summary>
    public partial class CardField : UserControl
    {
        private static readonly ImageBrush BACKGROUND_BRUSH = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/memory;component/img/cardbackground.png", UriKind.RelativeOrAbsolute)));
        private ImageBrush FrontImageBrush=null;
        public CardField()
        {
            InitializeComponent();
            Theme = "disney";
        }

        
        private void SetFrontImageBrush()
        {
            FrontImageBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/memory;component/img/" + Theme + "/" + CardId + ".jpg", UriKind.RelativeOrAbsolute)));
        }
        public string Theme { get; set; }


        public CardStatus Status
        {
            get { return (CardStatus)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Status.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(CardStatus), typeof(CardField), new PropertyMetadata(CardStatus.CLOSED,OnStatusChanged));

        private static void OnStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CardField Control = d as CardField;
            Control.OnChange();
        }


        private void Show()
        {
            switch (Status)
            {
                case CardStatus.CLOSED:
                    canvas.Background = BACKGROUND_BRUSH;
                    break;
                case CardStatus.FOUND:
                    SolidColorBrush fillColor = new SolidColorBrush(Colors.Black);
                    canvas.Background = fillColor;
                    break;
                case CardStatus.OPEN:
                   canvas.Background = FrontImageBrush;
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
            DependencyProperty.Register("CardId", typeof(int), typeof(CardField), new PropertyMetadata(-1,OnCardIdChanged));

        private static void OnCardIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CardField Control = d as CardField;
            Control.OnChange();
        }

        public void OnChange()
        {
            if (CardId != -1)
            {
                SetFrontImageBrush();
                Show();
            }
        }


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(CardField), new PropertyMetadata(null));

        public static readonly DependencyProperty CommandParameterProperty =
           DependencyProperty.Register("CommandParameter", typeof(object), typeof(CardField), new PropertyMetadata(null));

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }


    }
}
