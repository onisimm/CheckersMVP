using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersMVP.Models
{
    public class Board
    {
        public ObservableCollection<ObservableCollection<Square>> _Board { get; set; }
        private bool _IsBoardFlipped { get; set; }
        public Board()
        {
            SetupBoard();
        }

        private void SetupBoard()
        {
            UInt16 length = 8;
            UInt16 upper_half = 3;
            UInt16 lower_half = 4;

            _Board = new ObservableCollection<ObservableCollection<Square>>();
            for (int row = 0; row < length; row++)
            {
                _Board.Add(new ObservableCollection<Square>());
                for (int column = 0; column < length; column++)
                {
                    _Board[row].Add(new Square(false));

                    if ((row + column) % 2 != 0)
                    {
                        if (row < upper_half)
                        {
                            _Board[row][column].SetOccupied(true);
                        }
                        else if (row > lower_half)
                        {
                            _Board[row][column].SetOccupied(false);
                        }
                    }
                }
            }
        }

        public void CalculatePossibleMoves(Square piece, bool? isKing = null, bool? isWhiteDirection = null)
        {
            bool isWhite = piece.IsWhite();

            
        }

        public void MovePiece(Square piece, Square destination)
        {
            destination.MakeOccupied(true, piece.IsWhite(), piece.IsKing());
            piece.SetOccupied(false);
        }
    }
}
