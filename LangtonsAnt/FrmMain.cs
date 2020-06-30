using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace LangtonsAnt
{
    /// <summary>
    /// Icons made by https://www.flaticon.com/authors/freepik.
    /// </summary>
    public partial class FrmMain : Form
    {
        /// <summary>
        /// Grid cell size.
        /// </summary>
        private const int GRID_CELL_SIZE = 6;
        /// <summary>
        /// Wait time between two steps of the ant.
        /// </summary>
        private const int ANT_STEP_TIME_MS = 40;
        /// <summary>
        /// Grid controller object.
        /// </summary>
        private Grid2D _grid;
        /// <summary>
        /// Backgroundworker used to calculate the ant's path.
        /// </summary>
        private BackgroundWorker _antBw;
        /// <summary>
        /// Pause/resume the ant's path generation.
        /// </summary>
        private bool _pause;
        /// <summary>
        /// Stores the ant's path.
        /// </summary>
        private ConcurrentDictionary<Point, Color> _antPath = new ConcurrentDictionary<Point, Color>();
        /// <summary>
        /// Ant's current direction.
        /// </summary>
        private Direction _currentDirection = Direction.South;
        /// <summary>
        /// Delegate definition for the label update function.
        /// </summary>
        private delegate void UpdateLabelText(Label label, string text);
        /// <summary>
        /// Class initializer.
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// FrmMain Load event handler.
        /// </summary>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Create a new instance of the grid controller.
            _grid = new Grid2D(PbxGrid.Size, GRID_CELL_SIZE, Color.Gray, Color.White);
            // Create a new instance of the bw.
            _antBw = new BackgroundWorker()
            {
                WorkerReportsProgress = false,
                WorkerSupportsCancellation = true
            };
            // Subscription to the DoWork event.
            _antBw.DoWork += _antBw_DoWork;
            // Subscription to the RunWorkerCompleted event.
            _antBw.RunWorkerCompleted += _antBw_RunWorkerCompleted;
        }
        /// <summary>
        /// RunWorkerCompleted event handler.
        /// </summary>
        private void _antBw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {   
                // If cancelled by the user, clear the screen.
                _antPath.Clear();
                _grid.ResetColors();
            }
            // Remove the paused status.
            _pause = false;
            // Refresh the screen.
            PbxGrid.Invalidate();
            // Reset the start button text.
            BtnStart.Text = "Start";
        }
        /// <summary>
        /// DoWork event handler.
        /// </summary>
        private void _antBw_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get a reference to the bw.
            var bw = sender as BackgroundWorker;
            // Set the current position on the grid in the center.
            _grid.SetCurrentPosition(_grid.GridCenter);

            do
            {
                while (_pause && !bw.CancellationPending)
                {
                    // If paused, just wait and do nothing.
                    Thread.Sleep(ANT_STEP_TIME_MS);
                }
                // Check if user requested to stop.
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                // Wait for ANT_STEP_TIME_MS before the next step.
                Thread.Sleep(ANT_STEP_TIME_MS);
                // Get the ant's current position on the grid.
                var currentPosition = _grid.CurrentPosition;
                // Get the color of the current cell.
                var currentCellColor = _grid.GetCellColor(currentPosition);
                // If no color is returned, we are out of bounds. 
                // Exit without cancelling.
                if (!currentCellColor.HasValue) break;
                
                if (currentCellColor == _grid.CellDefaultColor)
                {
                    // Cell color flip.
                    _grid.SetCellColor(currentPosition, Color.Green);
                    // Save the current position in the path dictionary.
                    if (_antPath.ContainsKey(currentPosition))
                        _antPath[currentPosition] = Color.Green;
                    else
                        _antPath.TryAdd(currentPosition, Color.Green);
                    // Rotate the ant 90 degree clockwise.
                    switch (_currentDirection)
                    {
                        case Direction.North:
                            _currentDirection = Direction.East;
                            currentPosition.X++;
                            break;

                        case Direction.East:
                            _currentDirection = Direction.South;
                            currentPosition.Y++;
                            break;

                        case Direction.South:
                            _currentDirection = Direction.West;
                            currentPosition.X--;
                            break;

                        case Direction.West:
                            _currentDirection = Direction.North;
                            currentPosition.Y--;
                            break;
                    }
                }
                else
                {
                    // Cell color flip.
                    _grid.SetCellColor(currentPosition, _grid.CellDefaultColor);
                    // Save the current position in the path dictionary.
                    if (_antPath.ContainsKey(currentPosition))
                        _antPath[currentPosition] = _grid.CellDefaultColor;
                    else
                        _antPath.TryAdd(currentPosition, _grid.CellDefaultColor);
                    // Rotate the ant 90 degree counter-clockwise.
                    switch (_currentDirection)
                    {
                        case Direction.North:
                            _currentDirection = Direction.West;
                            currentPosition.X--;
                            break;

                        case Direction.East:
                            _currentDirection = Direction.North;
                            currentPosition.Y--;
                            break;

                        case Direction.South:
                            _currentDirection = Direction.East;
                            currentPosition.X++;
                            break;

                        case Direction.West:
                            _currentDirection = Direction.South;
                            currentPosition.Y++;
                            break;
                    }
                }
                // Set the ant's new position on the grid.
                if (!_grid.SetCurrentPosition(currentPosition))
                {
                    // If false is returned, we are out of bounds. 
                    // Exit without cancelling.
                    break;
                }
                // Update the steps label.
                UpdateLabel(LblSteps, string.Format("Steps: {0}", _antPath.LongCount()));
                // Call invalidate to update the screen.
                PbxGrid.Invalidate();
            }
            while (true);
        }
        /// <summary>
        /// Updates the text of a label from a different thread.
        /// </summary>
        private void UpdateLabel(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                var d = new UpdateLabelText(UpdateLabel);
                label.Invoke(d, new object[] { label, text });
            }
            else
            {
                label.Text = text;
            }
        }
        /// <summary>
        /// BtnStart Click event handler.
        /// </summary>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            switch (BtnStart.Text)
            {
                case "Start":
                    {
                        if (!_antBw.IsBusy)
                        {
                            // Update the steps label.
                            UpdateLabel(LblSteps, "Steps: 0");
                            _antPath.Clear();
                            _grid.ResetColors();
                            _antBw.RunWorkerAsync();
                            BtnStart.Text = "Pause";
                        }
                    }
                    break;

                case "Pause":
                    {
                        _pause = true;
                        BtnStart.Text = "Resume";
                    }
                    break;

                case "Resume":
                    {
                        _pause = false;
                        BtnStart.Text = "Pause";
                    }           
                    break;
            }
        }
        /// <summary>
        /// BtnStopReset Click event handler.
        /// </summary>
        private void BtnStopReset_Click(object sender, EventArgs e)
        {
            _antBw.CancelAsync();
        }
        /// <summary>
        /// BtnExit Click event handler.
        /// </summary>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            _antBw.CancelAsync();
            Application.Exit();
        }
        /// <summary>
        /// PbxGrid Paint event handler.
        /// </summary>
        private void PbxGrid_Paint(object sender, PaintEventArgs e)
        {
            // Set the background color of the grid.
            PbxGrid.BackColor = _grid.CellDefaultColor;
            // Redraws the grid.
            _grid.DrawGrid(e.Graphics);
            // Fills the cells of the ant's path.
            _grid.FillCells(e.Graphics, _antPath);
        }
    }
}
