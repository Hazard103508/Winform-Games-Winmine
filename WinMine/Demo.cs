using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game.Elements;

namespace WinMine
{
    public partial class Demo : Game.Game
    {
        #region Objects
        private DateTime? _startTime;
        #endregion

        #region Constructor
        public Demo()
        {
            InitializeComponent();
            Initialize();

            Start_Game();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Recursos graficos del juego
        /// </summary>
        public Elements.Resources Resources { get; set; }
        /// <summary>
        /// Configuracion del juego
        /// </summary>
        public Elements.Config Config { get; set; }
        /// <summary>
        /// Grilla del juego
        /// </summary>
        public Elements.Board Board { get; set; }
        /// <summary>
        /// Inidica si el juego esta en curso
        /// </summary>
        public bool Playing { get; set; }
        #endregion

        #region Events
        private void btnLink_Click(object sender, EventArgs e)
        {
            base.Open_ZeroSoft_URL();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Start_Game();
        }
        private void btnConfig_Click(object sender, EventArgs e)
        {
            var form = new WinMine.Config(this.Config);
            if (form.ShowDialog() == DialogResult.OK)
                Start_Game();
        }
        private void Demo_Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (Playing)
            {
                Point _mouseLocation = new Point(e.Location.X, e.Location.Y);
                var cell_Location = new Point(e.Location.X / Config.Cell_Size.Width, e.Location.Y / Config.Cell_Size.Height);
                // Obtengo la coordenada del tablero donde se realizo click

                bool _isFlagButton = e.Button == MouseButtons.Right;
                this.Board.Click(cell_Location, _isFlagButton);

                if (!_startTime.HasValue)
                    _startTime = DateTime.Now;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Carga los recursos graficos del juego
        /// </summary>
        private void Initialize()
        {
            string directory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");
            this.Resources = new Elements.Resources()
            {
                Image_Block = Load_Image($"{directory}/Block.png"),
                Image_Flag = Load_Image($"{directory}/Flag.png"),
                Image_Mine = Load_Image($"{directory}/Mine.png"),
                Image_Number0 = Load_Image($"{directory}/Number_0.png"),
                Image_Number1 = Load_Image($"{directory}/Number_1.png"),
                Image_Number2 = Load_Image($"{directory}/Number_2.png"),
                Image_Number3 = Load_Image($"{directory}/Number_3.png"),
                Image_Number4 = Load_Image($"{directory}/Number_4.png"),
                Image_Number5 = Load_Image($"{directory}/Number_5.png"),
                Image_Number6 = Load_Image($"{directory}/Number_6.png"),
                Image_Number7 = Load_Image($"{directory}/Number_7.png"),
                Image_Number8 = Load_Image($"{directory}/Number_8.png"),
            };

            Config = new Elements.Config();
        }
        /// <summary>
        /// Inicia una nueva partida
        /// </summary>
        private void Start_Game()
        {
            Playing = true;

            Board = new Elements.Board(Config, this.Resources); // carga la grilla
            Board.Match_Lose += (sender, e) =>
            {
                Playing = false;
                MessageBox.Show("Game Over", "Zero - Soft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            Board.Match_Won += (sender, e) =>
            {
                Playing = false;
                MessageBox.Show("You Win", "Zero - Soft", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            _startTime = null; // inicializa el tiempo del juego

            Point _gridSize = new Point(Config.Grid_Size.Width * Config.Cell_Size.Width, Config.Grid_Size.Height * Config.Cell_Size.Height);
            this.ClientSize = new Size(_gridSize.X, _gridSize.Y + pnlValues.Height);
        }
        #endregion

        #region Update
        protected override void Update()
        {
            if (Playing)
            {
                if (_startTime.HasValue)
                {
                    var time = DateTime.Now - _startTime;
                    txtTime.Text = time.Value.ToString("hh\\:mm\\:ss\\.ffff");
                }
                else
                    txtTime.Text = "00:00:00.0000";

                txtMines.Text = (Config.Mines - Board.Flags).ToString();
            }
        }
        #endregion

        #region Draw
        /// <summary>
        /// Dibuja la grilla
        /// </summary>
        /// <param name="drawHandler"></param>
        public override void Draw(DrawHandler drawHandler)
        {
            this.Board.Draw(drawHandler);
        }
        #endregion
    }
}
