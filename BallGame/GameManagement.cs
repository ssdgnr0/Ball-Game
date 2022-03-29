using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace BallGame
{
    public class GameManagement
    {
      int numberOfTargets = 20;
      public void StartGame(BallGameClass game)
      {
          game.spriteBatch.Begin();
          game.Ball.Draw(game.spriteBatch);
          game.Bat.Draw(game.spriteBatch);
          game.spriteBatch.End();
          for (int i = 0; i < numberOfTargets; i++)
          {
              game.Target.isVisible[i] = true;
              game.spriteBatch.Begin();
              game.Target.Draw(game.spriteBatch);
              game.spriteBatch.End();
          }
          game.Ball.Score = 0;
          game.Ball.lives = 3;
          game.state = GameState.PlayingGame;
      }
      public void GameOver(BallGameClass game)
      {      
          game.state = GameState.TitleScreen;
      }
    } 
}
