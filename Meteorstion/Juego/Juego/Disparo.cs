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
    public class Disparo
    {
        Texture2D textura;
        Rectangle rectangulo;
        int daño;

        public Disparo(Texture2D textura, Rectangle rectangulo, int daño)
        {
            this.textura = textura;
            this.rectangulo = rectangulo;
            this.daño = daño;
        }

        public Texture2D getTextura()
        { return textura; }
        public Rectangle getRectangulo()
        { return rectangulo; }
        public int getDaño()
        { return daño; }

        public void setTextura(Texture2D textura)
        { this.textura = textura; }
        public void setRectangulo(Rectangle rectangulo)
        { this.rectangulo = rectangulo; }
        public void setDaño(int daño)
        { this.daño = daño; }

        public void avanzar()
        {
            rectangulo.Y -= 7;
        }

        public bool Colision(Meteoro bien, Meteoro mal1, Meteoro mal2)
        {
            bool huboColision = false;

            if (this.rectangulo.Intersects(bien.getRectangulo()))
                huboColision = true;
            if (this.rectangulo.Intersects(mal1.getRectangulo()))
                huboColision = true;
            if (this.rectangulo.Intersects(mal2.getRectangulo()))
                huboColision = true;

            return huboColision;

        }
    }
}
