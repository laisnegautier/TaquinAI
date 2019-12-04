using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class Cell
    {
        // ensemble de toutes les valeurs possible pour un objet cellule
        string[] POSSIBLES_VALUES = new string[]{"-1","0","1","2","3","4","5","6","7","8","9","10","11","12","13","14",
                                               "15","16","17","18","19","20","21","22","23","-"};
        // Liste des mouvement possible pour une cellule
        public enum Moves { Up, Down, Left, Right }

        #region Attributes
        private string _value; // Valeur de l'objet
        #endregion

        #region Properties
        public string Value
        {
            get { return _value; }
            set
            {
                // Avant d'assigner la valeur on regarde si c'est une valeur valide
                if (POSSIBLES_VALUES.Contains(value)) _value = value;
            }
        }
        // Liste des mouvements possibles pour une cellule dans sa position
        public List<Moves> AvailableMoves { get; private set; } = new List<Moves>();
        #endregion

        #region Construct
        // La cellule par défaut est un trou
        public Cell() { Value = "-"; }

        // On peut lui passer une chaine de catactère
        public Cell(string value) { Value = value; }

        // Ou un entier
        public Cell(int value) { Value = value.ToString(); }
        #endregion

        #region Methods
        // Ajoute un mouvement à la liste des mouvements possible
        public void SetMoves(Moves move)
        {
            AvailableMoves.Add(move);
        }

        // Ajoute une liste de mouvements aux mouvement possible
        public void SetMoves(Moves[] move)
        {
            foreach (Moves m in move) AvailableMoves.Add(m);
        }

        // Renvoie true si la cellule peut bouger
        public bool IsMovable()
        {
            if (AvailableMoves.Count > 0) return true;
            else return false;
        }

        // Vide les mouvements possible de la cellule
        public void ClearMoves()
        {
            AvailableMoves = new List<Moves>();
        }
        
        public override string ToString()
        {
            return Value;
        }
        #endregion
    }
}
