using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    class KeyboardInput
    {
        #region Variables/Properties

        public bool UpKeyPressed { get; set; }
        public bool DownKeyPressed { get; set; }
        public bool RightKeyPressed { get; set; }
        public bool LeftKeyPressed { get; set; }
        public bool SpaceKeyPressed { get; set; }

        #endregion Variables/Properties

        public KeyboardInput()
        {
            UpKeyPressed = false;
            DownKeyPressed = false;
            RightKeyPressed = false;
            LeftKeyPressed = false;
        }

        public void evaluateKey(Keys key, Boolean pressed)
        {
            if (key == Keys.Left)
                LeftKeyPressed = pressed;
            else if (key == Keys.Right)
                RightKeyPressed = pressed;
            else if (key == Keys.Down)
                DownKeyPressed = pressed;
            else if (key == Keys.Up)
                UpKeyPressed = pressed;
            else if (key == Keys.Space)
                SpaceKeyPressed = pressed;

        }
    }
}
