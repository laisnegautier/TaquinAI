using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class AstarUni : Solver
    {
        public AstarUni()
        {

        }

        public override List<Board> Solve(EvaluableBoard board)
        {
            throw new NotImplementedException();
            /* 
            On ajoute le départ dans l'OpenSet
            
            Tant que l'openSet n'est pas vide
                currentBoard = meilleur de l'OpenSet
                
                si le currentBoard = fin => On stop et 
                                    on return le chemin

                Pour le current on trouve tous les voisins

                Pour chaque voisins, si il n'est pas dans le closeSet
                    On l'évalue
                    si on ne trouve pas le même dans l'OpenSet
                        on l'ajoute

                On ordonne l'OpenSet avec le meilleur en premier
             */
        }

        protected override int TotalScore(EvaluableBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
