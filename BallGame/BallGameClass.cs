using System;
using System.Collections.Generic;
using System.Linq;
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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BallGameClass : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        BaseSprite Background;
        public BallSprite Ball;
        public BatSprite Bat;
        public TargetRowSprite Target;
        public TitleScreenClass TitleScreen;
        public GameState state = GameState.TitleScreen;
        public GameManagement gaMe;
        DrawText font;
        public SoundEffect introM;
        public BallGameClass()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Background = new BaseSprite();
            Ball = new BallSprite();
            Bat = new BatSprite();
            Target = new TargetRowSprite();
            font = new DrawText();
            gaMe = new GameManagement();
            TitleScreen = new TitleScreenClass();
            base.Initialize();
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Loading the Backdround texture and seting up the Draw Rectangle
            Background.LoadTexture(Content.Load<Texture2D>(@"Images/Background"));
            Background.SetRectangle(
               new Rectangle(0,
                   0,
                   GraphicsDevice.Viewport.Width,
                   GraphicsDevice.Viewport.Height));
            //Loading the TitleScreen texture and setting up the Draw Rectangle
            TitleScreen.LoadTexture(Content.Load<Texture2D>(@"Images/TitleScreen"));
            TitleScreen.SetRectangle(
               new Rectangle(0,
                   0,
                   GraphicsDevice.Viewport.Width,
                   GraphicsDevice.Viewport.Height));
            //Loading the Ball texture and setting up the Draw Rectangle
            Ball.LoadTexture(Content.Load<Texture2D>(@"Images/Ball"));
            Ball.SetRectangle(new Rectangle(200,300, (int)((GraphicsDevice.Viewport.Width * 0.05f) + 0.5f), (int)(40.5)));
            //Loading the Bat texture and setting up the Draw Rectangle
            Bat.LoadTexture(Content.Load<Texture2D>(@"Images/Batt"));
            Bat.SetRectangle(new Rectangle(360, 550, 80, 25));
            //Loading the Target Texture and setting up the Draw Rectangle
            Target.LoadTexture(Content.Load<Texture2D>(@"Images/Targe"));
            Target.SetRectangle();
            //Loading the font
            font.LoadFont(Content.Load<SpriteFont>(@"Fonts/font1"));
            introM = Content.Load<SoundEffect>(@"Music/UIBGM_LOOP");
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            switch (state)
            {
                case GameState.TitleScreen:
                    TitleScreen.Update(this);
                    break;
                case GameState.PlayingGame:
                    Ball.Update(this);
                    Bat.Update(this);
                    Target.Update(this);
                    break;
            }
           base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Draw the Game Objects
            spriteBatch.Begin();
            switch (state)
            {
                case GameState.TitleScreen:
                    TitleScreen.Draw(spriteBatch);
                    break;
                case GameState.PlayingGame:
                    Background.Draw(spriteBatch);
                    Ball.Draw(spriteBatch);
                    Bat.Draw(spriteBatch);
                    Target.Draw(spriteBatch);
                    font.drawText(spriteBatch, "Lives = " + Ball.lives + " " + "Score = " + Ball.Score.ToString(), Color.White, 10, 550);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }     
    }
}
