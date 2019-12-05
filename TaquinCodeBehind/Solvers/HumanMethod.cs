using System;
using System.Collections.Generic;
using System.Linq;

namespace TaquinCodeBehind
{
    /// <summary>
    /// Class implémentant la méthode de résolution humaine
    /// </summary>
    public class Segments : AstarUni
    {
        #region Properties
        int Size { get; set; }
        #endregion

        #region Construct
        public Segments(IHeuristic heuristic): base(heuristic){}
        #endregion

        #region Methods
        // Fonction de résolution intermédiaire qui applique A* entre deux états quelconques
        EvaluableBoard UnderStep(int rank)
        {
            _destination = new EvaluableBoard(CreateStep(Size, rank));
            while (_openSet.Count > 0)
            {
                _currentBoard = _openSet[0];
                if (_currentBoard.Equals(_destination))
                {
                    closedCount += _closedSet.Count;
                    openCount += _openSet.Count;
                    // Si on est à la dernière étape, on renvoit le résultat
                    if (rank == Size * Size - 3)
                    {
                        return _currentBoard;
                    }
                    // Sinon on nettoie le solver pour la prochaine étape 
                    else
                    {
                        _openSet = new List<EvaluableBoard>();
                        _closedSet = new List<EvaluableBoard>();
                        _currentBoard.Cost = 0;
                        _currentBoard.Score = 0;
                        _openSet.Add(_currentBoard);
                        return _currentBoard;
                    }
                }
                List<EvaluableBoard> holder = CreateChild(_currentBoard, rank);
                foreach (EvaluableBoard testBoard in holder)
                {
                    if (FindPast(testBoard) || FindBest(testBoard)) { }
                    else
                    {
                        testBoard.Cost += 1;
                        // Evaluation d'une heuristique humaine spécifique
                        int thisHumanHeuri = Eval(testBoard, rank);
                        testBoard.Score = testBoard.Cost + thisHumanHeuri;
                        _openSet.Add(testBoard);
                    }
                }
                _closedSet.Add(_currentBoard);
                _openSet.Remove(_currentBoard);
                _openSet = _openSet.OrderBy(b => b.Score).ToList();
            }
            return null;
        }

        // Boucle de résoution
        public override List<Board> Solve(EvaluableBoard board)
        {
            // Etape d'initialisation
            _openSet = new List<EvaluableBoard>();
            _closedSet = new List<EvaluableBoard>();
            Size = board.Board.Structure.GetLength(0);
            _openSet.Add(board);
            EvaluableBoard result;
            // Boucle de résolution en ligne
            for (int rank = 0; rank < (Size * Size) - Size * 2; rank++)
            {
                _currentBoard = UnderStep(rank);
            }
            bool lineOne = true;
            int start = Size * Size - Size * 2;
            // Ensuite on place les deux dernières ligne par colonnes
            for (int rank = start; rank < start + Size; rank++)
            {
                _currentBoard = UnderStep(rank);
                int step = rank + Size;
                if (step < Size * Size - 2)
                {
                    _currentBoard = UnderStep(step);
                }
            }
            return Unpile(_currentBoard);
        }

        // Evaluation de l'heuristique humaine
        private int Eval(EvaluableBoard board, int step)
        {
            int score = 0;
            int optI, optJ, currI, currJ;
            if(step < (Size * Size) - Size * 2)
                for(int i = 0; i < step; i++)
                {
                    // Recherche de la position optimale
                    Functions.pos2coord(out optI, out optJ, i, Size);
                    // Recherche de la position courante
                    board.Board.FindCellByValue(out currI, out currJ, Convert.ToString(i));
                    // Prise ne compte de la distance case destination
                    score += 20 * (Math.Abs(optI - currI) + Math.Abs(optJ - currJ));
                }
            else {
                for (int i = 0; i < (Size * Size) - Size * 2; i++)
                {
                    // Recherche de la position optimale
                    Functions.pos2coord(out optI, out optJ, i, Size);
                    // Recherche de la position courante
                    board.Board.FindCellByValue(out currI, out currJ, Convert.ToString(i));
                    // Prise ne compte de la distance case destination
                    score += 20 * (Math.Abs(optI - currI) + Math.Abs(optJ - currJ));
                }
            }
            // Prise en compte de la case courante a placer
            Functions.pos2coord(out optI, out optJ, step, Size);
            board.Board.FindCellByValue(out currI, out currJ, Convert.ToString(step));
            score += 8 * (Math.Abs(optI - currI) + Math.Abs(optJ - currJ));

            // Recherche des trous
            int hole1I, hole1J, hole2I, hole2J;
            board.Board.FindEmptyOne(out hole1I, out hole1J);
            board.Board.FindEmptyTwo(out hole2I, out hole2J);
            
            // Prise en compte de la distance trou case à placer
            score += 3 * ( Math.Abs(hole1I - currI) + Math.Abs(hole1J - currJ));
            score += 3 * ( Math.Abs(hole2I - currI) + Math.Abs(hole2J - currJ));
            
            
            // Prise en compte de la distance trou destination
            int distH1 = Math.Abs(optI - hole1I) + Math.Abs(optJ - hole1J);
            int distH2 = Math.Abs(optI - hole2I) + Math.Abs(optJ - hole2J);

            //score += 5 * distH1;
            //score += 5 * distH2;
            score += 5 * Math.Min(distH1, distH2);
            return score;
        }

        // Fonction permettant de créer un tableau intermédiaire
        private Board CreateStep(int size, int rank)
        {
            Board board;
            List<Cell> structure = new List<Cell>();
            // Création classique pour les premières lignes
            if (rank < size * size - size * 2)
            {
                for (int i = 0; i <= rank; i++)
                {

                    Cell cell = new Cell(i);
                    structure.Add(cell);
                }
                for (int i = rank; i < (size * size - 2) - 1; i++)
                {
                    Cell empty = new Cell(-1);
                    structure.Add(empty);
                }
                for (int i = 0; i < 2; i++)
                {
                    Cell hole = new Cell("-");
                    structure.Add(hole);
                }
                board = new Board(structure.ToArray());
            }
            // Ensuite on créer en colonnes les tableaux
            else
            {
                // On rempli les première lignes normalement
                List<int> values;
                for (int i = 0; i <= Size * Size - Size * 2; i++)
                {
                    Cell cell = new Cell(i);
                    structure.Add(cell);
                }
                for (int i = Size * Size - Size * 2; i < (size * size - 2) - 1; i++)
                {
                    Cell empty = new Cell(-1);
                    structure.Add(empty);
                }
                for (int i = 0; i < 2; i++)
                {
                    Cell hole = new Cell("-");
                    structure.Add(hole);
                }
                board = new Board(structure.ToArray());
                int index = 0;
                // Ensuite on diférencie 3x3
                if (Size == 3)
                {
                    values = new List<int>() { 3, 6, 4, 5 };
                    while (values[index] != rank)
                    {
                        int posI, posJ;
                        Functions.pos2coord(out posI, out posJ, values[index], Size);
                        board.Structure[posI, posJ] = new Cell(values[index]);
                        index++;
                    }
                }
                // des Taquin 5x5
                else
                {
                    values = new List<int>() { 15, 20, 16, 21, 17, 22, 18, 19 };
                    while (values[index] != rank)
                    {
                        int posI, posJ;
                        Functions.pos2coord(out posI, out posJ, values[index], Size);
                        board.Structure[posI, posJ] = new Cell(values[index]);
                        index++;
                    }
                }
                int posValI, posValJ;
                Functions.pos2coord(out posValI, out posValJ, values[index], Size);
                board.Structure[posValI, posValJ] = new Cell(values[index]);
            }
            return board;
        }

        // Fonction de création des enfants spécifiques
        public static List<EvaluableBoard> CreateChild(EvaluableBoard board, int step)
        {
            List<EvaluableBoard> neighbours = new List<EvaluableBoard>();
            int size = board.Board.Structure.GetLength(0);
            List<int> values;
            // Valeurs possibles
            if (size == 3) values = new List<int>() {0, 1, 2, 3, 4, 7, 5, 6 };
            else values = new List<int>() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 20, 16, 21, 17, 22, 18, 19 };
            int maxIndex = values.IndexOf(step);
            foreach (Cell cell in board)
            {
                if(cell.Value != "-")
                {
                    int index = values.IndexOf(Convert.ToInt32(cell.Value));
                    // On interdit les mouvements au case déjà placées
                    if (index >= maxIndex)
                    {
                        int i, j;
                        board.Board.FindCellByValue(out i, out j, cell.Value);
                        if (cell.IsMovable())
                        {
                            foreach (Cell.Moves move in cell.AvailableMoves)
                            {
                                EvaluableBoard neighbour = CopyBoard(board);
                                neighbour.Cost = board.Cost;
                                neighbour.Board.Move(neighbour.Board.Structure[i, j], move);
                                neighbour.Previous = board;
                                neighbours.Add(neighbour);
                            }
                        }
                    }
                }
            }
            return neighbours;
        }
        #endregion
    }
}
