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
    public class TitleScreenClass : BaseSprite
    {
        GameManagement gamestate;
        public override void Update(BallGameClass game)
        {
            gamestate = new GameManagement();
            KeyboardState keyBoard = Keyboard.GetState();
            if (keyBoard.IsKeyDown(Keys.Enter))
            {
                gamestate.StartGame(game);
            }
            base.Update(game);
        }
    }
}
