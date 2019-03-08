using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Windows.Forms;

namespace Meteorstion
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
       //DETALLES DE CONEXIONES
        bool gano1;
        bool gano2;
        int vidasj1, vidasj2;
        bool pasoLaRonda, pasoLaRonda2, pasoLaRonda3;
        ComunicacionHost llamarHost;
        bool controlj1;

        // OTROS MÁS
        bool menuPrincipal = true;
        SpriteFont presstart;
        Roca rocaAp;
        Vida vidaAp;
        Texture2D texRoca;
        bool rondaEspecial;
        bool REB;
        bool terminado = false;

        //MUSICA
        SoundEffect victoria;
        Song musicaJuego;
        SoundEffect disparoS;
        SoundEffect explosionS;

        //OTROS
        int numeroDeRondas;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D fondopantalla;
        Texture2D vida;
        SpriteFont cartel;
        int cantidadMaxRondas;

        //NAVE
        Nave jugador1;
        Nave jugador2;
        List<Disparo> disparos_perdidos;
        List<Disparo> disparos_perdidos2;

        //METEORO
        Meteoro meteoroBien;
        Meteoro meteoroMal1;
        Meteoro meteoroMal2;
        Texture2D textura_meteoro;
        int velocidad_meteorito;
        int vidas_meteorito;
        List<Meteoro> meteoros;
        bool d1;
        bool d2;
        bool d3;

        //Calculo
        bool hayCalculo;
        int descansoCalculo;
        bool hacerCalculo;
        Calculo calculo;
        Texture2D fondo2;
        SpriteFont titulos;
        int rx2;
        int velocidad;
        Rectangle fondo1;
        int numeroDeJugador;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Window.Title = "Meteorstion";
            this.graphics.PreferredBackBufferWidth = 500;
            this.graphics.PreferredBackBufferHeight = 480;
        }

        protected override void Initialize()
        {
            llamarHost = new ComunicacionHost();

            jugador1 = new Nave(null, 68, 68, 65, 410, 3, 0);
            jugador2 = new Nave(null, 70, 70, 65, 410, 3, 0);
            disparos_perdidos = new List<Disparo>();
            disparos_perdidos2 = new List<Disparo>();
            vidas_meteorito = 1;
            velocidad_meteorito = 2;
            meteoroBien = new Meteoro(null, 140, 120, 30, 80, vidas_meteorito);
            meteoroMal1 = new Meteoro(null, 140, 120, 190, 80, 100);
            meteoroMal2 = new Meteoro(null, 140, 120, 350, 80, 100);
            hayCalculo = false;
            descansoCalculo = 0;
            numeroDeRondas = 1;
            meteoros = new List<Meteoro>();
            meteoros.Add(meteoroBien);
            meteoros.Add(meteoroMal1);
            meteoros.Add(meteoroMal2);
            hacerCalculo = false;
            calculo = new Calculo();
            cantidadMaxRondas = 31;
            d1 = true; d2 = true; d3 = true;
            rocaAp = new Roca(null, new Rectangle(0, 0, 100, 100));
            vidaAp = new Vida(null, new Rectangle(0, 0, 30, 30));
            rondaEspecial = false;
            velocidad = 2;
            rx2 = -50;
            pasoLaRonda = false;
            pasoLaRonda2 = false;
            pasoLaRonda3 = false;

            int acumulador = llamarHost.pedidoDeNumeroDeJugador();
            controlj1 = llamarHost.getControl1();

            if (acumulador == 1)
            {
                numeroDeJugador = 1;
                llamarHost.setControl1(true);
                llamarHost.setVidasj1(3);
            }

            else
            {
                if (acumulador == 2)
                {
                    numeroDeJugador = 2;
                    llamarHost.setVidasj2(3);
                }

                else
                    this.Exit();
            }

            llamarHost.setVictoriaJ1(false);
            llamarHost.setVictoriaJ2(false);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            titulos = Content.Load<SpriteFont>("titulo");
            presstart = Content.Load<SpriteFont>("presstart");
            fondo2 = Content.Load<Texture2D>("Imagenes/fondo2");
            fondo1 = new Rectangle(100, rx2, 405, 393);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            fondopantalla = Content.Load<Texture2D>("Imagenes/Fondo");
            vida = Content.Load<Texture2D>("Imagenes/corazonfinal");
            Texture2D texturaDeNave = Content.Load<Texture2D>("Imagenes/navefinal");
            Texture2D texturaDeNave2 = Content.Load<Texture2D>("Imagenes/navejugador2");
            jugador1.setTextura(texturaDeNave);
            jugador2.setTextura(texturaDeNave2);
            textura_meteoro = Content.Load<Texture2D>("Imagenes/meteorito");
            disparoS = Content.Load<SoundEffect>("disparo");
            explosionS = Content.Load<SoundEffect>("explocion");
            texRoca = Content.Load<Texture2D>("Imagenes/roca");
            victoria = Content.Load<SoundEffect>("victory");
            rocaAp.setTextura(texRoca);
            vidaAp.setTextura(vida);

            foreach (Meteoro m in meteoros)
            {
               m.setTextura(textura_meteoro);
            } 

            musicaJuego = Content.Load<Song>("cancion");
            cartel = Content.Load<SpriteFont>("Cartel");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(musicaJuego);
        }

        protected override void UnloadContent()
        {
            if (numeroDeJugador == 2)
            {
                llamarHost.setVictoriaJ1(true);
                llamarHost.setVidasj1(123);
            }

            if (numeroDeJugador == 1)
            {
                llamarHost.setVictoriaJ2(true);
                llamarHost.setVidasj2(123);
            }
        }

        protected override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape) || (jugador1.getVidas() == 0 && descansoCalculo == 49))
            {
                this.Exit();
            }

            if (menuPrincipal == true)
            {
                if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    menuPrincipal = false;
                }
            }

            else
            {

                rx2 += velocidad;
                fondo1 = new Rectangle(0, rx2, 405, 393);
                if (rx2 == 500)
                {
                    rx2 = -500;
                }

                if (terminado == false)
                {

                    if (numeroDeJugador == 1)
                        accionesUpdate(jugador1);

                    if (numeroDeJugador == 2)
                        accionesUpdate(jugador2);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            if (menuPrincipal == true)
            {
                spriteBatch.Draw(fondopantalla, new Rectangle(0, 0, 600, 490), Color.White);
                spriteBatch.Draw(fondopantalla, new Rectangle(600, 0, 600, 490), Color.White);
                spriteBatch.DrawString(titulos, "Meteorstion", new Vector2(100, 100), Color.White);
                spriteBatch.DrawString(presstart, "Presionar Enter", new Vector2(170, 200), Color.White);

                if (numeroDeJugador == 1)
                    spriteBatch.Draw(jugador1.getTextura(), new Rectangle(212, 260, 68, 68), Color.White);

                if (numeroDeJugador == 2)
                    spriteBatch.Draw(jugador2.getTextura(), new Rectangle(212, 260, 68, 68), Color.White);

            }

            else
            {
                if (numeroDeJugador == 1)
                    accionesDraw(jugador1);

                if (numeroDeJugador == 2)
                    accionesDraw(jugador2);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void asignacionEspacios(Meteoro bien, Meteoro mal1, Meteoro mal2)
        {
            int x = new Random().Next(0, 6);

            if (x == 0)
            {
                bien.setRectangulo(bien.getRectangulo().Width, bien.getRectangulo().Height, 30, bien.getRectangulo().Y);
                mal1.setRectangulo(mal1.getRectangulo().Width, mal1.getRectangulo().Height, 190, mal1.getRectangulo().Y);
                mal2.setRectangulo(mal2.getRectangulo().Width, mal2.getRectangulo().Height, 350, mal2.getRectangulo().Y);
            }

            if (x == 1)
            {
                bien.setRectangulo(bien.getRectangulo().Width, bien.getRectangulo().Height, 190, bien.getRectangulo().Y);
                mal1.setRectangulo(mal1.getRectangulo().Width, mal1.getRectangulo().Height, 30, mal1.getRectangulo().Y);
                mal2.setRectangulo(mal2.getRectangulo().Width, mal2.getRectangulo().Height, 350, mal2.getRectangulo().Y);
            }

            if (x == 2)
            {
                bien.setRectangulo(bien.getRectangulo().Width, bien.getRectangulo().Height, 190, bien.getRectangulo().Y);
                mal1.setRectangulo(mal1.getRectangulo().Width, mal1.getRectangulo().Height, 350, mal1.getRectangulo().Y);
                mal2.setRectangulo(mal2.getRectangulo().Width, mal2.getRectangulo().Height, 30, mal2.getRectangulo().Y);
            }

            if (x == 3)
            {
                bien.setRectangulo(bien.getRectangulo().Width, bien.getRectangulo().Height, 30, bien.getRectangulo().Y);
                mal1.setRectangulo(mal1.getRectangulo().Width, mal1.getRectangulo().Height, 350, mal1.getRectangulo().Y);
                mal2.setRectangulo(mal2.getRectangulo().Width, mal2.getRectangulo().Height, 190, mal2.getRectangulo().Y);
            }

            if (x == 4)
            {
                bien.setRectangulo(bien.getRectangulo().Width, bien.getRectangulo().Height, 350, bien.getRectangulo().Y);
                mal1.setRectangulo(mal1.getRectangulo().Width, mal1.getRectangulo().Height, 30, mal1.getRectangulo().Y);
                mal2.setRectangulo(mal2.getRectangulo().Width, mal2.getRectangulo().Height, 190, mal2.getRectangulo().Y);
            }

            if (x == 5)
            {
                bien.setRectangulo(bien.getRectangulo().Width, bien.getRectangulo().Height, 350, bien.getRectangulo().Y);
                mal1.setRectangulo(mal1.getRectangulo().Width, mal1.getRectangulo().Height, 190, mal1.getRectangulo().Y);
                mal2.setRectangulo(mal2.getRectangulo().Width, mal2.getRectangulo().Height, 30, mal2.getRectangulo().Y);
            }

        }

        public void comprobacion(Meteoro bien, Meteoro mal1, Meteoro mal2)
        {
            if (bien.getVidas() == 0)
            {
                mal1.acelerar();
                mal2.acelerar();
            }

            if (mal1.getVidas() == 0)
            {
                bien.acelerar();
                mal2.acelerar();
            }


            if (mal2.getVidas() == 0)
            {
                mal1.acelerar();
                bien.acelerar();
            }

        }

        public void accionesUpdate(Nave jugador)
        {
            if (numeroDeRondas <= cantidadMaxRondas)
            {

                jugador.Update(disparoS, numeroDeJugador, llamarHost);

                if (numeroDeJugador == 1 && pasoLaRonda == false)
                {
                    llamarHost.setVidasj1(jugador.getVidas());
                    pasoLaRonda = true;
                }

                if (numeroDeJugador == 2 && pasoLaRonda == false)
                {
                    llamarHost.setVidasj2(jugador.getVidas());
                    pasoLaRonda = true;
                }

               if (descansoCalculo == 50 && hayCalculo == false && rondaEspecial == false)
                {
                    Random azar = new Random();

                    if (azar.Next(1, 6) == 2)
                    {
                        rondaEspecial = true;

                        if (azar.Next(1, 6) % 2 == 0)
                        { REB = true; }
                        else
                        { REB = false; }
                    }

                    else
                    {
                        numeroDeRondas++;
                        pasoLaRonda = false;
                        pasoLaRonda2 = false;
                        pasoLaRonda3 = false;

                        if (numeroDeRondas > 1)
                            vidas_meteorito = numeroDeRondas / 2;

                        hayCalculo = true;
                        hacerCalculo = true;
                        meteoroBien.Reload(true, vidas_meteorito);
                        meteoroMal1.Reload(false, vidas_meteorito);
                        meteoroMal2.Reload(false, vidas_meteorito);
                        asignacionEspacios(meteoroBien, meteoroMal1, meteoroMal2);
                    }
                }

                if (descansoCalculo < 50 && rondaEspecial == false)
                {
                    descansoCalculo++;
                }

                if (hayCalculo)
                {
                    Random realentizacion = new Random();

                    comprobacion(meteoroBien, meteoroMal1, meteoroMal2);

                    if (numeroDeRondas > 10)
                    {
                        if (realentizacion.Next(0, 5) == 3)
                        {
                            foreach (Meteoro m in meteoros)
                            {
                                m.Update(velocidad_meteorito, jugador, jugador.getDisparos(), explosionS, llamarHost);
                            }
                        }
                    }

                    else
                    {
                        if (realentizacion.Next(0, 3) == 2)
                        {
                            foreach (Meteoro m in meteoros)
                            {
                                m.Update(velocidad_meteorito, jugador, jugador.getDisparos(), explosionS, llamarHost);
                            }
                        }
                    }
                }

                if (hacerCalculo)
                {
                    calculo = new Calculo();
                    hacerCalculo = false;
                }
            }

            else
            {
                if (jugador.acelerar(victoria) == true)
                    this.Exit();
            }
        }

        public void accionesDraw(Nave jugador)
        {
            spriteBatch.Draw(fondopantalla, new Rectangle(0, 0, 600, 490), Color.White);
            spriteBatch.Draw(fondo2, new Rectangle(100, rx2, 405, 393), Color.White);

            if (pasoLaRonda2 == false)
            {
                vidasj1 = llamarHost.getvidapj1();
                vidasj2 = llamarHost.getvidapj2();
                pasoLaRonda2 = true;
            }

            if (rondaEspecial)
            {
                if (REB == false)
                {
                    if (rocaAp.Update(jugador, explosionS))
                    {
                        rocaAp.Draw(spriteBatch);
                    }

                    else
                    {
                        rondaEspecial = false;
                    }
                }

                else
                {

                    if (vidaAp.Update(jugador, llamarHost))
                    {
                        vidaAp.Draw(spriteBatch);
                    }

                    else
                    {
                        rondaEspecial = false;
                    }
                }
            }


            if (pasoLaRonda3 == false)
            {
                gano1 = llamarHost.getVictoriaJ1();
                gano2 = llamarHost.getVictoriaJ2();
                pasoLaRonda3 = true;
            }

            if ((numeroDeJugador == 1 && gano2 == false) || (numeroDeJugador == 2 && gano1 == false))
            {

                if (hayCalculo && (numeroDeRondas <= cantidadMaxRondas))
                {
                    d1 = meteoroBien.Draw(spriteBatch);
                    d2 = meteoroMal1.Draw(spriteBatch);
                    d3 = meteoroMal2.Draw(spriteBatch);

                    spriteBatch.DrawString(cartel, calculo.getCuenta(), new Vector2(230, 20), Color.White);

                    spriteBatch.DrawString(cartel, calculo.getResultado().ToString(),
                    new Vector2(meteoroBien.getRectangulo().X + 55, meteoroBien.getRectangulo().Y + 50), Color.Black);

                    spriteBatch.DrawString(cartel, calculo.getResultadoM1().ToString(),
                    new Vector2(meteoroMal1.getRectangulo().X + 55, meteoroMal1.getRectangulo().Y + 50), Color.Black);

                    spriteBatch.DrawString(cartel, calculo.getResultadoM2().ToString(),
                    new Vector2(meteoroMal2.getRectangulo().X + 55, meteoroMal2.getRectangulo().Y + 50), Color.Black);

                    if (d1 == false && d2 == false && d3 == false)
                    {
                        descansoCalculo = 0;
                        hayCalculo = false;
                    }
                }

                if (numeroDeRondas <= cantidadMaxRondas)
                {
                    List<Disparo> dp = new List<Disparo>();
                    spriteBatch.DrawString(cartel, "Pts: ", new Vector2(365, 20), Color.White);

                    if (numeroDeJugador == 1)
                    {
                        spriteBatch.DrawString(cartel, "Ronda PJ1: " + (numeroDeRondas - 1).ToString(), new Vector2(365, 50), Color.White);
                        spriteBatch.DrawString(cartel, " x " + jugador.getVidas().ToString(), new Vector2(30, 20), Color.White);
                        spriteBatch.Draw(vida, new Rectangle(10, 20, 20, 20), Color.White);
                        spriteBatch.DrawString(cartel, jugador.getPuntaje().ToString(), new Vector2(435, 20), Color.White);
                        jugador.Draw(spriteBatch);
                        dp = disparos_perdidos;
                    }


                    if (numeroDeJugador == 2)
                    {
                        spriteBatch.DrawString(cartel, "Ronda PJ2: " + (numeroDeRondas - 1).ToString(), new Vector2(365, 50), Color.White);
                        spriteBatch.DrawString(cartel, " x " + jugador.getVidas().ToString(), new Vector2(30, 20), Color.White);
                        spriteBatch.Draw(vida, new Rectangle(10, 20, 20, 20), Color.White);
                        spriteBatch.DrawString(cartel, jugador.getPuntaje().ToString(), new Vector2(435, 20), Color.White);
                        jugador.Draw(spriteBatch);
                        dp = disparos_perdidos2;
                    }

                    foreach (Disparo d in jugador.getDisparos())
                    {
                        if (d.getTextura() == null)
                            d.setTextura(Content.Load<Texture2D>("Imagenes/disparo"));

                        if (d.getRectangulo().Y > 0 && d.getDaño() != 0)
                            spriteBatch.Draw(d.getTextura(), d.getRectangulo(), Color.White);
                        else
                        {
                            dp.Add(d);
                        }

                    }

                    foreach (Disparo p in dp)
                    {
                        jugador.eliminarDisparo(p);
                    }

                    dp.Clear();

                }
            }

            if ((numeroDeRondas > cantidadMaxRondas) || (numeroDeJugador == 1 && gano1 == true) || (numeroDeJugador == 2 && gano2 == true))
            {
                if (numeroDeJugador == 1 && gano1==false)
                {
                    llamarHost.setVictoriaJ1(true);
                }

                if (numeroDeJugador == 2 && gano2 == false)
                {
                    llamarHost.setVictoriaJ2(true);
                }

                spriteBatch.Draw(fondopantalla, new Rectangle(0, 0, 510, 490), Color.White);

                jugador.Draw(spriteBatch);

                if (jugador.acelerar(victoria) == false)
                {
                    spriteBatch.DrawString(cartel, "Ganaste", new Vector2(210, 20), Color.White);

                    if (jugador.getVidas() != 100)
                        jugador.setVidas(100);

                    if (terminado == false)
                    {
                        terminado = true;
                    }
                }
                else
                {
                    if(numeroDeJugador==1)
                        llamarHost.setVidasj1(123);

                    if (numeroDeJugador == 2)
                        llamarHost.setVidasj2(123);

                    this.Exit();
                }
            }

            if ((jugador.getVidas() < 1) || (numeroDeJugador == 1 && gano2 == true) || (numeroDeJugador == 2 && gano1 == true))
            {
                if (numeroDeJugador == 1 && gano2==false)
                {
                    llamarHost.setVictoriaJ2(true);
                }

                if (numeroDeJugador == 2 && gano1==false)
                {
                    llamarHost.setVictoriaJ1(true);
                }

                GraphicsDevice.Clear(Color.White);
                spriteBatch.Draw(fondopantalla, new Rectangle(0, 0, 510, 490), Color.White);
                spriteBatch.Draw(jugador.getTextura(), new Rectangle(212, 260, 68, 68), Color.White);
                spriteBatch.DrawString(titulos, "Juego Terminado", new Vector2(40, 100), Color.Red);

                if (terminado == false)
                {
                    terminado = true;
                }

                if (numeroDeJugador == 1 && vidasj2 == 123)
                {
                    this.Exit();
                }

                if (numeroDeJugador == 2 && vidasj1 == 123)
                {
                    this.Exit();
                }
            }

        }
    }

}