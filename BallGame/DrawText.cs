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
    class DrawText  
    {
        SpriteFont font;
        public void LoadFont(SpriteFont F)
        {
            font = F;
        }
        public virtual void  drawText(SpriteBatch spriteBatch,string text, Color textColor, float x, float y)
        {
            int layer;
            Vector2 textVector = new Vector2(x, y);              
            
            //Draw the shadow
            Color backColor = new Color(0, 0, 0, 20);
            for (layer = 0; layer < 10; layer++)
            {
                spriteBatch.DrawString(font, text, textVector, backColor);
                textVector.X++;
                textVector.Y++;
            }

            //Draw the solid part of the characters
            backColor = new Color(190, 190, 190);
            for (layer = 0; layer < 5; layer++)
            {
                spriteBatch.DrawString(font, text, textVector, backColor);
                textVector.X++;
                textVector.Y++;
            }
            //Draw the top part of the characters
            spriteBatch.DrawString(font, text, textVector, textColor);
        }
    }
}
