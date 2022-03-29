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
    public class TargetRowSprite : BaseSprite
    {
        public Rectangle[] spriteRectangl;
        public int numberOFTargets = 20;
        public float targetspacing = (800 - 0) / 20;
        public bool[] isVisible;
        public void SetRectangle()
        {
            isVisible = new bool[numberOFTargets];
             spriteRectangl = new Rectangle[numberOFTargets];
             for (int i = 0; i < numberOFTargets; i++)
             {
                 isVisible[i] = true;
                 spriteRectangl[i].X = (int)(0 + (i * targetspacing));
                 spriteRectangl[i].Y = 0;
                 spriteRectangl[i].Width = 80;
                 spriteRectangl[i].Height = 100;
                 spriteRectangl[i] = new Rectangle(spriteRectangl[i].X,
                     spriteRectangl[i].Y,
                     spriteRectangl[i].Width,
                     spriteRectangl[i].Height);
                 isVisible[i] = true; 
          }
        }             
        public override void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < numberOFTargets; i++)
            {
                if (isVisible[i])
                {
                    spriteBatch.Draw(spriteTexture, spriteRectangl[i], Color.White);
                }
            }      
            base.Draw(spriteBatch);
        }     
    }
}
