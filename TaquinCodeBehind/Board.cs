using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class Board : IEnumerable<Cell>
    {
        // Enumeration des quatres mouvements possibles dans le jeu du Taquin
        public enum Neighbours { Up, Down, Left, Right }

        #region Attributes
        private int _size;
        #endregion

        #region Properties
        // La structure contient toutes les cellules du tableau
        public Cell[,] Structure;
        #endregion

        #region Construct
        // Constructeur d'un tableau de taille (size x size)
        public Board(int size)
        {
            _size = size;
            Structure = new Cell[_size, _size];
        }

        // Constructeur d'un tableau à partir d'un tableau de cellules size by size
        public Board(Cell[,] board)
        {
            Structure = board;
            _size = Structure.GetLength(0);
        }

        // Constructeur d'un tableau à partir d'un tableau de cellules size*size
        public Board(Cell[] cells)
        {
            if (cells.Length % 3 == 0) _size = 3;
            if (cells.Length % 5 == 0) _size = 5;
            Structure = new Cell[_size, _size];
            int line = -1; // Modulo Hack
            for(int i = 0; i < _size*_size; i++)
            {
                if (i % _size == 0)
                    line++;
                Structure[line, i % _size] = cells[i];
            }
        }
        #endregion

        #region Methods
        // Methode pour trouver le premier trou dans la grille
        public void FindEmptyOne(out int i, out int j)
        {
            FindCellByValue(out i, out j, "-");
        }

        // Methode pour trouver le second trou dans la grille 
        public void FindEmptyTwo(out int i, out int j)
        {
            i = 0; j = 0;
            // L'astuce est de parcourir le tableau en sens inverse !
            for (int y = _size - 1; y >= 0; y--)
                for (int x = _size - 1; x >= 0; x--)
                {
                    if (Structure[y, x].Value == "-")
                    {
                        i = y; j = x;
                        break;
                    }
                }
        }

        // Methode permettant de trouver les coordonnées de n'importe qu'elle cellule par sa valeur
        public void FindCellByValue(out int i, out int j, string value)
        {
            i = 0; j = 0;
            for (int y = 0; y < _size; y++)
                for (int x = 0; x < _size; x++)
                {
                    if (Structure[y, x].Value == value)
                    {
                        i = y; j = x;
                        break;
                    }
                }
        }

        // Permet de nettoyer les mouvements possible dans le tableau
        public void ClearBoardStatus()
        {
            foreach (Cell cell in Structure) cell.ClearMoves();
        }

        // Permet de calculer tout les mouvement possibles dans le tableau
        public void CalculatePossibleMoves()
        {
            foreach(Cell cell in Structure)
            {
                if(cell.Value != "-") // Un trou ne peu pas bouger
                { 
                    List<Neighbours> neighbours = EvaluateNeighbours(cell); // Si la cellule à des mouvements possible
                    foreach (Neighbours n in neighbours)
                        switch (n)
                        {
                            // On ajoute ces movement à la cellule
                            case Neighbours.Up: cell.SetMoves(Cell.Moves.Up);  break;
                            case Neighbours.Down: cell.SetMoves(Cell.Moves.Down); break;
                            case Neighbours.Left: cell.SetMoves(Cell.Moves.Left); break;
                            case Neighbours.Right: cell.SetMoves(Cell.Moves.Right); break;
                        }
                }
            }
        }

        // Permet de savoir si la cellule peut bouger dans un trou de son voisinage
        public List<Neighbours> EvaluateNeighbours(Cell cell)
        {
            List<Neighbours> neighbours = new List<Neighbours>();
            int i, j;
            FindCellByValue(out i, out j, cell.Value);
            if (i > 0) if(Structure[i - 1, j].Value == "-") neighbours.Add(Neighbours.Up);
            if (i < _size - 1) if (Structure[i + 1, j].Value == "-") neighbours.Add(Neighbours.Down);
            if (j > 0) if (Structure[i, j - 1].Value == "-") neighbours.Add(Neighbours.Left);
            if (j < _size - 1) if (Structure[i, j + 1].Value == "-") neighbours.Add(Neighbours.Right);
            return neighbours;
        }

        // Permet de bouger un cellule donnée dans un sens donnée
        public void Move(Cell cell, Cell.Moves move )
        {
            Cell holder;
            int i, j;
            FindCellByValue(out i, out j, cell.Value);
            switch (move)
            {
                // On écahnge les réference de cellule dans le tableau
                case Cell.Moves.Up:
                    holder = Structure[i - 1, j];
                    Structure[i - 1, j] = cell;
                    Structure[i, j] = holder;
                    break;
                case Cell.Moves.Down:
                    holder = Structure[i + 1, j];
                    Structure[i + 1, j] = cell;
                    Structure[i, j] = holder;
                    break;
                case Cell.Moves.Left:
                    holder = Structure[i, j - 1];
                    Structure[i, j - 1] = cell;
                    Structure[i, j] = holder;
                    break;
                case Cell.Moves.Right:
                    holder = Structure[i, j + 1];
                    Structure[i, j + 1] = cell;
                    Structure[i, j] = holder;
                    break;
            }
            // On supprime les anciens mouvements et on calcule les nouveaux mouvements possible        
            ClearBoardStatus();
            CalculatePossibleMoves();
        }

        // Permet d'afficher le board dans la console pour débuger plus simplement
        public override string ToString()
        {
            string result = "";
            for(int i =0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    result += (Structure[i, j].ToString() + " ");
                }
                result += "\n";
            }
            return result;
        }
        #endregion

        #region IEnumerable
        /// <summary>
        /// Implementation de l'interface IEnumerable permettant de rendre Itérable le tableau
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Cell> GetEnumerator()
        {
            int line = -1;
            for (int i = 0; i < _size * _size; i++)
            {
                if (i % _size == 0) line++;
                yield return Structure[line, i % _size];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
