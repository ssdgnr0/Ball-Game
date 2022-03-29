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
    public class BatSprite : BaseSprite
    {
        protected float x = 360;
        protected float y = 550;
        protected float XSpeed = 20 / 3;
        protected float YSpeed = 20 / 3;
        protected float displayWidth = 800;
        protected float displayHeight = 600;

      //  public void SetRectangle()
        //{
           // spriteRectangle.X = (int)x;   //(int)(0 + (i * targetspacing));
           /// spriteRectangle.Y = (int)y;
            //spriteRectangle.Width = 80;
           // spriteRectangle.Height = 25;
           // spriteRectangle = new Rectangle(spriteRectangle.X, spriteRectangle.Y, spriteRectangle.Width, spriteRectangle.Height);   
        //}  
        public override void Update(BallGameClass game)
        {
            KeyboardState keyBoard = Keyboard.GetState();
            if (keyBoard.IsKeyDown(Keys.A) && spriteRectangle.X > displayWidth - displayWidth)
            {
                x = x - XSpeed;
                spriteRectangle.X = (int)(x - 0.4f);
            }
            if (keyBoard.IsKeyDown(Keys.D) && spriteRectangle.X + spriteRectangle.Width < displayWidth)
            {
                x = x + XSpeed;
                spriteRectangle.X = (int)(x + 0.4);
            }
            if (keyBoard.IsKeyDown(Keys.W) && spriteRectangle.Y > displayHeight - displayHeight)
            {
                y = y - YSpeed;
                spriteRectangle.Y = (int)(y - 0.4);
            }
            if (keyBoard.IsKeyDown(Keys.S) && spriteRectangle.Y + spriteRectangle.Height < displayHeight)
            {
                y = y + YSpeed;
                spriteRectangle.Y = (int)(y + 0.4);
            }
            //
            if (x + spriteRectangle.Width >= displayWidth)
            {
                spriteRectangle.X = (int)displayWidth - spriteRectangle.Width;
            }
            if (x <= 0)
            {
                spriteRectangle.X = (int)displayWidth - (int)displayWidth;
            }
            if (y + spriteRectangle.Height >= displayHeight)
            {
                spriteRectangle.Y = (int)displayHeight - spriteRectangle.Height;
            }
            if (y < 0)
            {
                spriteRectangle.Y = (int)displayHeight - (int)displayHeight;
            }        
            base.Update(game);
        }
        public bool CheckCollision(Rectangle target)
        {
            return spriteRectangle.Intersects(target);
        }
    }
}
