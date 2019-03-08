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
    class Roca
    {
        Texture2D textura;
        Rectangle rectangulo;
        List<Disparo> disparos_perdidos;

        public Roca(Texture2D textura, Rectangle rectangulo)
        {
            this.textura = textura;
            this.rectangulo = rectangulo;
            disparos_perdidos = new List<Disparo>();
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

        public bool Update(Nave personaje, SoundEffect sonido)
        {
            bool r = true;

            if (this.rectangulo.X == 0 && this.rectangulo.Y == 0)
            {
                this.rectangulo.X = personaje.getRecangulo().X;
                this.rectangulo.Y = 40;
            }
            this.rectangulo.Y += 5;

            if (this.rectangulo.Intersects(personaje.getRecangulo()))
            {
                this.quitarVida(personaje);

                if(personaje.getPuntaje()>0)
                personaje.setPuntaje(personaje.getPuntaje() - 200);

                sonido.Play();
                this.rectangulo.X = 0;
                this.rectangulo.Y = 0;
                r = false;
            }


            foreach (Disparo d in personaje.getDisparos())
            {
                if (this.rectangulo.Intersects(d.getRectangulo()))
                {

                    disparos_perdidos.Add(d);
                }

            }

            foreach (Disparo p in disparos_perdidos)
            {
                List<Disparo> disp = personaje.getDisparos();
                disp.Remove(p);
                personaje.setDisparos(disp);
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

        public void quitarVida(Nave personaje)
        {
            personaje.setVidas(personaje.getVidas() - 1);
        }

    }
}
