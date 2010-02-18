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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.Text;

namespace Space_Cats_V1._2
{
    class ScrollingBackgroundManager
    {
        //Instance Variables
        private ScrollingBackground z_backgroundImage1;
        private ScrollingBackground z_backgroundImage2;
        private Rectangle z_viewPort;

        //Constructor
        public ScrollingBackgroundManager(Texture2D background, Rectangle viewPort)
        {
            this.z_viewPort = viewPort;
            this.z_backgroundImage1 = new ScrollingBackground(background);
            this.z_backgroundImage2 = new ScrollingBackground(background);
        }

        //Update Method
        public void Update()
        {
            //Update the Scrolling Background Images
            if (this.z_backgroundImage1.getPosition().Y >= this.z_viewPort.Height)
            {
                //Then it is off of the stage, reset it back at the top
                this.z_backgroundImage1.setPosition(new Vector2(0, 0.0f - this.z_viewPort.Height));
                //this.z_backgroundImage1.upDatePosition();
            }
            if (this.z_backgroundImage2.getPosition().Y >= this.z_viewPort.Height)
            {
                //Then it is off of the stage, reset it back at the top
                this.z_backgroundImage2.setPosition(new Vector2(0, 0.0f - this.z_viewPort.Height));
                //this.z_backgroundImage2.upDatePosition();
            }
            //The order of the upDatePosition Matters I think
            if (this.z_backgroundImage1.getPosition().Y > this.z_backgroundImage2.getPosition().Y)
            {
                this.z_backgroundImage2.upDatePosition();
                this.z_backgroundImage1.upDatePosition();
            }
            else
            {
                this.z_backgroundImage1.upDatePosition();
                this.z_backgroundImage2.upDatePosition();
            }
        }

        //Draw Method
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw Background images
            if (this.z_backgroundImage1.getIsAlive())
                spriteBatch.Draw(this.z_backgroundImage1.getSprite(), this.z_backgroundImage1.getPosition(), null,
                    Color.White, 0, new Vector2(0, 0), this.z_backgroundImage1.Scale(this.z_viewPort)
                    , SpriteEffects.None, 1);
            if (this.z_backgroundImage2.getIsAlive())
                spriteBatch.Draw(this.z_backgroundImage2.getSprite(), this.z_backgroundImage2.getPosition(), null,
                    Color.White, 0, new Vector2(0, 0), this.z_backgroundImage2.Scale(this.z_viewPort)
                    , SpriteEffects.None, 1);


        }
        
    }
}
