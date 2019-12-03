using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public abstract class Solver
    {
        #region Attributes
        // Liste des ouverts 
        protected List<EvaluableBoard> _openSet = new List<EvaluableBoard>();
        // Liste des fermés contient les noeuds déjà évalués
        protected List<EvaluableBoard> _closedSet = new List<EvaluableBoard>();
        public int openCount;
        public int closedCount;
        #endregion

        #region Properties
        public IHeuristic Heuristic { get; set; } // L'algorithme de résolution à besoin d'une estimation du coup
        #endregion

        #region AbstractsToOverride
        /// <summary>
        /// La fonction ou s'implémente l'algorithme de résolution choisi
        /// </summary>
        /// <param name="board"> tableau cible à résoudre </param>
        /// <returns></returns>
        public abstract List<Board> Solve(EvaluableBoard board);
        #endregion

        #region Methods
        // Methode permettant de récupérer le chemin de résolution
        public List<Board> Unpile(EvaluableBoard board)
        {
            List<Board> result = new List<Board>();
            while (board != null)
            {
                result.Add(board.Board);
                //Console.WriteLine(board.Board);
                board = board.Previous;
            }
            return result;
        }

        // Méthode permettant de dupliquer un board en rompant 
        // les effet de bord dus au type référence des tableaux
        public static EvaluableBoard CopyBoard(EvaluableBoard board)
        {
            EvaluableBoard result = new EvaluableBoard(board.Score);
            Cell[,] structure = new Cell[board.Size,board.Size];
            // On replace au bon endroit toute les cellules
            foreach(Cell cell in board)
            {
                Cell newCell = new Cell(cell.Value);
                int posI, posJ;
                board.Board.FindCellByValue(out posI,out posJ, cell.Value);
                structure[posI, posJ] = newCell;
            }
            // On s'occupe de replaer les trous
            Cell emptyOne = new Cell("-");
            Cell emptyTwo = new Cell("-");
            int e1i, e1j, e2i, e2j;
            board.Board.FindEmptyOne(out e1i, out e1j);
            board.Board.FindEmptyTwo(out e2i, out e2j);
            structure[e1i, e1j] = emptyOne;
            structure[e2i, e2j] = emptyTwo;
            // On créer le duplicata
            result.Board = new Board(structure);
            result.Size = result.Board.Structure.GetLength(0);
            return result;
        }

        /// <summary>
        /// Méthode retournant les voisins d'un état spécifique
        /// </summary>
        public static List<EvaluableBoard> CreateChild(EvaluableBoard board)
        {
            List<EvaluableBoard> neighbours = new List<EvaluableBoard>();
            // On regarde si les cellules peuvent bouger
            foreach(Cell cell in board)
            {
                int i, j;
                board.Board.FindCellByValue(out i, out j, cell.Value);
                if (cell.IsMovable())
                {
                    // Pour chaque mouvement possible, on crée un tableau ou on effectue le mouvement
                    foreach(Cell.Moves move in cell.AvailableMoves)
                    {
                        EvaluableBoard neighbour = CopyBoard(board);
                        neighbour.Cost = board.Cost;
                        neighbour.Board.Move(neighbour.Board.Structure[i,j], move);
                        neighbour.Previous = board;
                        neighbours.Add(neighbour);
                    }
                }
            }
            return neighbours;
        }


        public bool FindPast(EvaluableBoard board)
        {
            bool result = false;
            foreach(EvaluableBoard oldBoard in _closedSet)
                if (oldBoard.Equals(board)) result = true;
            return result;
        }

        public bool FindBest(EvaluableBoard board)
        {
            bool result = false;
            foreach (EvaluableBoard currentBoard in _openSet)
            {
                if (board.Equals(currentBoard) && currentBoard.Cost <= board.Cost) result = true;
                else if(board.Equals(currentBoard) && currentBoard.Cost > board.Cost) { currentBoard.Cost = board.Cost; }
            }
            return result;
        }
        #endregion
    }
}
