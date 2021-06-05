using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace Tetris
{
    /// <summary>
    /// Main form for the Tetris game
    /// </summary>
    public partial class Tetris : Form, ISerializable
    {
        #region Variables

        private bool playing { get; set; }
        private static int cellSize = 31;
        private static int numRows = 18;
        private static int numCols = 10;
        private int currentTickInterval;
        private int currentLevel;
        private bool paused;
        private int highScore;
        private Level level;
        private TetrisBoard board;
        private KeyboardInput input = new KeyboardInput();
        private Dictionary<string, Cell> boardCells = new Dictionary<string, Cell>();
        private WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        #endregion Variables

        #region Methods
        /// <summary>
        /// Default contructor for the Tetris class
        /// </summary>
        public Tetris()
        {
            InitializeComponent();
            DoubleBuffered = true;
            level = new Level();
            board = new TetrisBoard(ref level);
            highScore = 0;
            textBoxHighScore.Text = highScore.ToString();
            currentTickInterval = level.BaseTickInterval;
            currentLevel = level.CurrentLevel;
            paused = false;
            DrawBackgroundBoard();
            wplayer.URL = "tetris.mp3";
            wplayer.settings.setMode("loop", true);
            wplayer.settings.volume = 20;
        }

        /// <summary>
        /// Draws the empty Tetris board
        /// </summary>
        private void DrawBackgroundBoard()
        {
            foreach (KeyValuePair<string, Cell> c in boardCells)
            {
                c.Value.Dispose();
            }
            boardCells.Clear();

            for ( int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    Cell cell = new Cell(row, col);
                    cell.Parent = gameGrid;
                    cell.Top = row * cellSize;
                    cell.Left = col * cellSize;
                    boardCells.Add(CellKey(row, col), cell);
                }
            }    
        }

        /// <summary>
        /// Creates a string value from 2 int
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private string CellKey(int row, int col)
        {
            return row.ToString() + ", " + col.ToString();
        }

        /// <summary>
        /// Resets the game
        /// </summary>
        private void Reset()
        {
            ResetTextFields();
            level = new Level();
            board = new TetrisBoard(ref level);
            currentLevel = level.CurrentLevel;
            paused = false;
            playing = true;
            tickTimer.Interval = level.BaseTickInterval;
            tickTimer.Enabled = true;            
        }

        private void ResetTextFields()
        {
            textBoxScore.Text = "0";
            textBoxRowsCompleted.Text = "0";
            labelGameOver.Text = "";
        }

        /// <summary>
        /// Updates the different text fields in the game
        /// </summary>
        private void UpdateTextFields()
        {
            textBoxScore.Text = level.Score.ToString();
            textBoxRowsCompleted.Text = board.RowsCompleted.ToString();
            textBoxLevel.Text = level.CurrentLevel.ToString();           
        }

        /// <summary>
        /// Checks for level up and increases the game speed
        /// </summary>
        private void CheckLevelUp()
        {
            if (level.CurrentLevel > currentLevel)
            {
                currentLevel = level.CurrentLevel;
                
                tickTimer.Interval = level.BaseTickInterval;
                currentTickInterval = tickTimer.Interval;
            }
        }

        /// <summary>
        /// Redraws the board from its current state
        /// </summary>
        private void UpdateGameBoard()
        {
            Cell cell;
            for ( int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    boardCells.TryGetValue(CellKey(row, col), out cell);
                    cell.CellColor = board.grid[row, col];
                }
            }
            Block block = board.CurrentBlock;
            for (int row = 0; row < block.currBlock.GetLength(0); row++)
            {
                for (int col = 0; col < block.currBlock.GetLength(1); col++)
                {
                    Coordinate c = new Coordinate(col, row);
                    c = block.toBoardCoord(c);
                    if (block.currBlock[row, col] && c.x >= 0 && c.x < numCols && c.y < numRows)
                    {
                        boardCells.TryGetValue(CellKey(c.y, c.x), out cell);

                        cell.CellColor = block.blockColor;
                    }
                }
            }
        }

        /// <summary>
        /// Takes the appropriate actions when the game is over
        /// </summary>
        private void GameOver()
        {
            tickTimer.Enabled = false;
            playing = false;
            labelGameOver.Text = "YOU LOSE!";
            if (level.Score > highScore)
            {
                highScore = level.Score;
                textBoxHighScore.Text = highScore.ToString();
            }
        }

        /// <summary>
        /// Pauses the game
        /// </summary>
        private void PauseGame()
        {
            if (paused == false)
            {
                tickTimer.Enabled = false;
                playing = false;
                paused = true;
            }
        }

        /// <summary>
        /// Resumes the game
        /// </summary>
        private void ResumeGame()
        {
            if (paused == true)
            {
                tickTimer.Enabled = true;
                playing = true;
                paused = false;
            }
        }

        #endregion

        #region Serialization methods

        /// <summary>
        /// Saves a game
        /// </summary>
        public void SaveGame()
        {
            Stream outstream;
            BinaryFormatter bin_format = new BinaryFormatter();
            SaveFileDialog save_dialog = new SaveFileDialog();
            ArrayList list = new ArrayList();
            //gather objects to be serialized
            list.Add(board);
            //set save window information
            save_dialog.Filter = "Tetris Game file (*.trs)|*.trs|All files (*.*)|*.*";
            save_dialog.FilterIndex = 1;
            save_dialog.RestoreDirectory = true;
            //serialize objects
            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                if ((outstream = save_dialog.OpenFile()) != null)
                {
                    bin_format.Serialize(outstream, list);
                    outstream.Close();
                }
            }       
        }

        /// <summary>
        /// Loads a game
        /// </summary>
        public void LoadGame()
        {
            Stream instream;
            BinaryFormatter bin_format = new BinaryFormatter();
            OpenFileDialog open_dialog = new OpenFileDialog();
            ArrayList list;
            //deserialize objects
            if (open_dialog.ShowDialog() == DialogResult.OK)
                if ((instream = open_dialog.OpenFile()) != null)
                {
                    list = (ArrayList)bin_format.Deserialize(instream);
                    instream.Close();
                    //set up objects
                    board = (TetrisBoard)list[0];
                }
            UpdateGameBoard();
            PauseGame();
        }

        public void SaveGameJSON()
        {
            Stream instream;
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ArrayList));
            SaveFileDialog save_dialog = new SaveFileDialog();
            ArrayList list = new ArrayList();
            //gather objects to be serialized
            list.Add(board);
            //set save window information
            save_dialog.Filter = "Tetris Game file (*.json)|*.json";
            save_dialog.FilterIndex = 1;
            save_dialog.RestoreDirectory = true;
            //serialize objects
            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                if ((instream = save_dialog.OpenFile()) != null)
                {
                    jsonFormatter.WriteObject(instream, list);
                    instream.Close();
                }
            }
        }

        public void LoadGameJSON()
        {
            Stream instream;
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ArrayList));
            OpenFileDialog open_dialog = new OpenFileDialog();
            ArrayList list;
            open_dialog.Filter = "Tetris Game file (*.json)|*.json";
            open_dialog.FilterIndex = 1;
            //deserialize objects
            if (open_dialog.ShowDialog() == DialogResult.OK)
                if ((instream = open_dialog.OpenFile()) != null)
                {
                    list = (ArrayList)jsonFormatter.ReadObject(instream); ;
                    instream.Close();
                    //set up objects
                    board = (TetrisBoard)list[0];
                }
            UpdateGameBoard();
            PauseGame();
        }

        public void SaveGameXML()
        {
            Stream instream;
            XmlSerializer xml_format = new XmlSerializer(typeof(ArrayList));
            SaveFileDialog save_dialog = new SaveFileDialog();
            ArrayList list = new ArrayList();
            //gather objects to be serialized
            list.Add(board);
            //set save window information
            save_dialog.Filter = "Tetris Game file (*.xml)|*.xml";
            save_dialog.FilterIndex = 1;
            save_dialog.RestoreDirectory = true;
            //serialize objects
            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                if ((instream = save_dialog.OpenFile()) != null)
                {
                    xml_format.Serialize(instream, list);
                    instream.Close();
                }
            }
        }

        public void LoadGameXML()
        {
            Stream instream;
            XmlSerializer xml_format = new XmlSerializer(typeof(ArrayList));
            OpenFileDialog open_dialog = new OpenFileDialog();
            ArrayList list;
            open_dialog.Filter = "Tetris Game file (*.xml)|*.xml";
            open_dialog.FilterIndex = 1;
            //deserialize objects
            if (open_dialog.ShowDialog() == DialogResult.OK)
                if ((instream = open_dialog.OpenFile()) != null)
                {
                    list = (ArrayList)xml_format.Deserialize(instream);
                    instream.Close();
                    //set up objects
                    board = (TetrisBoard)list[0];
                }
            UpdateGameBoard();
            PauseGame();
        }

        #endregion

        #region Event methods

        /// <summary>
        /// Game timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tickTimer_Tick(object sender, EventArgs e)
        {
            if (playing)
            {
                if (!board.OnTick())
                {
                    GameOver();
                }
                UpdateGameBoard();
                UpdateTextFields();
                CheckLevelUp();
            }
        }

        /// <summary>
        /// Starts the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveGame();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadGame();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            PauseGame();
        }

        private void buttonResume_Click(object sender, EventArgs e)
        {
            ResumeGame();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Tetris_KeyUp(object sender, KeyEventArgs e)
        {
            if (playing)
            {
                if (input.SpaceKeyPressed)
                    board.LowerCurrentBlock();
                if (input.LeftKeyPressed)
                    board.MoveCurrentBlockLeft();
                if (input.RightKeyPressed)
                    board.MoveCurrentBlockRight();
                if (input.UpKeyPressed)
                    board.rotateCurrentBlockCounterClockwise();
                if (input.DownKeyPressed)
                    board.rotateCurrentBlockClockwise();
                UpdateGameBoard();
            }     
            input.evaluateKey(e.KeyCode, false);
        }

        private void Tetris_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (playing)
            {
                if (input.SpaceKeyPressed)
                {
                    board.LowerCurrentBlock();
                    e.Handled = true;
                    UpdateGameBoard();
                }   
            }
        }

        private void Tetris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && playing)
                input.evaluateKey(e.KeyCode, true); e.Handled = true;
        }

        private void Tetris_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        /// <summary>
        /// Processes the different keys used to play the game
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {            
            switch (keyData)
            {
                case Keys.Home:
                    level.IncreaseGameLevel();
                    return true;
                case (Keys.Control | Keys.P):
                    PauseGame();
                    return true;
                case (Keys.Control | Keys.G):
                    ResumeGame();
                    return true;
                //case (Keys.Alt | Keys.S):
                    //this.reset();
                    //return true;
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    input.evaluateKey(keyData, true);
                    return true;
            } 
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMute.Checked == false)
                wplayer.controls.play();
            else
                wplayer.controls.stop();
        }

        private void toolStripMenuItemHowToPlay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Controls: Use Left & Right Arrow Keys to move sideways\n"
                + "Use Up & Down arrow keys to rotate\n"
                + "Press Space to drop the block\n"
                + "\t\tEnjoy!", "How to Play", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItemAboutDev_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Just Another Lost Soul in a vast Ocean of Bits", "Who Am I?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
