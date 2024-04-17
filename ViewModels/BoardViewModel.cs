using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CheckersMVP.Models;
using CheckersMVP.Commands;
using static System.Net.WebRequestMethods;


namespace CheckersMVP.ViewModels
{
    public class BoardViewModel : INotifyPropertyChanged
    {
        private string _IMAGES_PATH = Globals.RELATIVE_IMAGES_PATH;

        private BitmapImage _boardImage;
        private Board _board;

        public ICommand SquareClickedCommand { get; }

        public BitmapImage BoardImage
        {
            get { return _boardImage; }
            set
            {
                if (_boardImage != value)
                {
                    _boardImage = value;
                    OnPropertyChanged(nameof(BoardImage));
                }
            }
        }

        public Board Board
        {
            get { return _board; }
            set
            {
                if (_board != value)
                {
                    _board = value;
                    OnPropertyChanged(nameof(Board));
                }
            }
        }

        public BoardViewModel()
        {
            string boardImagePath = Path.Combine(_IMAGES_PATH, "board.jpeg");
            BoardImage = new BitmapImage(new Uri(boardImagePath, UriKind.Absolute));
            Board = new Board();

            SquareClickedCommand = new RelayCommand(OnSquareClicked);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnSquareClicked(object parameter)
        {
            var piece = parameter as Square;
            if (!piece.IsOccupied())
            {
                
            }
        }
    }
}
