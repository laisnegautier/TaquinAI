using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class Functions
    {
        // Permet de transformer des coordonées 2D en 1D
        public static int coord2pos(int i, int j, int size)
        {
            return (i * size + j);
        }

        // Permet de transformer une position en coordonées
        public static void pos2coord(out int i, out int j, int rank, int size)
        {
            j = rank % size;
            i = rank / size;
        }

        /// <summary>
        /// Méthode qui créer l'étape finale d'un taquin résolu
        /// </summary>
        /// <param name="size"> Taille du taquin a résoude (3x3 ou 5x5)</param>
        public static EvaluableBoard CreateTarget(int size)
        {
            // On ajoute toutes les valeurs en fonction de la taille
            Cell[] list = new Cell[size * size];
            for (int i = 0; i < size * size - 2; i++)
            {
                Cell cell = new Cell(i);
                list[i] = cell;
            }
            // On ajoute ensuite les trous
            for (int j = 0; j < 2; j++)
            {
                Cell cell = new Cell("-");
                list[list.Length - 1 - j] = cell;
            }
            Board board = new Board(list);
            return new EvaluableBoard(board);
        }
    }
}
