using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    /// <summary>
    /// Class permettant d'encapsuler un tableau pour l'interface graphique
    /// </summary>
    public class Taquin : IEnumerable<Cell>
    {
        #region Properties
        public int Size { get; }
        public Board Board { get; private set; }
        #endregion

        #region Construct
        public Taquin(int size) // Le taquin se construit en fonction de sa taille et se rempli automatiquement
        {
            Size = size;
            Populate(size); // Remplissage
            SetMoves(); // Calcul de l'état actuel
        }

        public Taquin(string fileName) // Permet de créer un Taquin depuis un fichier .tqn correctement formatté
        {
            // Lecture du fichier
            string[] lines = File.ReadAllLines(fileName);
            Size = lines[0].Length < 6 ? 3 : 5;
            Cell[,] finalBoard = new Cell[Size, Size];
            int currentLineCount = 0;
            foreach(string l in lines)
            {
                int currentColumn = 0;
                string[] values = l.Split(',');
                foreach(string value in values)
                {
                    Cell cell = new Cell(values[currentColumn]);
                    finalBoard[currentLineCount, currentColumn % Size] = cell;
                    currentColumn++;
                }
                currentLineCount++;
            }
            // On renvoie le tableau 
            Board = new Board(finalBoard);
            Console.WriteLine(Board);
            Board.CalculatePossibleMoves();
        }
        #endregion

        #region Methods
        public void Populate(int size)
        {
           // Can be factorized
            Cell[] cells = new Cell[size*size];
            for(int i = 0; i < (size*size)-2; i++)
            {
                Cell cell = new Cell(i);
                cells[i] = cell;
            }
            cells[cells.Length - 2] = new Cell();
            cells[cells.Length - 1] = new Cell();
            Board = new Board(cells);
        }

        // Calcule tous les mouvements pour chaque cellule du tableau
        public void SetMoves()
        {
            if(Board != null)
            {
                Board.CalculatePossibleMoves();
            }
        }

        // Renvoie la cell du Taquin en position i,j
        public Cell GetCell(int i, int j)
        {
            return Board.Structure[i, j];
        }

        // Bouge une cellule du Taquin
        public void Move(Cell cell)
        {
            if(cell.IsMovable())
            Board.Move(cell, cell.AvailableMoves[0]);
        }

        // Permet de representer le tableau courrant du Taquin en console pour debuguer
        public override string ToString()
        {
            return Board.ToString();
        }
        #endregion

        #region IEnumerable
        public IEnumerator<Cell> GetEnumerator()
        {
            int line = -1;
            for(int i = 0; i < Size*Size; i++)
            {
                if (i % Size == 0) line++;
                yield return Board.Structure[line,i % Size];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
