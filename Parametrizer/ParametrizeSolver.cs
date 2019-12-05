using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaquinCodeBehind;
using System.Diagnostics;

namespace Parametrizer
{
    /// <summary>
    /// Classe reprenant la structure du solver méthode humaine 
    /// et le rend facilement paramétrable afin de l'optimiser
    /// </summary>
    class ParametrizeSolver
    {
        #region Attributes
        List<EvaluableBoard> _openSet = new List<EvaluableBoard>();
        List<EvaluableBoard> _closedSet = new List<EvaluableBoard>();
        EvaluableBoard _destination;
        EvaluableBoard _currentBoard;
        #endregion

        #region Properties
        int Size { get; set; }
        public List<int> Params { get; set; }
        public TimeSpan performance { get; set; }
        #endregion

        #region Construct
        // Constructeur pour une heuristique à trois paramètres
        public ParametrizeSolver( int param1, int param2, int param3)
        {
            // vérification et assignation des valeurs
            param1 = param1 < 0 ? 0 : param1;
            param2 = param2 < 0 ? 0 : param2;
            param3 = param3 < 0 ? 0 : param3;
            Params = new List<int>();
            Params.Add(param1);
            Params.Add(param2);
            Params.Add(param3);
        }

        // Constructeur pour une heuristique à cinq paramètres
        public ParametrizeSolver(int param1, int param2, int param3, int param4, int param5)
        {
            // vérification et assignation des valeurs
            param1 = param1 < 0 ? 0 : param1;
            param2 = param2 < 0 ? 0 : param2;
            param3 = param3 < 0 ? 0 : param3;
            param4 = param4 < 0 ? 0 : param4;
            param5 = param5 < 0 ? 0 : param5;
            Params = new List<int>();
            Params.Add(param1);
            Params.Add(param2);
            Params.Add(param3);
            Params.Add(param4);
            Params.Add(param5);
        }
        #endregion

        #region Methods_Solving
        // Fonction permettant de résoudre 
        Stopwatch UnderStep(int rank, Stopwatch chrono)
        {
            _destination = new EvaluableBoard(CreateStep(Size, rank));
            // Boucle de résolution
            while (_openSet.Count > 0)
            {
                _currentBoard = _openSet[0];
                if (_currentBoard.Equals(_destination))
                {
                    // Si l'on est à la dernière étape on stop le chrono
                    if (rank == Size * Size - 3)
                    {
                        chrono.Stop();
                        return chrono;
                    }
                    // Sinon on nettoie le solver pour la prochaine étape
                    else
                    {
                        _openSet = new List<EvaluableBoard>();
                        _closedSet = new List<EvaluableBoard>();
                        _currentBoard.Cost = 0;
                        _currentBoard.Score = 0;
                        _openSet.Add(_currentBoard);
                        break;
                    }
                }
                // Gestion de la descendance
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
                // Si le solver dépasse la minute on l'interrompt
                if (chrono.Elapsed.Minutes >= 1)
                    break;
            }
            return chrono;
        }

        // Méthode de résolution globlae
        public Stopwatch Solve(EvaluableBoard board)
        {
            // Etape d'initialisation
            _openSet = new List<EvaluableBoard>();
            _closedSet = new List<EvaluableBoard>();
            Size = board.Board.Structure.GetLength(0);
            // On prend le premier état
            _openSet.Add(board);
            // On init et on démarre un Chronomètre
            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            // On parcours d'abord en ligne case par case
            for (int rank = 0; rank < (Size * Size) - Size * 2; rank++)
            {
                // On résoud chaque étape une par une en placant la case cible
                chrono = UnderStep(rank, chrono);
                if (chrono.Elapsed.Minutes >= 1)
                    return chrono;

            }
            int start = Size * Size - Size * 2;
            // On parcours ensuite les deux dernière lignes en colonnes
            for (int rank = start; rank < start + Size; rank++)
            {
                // On fait la ligne du haut 
                chrono = UnderStep(rank, chrono);
                if (chrono.Elapsed.Minutes >= 1)
                    return chrono;
                // Puis la ligne du bas
                int step = rank + Size;
                if (step < Size * Size - 2)
                {
                    chrono = UnderStep(step, chrono);
                    if (chrono.Elapsed.Minutes >= 1)
                        return chrono;
                }
            }
            // On arrête le chrono si on a fini
            chrono.Stop();
            return chrono;
        }

        // Implémentation de l'Heuristique spécifique à cette méthode humaine
        private int Eval(EvaluableBoard board, int step)
        {
            int score = 0;
            int optI, optJ, currI, currJ;

            // Prise en compte de la case courante a placer
            Functions.pos2coord(out optI, out optJ, step, Size);
            board.Board.FindCellByValue(out currI, out currJ, Convert.ToString(step));
            score += Params[0] * (Math.Abs(optI - currI) + Math.Abs(optJ - currJ));

            int hole1I, hole1J, hole2I, hole2J;
            board.Board.FindEmptyOne(out hole1I, out hole1J);
            board.Board.FindEmptyTwo(out hole2I, out hole2J);
            // Prise en compte de la distance trou case à placer
            int distH1T = Math.Abs(hole1I - currI) + Math.Abs(hole1J - currJ);
            int distH2T = Math.Abs(hole2I - currI) + Math.Abs(hole2J - currJ);
            score += Params[1] * distH1T;
            score += Params[1] * distH2T;

            // Prise en compte de la distance trou destination
            int distH1 = Math.Abs(optI - hole1I) + Math.Abs(optJ - hole1J);
            int distH2 = Math.Abs(optI - hole2I) + Math.Abs(optJ - hole2J);
            score += Params[2] * Math.Min(distH1, distH2);

            return score;
        }

        // Permet de créer une étape intermédiaire pour n'importe quel rang
        private Board CreateStep(int size, int rank)
        {
            Board board;
            List<Cell> structure = new List<Cell>();
            // On rempli normalement le tableau si l'on est avant les deux dernières lignes
            if(rank < size * size - size * 2)
            {
                // Ajout des valeurs
                for (int i = 0; i <= rank; i++)
                {
                    Cell cell = new Cell(i);
                    structure.Add(cell);
                }
                // On ajoute ensuite les cases non pertinentes (-1)
                for (int i = rank; i < (size * size - 2) - 1; i++)
                {
                    Cell empty = new Cell(-1);
                    structure.Add(empty);
                }
                // On rajoute les deux trous
                for (int i = 0; i < 2; i++)
                {
                    Cell hole = new Cell("-");
                    structure.Add(hole);
                }
                board = new Board(structure.ToArray());
            }
            // On rempli les deux dernières lignes différemment
            else
            {
                // On remplis d'abord le début normalement
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
                // Ensuite on dissocie 3x3
                if(Size == 3)
                {
                    values = new List<int>() { 3, 6, 4, 5 };
                    // ON ajoute les valeurs en colonnes
                    while(values[index] != rank)
                    {
                        int posI, posJ;
                        Functions.pos2coord(out posI, out posJ, values[index], Size);
                        board.Structure[posI, posJ] = new Cell(values[index]);
                        index++;
                    }
                }
                // et les Taquin 5x5
                else
                {
                    values = new List<int>() { 15, 20, 16, 21, 17, 22, 18, 19 };
                    // On ajoute alors les valeurs en colonnes
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
        #endregion

        #region Method_FromSolver
        // Méthode permettant de copier un tableau pour briser les références
        public static EvaluableBoard CopyBoard(EvaluableBoard board)
        {
            EvaluableBoard result = new EvaluableBoard(board.Score);
            Cell[,] structure = new Cell[board.Size, board.Size];
            foreach (Cell cell in board)
            {
                Cell newCell = new Cell(cell.Value);
                int posI, posJ;
                board.Board.FindCellByValue(out posI, out posJ, cell.Value);
                structure[posI, posJ] = newCell;
            }
            // Might me proper
            Cell emptyOne = new Cell("-");
            Cell emptyTwo = new Cell("-");
            int e1i, e1j, e2i, e2j;
            board.Board.FindEmptyOne(out e1i, out e1j);
            board.Board.FindEmptyTwo(out e2i, out e2j);
            structure[e1i, e1j] = emptyOne;
            structure[e2i, e2j] = emptyTwo;
            // Till there is not really needed
            result.Board = new Board(structure);
            result.Size = result.Board.Structure.GetLength(0);
            return result;
        }

        // Fonciton de recherche des antécédents
        public bool FindPast(EvaluableBoard board)
        {
            bool result = false;
            foreach (EvaluableBoard oldBoard in _closedSet)
                if (oldBoard.Equals(board)) result = true;
            return result;
        }

        public bool FindBest(EvaluableBoard board)
        {
            bool result = false;
            foreach (EvaluableBoard currentBoard in _openSet)
            {
                if (board.Equals(currentBoard) && currentBoard.Cost <= board.Cost) result = true;
                else if (board.Equals(currentBoard) && currentBoard.Cost > board.Cost) { currentBoard.Cost = board.Cost; }
            }
            return result;
        }

        // Création des enfants spécifique à la méthode humaine
        public static List<EvaluableBoard> CreateChild(EvaluableBoard board, int step)
        {
            List<EvaluableBoard> neighbours = new List<EvaluableBoard>();
            int size = board.Board.Structure.GetLength(0);
            List<int> values;
            // Valeurs possibles dans les tableaux
            if (size == 3) values = new List<int>() { 0, 1, 2, 3, 4, 7, 5, 6 };
            else values = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 20, 16, 21, 17, 22, 18, 19 };
            int maxIndex = values.IndexOf(step);
            // On parcours toutes les cellules du tableau
            foreach (Cell cell in board)
            {
                if (cell.Value != "-")
                {
                    int index = values.IndexOf(Convert.ToInt32(cell.Value));
                    // On bloque le mouvement des cases déjà positionnées
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