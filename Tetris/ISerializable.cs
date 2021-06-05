using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    interface ISerializable
    {
        void SaveGame();
        void LoadGame();

        void SaveGameJSON();
        void LoadGameJSON();

        void SaveGameXML();
        void LoadGameXML();
    }
}
