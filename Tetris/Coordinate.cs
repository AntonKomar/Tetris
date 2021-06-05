using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Tetris
{
    /// <summary>
    /// An object that represents a set of coordinates (x,y)
    /// </summary>
    [Serializable]
    [DataContract]
    class Coordinate
    {
        [DataMember]
        public int x { get; set; }
        [DataMember]
        public int y { get; set; }

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
