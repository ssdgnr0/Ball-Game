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
    public class BaseSprite
    {
        protected Texture2D spriteTexture;
        protected Rectangle spriteRectangle;

        public void LoadTexture(Texture2D inspriteTexture)
        {
            spriteTexture = inspriteTexture;
        }

        public void SetRectangle(Rectangle inspriteRectangle)
        {
            spriteRectangle = inspriteRectangle;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteTexture, spriteRectangle, Color.White);
        }
        public virtual void Update(BallGameClass game)
        {
        }
    }
}
