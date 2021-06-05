using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Tetris
{
    [Serializable]
    [DataContract]
    class Shape
    {
        #region fields and properties

        private const int numShape = 7;
        [DataMember]
        public Int32[] ColorSet { get; private set; }
        [DataMember]
        public bool[][,] BlockConfig { get; private set; } = new bool[numShape][,];

        #endregion

        public Shape()
        {
            defineShapes();
            ColorSet = getColorSet();
        }

        #region Methods

        /// <summary>
        /// defines the master shape array with hardcoded values for the seven different shapes
        /// </summary>
        private void defineShapes()
        {

            //hardcoding the 7 different shapes into 4x4 bool arrays
            bool[,] straightLine = new bool[4, 4] { { false, true, false, false }, { false, true, false, false }, { false, true, false, false }, { false, true, false, false } };
            bool[,] leftThunder = new bool[4, 4] { { false, false, false, false }, { true, true, false, false }, { false, true, true, false }, { false, false, false, false } };
            bool[,] rightThunder = new bool[4, 4] { { false, false, false, false }, { false, false, true, true }, { false, true, true, false }, { false, false, false, false } };
            bool[,] triangle = new bool[4, 4] { { false, false, true, false }, { false, true, true, false }, { false, false, true, false }, { false, false, false, false } };
            bool[,] rightL = new bool[4, 4] { { false, false, false, false }, { false, true, true, false }, { false, false, true, false }, { false, false, true, false } };
            bool[,] leftL = new bool[4, 4] { { false, false, false, false }, { false, true, true, false }, { false, true, false, false }, { false, true, false, false } };
            bool[,] square = new bool[4, 4] { { false, false, false, false }, { false, true, true, false }, { false, true, true, false }, { false, false, false, false } };

            //allocate the master array
            for (int i = 0; i<numShape; i++)
                BlockConfig[i] = new bool[4, 4];

            // assign each shape o the master shape array
            BlockConfig[0] = straightLine;
            BlockConfig[1] = leftThunder;
            BlockConfig[2] = rightThunder;
            BlockConfig[3] = triangle;
            BlockConfig[4] = rightL;
            BlockConfig[5] = leftL;
            BlockConfig[6] = square;
        }


        private Int32[] getColorSet()
        {
            Int32 blue = Convert.ToInt32("0xFF0000FF", 16);
            Int32 yellow = Convert.ToInt32("0xFFFFFF00", 16);
            Int32 green = Convert.ToInt32("0xFF008000", 16);
            Int32 beige = Convert.ToInt32("0xFFF5F5DC", 16);
            Int32 crimson = Convert.ToInt32("0xFFDC143C", 16);
            Int32 darkOrange = Convert.ToInt32("0xFFFF8C00", 16);
            Int32 darkViolet = Convert.ToInt32("0xFF9400D3", 16);

            Int32[] set = { blue, yellow, green, beige, crimson, darkOrange, darkViolet };

            return set;
        }

        #endregion
    }
}
