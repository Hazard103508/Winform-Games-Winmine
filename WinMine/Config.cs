using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMine
{
    public partial class Config : Game.Base
    {
        #region Constructor
        public Config(Elements.Config config)
        {
            InitializeComponent();
            this.ConfigInfo = config;

            txtWidth.Value = config.Grid_Size.Width;
            txtHeight.Value = config.Grid_Size.Height;
            txtMines.Value = config.Mines;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Configuracion del juego
        /// </summary>
        public Elements.Config ConfigInfo { get; set; }
        #endregion

        #region Events
        private void txtWidth_ValueChanged(object sender, EventArgs e)
        {
            Set_MaxMines();
        }

        private void txtHeight_ValueChanged(object sender, EventArgs e)
        {
            Set_MaxMines();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            ConfigInfo.Grid_Size = new Size((int)txtWidth.Value,(int)txtHeight.Value);
            ConfigInfo.Mines = (int)txtMines.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Asigna el valor maximo que 
        /// </summary>
        private void Set_MaxMines()
        {
            txtMines.Maximum = txtWidth.Value * txtHeight.Value;
        }
        #endregion
    }
}
