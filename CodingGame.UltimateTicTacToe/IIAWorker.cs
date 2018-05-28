using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGame.UltimateTicTacToe
{
    public interface IIAWorker
    {
        /// <summary>
        /// Executé lorsque c'est à l'IA de jouer
        /// </summary>
        /// <param name="input">Ligne 1: 2 entiers séparés par un espace opponentRow et opponentCol, les coordonnées jouées par l'adversaire au tour précédent (-1 -1 pour le tout premier tour). 
        /// toutes les lignes suivantes : 2 entiers séparés par un espace row et col, les coordonnées où vous pouvez jouer.</param>
        /// <returns>2 entiers séparés par un espace row et col</returns>
        string Play(List<string> input);
    }
}
