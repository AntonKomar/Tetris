using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    [Serializable]
    [DataContract]
    class Board : Rectangle
    {
        #region fields and properties

        [DataMember]
        public int[,] grid = new int[numRows, numCols];
        [DataMember]
        public int boardColor;

        #endregion
    }
}
