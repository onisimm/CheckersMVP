using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersMVP.Models
{
    public class Square
    {
        #region Private Members
        private bool _IsOccupied { get; set; }
        private bool? _IsWhite { get; set; }
        private bool _IsKing { get; set; }
        private UInt16 _Row { get; set; }
        private UInt16 _Column { get; set; }
        private bool _IsHighlighted { get; set; }
        #endregion

        public Square(bool isOccupied, bool? isWhite = true, bool isKing = false)
        {
            this._IsOccupied = isOccupied;

            if (_IsOccupied)
            {
                this._IsWhite = isWhite;
                this._IsKing = isKing;
            }
            else
            {
                this._IsWhite = null;
                this._IsKing = false;
            }
        }

        public Square(Square pieceToCopy)
        {
            this._IsOccupied = pieceToCopy._IsOccupied;
            this._IsWhite = pieceToCopy._IsWhite;
            this._IsKing = pieceToCopy._IsKing;
        }

        #region Getters
        public bool IsOccupied()
        {
            return !_IsOccupied;
        }

        public bool IsKing()
        {
            return _IsKing;
        }

        public bool IsWhite()
        {
            return _IsWhite == true;
        }

        public UInt16 GetRow()
        {
            return _Row;
        }

        public UInt16 GetColumn()
        {
            return _Column;
        }

        public bool IsHighlighted()
        {
            return _IsHighlighted;
        }
        #endregion

        #region Setters

        public void SetOccupied(bool isOccupied = false, bool? isWhite = null) // calling with no arguments will set the square to unoccupied
        {
            _IsOccupied = isOccupied;
            _IsWhite = isWhite;
        }

        public void ToggleKing()
        {
            _IsKing = !_IsKing;
        }

        public void ToggleHighlight()
        {
            _IsHighlighted = !_IsHighlighted;
        }
        #endregion

        public string PieceImage
        {
            get
            {
                if (IsOccupied())
                {
                    return null; // Return null if the square is empty
                }
                else
                {

                    string color = _IsWhite == true ? "white" : "black";
                    string type = _IsKing ? "king" : "piece";

                    string _IMAGES_PATH = Globals.RELATIVE_IMAGES_PATH;
                    return $"{_IMAGES_PATH}/{color}_{type}.png"; // Assuming your images are in a folder named "Images"
                }
            }
        }
    }
}
