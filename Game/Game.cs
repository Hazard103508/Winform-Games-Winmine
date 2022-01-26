using Game.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Game : Base
    {
        #region Objects
        /// <summary>
        /// Timer que refresca la imagen del juego
        /// </summary>
        private Timer _timer;

        /// <summary>
        /// Evento que se desencadena al liberar el boton del mouse sobre el lienzo
        /// </summary>
        public event EventHandler<MouseEventArgs> Canvas_MouseUp;
        #endregion

        #region Constructor
        public Game()
        {
            InitializeComponent();

            _timer = new Timer();
            _timer.Interval = 1000 / 60; // 60 PFS 
            _timer.Tick += (sender, e) =>
            {
                this.Update();  // ejecuta logica propia del juego

                using (DrawHandler drawHandler = new DrawHandler(this.Canvas.Width, this.Canvas.Height))
                {
                    this.Draw(drawHandler);    // Actualiza la imagen en cada cuadro
                    Canvas.Image = drawHandler.BaseImage; // asigna la imagen del nuevo cuadro al picture box
                }
            };

            _timer.Start(); // inicia el juego
        }
        #endregion

        #region Events
        private void pcCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (Canvas_MouseUp != null)
                Canvas_MouseUp(sender, e);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Carga una imagen 
        /// </summary>
        /// <param name="path">ruta de la imagen a cargar</param>
        /// <returns></returns>
        protected Image Load_Image(string path)
        {
            try
            {
                return Image.FromFile(path);
            }
            catch
            {
                MessageBox.Show("Load File Error\n" + path);
                return null;
            }
        }
        /// <summary>
        /// Metodo que donde se escribe la logica del juego
        /// </summary>
        protected new virtual void Update()
        {
        }
        /// <summary>
        /// Dibuja todos los sprites en pantalla
        /// </summary>
        /// <param name="drawHandler">controlador de dibujado</param>
        public virtual void Draw(DrawHandler drawHandler)
        {
        }
        #endregion
    }
}
