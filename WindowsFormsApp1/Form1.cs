using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private List<MOTO> Jugador = new List<MOTO>();
        private MOTO Powerup = new MOTO();


        int MaxWidth;
        int MaxHeight;

        int score;

        Random rand = new Random();

        bool Izquierda, Derecha, Arriba, Abajo;


        public Form1()
        {
            InitializeComponent();

            new Configuracion();
        }

        private void KeyDOWN(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Configuracion.Direcciones != "derecha")
            {
                Izquierda = true;
            }
            if (e.KeyCode == Keys.Right && Configuracion.Direcciones != "izquierda")
            {
                Derecha = true;
            }
            if (e.KeyCode == Keys.Up && Configuracion.Direcciones != "abajo")
            {
                Arriba = true;
            }
            if (e.KeyCode == Keys.Down && Configuracion.Direcciones != "arriba")
            {
                Abajo = true;
            }
        }

        private void KeyUP(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                Izquierda = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                Derecha = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                Arriba = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                Abajo = false;
            }
        }

        private void Start_Game(object sender, EventArgs e)
        {
            Restart();
        }

        private void Timer_Juego(object sender, EventArgs e)
        {
            if (Izquierda)
            {
                Configuracion.Direcciones = "izquierda";
            }
            if (Derecha)
            {
                Configuracion.Direcciones = "derecha";
            }
            if (Abajo)
            {
                Configuracion.Direcciones = "abajo";
            }
            if (Arriba)
            {
                Configuracion.Direcciones = "arriba";
            }

            for (int i = Jugador.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Configuracion.Direcciones)
                    {
                        case "izquierda":
                            Jugador[i].X--;
                            break;
                        case "derecha":
                            Jugador[i].X++;
                            break;
                        case "abajo":
                            Jugador[i].Y++;
                            break;
                        case "arriba":
                            Jugador[i].Y--;
                            break;

                    }

                    if (Jugador[i].X < 0)
                    {
                        Jugador[i].X = MaxWidth;
                    }
                    if (Jugador[i].X > MaxWidth)
                    {
                        Jugador[i].X = 0;
                    }
                    if (Jugador[i].Y < 0)
                    {
                        Jugador[i].Y = MaxHeight;
                    }
                    if (Jugador[i].Y > MaxHeight)
                    {
                        Jugador[i].Y = 0;
                    }

                    if (Jugador[i].X == Powerup.X && Jugador[i].Y == Powerup.Y)
                    {
                        CrecerStela();
                    }

                    for (int j = 1; j < Jugador.Count; j++)
                    {

                        if (Jugador[i].X == Jugador[j].X && Jugador[i].Y == Jugador[j].Y)
                        {
                            GAMEOVER();
                        }

                    }


                }
                else
                {
                    Jugador[i].X = Jugador[i - 1].X;
                    Jugador[i].Y = Jugador[i - 1].Y;
                } 
            }

            Fondo_Juego.Invalidate();   
        }

        private void Update_Fondo(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush ColorMoto, ColorMoto1;

            for (int i = 0; i < Jugador.Count; i++) 
            {
                if (i == 0)
                {
                    ColorMoto = Brushes.Blue;
                }
                else if (i == 1)
                {
                    ColorMoto = Brushes.Blue;
                }
                else
                {
                    ColorMoto = Brushes.Cyan;
                }

                canvas.FillEllipse(ColorMoto, new Rectangle
                    (
                    Jugador[i].X * Configuracion.Ancho,
                    Jugador[i].Y * Configuracion.Largo,
                    Configuracion.Ancho,
                    Configuracion.Largo
                    ));
            }

            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
                    (
                    Powerup.X * Configuracion.Ancho,
                    Powerup.Y * Configuracion.Largo,
                    Configuracion.Ancho,
                    Configuracion.Largo
                    ));

        }

        private void Restart()
        {
            MaxWidth = Fondo_Juego.Width / Configuracion.Ancho - 1;
            MaxHeight = Fondo_Juego.Height / Configuracion.Largo - 1;

            Jugador.Clear();
            Boton_Start.Enabled = false;

            score = 0;
            txtScore.Text = "Score: " + score;

            MOTO moto = new MOTO { X = 10, Y = 5 };
            Jugador.Add(moto); // crear la moto

            for (int i = 0; i < 50; i++)
            {
                MOTO estela = new MOTO();
                Jugador.Add(estela);
            }

            Powerup = new MOTO { X = rand.Next(2, MaxWidth), Y = rand.Next(2, MaxHeight) };

            Timer_del_juego.Start();
        }
        
        private void CrecerStela()
        {

            score = score + 50;
            txtScore.Text = "Score: " + score;

            for (int i = 0; i < 50; i++) 
            {
                MOTO estela2 = new MOTO
                {
                    X = Jugador[Jugador.Count - 1].X,
                    Y = Jugador[Jugador.Count - 1].Y
                };

                Jugador.Add(estela2);
            }

            Powerup = new MOTO { X = rand.Next(2, MaxWidth), Y = rand.Next(2, MaxHeight) };


        }

        private void GAMEOVER()
        {
            Timer_del_juego.Stop();

            Boton_Start.Enabled = true;

            for (int i = 0; i < Jugador.Count; i++)
            {
                Jugador[i].destruirse();
            }
        }
    }
}
