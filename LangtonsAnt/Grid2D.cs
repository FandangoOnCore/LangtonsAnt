using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;

namespace LangtonsAnt
{
    /// <summary>
    /// Langton's ant grid controller class.
    /// </summary>
    internal class Grid2D
    {
        /// <summary>
        /// Colored grid.
        /// </summary>
        private Color[,] _grid;
        /// <summary>
        /// Size of the squared cells of the grid.
        /// </summary>
        private int _cellSize;
        /// <summary>
        /// Cell's default color.
        /// </summary>
        public Color CellDefaultColor { get; private set; } = Color.Transparent;
        /// <summary>
        /// Grid lines color.
        /// </summary>
        private Color _gridColor;
        /// <summary>
        /// Current position on the grid.
        /// </summary>
        private Point _currentPosition;
        /// <summary>
        /// Returns the coordinates of the center of the grid.
        /// </summary>
        public Point GridCenter
        {
            get { return new Point(_grid.GetLength(0) / 2, _grid.GetLength(1) / 2); }
        }
        /// <summary>
        /// Returns the current position on the grid.
        /// </summary>
        public Point CurrentPosition
        {
            get { return _currentPosition; }
        }
        /// <summary>
        /// Class initializer 0.
        /// </summary>
        public Grid2D(Size hostControlSize, int cellSize, Color gridColor)
        {
            _cellSize = cellSize;
            _grid = new Color[hostControlSize.Width / _cellSize, hostControlSize.Height / _cellSize];
            _gridColor = gridColor;
            ResetColors();
        }
        /// <summary>
        /// Class initializer 1.
        /// </summary>
        public Grid2D(Size hostControlSize, int cellSize, Color gridColor, Color defaultCellColor)
        {
            _cellSize = cellSize;
            _grid = new Color[hostControlSize.Width / _cellSize, hostControlSize.Height / _cellSize];
            _gridColor = gridColor;
            CellDefaultColor = defaultCellColor;
            ResetColors();
        }
        /// <summary>
        /// Resets the color of all the cells of the grid to default.
        /// </summary>
        public void ResetColors()
        {
            for (var i = 0; i < _grid.GetLength(0); i++)
            {
                for (var j = 0; j < _grid.GetLength(1); j++)
                {
                    _grid[i, j] = CellDefaultColor;
                }
            }
        }
        /// <summary>
        /// Returns the color of the cell at the coordinates given by the Point struct,
        /// null if the coordinates are out-of-bounds.
        /// </summary>
        public Color? GetCellColor(Point pos)
        {
            if (pos.X >= _grid.GetLength(0) || pos.Y >= _grid.GetLength(1) || pos.X < 0 || pos.Y < 0)
                return null;
            return _grid[pos.X, pos.Y];
        }
        /// <summary>
        /// Returns the color of the cell at the coordinates given by the parameters x and y,
        /// null if the coordinates are out-of-bounds.
        /// </summary>
        public Color? GetCellColor(int x, int y)
        {
            if (x >= _grid.GetLength(0) || y >= _grid.GetLength(1) || x < 0 || y < 0)
                return null;
            return _grid[x, y];
        }
        /// <summary>
        /// Sets the color of the cell at the coordinates given by the Point struct.
        /// </summary>
        public void SetCellColor(Point pos, Color color)
        {
            if (pos.X >= _grid.GetLength(0) || pos.Y >= _grid.GetLength(1) || pos.X < 0 || pos.Y < 0)
                return;
            _grid[pos.X, pos.Y] = color;
        }
        /// <summary>
        /// Sets the color of the cell at the coordinates given by the parameters x and y.
        /// </summary>
        public void SetCellColor(int x, int y, Color color)
        {
            if (x >= _grid.GetLength(0) || y >= _grid.GetLength(1) || x < 0 || y < 0)
                return;
            _grid[x, y] = color;
        }
        /// <summary>
        /// Sets the current position on the grid.
        /// Returns false if the specified position is out-of-bounds.
        /// </summary>
        public bool SetCurrentPosition(int x, int y)
        {
            if (x >= _grid.GetLength(0) || y >= _grid.GetLength(1) || x < 0 || y < 0)
                return false;
            _currentPosition = new Point(x, y);
            return true;
        }
        /// <summary>
        /// Sets the current position on the grid.
        /// Returns false if the specified position is out-of-bounds.
        /// </summary>
        public bool SetCurrentPosition(Point pos)
        {
            if (pos.X >= _grid.GetLength(0) || pos.Y >= _grid.GetLength(1) || pos.X < 0 || pos.Y < 0)
                return false;
            _currentPosition = new Point(pos.X, pos.Y);
            return true;
        }
        /// <summary>
        /// Updates the colors of the cells in the dictionary.
        /// </summary>
        public void FillCells(Graphics g, ConcurrentDictionary<Point, Color> cellsDictionary)
        {
            foreach (var cell in cellsDictionary)
            {
                var xCoord = cell.Key.X * _cellSize;
                var yCoord = cell.Key.Y * _cellSize;
                using (var brush = new SolidBrush(cell.Value))
                {
                    g.FillRectangle(brush, xCoord + 1, yCoord + 1, _cellSize - 1, _cellSize - 1);
                } 
            }
        }
        /// <summary>
        /// Draws the grid.
        /// </summary>
        public void DrawGrid(Graphics g)
        {
            using (var p = new Pen(_gridColor))
            {
                for (int y = 0; y <= _grid.GetLength(1); ++y)
                    g.DrawLine(p, 0, y * _cellSize, _grid.GetLength(0) * _cellSize, y * _cellSize);

                for (int x = 0; x <= _grid.GetLength(0); ++x)
                    g.DrawLine(p, x * _cellSize, 0, x * _cellSize, _grid.GetLength(1) * _cellSize);
            }
        }
    }
}
