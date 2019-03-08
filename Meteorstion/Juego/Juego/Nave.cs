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
    public class Nave
    {
        Texture2D textura;
        Rectangle rectangulo;
        int vidas;
        int puntaje;
        List<Disparo> disparos;
        int tiempo_por_disparo;
        bool hold;
        char ultPos;
        bool reproducido;
        bool holdDeHold;

        public Nave(Texture2D textura, int alto, int ancho, int x, int y, int vidas, int puntaje)
        {
            this.textura = textura;
            rectangulo = new Rectangle(x, y, alto, ancho);
            this.vidas = vidas;
            this.puntaje = puntaje;
            disparos = new List<Disparo>();
            hold = true;
            ultPos = 'i';
            reproducido = false;
            holdDeHold = false;
        }

        public void setTextura(Texture2D textura)
        {
            this.textura = textura;
        }
        public void setRecangulo(Rectangle rectangulo)
        {
            this.rectangulo = rectangulo;
        }
        public void setVidas(int vidas)
        {
            this.vidas = vidas;
        }
        public void setPuntaje(int puntaje)
        {
            this.puntaje = puntaje;
        }
        public void setDisparos(List<Disparo> disparos)
        { this.disparos = disparos; }

        public Texture2D getTextura()
        {
            return textura;
        }
        public Rectangle getRecangulo()
        {
            return rectangulo;
        }
        public int getVidas()
        {
            return vidas;
        }
        public int getPuntaje()
        {
            return puntaje;
        }
        public List<Disparo> getDisparos()
        { return disparos; }


        public void Update(SoundEffect sonidoD, int numeroDeJugador, ComunicacionHost llamarHost)
        {
            this.Movimiento(numeroDeJugador, llamarHost);
            this.Disparo(sonidoD);

            foreach (Disparo d in disparos)
            {
                d.avanzar();
            }

            this.tiempo_por_disparo++;

        }

        public void plasmarMovimiento(List<int> movimientos)
        {

            foreach (int movimiento in movimientos)
            {

                if (movimiento == 1)
                {
                    this.rectangulo.X = 220;
                    hold = true;
                    ultPos = 'm';
                }

                if (movimiento == 2)
                {
                    this.rectangulo.X = 65;
                    ultPos = 'i';

                }

                if (movimiento == 3)
                {
                    this.rectangulo.X = 390;
                    ultPos = 'd';
                }

                if (movimiento == 4)
                {
                    this.rectangulo.X = 220;
                    ultPos = 'm';
                    hold = true;
                }

                if (movimiento == 0)
                {
                    hold = false;
                    holdDeHold = false;
                }

            }

        }


        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.textura, this.rectangulo, Color.White);
        }

        public void Movimiento(int numeroDeJugador, ComunicacionHost llamarHost)
        {

            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left)
                 && ultPos == 'd')
            {
                this.rectangulo.X = 220;
                hold = true;
                ultPos = 'm';
                holdDeHold = false;

            }

            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left)
                 && ultPos == 'm' && hold == false)
            {
                this.rectangulo.X = 65;
                ultPos = 'i';

            }

            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right)
               && ultPos == 'm' && hold == false)
            {
                this.rectangulo.X = 390;
                ultPos = 'd';
            }

            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right)
                 && ultPos == 'i')
            {
                this.rectangulo.X = 220;
                ultPos = 'm';
                hold = true;
                holdDeHold = false;
            }

            if (ultPos == 'm' && Keyboard.GetState().IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Right)
                && Keyboard.GetState().IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Left) && holdDeHold == false)
            {
                holdDeHold = true;
                hold = false;
            }

        }

        public void Disparo(SoundEffect sonidoD)
        {
            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space) &&
               this.tiempo_por_disparo > 14)
            {
                this.tiempo_por_disparo = 0;
                sonidoD.Play();
                this.disparos.Add(new Disparo(null, new Rectangle(rectangulo.X + 30, rectangulo.Y + 5, 8, 24), 1));
            }

        }

        public void eliminarDisparo(Disparo d)
        {
            disparos.Remove(d);
        }

        public bool acelerar(SoundEffect sonido)
        {
            if (reproducido == false)
            {
                reproducido = true;
                sonido.Play();
            }

            if (rectangulo.Y > -100)
            {
                this.rectangulo.Y--;
                return false;
            }

            else
            {
                return true;
            }
        }
    }
}
