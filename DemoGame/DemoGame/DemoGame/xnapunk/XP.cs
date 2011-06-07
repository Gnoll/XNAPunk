using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using xnapunk.graphics;

namespace xnapunk
{
    public abstract class XP : Game
    {

        private static XP Singleton;

        public static World World = new World();
        public static SpriteBatch Canvas;
        public static GraphicsDeviceManager Graphics;
        public static Point Dimensions;
        public static Color BackgroundColor = Color.CornflowerBlue;
        public static SpriteFont Font;
        public static Camera Camera = new Camera();
        public static ContentManager ContentManager;
        public static int FrameRate;

        public static World GotoWorld = null;

        public static Random Rand = new Random(1337);

        public static bool MouseVisible
        {
            get { return XP.Singleton.IsMouseVisible; }
            set { XP.Singleton.IsMouseVisible = value; }
        }
        
        public String Title
        {
            get { return Window.Title; }
            set { Window.Title = value; }
        }

        public XP(Point dimensions, int framerate)
        {
            XP.ContentManager = Content;
            Dimensions = dimensions;
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            FrameRate = framerate;
            TargetElapsedTime = TimeSpan.FromSeconds(1 / (float)FrameRate);
            XP.Singleton = this;            
        }

        public static Image Load(String id) { return new Image(ContentManager.Load<Texture2D>(id)); }

        public XP(Point dimensions) : this(dimensions, 30) { }

        protected override void Initialize()
        {
            Graphics.PreferredBackBufferWidth = Dimensions.X;
            Graphics.PreferredBackBufferHeight = Dimensions.Y;
            
            Graphics.ApplyChanges();

            base.Initialize();
        }


        protected override void LoadContent()
        {
            Canvas = new SpriteBatch(GraphicsDevice);
            Font = Content.Load<SpriteFont>("Default");
        }

        protected override void UnloadContent()
        {

        }

        public static void ExitApp()
        {
            XP.Singleton.ExitGame();
        }

        public void ExitGame()
        {
            base.Exit();
        }

        protected override void Update(GameTime gameTime)
        {
            World.Update(gameTime);
            base.Update(gameTime);

            if (GotoWorld != null && World != GotoWorld)
            {
                XP.Camera.Position = Vector2.Zero;
                World = GotoWorld; 
                GotoWorld = null;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackgroundColor);

            Canvas.Begin();
            World.Draw(gameTime);
            Canvas.End();

            base.Draw(gameTime);
        }

        public static float AngleBetween(float x1, float y1, float x2, float y2)
		{
			float a = (float)(Math.Atan2(y2 - y1, x2 - x1) * DEG);
			return a < 0 ? a + 360 : a;
		}

        public static float Distance(float x1, float y1, float x2, float y2)
		{
			return (float)Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
		}

        public static float Distance(Vector2 a, Vector2 b)
        {
            return (float)Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y));
        }

        public const double DEG = -180 / Math.PI;
        public const double RAD = Math.PI / -180;

    }
}
