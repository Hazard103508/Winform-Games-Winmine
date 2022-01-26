using Game.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMine.Elements
{
    public class Cell: Sprite
    {
        #region Constructor
        public Cell(Image image, Point position) : base(image, position)
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Estado de la celda
        /// </summary>
        public CellState State{ get; set; }
        /// <summary>
        /// Valor numerico de la celda
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// Indica si la celda pocee una mina
        /// </summary>
        public bool HasMine { get; set; }
        #endregion
    }

    public enum CellState
    {
        Covered,
        Flagged,
        Uncovered
    }
}
