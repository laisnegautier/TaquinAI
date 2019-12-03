using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class CornerConflict : IHeuristic
    {
        /// <summary>
        /// Fonction principale qui evalue le cout de l'heuristique C 
        /// entre deux tableau quelconques
        /// </summary>
        /// <param name="currBoard"> Le tableau à évaluer </param>
        /// <param name="destBoard"> Le tableau avec lequel on compare </param>
        /// <returns></returns>
        public int EvaluateBoard(Board currBoard, Board destBoard)
        {
            int size = currBoard.Structure.GetLength(0);
            int cost = 0;
            // Liste des valeurs que l'on peut rencontrer dans les coins
            List<int> cornerValues;
            // Evaluation de l'heuristique pour un board de taille 3x3
            if (size == 3)
            {
                cornerValues = new List<int> { 0, 2, 6 };
                // Liste des valeurs déja impliquées dans un conflit
                List<int> usedPile = new List<int>();
                foreach (int value in cornerValues)
                {
                    int optI, optJ, currI, currJ;
                    Functions.pos2coord(out optI, out optJ, value, size);
                    currBoard.FindCellByValue(out currI, out currJ, value.ToString());
                    if (optI != currI || optJ != currJ) // Si le coin est mal placé
                    {
                        // On cherche si une case sur le bord est à la bonne place
                        if (value == 0)
                        {
                            if (currBoard.Structure[optI, optJ + 1].Value == "1")
                            {
                                cost += 2;
                                usedPile.Add(1);
                            }
                            else if (currBoard.Structure[optI + 1, optJ].Value == "3")
                            {
                                cost += 2;
                                usedPile.Add(3);
                            }
                        }
                        else if (value == 2)
                        {
                            if (!(usedPile.Contains(1)))
                            {
                                if (currBoard.Structure[optI, optJ - 1].Value == "1")
                                    cost += 2;
                            }
                            else if (currBoard.Structure[optI + 1, optJ].Value == "5") cost += 2;
                        }
                        else
                        {
                            if (!(usedPile.Contains(3)))
                            {
                                if (currBoard.Structure[optI - 1, optJ].Value == "3")
                                    cost += 2;
                            }
                        }
                    }
                }
            }
            // Evaluation de l'heuristique pour un board de taille 5x5
            else if (size == 5)
            {
                cornerValues = new List<int> { 0, 4, 20 };
                // Pour chaque coin, on évalue son implication dans l'heuristique C
                foreach (int value in cornerValues)
                {
                    int optI, optJ, currI, currJ;
                    Functions.pos2coord(out optI, out optJ, value, size);
                    currBoard.FindCellByValue(out currI, out currJ, value.ToString());
                    if (optI != currI || optJ != currJ) // Si le coin est mal placé
                    {
                        // On évalue si ses voisins sont en palce ou non
                        if (value == 0)
                        {
                            if (currBoard.Structure[optI, optJ + 1].Value == "1") cost += 2;
                            else if (currBoard.Structure[optI + 1, optJ].Value == "5") cost += 2;
                        }
                        else if (value == 4)
                        {
                            if (currBoard.Structure[optI, optJ - 1].Value == "3") cost += 2;
                            else if (currBoard.Structure[optI + 1, optJ].Value == "9") cost += 2;
                        }
                        else
                        {
                            if (currBoard.Structure[optI - 1, optJ].Value == "15") cost += 2;
                            else if (currBoard.Structure[optI, optJ + 1].Value == "21") cost += 2;
                        }
                    }
                }
            }
            return cost;
        }
    }
}

