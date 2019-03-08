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

namespace Meteorstion
{
    public class Meteoro
    {
        Texture2D textura;
        Rectangle rectangulo;
        int vidas;
        public int disminuidorPuntaje;

        public Meteoro(Texture2D textura, int ancho, int alto, int x, int y, int vidas)
        {
            this.textura = textura;
            rectangulo = new Rectangle(x, y, ancho, alto);
            this.vidas = vidas;
            disminuidorPuntaje = 0;
        }

        public void setTextura(Texture2D textura)
        {
            this.textura = textura;
        }
        public void setRectangulo(int ancho, int alto, int x, int y)
        {
            this.rectangulo.Width = ancho;
            this.rectangulo.Height = alto;
            this.rectangulo.X = x;
            this.rectangulo.Y = y;
        }
        public void setVidas(int vidas)
        {
            this.vidas = vidas;
        }
        public Texture2D getTextura()
        {
            return textura;
        }
        public Rectangle getRectangulo()
        {
            return rectangulo;
        }
        public int getVidas()
        {
            return vidas;
        }

        public void Update(int velocidad_meteorito, Nave personaje, List<Disparo> disparos,
            SoundEffect explosionS, ComunicacionHost llamadahost)
        {
            List<Disparo> disparos_perdidos = new List<Disparo>();

            if (this.vidas > 0)
            {
                if (this.rectangulo.Y != 490)
                    this.rectangulo.Y += velocidad_meteorito;

                if (this.rectangulo.Intersects(personaje.getRecangulo()))
                {
                    this.vidas = 0;
                    personaje.setVidas(personaje.getVidas() - 1);
                    llamadahost.transferirVidaJugador1(personaje.getVidas());
                    explosionS.Play();

                }

                foreach (Disparo p in disparos)
                {
                    if (this.rectangulo.Intersects(p.getRectangulo()))
                    {
                        if (this.vidas != 100)
                        {
                            this.setVidas(this.getVidas() - 1);

                            if (this.vidas == 0)
                            {
                                personaje.setPuntaje(personaje.getPuntaje() + (100 - disminuidorPuntaje));
                                disminuidorPuntaje = 0;
                                explosionS.Play();
                            }

                        }

                        disparos_perdidos.Add(p);
                    }

                }

                foreach (Disparo p in disparos_perdidos)
                {
                    disparos.Remove(p);
                }

            }
        }

        public bool Draw(SpriteBatch s)
        {
            if (this.vidas > 0 && this.rectangulo.Y < 490)
            {
                s.Draw(this.textura, this.rectangulo, Color.White);
                return true;
            }
            else
                return false;
        }

        public void Reload(bool esBueno, int vidas_meteorito)
        {
            this.setTextura(this.textura);
            this.setRectangulo(140, 120, this.rectangulo.X, 80);

            if (esBueno)
                this.setVidas(vidas_meteorito);

            else
                this.setVidas(100);
        }

        public void acelerar()
        {
            this.rectangulo.Y += 20;
        }

    }
}
