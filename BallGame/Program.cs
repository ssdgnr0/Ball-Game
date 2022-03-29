using System;

namespace BallGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (BallGameClass game = new BallGameClass())
            {
                game.Run();
            }
        }
    }
}

