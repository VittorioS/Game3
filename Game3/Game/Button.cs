using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class Button
    {

        public enum ButtonState
        {
            None,
            Pressed,
            Hover,
            Released
        }

        
        private Rectangle _rectangle;
        private ButtonState _state;
        public ButtonState State
        {
            get { return _state; }
            set { _state = value; } // you can throw some events here if you'd like
        }

        private Dictionary<ButtonState, Texture2D> _textures;

        public Button(Rectangle rectangle, Texture2D noneTexture, Texture2D hoverTexture, Texture2D pressedTexture)
        {
            _rectangle = rectangle;
            _textures = new Dictionary<ButtonState, Texture2D>
        {
            { ButtonState.None, noneTexture },
            { ButtonState.Hover, hoverTexture },
            { ButtonState.Pressed, pressedTexture }
        };
        }

        public void Update(MouseState mouseState)
        {
            if (_rectangle.Contains(mouseState.X, mouseState.Y))
            {
                if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                    State = ButtonState.Pressed;
                else
                    State = State == ButtonState.Pressed ? ButtonState.Released : ButtonState.Hover;
            }
            else
            {
                State = ButtonState.None;
            }
        }

        // Make sure Begin is called on s before you call this function
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textures[State], _rectangle, Color.White);
        }

    }
}
