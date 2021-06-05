using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Tetris
{
    [Serializable]
    [DataContract]
    class Level
    {
        #region Fields and Properties

        [DataMember]
        public int CurrentLevel { get; private set; }
        [DataMember]
        public int Score { get; private set; }
        [DataMember]
        public int BaseTickInterval { get; private set; }

        #endregion
        
        public Level()
        {
            Score = 0;
            CurrentLevel = 1;
            BaseTickInterval = 500;
        }

        #region Methods

        /// <summary>
        /// Increases the game level and speed when the Home key is pressed
        /// </summary>
        public void IncreaseGameLevel()
        {
            CurrentLevel++;
            BaseTickInterval = (int)(BaseTickInterval * 0.75);
        }
        
        public void ScoreUp(int numCompleted, int rowPoints, int rowBonus)
        {
            Score += numCompleted * rowPoints + ((numCompleted - 1) * rowBonus);
        }

        #endregion
    }
}
