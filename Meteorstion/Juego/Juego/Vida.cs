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
    class Vida
    {
        Texture2D textura;
        Rectangle rectangulo;

        public Vida(Texture2D textura, Rectangle rectangulo)
        {
            this.textura = textura;
            this.rectangulo = rectangulo;
        }

        public void setTextura(Texture2D textura)
        {
            this.textura = textura;
        }
        public void setRecangulo(Rectangle rectangulo)
        {
            this.rectangulo = rectangulo;
        }
        public Texture2D getTextura()
        {
            return textura;
        }
        public Rectangle getRecangulo()
        {
            return rectangulo;
        }

        public bool Update(Nave personaje, ComunicacionHost llamadahost)
        {
            bool r = true;

            if (this.rectangulo.X == 0 && this.rectangulo.Y == 0)
                asignacion();

            this.rectangulo.Y += 5;

            if (this.rectangulo.Intersects(personaje.getRecangulo()))
            {
                this.entregarVida(personaje, llamadahost);
                personaje.setPuntaje(personaje.getPuntaje() + 200);
                this.rectangulo.X = 0;
                this.rectangulo.Y = 0;
                r = false;
            }

            if (this.rectangulo.Y > 400)
            {
                this.rectangulo.X = 0;
                this.rectangulo.Y = 0;
                r = false;
            }

            return r;
        }

        public void Draw(SpriteBatch s)
        {
            s.Draw(this.textura, this.rectangulo, Color.White);
        }

        public void entregarVida(Nave personaje, ComunicacionHost llamadahost)
        {
            personaje.setVidas(personaje.getVidas() + 1);
            llamadahost.transferirVidaJugador1(personaje.getVidas());
        }

        public void asignacion()
        {
            int r = new Random().Next(1, 4);

            if (r == 1)
            {
                this.rectangulo.X = 65;
            }

            if (r == 2)
            {
                this.rectangulo.X = 220;
            }

            if (r == 3)
            {
                this.rectangulo.X = 390;
            }

            this.rectangulo.Y = 40;

        }
    }
}
