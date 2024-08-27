using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
        private List<MOTO> BOT1 = new List<MOTO>();
        private MOTO Powerup = new MOTO();
        private MOTO Powerup2 = new MOTO();
        private MOTO Powerup_tiempo = new MOTO();


        int MaxWidth;
        int MaxHeight;

        int score;
        int Combustible;
        int CC;

        Random rand = new Random();

        bool Izquierda, Derecha, Arriba, Abajo, tempo_lento, moto_viva;

        public Form1()
        {
            InitializeComponent();

            new Configuracion();
            Configuracion.Direcciones = "derecha";
            BOT1C.Direcciones = "izquierda";
            Combustible = 100;
        }

        BotConfig BOT1C = new BotConfig();


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
            int d = rand.Next(1, 50);
            if (d == 1 && BOT1C.Direcciones != "derecha")
            {
                BOT1C.Direcciones = "izquierda";
            }
            else if (d == 2 && BOT1C.Direcciones != "izquierda")
            {
                BOT1C.Direcciones = "derecha";
            }
            else if (d == 3 && BOT1C.Direcciones != "arriba")
            {
                BOT1C.Direcciones = "abajo";
            }
            else if (d == 4 && BOT1C.Direcciones != "abajp")
            {
                BOT1C.Direcciones = "arriba";
            }
            
            
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
                    if (Jugador[i].X == Powerup2.X && Jugador[i].Y == Powerup2.Y)
                    {
                        CrecerStela2();
                    }
                    if (Jugador[i].X == Powerup_tiempo.X && Jugador[i].Y == Powerup_tiempo.Y)
                    {
                        if (tempo_lento == false)
                        {
                            Timer_del_juego.Interval = 80;
                            tempo_lento = true;
                        }
                        else
                        {
                            Timer_del_juego.Interval = 40;
                            tempo_lento = false;
                        }
                        Powerup_tiempo = new MOTO { X = rand.Next(2, MaxWidth), Y = rand.Next(2, MaxHeight) };
                    }

                    for (int j = 1; j < Jugador.Count; j++)
                    {

                        if (Jugador[i].X == Jugador[j].X && Jugador[i].Y == Jugador[j].Y)
                        {
                            GAMEOVER();;
                        }
                    }
                    for (int j = 1; j < BOT1.Count; j++)
                    {

                        if (Jugador[i].X == BOT1[j].X && Jugador[i].Y == BOT1[j].Y)
                        {
                            GAMEOVER(); ;
                        }
                    }
                }
                else
                {
                    Jugador[i].X = Jugador[i - 1].X;
                    Jugador[i].Y = Jugador[i - 1].Y;
                }
            }

            for (int i = BOT1.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (BOT1C.Direcciones)
                    {
                        case "izquierda":
                            BOT1[i].X--;
                            break;
                        case "derecha":
                            BOT1[i].X++;
                            break;
                        case "abajo":
                            BOT1[i].Y++;
                            break;
                        case "arriba":
                            BOT1[i].Y--;
                            break;

                    }

                    if (BOT1[i].X < 0)
                    {
                        BOT1[i].X = MaxWidth;
                    }
                    if (BOT1[i].X > MaxWidth)
                    {
                        BOT1[i].X = 0;
                    }
                    if (BOT1[i].Y < 0)
                    {
                        BOT1[i].Y = MaxHeight;
                    }
                    if (BOT1[i].Y > MaxHeight)
                    {
                        BOT1[i].Y = 0;
                    }
                    for (int j = 0; j < Jugador.Count; j++)
                    {

                        if (BOT1[i].X == Jugador[j].X && BOT1[i].Y == Jugador[j].Y)
                        {
                            Timer_del_juego.Interval = 500;
                        }
                    }
                }
                else
                {
                    BOT1[i].X = BOT1[i - 1].X;
                    BOT1[i].Y = BOT1[i - 1].Y;
                }
            }

            Fondo_Juego.Invalidate();
            PORCOM.Text = "FUEL: " + Combustible + "%";
            if (CC == 5)
            {
                Combustible--;
                CC = 0;
            }
            if (Combustible <= -1)
            {
                GAMEOVER();
            }
            CC++;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Update_Fondo(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush ColorMoto, ColorMoto2;

            for (int i = 0; i < BOT1.Count; i++)
            {
                if (i == 0)
                {
                    ColorMoto2 = Brushes.DarkRed;
                }
                else if (i == 1)
                {
                    ColorMoto2 = Brushes.DarkRed;
                }
                else
                {
                    ColorMoto2 = Brushes.Red;
                }

                canvas.FillEllipse(ColorMoto2, new Rectangle
                    (
                    BOT1[i].X * Configuracion.Ancho,
                    BOT1[i].Y * Configuracion.Largo,
                    Configuracion.Ancho,
                    Configuracion.Largo
                    ));
            }

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

            canvas.FillEllipse(Brushes.Purple, new Rectangle
                    (
                    Powerup.X * Configuracion.Ancho,
                    Powerup.Y * Configuracion.Largo,
                    Configuracion.Ancho,
                    Configuracion.Largo
                    ));

            canvas.FillEllipse(Brushes.Purple, new Rectangle
                    (
                    Powerup2.X * Configuracion.Ancho,
                    Powerup2.Y * Configuracion.Largo,
                    Configuracion.Ancho,
                    Configuracion.Largo
                    ));


            canvas.FillEllipse(Brushes.DarkGreen, new Rectangle
                    (
                    Powerup_tiempo.X * Configuracion.Ancho,
                    Powerup_tiempo.Y * Configuracion.Largo,
                    Configuracion.Ancho,
                    Configuracion.Largo
                    ));

        }

        

        private void Restart()
        {
            MaxWidth = Fondo_Juego.Width / Configuracion.Ancho - 1;
            MaxHeight = Fondo_Juego.Height / Configuracion.Largo - 1;
            Timer_del_juego.Interval = 40;

            Jugador.Clear();
            Boton_Start.Enabled = false;

            score = 0;
            txtScore.Text = "Score: " + score;

            MOTO moto = new MOTO { X = 5, Y = 10 };
            MOTO enemigo1 = new MOTO { X= 70, Y= 10 };
            Jugador.Add(moto); // crear la moto
            BOT1.Add(enemigo1);


            for (int i = 0; i < 50; i++)
            {
                MOTO estela = new MOTO();
                Jugador.Add(estela);
                BOT1.Add(estela);
            }

            Powerup = new MOTO { X = rand.Next(2, MaxWidth), Y = rand.Next(2, MaxHeight) };
            Powerup2 = new MOTO { X = rand.Next(2, MaxWidth), Y = rand.Next(2, MaxHeight) };
            Powerup_tiempo = new MOTO { X = rand.Next(2, MaxWidth), Y = rand.Next(2, MaxHeight) };

            Timer_del_juego.Start();
            Combustible = 100;
            CC = 0;
            Configuracion.Direcciones = "derecha";
        }
        
        private void CrecerStela()
        {

            score = score + 50;
            txtScore.Text = "Score: " + score;

            for (int i = 0; i < 3; i++) 
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
        private void CrecerStela2()
        {

            score = score + 50;
            txtScore.Text = "Score: " + score;

            for (int i = 0; i < 3; i++)
            {
                MOTO estela2 = new MOTO
                {
                    X = Jugador[Jugador.Count - 1].X,
                    Y = Jugador[Jugador.Count - 1].Y
                };

                Jugador.Add(estela2);
            }

            Powerup2 = new MOTO { X = rand.Next(2, MaxWidth), Y = rand.Next(2, MaxHeight) };
        }

        private void GASOLINA_RECHARCH()
        {
            
        }
        private void GAMEOVER()
        {
            Boton_Start.Enabled = true;

            Timer_del_juego.Stop();
            Jugador.Clear();
            BOT1.Clear();

        }

        private void BOT1MUERE()
        {
            for (int i = 0; i < BOT1.Count; i++) {
                BOT1.Remove(BOT1[0]);
            }
        }
    }
}
