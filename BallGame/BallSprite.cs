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
    public class BallSprite : BaseSprite
    {
        protected float displayHeight = 600;
        protected float displayWidth = 800;
        protected float x = 0;
        protected float y = 200;
        protected float XSpeed = 800 / 200.0f;
        protected float YSpeed = 600 / 200.0f;
        public int lives = 3;
        public int Score = 0;

        public override  void  Update(BallGameClass game)
        {
            x = x + XSpeed;
            y = y + YSpeed;
            spriteRectangle.X = (int)(x + 0.5f);
            spriteRectangle.Y = (int)(y + 0.5f);

             if (x + spriteRectangle.Width >= displayWidth)
            {
                XSpeed = XSpeed * -1;
            }
            if (x <= 0)
            {
                XSpeed = XSpeed * -1;
            }
            if (y + spriteRectangle.Height >= displayHeight)
            {
                YSpeed = YSpeed * -1;
                lives--;      
            }
            if (y <= 0)
            {
                YSpeed = YSpeed * -1;
            }                    
            if (game.Bat.CheckCollision(spriteRectangle))
            {
                // bat has hit the ball.
                YSpeed = YSpeed * -1;
            }
            for (int i = 0; i < game.Target.numberOFTargets; i++)
            {
                if (game.Target.spriteRectangl[i].Intersects(spriteRectangle) && game.Target.isVisible[i])
                {
                    game.Target.isVisible[i] = false;
                    YSpeed = YSpeed * -1;
                    Score = Score + 10;
                }
            }
          if (lives == 0)
            {
                game.gaMe.GameOver(game);             
            }
           base.Update(game);       
        }
    }
}
