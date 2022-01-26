using Game.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMine.Elements
{
    public class Board : Sprite
    {
        #region Events
        public event EventHandler Match_Won;
        public event EventHandler Match_Lose;
        #endregion

        #region Objects
        /// <summary>
        /// Coordenadas de la grilla a descubrir por el jugador
        /// </summary>
        private List<Point> _availableLocations;
        #endregion

        #region Constructor
        public Board(Elements.Config config, Elements.Resources resources) : base(null, Point.Empty)
        {
            this.Config = config;
            this.Resources = resources;

            Load_Match();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Cantidad de banderas en la grilla
        /// </summary>
        public int Flags { get; set; }
        /// <summary>
        /// Configuracion de la partida
        /// </summary>
        private Elements.Config Config { get; set; }
        /// <summary>
        /// Matris de celdas
        /// </summary>
        private Cell[,] Matrix { get; set; }
        /// <summary>
        /// Recursos graficos
        /// </summary>
        private Elements.Resources Resources { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Carga una nuvea partida 
        /// </summary>
        private void Load_Match()
        {
            // Creo la matriz a dibujar
            Matrix = new Cell[Config.Grid_Size.Width, Config.Grid_Size.Height];
            _availableLocations = new List<Point>();

            for (int x = 0; x < Config.Grid_Size.Width; x++)
                for (int y = 0; y < Config.Grid_Size.Height; y++)
                {
                    Point _position = new Point(x * Config.Cell_Size.Width, y * Config.Cell_Size.Height);
                    Matrix[x, y] = new Cell(Resources.Image_Block, _position);
                    // Crea un bloque nuevo
                    _availableLocations.Add(new Point(x, y));
                }


            Random r = new Random(DateTime.Now.Millisecond);
            // Defino la ubicacion de las minas al azar
            for (int i = 0; i < Config.Mines; i++)
            {
                int index = r.Next(0, _availableLocations.Count); // obtiene una posicion aleatoria de la grilla para ubicar la mina

                var location = _availableLocations[index];
                Matrix[location.X, location.Y].HasMine = true; // marco la mina
                _availableLocations.Remove(location); // borro la cooredanada de las lista de coordenadas disponibles

                // Sumo en 1 el valor de cada celda alrededor de la mina
                Add_CellValue(new Point(location.X - 1, location.Y - 1));
                Add_CellValue(new Point(location.X, location.Y - 1));
                Add_CellValue(new Point(location.X + 1, location.Y - 1));
                Add_CellValue(new Point(location.X - 1, location.Y));
                Add_CellValue(new Point(location.X + 1, location.Y));
                Add_CellValue(new Point(location.X - 1, location.Y + 1));
                Add_CellValue(new Point(location.X, location.Y + 1));
                Add_CellValue(new Point(location.X + 1, location.Y + 1));

                // de esta manera cada mina cercana a las celdas aumentara en 1 el valor
            }
        }
        /// <summary>
        /// Agrega en 1 al valor de la celda
        /// </summary>
        /// <param name="location">Corredanda de la celda a agregar valor numerico</param>
        private void Add_CellValue(Point location)
        {
            if (location.X < 0 || location.X >= Config.Grid_Size.Width)
                return;

            if (location.Y < 0 || location.Y >= Config.Grid_Size.Height)
                return;

            var cell = Matrix[location.X, location.Y];
            if (!cell.HasMine)
                cell.Value++;
        }
        /// <summary>
        /// Selecciona una celda de la grilla
        /// </summary>
        /// <param name="location">Coordenada de la celda a seleccionar</param>
        /// <param name="_isFlagButton">Indica si se quiere marcar la celda con una Bandera</param>
        public void Click(Point location, bool _isFlagButton)
        {
            if (location.X < Config.Grid_Size.Width && location.Y < Config.Grid_Size.Height)
            {
                var cell = this.Matrix[location.X, location.Y];
                if (cell.State == CellState.Uncovered)
                    return;
                else if (cell.State == CellState.Covered)
                {
                    if (_isFlagButton)
                    {
                        cell.State = CellState.Flagged; // asigna una bandera
                        Update_CellImage(cell); // actualiza la imagen
                        Flags++;
                    }
                    else
                    {
                        Spread_Selection(location); // descubre la celda seleccionada y las cercanas en caso de que corresponda

                        if (cell.HasMine)
                            Match_Lose(this, null); // al descubrir la mina finaliza el juego
                        else
                        {
                            if (!_availableLocations.Any())
                                Match_Won(this, null); // si no quedan celdas a descubir se da por ganada la partida
                        }
                    }
                }
                else if (cell.State == CellState.Flagged)
                {
                    if (_isFlagButton)
                    {
                        cell.State = CellState.Covered; // quita la bandera
                        Update_CellImage(cell); // actualiza la imagen
                        Flags--;
                    }
                }
            }
        }
        /// <summary>
        /// Propaga la seleccion para descubrir celdas vacias
        /// </summary>
        /// <param name="location">Posicion inicial seleccionada</param>
        private void Spread_Selection(Point location)
        {
            if (location.X < 0 || location.X >= Config.Grid_Size.Width) // coordenada fuera de rango
                return;

            if (location.Y < 0 || location.Y >= Config.Grid_Size.Height) // coordenada fuera de rango
                return;

            var cell = this.Matrix[location.X, location.Y];
            if (cell.State != CellState.Covered)
                return;

            _availableLocations.Remove(location); // quita la coordenada de la lista de celdas pendientes a descubrir
            cell.State = CellState.Uncovered;
            Update_CellImage(cell); // actualiza la imagen

            if (cell.HasMine) // la celda tiene una mina
                return;

            if (cell.Value == 0) // si la celda esta vacia propaga la seleccion a las celdas cercanas
            {
                Spread_Selection(new Point(location.X - 1, location.Y - 1));
                Spread_Selection(new Point(location.X, location.Y - 1));
                Spread_Selection(new Point(location.X + 1, location.Y - 1));
                Spread_Selection(new Point(location.X - 1, location.Y));
                Spread_Selection(new Point(location.X + 1, location.Y));
                Spread_Selection(new Point(location.X - 1, location.Y + 1));
                Spread_Selection(new Point(location.X, location.Y + 1));
                Spread_Selection(new Point(location.X + 1, location.Y + 1));
            }
        }
        /// <summary>
        /// actualiza la imagen de la celda
        /// </summary>
        /// <param name="cell">Celda a actualizar</param>
        private void Update_CellImage(Cell cell)
        {
            cell.Image =
                cell.State == CellState.Covered ? this.Resources.Image_Block :
                cell.State == CellState.Flagged ? this.Resources.Image_Flag :
                cell.HasMine ? this.Resources.Image_Mine :
                cell.Value == 0 ? this.Resources.Image_Number0 :
                cell.Value == 1 ? this.Resources.Image_Number1 :
                cell.Value == 2 ? this.Resources.Image_Number2 :
                cell.Value == 3 ? this.Resources.Image_Number3 :
                cell.Value == 4 ? this.Resources.Image_Number4 :
                cell.Value == 5 ? this.Resources.Image_Number5 :
                cell.Value == 6 ? this.Resources.Image_Number6 :
                cell.Value == 7 ? this.Resources.Image_Number7 :
                this.Resources.Image_Number8;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Dibuja la grilla
        /// </summary>
        /// <param name="drawHandler"></param>
        public override void Draw(DrawHandler drawHandler)
        {
            for (int x = 0; x < Config.Grid_Size.Width; x++)
                for (int y = 0; y < Config.Grid_Size.Height; y++)
                    Matrix[x, y].Draw(drawHandler);
        }
        #endregion
    }
}
