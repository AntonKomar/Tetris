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
    class TetrisBoard : Board
    {
        #region Variables

        [DataMember]
        private readonly Coordinate coord;
        [DataMember]
        private Level level;
        [DataMember]
        public int RowsCompleted { get; private set; }
        [DataMember]
        public Block CurrentBlock { get; private set; }

        #endregion Variables

        public TetrisBoard() { }

        public TetrisBoard(ref Level level)
        {
            RowsCompleted = 0;
            this.level = level; 
            CurrentBlock = new Block();
            coord = new Coordinate(0, 0);
            ColorCodeBoard();
        }

        #region Methods

        /// <summary>
        /// board timer
        /// </summary>
        public bool OnTick()
        {
            if ( CurrentBlock.currBlock == null || !CanDrop())
            {
                SpawnNewBlock();
                return isFirstMovePossible();
            }
            LowerCurrentBlock();
            CheckFullRows();
            return true;
        }

        /// <summary>
        /// Check if a row is full
        /// </summary>
        /// <param name="currentRow"></param>
        public bool IsFullRow(int currentRow)
        {
            for (int col = 0; col < numCols; col++)
            {
                if (grid[currentRow, col] == boardColor)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Check all the board rows for completion
        /// </summary>
        private void CheckFullRows()
        {
            int numCompleted = 0;
            int rowPoints = level.CurrentLevel * 100;
            int rowBonus = level.CurrentLevel * 50;
            for (int row = 0; row < numRows; row++)
            {
                if (IsFullRow(row))
                {
                    RemoveRow(row);
                    numCompleted++;
                }
            }
            if (numCompleted > 0)
            {
                level.ScoreUp(numCompleted, rowPoints, rowBonus);
                UpdateRowsAndLevel(numCompleted);
            }
        }

        /// <summary>
        /// Removes a completed row
        /// </summary>
        /// <param name="removedRow"></param>
        public void RemoveRow(int removedRow)
        {
            for (int row = removedRow; row > 0; row--)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (row - 1 <= 0)
                        grid[row, col] = boardColor;
                    else
                        grid[row, col] = grid[row - 1, col];
                }
            }
        }

        /// <summary>
        /// spawn the next tetromino 
        /// </summary>
        private void SpawnNewBlock()
        {
            // lock the last falling block where it fell
            lockLastBlock();
            CurrentBlock.getNextBlock();
        }

        public bool isFirstMovePossible()
        {
            if (CanDrop())
                return true;
            return false;
        }

        public void LowerCurrentBlock()
        {
            if (CanDrop())
                CurrentBlock.y++;
        }

        /// <summary>
        /// Lock the last played block into position once it is done moving
        /// </summary>
        private void lockLastBlock()
        {
            if (CurrentBlock.currBlock != null)
            {
                Coordinate c = null;
                int dim = 4;

                for (int row = 0; row < dim; row++)
                {
                    for (int col = 0; col < dim; col++)
                    {
                        if (CurrentBlock.currBlock[row, col])
                        {
                            c = CurrentBlock.toBoardCoord(new Coordinate(col, row));
                            grid[c.y, c.x] = CurrentBlock.blockColor;
                        }
                    }
                }
            }           
        }

        /// <summary>
        /// Move the current block left if possible
        /// </summary>
        public void MoveCurrentBlockLeft()
        {
            if (CanMoveSideWays(true))
                CurrentBlock.x--;
        }

        /// <summary>
        /// Moves the current block right if possible
        /// </summary>
        public void MoveCurrentBlockRight()
        {
            if (CanMoveSideWays(false))
                CurrentBlock.x++;
        }

        /// <summary>
        /// Rotate the current block counter clockwise if possible
        /// </summary>
        public void rotateCurrentBlockCounterClockwise()
        {
            if (CanRotate(false))
                CurrentBlock.rotateCounterClockwise();
        }

        /// <summary>
        /// Rotate the current block clockwise if possible
        /// </summary>
        public void rotateCurrentBlockClockwise()
        {
            if (CanRotate(true))
                CurrentBlock.rotateClockwise();
        }

        /// <summary>
        /// Returns true if the current block can move sideways else false
        /// </summary>
        /// <param name="left"></param>
        /// <returns></returns>
        private bool CanMoveSideWays(bool left)
        {
            bool isMoveable = true;
            Block whenMoved = CurrentBlock.Clone();
            if (left)
                whenMoved.x--;
            else
                whenMoved.x++;

            if (!CanBeThere(whenMoved))
                isMoveable = false;

            return isMoveable;
        }

        /// <summary>
        /// Returns true if the current block can rotate else false
        /// </summary>
        /// <param name="clockwise"></param>
        /// <returns></returns>
        private bool CanRotate(bool clockwise)
        {
            bool isRotatable = true;
            Block whenRotated = CurrentBlock.Clone();

            if (clockwise)
                whenRotated.rotateClockwise();
            else
                whenRotated.rotateCounterClockwise();

            if (!CanBeThere(whenRotated))
                isRotatable = false;

            return isRotatable;
        }

        /// <summary>
        /// Returns true if the current block can drop one row down else false
        /// </summary>
        /// <returns></returns>
        private bool CanDrop()
        {
            bool canDrop = true;
            Block ifDropped = CurrentBlock.Clone();
            ifDropped.y++;

            if (!CanBeThere(ifDropped))
                canDrop = false;
            return canDrop;
        }

        /// <summary>
        /// Returns true if the current block is allowed to make its next move else false
        /// </summary>
        /// <param name="ablock"></param>
        /// <returns></returns>
        private bool CanBeThere(Block ablock)
        {
            bool isMoveable = true;
            int dim = 4;

            for (int row = 0; row < dim; row++)
            {
                for (int col = 0; col < dim; col++)
                {
                    if (ablock.currBlock[row, col])
                    {
                        Coordinate c = ablock.toBoardCoord(new Coordinate(col, row));
                        if (IsOccupiedCell(c) || c.x >= numCols || c.x < 0 || c.y >= numRows)
                            isMoveable = false;
                    }
                }
            }
            return isMoveable;
        }

        /// <summary>
        /// Returns true if a cell is occupied otherwise false
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool IsOccupiedCell(Coordinate c)
        {
            if (c.x < numCols && c.x >=0 && c.y < numRows && c.y >= 0 && grid[c.y, c.x] == boardColor)
                return false;
            return true;
        }

        

        private void UpdateRowsAndLevel(int numCompleted)
        {
            for (int i = 0; i < numCompleted; i++)
            {
                RowsCompleted++;
                if (RowsCompleted % 10 == 0)
                {
                    level.IncreaseGameLevel();
                }
            }
        }

        

        /// <summary>
        /// Gives the empty board its basic color
        /// </summary>
        private void ColorCodeBoard()
        {
            boardColor = Convert.ToInt32("FF4682B4", 16);
            for (int i = 0; i < numRows; i++ )
            {
                for (int j = 0; j < numCols; j++)
                {
                    grid[i, j] = boardColor;
                }
            }
        }

        #endregion
    }
}
