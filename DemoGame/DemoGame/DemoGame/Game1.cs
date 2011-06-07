using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using xnapunk;
using demogame;

namespace DemoGame
{

    public class Game1 : XP
    {

        public Game1()
            : base(new Point(800, 600))
        {
            XP.BackgroundColor = Color.FromNonPremultiplied(32, 32, 32, 255);
            XP.Title = "XNAPunk";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            XP.World = new MainMenu();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) XP.ExitApp();

            base.Update(gameTime);
        }

        public static void Main(string[] args)
        {
            using (Game game = new Game1())
            {
                game.Run();
            }
        }

    }
}
