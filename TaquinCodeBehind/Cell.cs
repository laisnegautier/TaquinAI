using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class Cell
    {
        string[] POSSIBLES_VALUES = new string[]{"-1","0","1","2","3","4","5","6","7","8","9","10","11","12","13","14",
                                               "15","16","17","18","19","20","21","22","23","-"};
        public enum Moves { Up, Down, Left, Right }


        #region Attributes
        private List<Moves> _availableMoves = new List<Moves>();
        private string _value;
        #endregion

        #region Properties
        public string Value
        {
            get { return _value; }
            set
            {
                if (POSSIBLES_VALUES.Contains(value)) _value = value;
            }
        }
        public List<Moves> AvailableMoves { get { return _availableMoves; } }
        #endregion

        #region Construct
        public Cell() { Value = "-"; }

        public Cell(string value) { Value = value; }

        public Cell(int value) { Value = value.ToString(); }
        #endregion

        #region Methods
        public void SetMoves(Moves move)
        {
            _availableMoves.Add(move);
        }
        public void SetMoves(Moves[] move)
        {
            foreach (Moves m in move) _availableMoves.Add(m);
        }
        public bool IsMovable()
        {
            if (AvailableMoves.Count > 0) return true;
            else return false;
        }
        public void ClearMoves()
        {
            _availableMoves = new List<Moves>();
        }

        public override string ToString()
        {
            return Value;
        }
        #endregion
    }
}
