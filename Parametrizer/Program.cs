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
    /// Algorithme génétique permettant de trouver les paramètres optimaux pour le solver
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Initialisations
            Setup();
            int nbGen = 10; // Nombre de génération
            int nbIndiv = 100; // Nombre d'individus de la population
            int nbCible = 20; // Nombre d'exemple a résoudre

            Random r = new Random();

            List<ParametrizeSolver> _population = new List<ParametrizeSolver>();
            List<EvaluableBoard> _targets = new List<EvaluableBoard>();

            //Initialisation Création de la population
            Console.Write("Initializing population : ");
            for (int _ = 0; _ < nbIndiv; _++)
            {
                int max = 10;
                //ParametrizeSolver current = new ParametrizeSolver(r.Next(0, max), r.Next(0, max), r.Next(0, max), r.Next(0, max), r.Next(0, max));
                ParametrizeSolver current = new ParametrizeSolver(7, 4, 8);//,9,4);
                Mutate(current, r);
                _population.Add(current);
            }
            Console.Write(_population.Count + " solver created.");
            // Initialisation : Creation des cibles
            Console.Write(" - Initializing targets : ");
            for(int _ = 0; _ < nbCible; _++)
            {
                Board b = new Board(5);
                Fill(b);
                EvaluableBoard target = new EvaluableBoard(b);
                _targets.Add(target);
            }
            Console.Write(_targets.Count + " target created. \n \n");

            // Life Loop
            Console.WriteLine("Starting Life Loop :\n");
            for (int i = 0; i < nbGen; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Starting generation {0}", i);
                // Mélanger les cibles
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                // Updating targets
                _targets = new List<EvaluableBoard>();
                for (int _ = 0; _ < nbCible; _++)
                {
                    Board b = new Board(5);
                    Fill(b);
                    b = Shuffle(b, r, 100 * (i+1)); // Difficulté du mélange
                    EvaluableBoard target = new EvaluableBoard(b);
                    _targets.Add(target);
                }
                Console.WriteLine(" - All targets shuffled - Starting :");
                // Calculating performances
                Console.ForegroundColor = ConsoleColor.Black;
                int top = Console.CursorTop;
                foreach (ParametrizeSolver solver in _population)
                {
                    List<TimeSpan> _performances = new List<TimeSpan>();

                    int progress = (_population.IndexOf(solver)+1);
                    string progressStr = new String('=', progress);

                    foreach (EvaluableBoard board in _targets)
                    {
                        Stopwatch chrono = solver.Solve(board);
                        TimeSpan perf = chrono.Elapsed;
                        _performances.Add(perf);
                    }
                    // Informations d'avancement
                    Console.SetCursorPosition(0, top);
                    Console.Write("\rProgress [" + progressStr + new String(' ', (nbIndiv - progress)) + "] - ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(progress + "% \n");
                    Console.ForegroundColor = ConsoleColor.Black;
                    // Calcul du temps moyen
                    var averageTimespan = new TimeSpan(Convert.ToInt64(_performances.Average(ts => ts.Ticks)));
                    solver.performance = averageTimespan;
                }
                _population = _population.OrderBy(s => s.performance).ToList();
                ParametrizeSolver _currentBest = _population[0];
                Console.ForegroundColor = ConsoleColor.Green;
                //Console.Write("Result of generation {0} : Best solver mean time is {1}, with p1 = {2} - p2 = {3} - p3 = {4} - p4 = {5} - p5 = {6}\n",i, _currentBest.performance, _currentBest.Params[0], _currentBest.Params[1], _currentBest.Params[2], _currentBest.Params[3], _currentBest.Params[4]);
                Console.Write("Result of generation {0} : Best solver mean time is {1}, with p1 = {2} - p2 = {3} - p3 = {4}\n", i, _currentBest.performance, _currentBest.Params[0], _currentBest.Params[1], _currentBest.Params[2]);

                ParametrizeSolver _currentWorst = _population[nbIndiv - 1];
                Console.ForegroundColor = ConsoleColor.DarkRed;
                //Console.Write("Result of generation {0} : Worst solver mean time is {1}, with p1 = {2} - p2 = {3} - p3 = {4} - p4 = {5} - p5 = {6}\n\n", i, _currentWorst.performance, _currentWorst.Params[0], _currentWorst.Params[1], _currentWorst.Params[2], _currentBest.Params[3], _currentBest.Params[4]);
                Console.Write("Result of generation {0} : Worst solver mean time is {1}, with p1 = {2} - p2 = {3} - p3 = {4}\n\n", i, _currentWorst.performance, _currentWorst.Params[0], _currentWorst.Params[1], _currentWorst.Params[2]);

                Console.ForegroundColor = ConsoleColor.Black;
                // Dealing with generation decendance...

                _population = _population.GetRange(0, nbIndiv / 2);
                // Evolution pour la génération suivante 
                while(_population.Count < nbIndiv - nbIndiv/4)
                {
                    // Choix de parents
                    ParametrizeSolver father = _population[r.Next(0, _population.Count)]; // /2 Pour favoriser les meilleurs pas forcément
                    ParametrizeSolver mother = _population[r.Next(0, _population.Count)];// La meilleure solution
                    int param1, param2, param3;//, param4, param5;
                    int gene1, gene2, gene3;//, gene4, gene5;
                    gene1 = r.Next(0, 2);
                    gene2 = r.Next(0, 2);
                    gene3 = r.Next(0, 2);
                    //gene4 = r.Next(0, 2);
                    //gene5 = r.Next(0, 2);
                    param1 = gene1 == 0 ? father.Params[0] : mother.Params[0];
                    param2 = gene2 == 0 ? father.Params[1] : mother.Params[1];
                    param3 = gene3 == 0 ? father.Params[2] : mother.Params[2];
                    //param4 = gene4 == 0 ? father.Params[3] : mother.Params[3];
                    //param5 = gene5 == 0 ? father.Params[4] : mother.Params[4];
                    // Création et mutation d'un enfant
                    ParametrizeSolver child = new ParametrizeSolver(param1, param2, param3);//, param4, param5);
                    Mutate(child, r);
                    _population.Add(child);
                }
                // Ajout d'objets aléatoire pour agrandir la diversité
                while(_population.Count < nbIndiv)
                {
                    int max = 10;
                    ParametrizeSolver current = new ParametrizeSolver(r.Next(0, max), r.Next(0, max), r.Next(0, max));//, r.Next(0, max), r.Next(0, max));
                    Mutate(current, r);
                    _population.Add(current);
                }
            }

            Console.Read();
        }

        #region Methods_Utilitaries
        // Permet de melanger les exemples à un niveau de difficulté choisies
        static Board Shuffle(Board b, Random r, int diff)
        {
            int size = b.Structure.GetLength(0);
            Taquin t = new Taquin(size);

            for (int i = 0; i <= diff; i++)
            {
                foreach (Cell cell in t)
                {
                    if (cell.IsMovable())
                    {
                        if (r.Next(2) == 1) t.Move(cell);
                    };
                }
                t.Board.ClearBoardStatus();
                t.Board.CalculatePossibleMoves();
            }
            return t.Board;
        }

        // Permet de remplir les exemple à résoudre 
        static void Fill(Board b)
        {
            int size = b.Structure.GetLength(0);
            for(int val = 0; val < size*size-2; val++)
            {
                Cell c = new Cell(val);
                int posI, posJ;
                Functions.pos2coord(out posI, out posJ, val, size);
                b.Structure[posI, posJ] = c; 
            }
            for(int _ = 0; _ < 2; _++)
            {
                Cell c = new Cell("-");
                b.Structure[4, 3 + _] = c;
            }
        }

        // Fonction permettant de faire muter un solver
        static void Mutate(ParametrizeSolver solver, Random  r)
        {
            int luck;
            // Probabilité de mutation et degré de mutation
            int probMut = 2;
            int mutRate = 1;
            // Pour chaque paramètre on regarde 
            for (int i = 0; i < 3; i++)
            {
                luck = r.Next(10);
                if(luck > probMut)
                {
                    if(luck > 5)
                        solver.Params[i] += mutRate;
                    else if(solver.Params[i]> 0) solver.Params[i] -= mutRate;
                }
            }
        }

        // Fonciton d'initialisation de la console
        static void Setup()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WindowHeight = 69 - 20;
            Console.WindowWidth = 266 - 40;
            Console.Clear();
        }
        #endregion
    }
}
