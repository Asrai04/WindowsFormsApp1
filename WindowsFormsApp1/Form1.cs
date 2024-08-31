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
        private LinkList BOT2 = new LinkList();
        private LinkList BOT3 = new LinkList();
        private LinkList BOT4 = new LinkList();

        private MOTO Powerup = new MOTO(-10, -10);
        private MOTO Powerup2 = new MOTO(-10, -10);
        private MOTO Powerup_tiempo = new MOTO(-10, -10);
        private MOTO GASOLINA = new MOTO(-10, -10);
        private MOTO Escudo = new MOTO(-10, -10);

        private MOTO motito = new MOTO(-10, -10);
        private MOTO h = new MOTO(-10, -10);
        private List<MOTO> BOT2L = new List<MOTO>();
        private List<MOTO> BOT3L = new List<MOTO>();
        private List<MOTO> BOT4L = new List<MOTO>();

        private List<int> ITEMS = new List<int>();


        int MaxWidth;
        int MaxHeight;

        int score;
        int Combustible;
        int CC;
        int CC2;
        int CC3;
        int CH;
        int CI;

        Random rand = new Random();

        bool Izquierda, Derecha, Arriba, Abajo, tempo_lento, BOT1_vivo, BOT2_vivo, BOT3_vivo, BOT4_vivo, TEscudo, Ttiempo;

        public Form1()
        {
            InitializeComponent();

            new Configuracion();
            Configuracion.Direcciones = "derecha";
            BOT1C.Direcciones = "izquierda";
            BOT2C.Direcciones = "izquierda";
            Combustible = 100;
    }

        BotConfig BOT1C = new BotConfig();
        BotConfig BOT2C = new BotConfig();
        BotConfig BOT3C = new BotConfig();
        BotConfig BOT4C = new BotConfig();

        private void label1_Click_1(object sender, EventArgs e)
        {

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
            ////////////////////////////////////////////////////////////////////////
            if (e.KeyCode == Keys.A && Configuracion.Direcciones != "derecha")
            {
                Izquierda = true;
            }
            if (e.KeyCode == Keys.D && Configuracion.Direcciones != "izquierda")
            {
                Derecha = true;
            }
            if (e.KeyCode == Keys.W && Configuracion.Direcciones != "abajo")
            {
                Arriba = true;
            }
            if (e.KeyCode == Keys.S && Configuracion.Direcciones != "arriba")
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
            ///////////////////////////////////////////////////////////////////////
            if (e.KeyCode == Keys.A)
            {
                Izquierda = false;
            }
            if (e.KeyCode == Keys.D)
            {
                Derecha = false;
            }
            if (e.KeyCode == Keys.W)
            {
                Arriba = false;
            }
            if (e.KeyCode == Keys.S)
            {
                Abajo = false;
            }
            ///////////////////////////////////////////////////////////////////////
            if (e.KeyCode == Keys.Space)
            {
                if (ITEMS.Count > 0)
                {
                    if (ITEMS[0] == 1)
                    {
                        HIPERVELOCIDAD();
                        ITEMS.RemoveAt(0);
                    }
                    if (ITEMS[0] == 2)
                    {
                        INVENCIBLE();
                        ITEMS.RemoveAt(0);
                    } 
                }
            }
        }
        private void Start_Game(object sender, EventArgs e)
        {

            Restart();

        }

        private void Timer_Juego(object sender, EventArgs e)
        {
            int d = rand.Next(1, 50);
            int d2 = rand.Next(1, 50);
            int d3 = rand.Next(1, 50);
            int d4 = rand.Next(1, 50);
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
            //////////////////////////////////////////////////////
            if (d2 == 1 && BOT2C.Direcciones != "derecha")
            {
                BOT2C.Direcciones = "izquierda";
            }
            else if (d2 == 2 && BOT2C.Direcciones != "izquierda")
            {
                BOT2C.Direcciones = "derecha";
            }
            else if (d2 == 3 && BOT2C.Direcciones != "arriba")
            {
                BOT2C.Direcciones = "abajo";
            }
            else if (d2 == 4 && BOT2C.Direcciones != "abajp")
            {
                BOT2C.Direcciones = "arriba";
            }
            /////////////////////////////////////////////////////
            if (d3 == 1 && BOT3C.Direcciones != "derecha")
            {
                BOT3C.Direcciones = "izquierda";
            }
            else if (d3 == 2 && BOT3C.Direcciones != "izquierda")
            {
                BOT3C.Direcciones = "derecha";
            }
            else if (d3 == 3 && BOT3C.Direcciones != "arriba")
            {
                BOT3C.Direcciones = "abajo";
            }
            else if (d3 == 4 && BOT3C.Direcciones != "abajp")
            {
                BOT3C.Direcciones = "arriba";
            }
            /////////////////////////////////////////////////////
            if (d4 == 1 && BOT4C.Direcciones != "derecha")
            {
                BOT4C.Direcciones = "izquierda";
            }
            else if (d4 == 2 && BOT4C.Direcciones != "izquierda")
            {
                BOT4C.Direcciones = "derecha";
            }
            else if (d4 == 3 && BOT4C.Direcciones != "arriba")
            {
                BOT4C.Direcciones = "abajo";
            }
            else if (d4 == 4 && BOT4C.Direcciones != "abajp")
            {
                BOT4C.Direcciones = "arriba";
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
                    if (Jugador[i].X > MaxWidth && Jugador[i].X < 5000)
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

                    if (Jugador[i].X == h.X && Jugador[i].Y == h.Y)
                    {
                        CrecerStela(1);
                    }
                    if (Jugador[i].X == Powerup2.X && Jugador[i].Y == Powerup2.Y)
                    {
                        CrecerStela2(1);
                    }
                    if (Jugador[i].X == GASOLINA.X && Jugador[i].Y == GASOLINA.Y)
                    {
                        Combustible = 100;
                        GASOLINA = new MOTO(rand.Next(2, MaxWidth), rand.Next(2, MaxHeight));
                    }
                    if (Jugador[i].X == Escudo.X && Jugador[i].Y == Escudo.Y)
                    {
                        Escudo = new MOTO(rand.Next(2, MaxWidth), rand.Next(2, MaxHeight));
                        txtEscudo.Text = "Escudo:" + 1;
                        ITEMS.Add(2);
                    }
                    if (Jugador[i].X == Powerup_tiempo.X && Jugador[i].Y == Powerup_tiempo.Y)
                    {
                        CH++;
                        tempo_lento = true;
                        Powerup_tiempo = new MOTO(rand.Next(2, MaxWidth), rand.Next(2, MaxHeight));
                        txtBomba.Text = "Hipervelocidad:" + CH;
                        ITEMS.Add(1);
                    }

                    for (int j = 1; j < Jugador.Count; j++)
                    {

                        if (Jugador[i].X == Jugador[j].X && Jugador[i].Y == Jugador[j].Y && TEscudo == false)
                        {
                            GAMEOVER();;
                        }
                    }
                    for (int j = 1; j < BOT1.Count; j++)
                    {

                        if (Jugador[i].X == BOT1[j].X && Jugador[i].Y == BOT1[j].Y && BOT1_vivo == true && TEscudo == false)
                        {
                            GAMEOVER(); ;
                        }
                    }
                    for (int j = 1; j < BOT2L.Count; j++)
                    {

                        if (Jugador[i].X == BOT2L[j].X && Jugador[i].Y == BOT2L[j].Y && BOT2_vivo == true && TEscudo == false)
                        {
                            GAMEOVER(); ;
                        }
                    }
                    for (int j = 1; j < BOT3L.Count; j++)
                    {

                        if (Jugador[i].X == BOT3L[j].X && Jugador[i].Y == BOT3L[j].Y && BOT3_vivo == true && TEscudo == false)
                        {
                            GAMEOVER(); ;
                        }
                    }
                    for (int j = 1; j < BOT4L.Count; j++)
                    {

                        if (Jugador[i].X == BOT4L[j].X && Jugador[i].Y == BOT4L[j].Y && BOT4_vivo == true && TEscudo == false)
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
                            for (int ll = BOT1.Count - 1; ll > 0; ll--)
                            {
                                BOT1[ll].destruirse();
                                BOT1_vivo = false;
                                score = score + 150;
                                txtScore.Text = "Score: " + score;
                            }
                        }
                        if (BOT1[i].X == h.X && BOT1[i].Y == h.Y)
                        {
                            CrecerStela(2);
                        }
                        if (BOT1[i].X == Powerup2.X && BOT1[i].Y == Powerup2.Y)
                        {
                            CrecerStela2(2);
                        }
                    }
                }
                else
                {
                    BOT1[i].X = BOT1[i - 1].X;
                    BOT1[i].Y = BOT1[i - 1].Y;
                }
            }

            for (int i = BOT2L.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (BOT2C.Direcciones)
                    {
                        case "izquierda":
                            BOT2L[i].X--;
                            break;
                        case "derecha":
                            BOT2L[i].X++;
                            break;
                        case "abajo":
                            BOT2L[i].Y++;
                            break;
                        case "arriba":
                            BOT2L[i].Y--;
                            break;

                    }

                    if (BOT2L[i].X < 0)
                    {
                        BOT2L[i].X = MaxWidth;
                    }
                    if (BOT2L[i].X > MaxWidth && BOT2L[i].X < 5000)
                    {
                        BOT2L[i].X = 0;
                    }
                    if (BOT2L[i].Y < 0)
                    {
                        BOT2L[i].Y = MaxHeight;
                    }
                    if (BOT2L[i].Y > MaxHeight)
                    {
                        BOT2L[i].Y = 0;
                    }
                    for (int j = 0; j < Jugador.Count; j++)
                    {

                        if (BOT2L[i].X == Jugador[j].X && BOT2L[i].Y == Jugador[j].Y)
                        {
                            for (int ll = BOT2L.Count - 1; ll > 0; ll--)
                            {
                                BOT2L[ll].destruirse();
                                BOT2_vivo = false;
                                score = score + 150;
                                txtScore.Text = "Score: " + score;
                            }
                        }
                        if (BOT2L[i].X == h.X && BOT2L[i].Y == h.Y)
                        {
                            CrecerStela(3);
                        }
                        if (BOT2L[i].X == Powerup2.X && BOT2L[i].Y == Powerup2.Y)
                        {
                            CrecerStela2(3);
                        }
                    }
                }
                else
                {
                    BOT2L[i].X = BOT2L[i - 1].X;
                    BOT2L[i].Y = BOT2L[i - 1].Y;
                }
            }

            for (int i = BOT3L.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (BOT3C.Direcciones)
                    {
                        case "izquierda":
                            BOT3L[i].X--;
                            break;
                        case "derecha":
                            BOT3L[i].X++;
                            break;
                        case "abajo":
                            BOT3L[i].Y++;
                            break;
                        case "arriba":
                            BOT3L[i].Y--;
                            break;

                    }

                    if (BOT3L[i].X < 0)
                    {
                        BOT3L[i].X = MaxWidth;
                    }
                    if (BOT3L[i].X > MaxWidth && BOT3L[i].X < 5000)
                    {
                        BOT3L[i].X = 0;
                    }
                    if (BOT3L[i].Y < 0)
                    {
                        BOT3L[i].Y = MaxHeight;
                    }
                    if (BOT3L[i].Y > MaxHeight)
                    {
                        BOT3L[i].Y = 0;
                    }
                    for (int j = 0; j < Jugador.Count; j++)
                    {

                        if (BOT3L[i].X == Jugador[j].X && BOT3L[i].Y == Jugador[j].Y)
                        {
                            for (int ll = BOT3L.Count - 1; ll > 0; ll--)
                            {
                                BOT3L[ll].destruirse();
                                BOT3_vivo = false;
                                score = score + 150;
                                txtScore.Text = "Score: " + score;
                            }
                        }
                        if (BOT3L[i].X == h.X && BOT3L[i].Y == h.Y)
                        {
                            CrecerStela(4);
                        }
                        if (BOT3L[i].X == Powerup2.X && BOT3L[i].Y == Powerup2.Y)
                        {
                            CrecerStela2(4);
                        }
                    }
                }
                else
                {
                    BOT3L[i].X = BOT3L[i - 1].X;
                    BOT3L[i].Y = BOT3L[i - 1].Y;
                }
            }

            for (int i = BOT4L.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (BOT4C.Direcciones)
                    {
                        case "izquierda":
                            BOT4L[i].X--;
                            break;
                        case "derecha":
                            BOT4L[i].X++;
                            break;
                        case "abajo":
                            BOT4L[i].Y++;
                            break;
                        case "arriba":
                            BOT4L[i].Y--;
                            break;

                    }

                    if (BOT4L[i].X < 0)
                    {
                        BOT4L[i].X = MaxWidth;
                    }
                    if (BOT4L[i].X > MaxWidth && BOT4L[i].X < 5000)
                    {
                        BOT4L[i].X = 0;
                    }
                    if (BOT4L[i].Y < 0)
                    {
                        BOT4L[i].Y = MaxHeight;
                    }
                    if (BOT4L[i].Y > MaxHeight)
                    {
                        BOT4L[i].Y = 0;
                    }
                    for (int j = 0; j < Jugador.Count; j++)
                    {

                        if (BOT4L[i].X == Jugador[j].X && BOT4L[i].Y == Jugador[j].Y)
                        {
                            for (int ll = BOT4L.Count - 1; ll > 0; ll--)
                            {
                                BOT4L[ll].destruirse();
                                BOT4_vivo = false;
                                score = score + 150;
                                txtScore.Text = "Score: " + score;
                            }
                        }
                        if (BOT4L[i].X == h.X && BOT4L[i].Y == h.Y)
                        {
                            CrecerStela(5);
                        }
                        if (BOT4L[i].X == Powerup2.X && BOT4L[i].Y == Powerup2.Y)
                        {
                            CrecerStela2(5);
                        }
                    }
                }
                else
                {
                    BOT4L[i].X = BOT4L[i - 1].X;
                    BOT4L[i].Y = BOT4L[i - 1].Y;
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

            if (Ttiempo == true)
            {
                CC2++;
            }
            if (CC2 == 40)
            {
                Timer_del_juego.Interval = 40;
                tempo_lento = false;
                Ttiempo = false;
                CC2 = 0;
            }
            if (TEscudo == true)
            {
                CC3++;
            }
            if (CC3 == 20)
            {
                TEscudo = false;
                CC3 = 0;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Update_Fondo(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush ColorMoto, ColorMoto2, ColorMoto3, ColorMoto4, ColorMoto5;


            if (BOT1_vivo == true)
            {
                for (int i = 0; i < BOT1.Count; i++)
                {
                    if (i == 0)
                    {
                        ColorMoto2 = Brushes.Orange;
                    }
                    else if (i == 1)
                    {
                        ColorMoto2 = Brushes.Orange;
                    }
                    else
                    {
                        ColorMoto2 = Brushes.Yellow;
                    }

                    canvas.FillEllipse(ColorMoto2, new Rectangle
                        (
                        BOT1[i].X * Configuracion.Ancho,
                        BOT1[i].Y * Configuracion.Largo,
                        Configuracion.Ancho,
                        Configuracion.Largo
                        ));
                }
            }

            if (BOT2_vivo == true)
            {
                for (int i = 0; i < BOT2L.Count; i++)
                {
                    if (i == 0)
                    {
                        ColorMoto3 = Brushes.Gray;
                    }
                    else if (i == 1)
                    {
                        ColorMoto3 = Brushes.Gray;
                    }
                    else
                    {
                        ColorMoto3 = Brushes.LightGray;
                    }

                    canvas.FillEllipse(ColorMoto3, new Rectangle
                        (
                        BOT2L[i].X * Configuracion.Ancho,
                        BOT2L[i].Y * Configuracion.Largo,
                        Configuracion.Ancho,
                        Configuracion.Largo
                        ));
                }
            }
            if (BOT3_vivo == true)
            {
                for (int i = 0; i < BOT3L.Count; i++)
                {
                    if (i == 0)
                    {
                        ColorMoto4 = Brushes.Green;
                    }
                    else if (i == 1)
                    {
                        ColorMoto4 = Brushes.Green;
                    }
                    else
                    {
                        ColorMoto4 = Brushes.LightGreen;
                    }

                    canvas.FillEllipse(ColorMoto4, new Rectangle
                        (
                        BOT3L[i].X * Configuracion.Ancho,
                        BOT3L[i].Y * Configuracion.Largo,
                        Configuracion.Ancho,
                        Configuracion.Largo
                        ));
                }
            }
            if (BOT4_vivo == true)
            {
                for (int i = 0; i < BOT4L.Count; i++)
                {
                    if (i == 0)
                    {
                        ColorMoto5 = Brushes.Purple;
                    }
                    else if (i == 1)
                    {
                        ColorMoto5 = Brushes.Purple;
                    }
                    else
                    {
                        ColorMoto5 = Brushes.Pink;
                    }

                    canvas.FillEllipse(ColorMoto5, new Rectangle
                        (
                        BOT4L[i].X * Configuracion.Ancho,
                        BOT4L[i].Y * Configuracion.Largo,
                        Configuracion.Ancho,
                        Configuracion.Largo
                        ));
                }
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
                    h.X * Configuracion.Ancho,
                    h.Y * Configuracion.Largo,
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

            canvas.FillEllipse(Brushes.Purple, new Rectangle
                    (
                    h.X * Configuracion.Ancho,
                    h.Y * Configuracion.Largo,
                    Configuracion.Ancho,
                    Configuracion.Largo
                    ));

            canvas.FillEllipse(Brushes.Red, new Rectangle
                    (
                    GASOLINA.X * Configuracion.Ancho,
                    GASOLINA.Y * Configuracion.Largo,
                    Configuracion.Ancho,
                    Configuracion.Largo
                    ));
            canvas.FillEllipse(Brushes.Cyan, new Rectangle
                    (
                    Escudo.X * Configuracion.Ancho,
                    Escudo.Y * Configuracion.Largo,
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

            BOT1_vivo = true;
            BOT2_vivo = true;
            BOT3_vivo = true;
            BOT4_vivo = true;
            Ttiempo = false;
            tempo_lento = false;

            MOTO moto = new MOTO (5, 10);
            MOTO enemigo1 = new MOTO(70, 10);
            MOTO enemigo2 = new MOTO(5, 50);
            MOTO enemigo3 = new MOTO(70, 50);
            MOTO enemigo4 = new MOTO(30, 50);
            Jugador.Add(moto); // crear la moto
            BOT1.Add(enemigo1);
            NODO PREBA = new NODO(Powerup);
            BOT2.insertarDato(enemigo2);
            BOT3.insertarDato(enemigo3);
            BOT4.insertarDato(enemigo4);

            for (int i = 0; i < 4; i++)
            {
                MOTO estela = new MOTO(-10, -10);
                MOTO estela2 = new MOTO(-10, -10);
                MOTO estela3 = new MOTO(-10, -10);
                MOTO estela4 = new MOTO(-10, -10);
                MOTO estela5 = new MOTO(-10, -10);

                Jugador.Add(estela);
                BOT1.Add(estela2);
                BOT2.insertarDato(estela3);
                BOT3.insertarDato(estela4);
                BOT4.insertarDato(estela5);
            }

            for (int i = 0;  i < 5; i++)
            {
                NODO P = BOT2.borrarDato();
                MOTO P2 = P.optenerData();

                NODO PA = BOT3.borrarDato();
                MOTO PA2 = PA.optenerData();

                NODO PAt = BOT4.borrarDato();
                MOTO PAt2 = PAt.optenerData();

                BOT2L.Add(P2);
                BOT3L.Add(PA2);
                BOT4L.Add(PAt2);
            }


            Powerup2 = new MOTO (rand.Next(2, MaxWidth), rand.Next(2, MaxHeight));
            Powerup_tiempo = new MOTO ( rand.Next(2, MaxWidth), rand.Next(2, MaxHeight) );
            GASOLINA = new MOTO(rand.Next(2, MaxWidth), rand.Next(2, MaxHeight));
            Escudo = new MOTO(rand.Next(2, MaxWidth), rand.Next(2, MaxHeight));
            h = PREBA.optenerData();
            h = new MOTO (rand.Next(2, MaxWidth), rand.Next(2, MaxHeight));

            Timer_del_juego.Start();
            Combustible = 100;
            CC = 0;
            CH = 0;
            TEscudo = false;
            Configuracion.Direcciones = "derecha";
        }
        
        private void CrecerStela(int h2)
        {

            score = score + 50;
            txtScore.Text = "Score: " + score;
            if (h2 == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    MOTO estela2 = new MOTO(-10, -10)
                    {
                        X = Jugador[Jugador.Count - 1].X,
                        Y = Jugador[Jugador.Count - 1].Y
                    };

                    Jugador.Add(estela2);
                }
            }
            else if (h2 == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    MOTO estela2 = new MOTO(-10, -10)
                    {
                        X = BOT1[BOT1.Count - 1].X,
                        Y = BOT1[BOT1.Count - 1].Y
                    };

                    BOT1.Add(estela2);
                }
            }
            else if (h2 == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    MOTO estela2 = new MOTO(-10, -10)
                    {
                        X = BOT2L[BOT2L.Count - 1].X,
                        Y = BOT2L[BOT2L.Count - 1].Y
                    };

                    BOT2L.Add(estela2);
                }
            }
            else if (h2 == 4)
            {
                for (int i = 0; i < 3; i++)
                {
                    MOTO estela2 = new MOTO(-10, -10)
                    {
                        X = BOT3L[BOT3L.Count - 1].X,
                        Y = BOT3L[BOT3L.Count - 1].Y
                    };

                    BOT3L.Add(estela2);
                }
            }

            h = new MOTO (rand.Next(2, MaxWidth), rand.Next(2, MaxHeight));


        }
        private void CrecerStela2(int h3)
        {

            score = score + 50;
            txtScore.Text = "Score: " + score;
            if (h3 == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    MOTO estela2 = new MOTO(-10, -10)
                    {
                        X = Jugador[Jugador.Count - 1].X,
                        Y = Jugador[Jugador.Count - 1].Y
                    };

                    Jugador.Add(estela2);
                }
            }
            else if (h3 == 2) 
            {
                for (int i = 0; i < 3; i++)
                {
                    MOTO estela2 = new MOTO(-10, -10)
                    {
                        X = BOT1[BOT1.Count - 1].X,
                        Y = BOT1[BOT1.Count - 1].Y
                    };

                    BOT1.Add(estela2);
                }
            }
            else if (h3 == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    MOTO estela2 = new MOTO(-10, -10)
                    {
                        X = BOT2L[BOT2L.Count - 1].X,
                        Y = BOT2L[BOT2L.Count - 1].Y
                    };

                    BOT2L.Add(estela2);
                }
            }
            else if (h3 == 4)
            {
                for (int i = 0; i < 3; i++)
                {
                    MOTO estela2 = new MOTO(-10, -10)
                    {
                        X = BOT3L[BOT3L.Count - 1].X,
                        Y = BOT3L[BOT3L.Count - 1].Y
                    };

                    BOT3L.Add(estela2);
                }
            }

            Powerup2 = new MOTO (rand.Next(2, MaxWidth), rand.Next(2, MaxHeight));
        }

        private void HIPERVELOCIDAD()
        {
            CH--;
            Ttiempo = true;
            Timer_del_juego.Interval = 20;
            tempo_lento = false;
            txtBomba.Text = "Hipervelocidad:" + CH;
        }
        private void INVENCIBLE()
        {
            CI--;
            TEscudo = true;
            txtEscudo.Text = "Escudo:" + CI;
        }
        
        private void GAMEOVER()
        {
            Boton_Start.Enabled = true;

            Timer_del_juego.Stop();
            Jugador.Clear();
            BOT1.Clear();
            BOT2L.Clear();
            BOT3L.Clear();
            BOT4L.Clear();
        }
    }
}