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
    class Enemy1 : IEnemyShip
    {
        //Instance Variables
        private AI_ZigZag z_AI;
        private bool z_isAvailable;

        //Constructor
        public Enemy1(Texture2D loadedSprite, Rectangle viewPort)
            : base(loadedSprite)
        {
            z_AI = new AI_ZigZag(viewPort);
            this.setPosition(this.z_AI.getStartingPosition());
            this.z_isAvailable = true;
        }

        //Accessors

        //Mutators











        public override void AIUpdate(GameTime gameTime)
        {
            if (this.z_AI.okToRemove())
            {
                this.setIsAlive(false);
                return;
            }

            this.setVelocity(this.z_AI.calculateNewVelocity(this.getPosition(), gameTime));

            this.upDatePosition();
        }

        public override bool getIsAvailable()
        {
            return this.z_isAvailable;
        }

        public override void setIsAvailable(bool isAvailable)
        {
            this.z_isAvailable = isAvailable;
        }

    }
}
