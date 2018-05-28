using System.Collections.Generic;

namespace CodingGame.UltimateTicTacToe
{
    public class StudentWorker : IIAWorker
    {
        public string Play(List<string> input)
        {
            string[] inputs = input[0].Split(' ');
            
            int opponentRow = int.Parse(inputs[0]);
            int opponentCol = int.Parse(inputs[1]);
            for (int i = 1; i < input.Count; i++)
            {
                inputs = input[i].Split(' ');
                int row = int.Parse(inputs[0]);
                int col = int.Parse(inputs[1]);
            }

            // Write your logic here

            return input[1];
            return "0 0"; // Replace by your result
        }
    }
}
