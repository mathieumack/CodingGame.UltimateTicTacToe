using System;
using System.Collections.Generic;

namespace CodingGame.UltimateTicTacToe
{
    class Program
    {
        public static IIAWorker profworker;
        public static IIAWorker studentworker;
        public static int[,] GameBoard;
        public static int currentPlayer = 0;

        /// <summary>
        /// Tic - tac - toe est un jeu tour par tour dont l'objectif est d'être le premier à aligner 3 symboles.
        /// Le jeu se déroule sur une grille 3x3.Vous devez écrire les coordonnées de la case que vous voulez marquer. Le premier joueur qui aligne 3 de ses marques(verticalement, horizontalement et en diagonale) a gagné.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int i = 0;
            while (i < 1000)
            {
                StartNewGame();
                i++;
            }

            Console.ReadLine();

        }

        static void StartNewGame()
        {
            profworker = new ProfWorker();
            studentworker = new StudentWorker();

            GameBoard = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameBoard[i, j] = -1;
                }
            }

            currentPlayer = 0;

            string action = "-1 -1";

            Console.Write("Nouvelle partie ... ");

            while (!CheckEndGame())
            {
                currentPlayer = (currentPlayer + 1) % 2;
                action = Play(action);
            }

            Console.WriteLine((currentPlayer == 1 ? "Le prof" : "L'étudiant") + " gagne !");
        }

        static bool CheckEndGame()
        {
            // Check if we are in a valid use case :
            // Valid line ?
            var result = CheckEndGameRow(0, 0);
            result = result || CheckEndGameRow(1, 0);
            result = result || CheckEndGameRow(2, 0);
            result = result || CheckEndGameRow(0, 1);
            result = result || CheckEndGameRow(1, 1);
            result = result || CheckEndGameRow(2, 1);

            // Valid col ?
            result = result || CheckEndGameCol(0, 0);
            result = result || CheckEndGameCol(1, 0);
            result = result || CheckEndGameCol(2, 0);
            result = result || CheckEndGameCol(0, 1);
            result = result || CheckEndGameCol(1, 1);
            result = result || CheckEndGameCol(2, 1);

            // Valid diagonal ?
            result = result || CheckEndGameDiagonal1(0);
            result = result || CheckEndGameDiagonal1(1);
            result = result || CheckEndGameDiagonal2(0);
            result = result || CheckEndGameDiagonal2(1);

            return result;
        }

        static bool CheckEndGameDiagonal1(int player)
        {
            return GameBoard[0, 0] == player && GameBoard[1, 1] == player && GameBoard[2, 2] == player;
        }

        static bool CheckEndGameDiagonal2(int player)
        {
            return GameBoard[0,2] == player && GameBoard[1, 1] == player && GameBoard[2, 0] == player;
        }

        static bool CheckEndGameRow(int row, int player)
        {
            return GameBoard[row, 0] == player && GameBoard[row, 1] == player && GameBoard[row, 2] == player;
        }

        static bool CheckEndGameCol(int col, int player)
        {
            return GameBoard[0, col] == player && GameBoard[1, col] == player && GameBoard[2, col] == player;
        }

        static string Play(string previousAction)
        {
            var player = currentPlayer == 0 ? studentworker : profworker;

            var inputs = new List<string>()
            {
                previousAction
            };
            inputs.AddRange(GetAvailableActions());

            var play = player.Play(inputs);
            var playLine = play.Split(' ');
            int row = int.Parse(playLine[0]);
            int col = int.Parse(playLine[1]);

            GameBoard[row, col] = currentPlayer;

            return play;
        }

        static List<string> GetAvailableActions()
        {
            var result = new List<string>();

            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (GameBoard[i, j] == -1)
                        result.Add(i + " " + j);
                }
            }

            return result;
        }
    }
}
