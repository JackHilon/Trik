using System;

namespace Trik
{
    class Program
    {
        static void Main(string[] args)
        {
            // Trik problem --> three cups trik (ball initial place is in the left (A) Cup)

            //   (A) Cup       (B) Cup       (C) Cup

            //   https://open.kattis.com/problems/trik

            TrikGame();
        }
        private static void TrikGame()
        {
            var Moves = EnterCupsMoves();

            var Game = GameMoves(Moves);

            Console.WriteLine(WhereTrue(Game));
        }
        private static bool[] GameMoves(char[] moves)
        {
            bool[] game = new bool[3] { true, false, false };

            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] == 'A')
                    SwapA(game);
                if (moves[i] == 'B')
                    SwapB(game);
                if (moves[i] == 'C')
                    SwapC(game);
            }
            return game;
        }
        private static char[] EnterCupsMoves()
        {
            char[] ans;
            var str = " ";
            try
            {
                str = Console.ReadLine();
                ans = str.ToCharArray();
                for (int i = 0; i < ans.Length; i++)
                {
                    if (ans[i] != 'A' && ans[i] != 'B' && ans[i] != 'C')
                        throw new ArgumentException();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
                return EnterCupsMoves();
            }
            return ans; // str.ToCharArray();
        }

        private static int WhereTrue(bool[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == true)
                    return (i + 1);
            }
            return 0;
        }
        private static void SwapA(bool[] arr)
        {
            var temp = arr[0];
            arr[0] = arr[1];
            arr[1] = temp;
        }
        private static void SwapB(bool[] arr)
        {
            var temp = arr[1];
            arr[1] = arr[2];
            arr[2] = temp;
        }
        private static void SwapC(bool[] arr)
        {
            var temp = arr[0];
            arr[0] = arr[2];
            arr[2] = temp;
        }
    }
}
