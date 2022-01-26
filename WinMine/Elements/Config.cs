using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMine.Elements
{
    public class Config
    {
        #region Constructor
        public Config()
        {
            Mines = 20;
            Grid_Size = new Size(15, 20);
            Cell_Size = new Size(20, 20);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Tamaño de cada celda
        /// </summary>
        public Size Cell_Size { get; set; }
        /// <summary>
        /// Minas que tendra la partida
        /// </summary>
        public int Mines { get; set; }
        /// <summary>
        /// Tamaño del de la grilla
        /// </summary>
        public Size Grid_Size { get; set; }
        #endregion
    }
}
