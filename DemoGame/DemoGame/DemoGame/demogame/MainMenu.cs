using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using xnapunk;
using xnapunk.graphics;
using xnapunk.colliders;
using Microsoft.Xna.Framework.Input;

namespace demogame
{
    class MainMenu : World
    {

        private static Color color = Color.FromNonPremultiplied(233, 49, 95, 255);

        private string[] menuItems = { "World 1", "World 2", "Quit" };
        private List<Text> items = new List<Text>();

        private int _selected;
        private int selected
        {
            get { return _selected; }
            set
            {
                items[_selected].Tint = color;
                _selected = value;
                if (_selected > items.Count - 1) _selected = 0;
                else if (_selected < 0) _selected = items.Count - 1;
                items[_selected].Tint = Color.White;
            }
        }

        public MainMenu()
        {
            AddGraphic(XP.Load("Background"));

            int offsetY = 200;
            foreach (String item in menuItems)
            {
                Text txt = new Text(item); //create Text graphic
                txt.Font = XP.Font; //default font
                txt.Tint = color;
                txt.MeasureString(); //just measure string size when needed
                txt.Position = -txt.Size / 2;

                AddGraphic(txt, 400, offsetY);
                offsetY += 50;
                items.Add(txt);
            }

            selected = 0;

        }

        private Keys[] lastKeys = new Keys[0];
        public override void Update(GameTime gameTime)
        {
            KeyboardState keys = Keyboard.GetState();

            if (keys.IsKeyDown(Keys.Down) && !lastKeys.Contains(Keys.Down)) selected++;
            if (keys.IsKeyDown(Keys.Up) && !lastKeys.Contains(Keys.Up)) selected--;

            if (keys.IsKeyDown(Keys.Enter))
            {
                switch (selected)
                {
                    case 0: //world 1
                        XP.GotoWorld = new ExampleWorld();
                        break;
                    case 1: //world 2
                        XP.GotoWorld = new ExampleWorld2();
                        break;
                    case 2: //exit
                        XP.ExitApp();
                        break;
                }
            }

            lastKeys = keys.GetPressedKeys();

            base.Update(gameTime);
        }

    }
}
