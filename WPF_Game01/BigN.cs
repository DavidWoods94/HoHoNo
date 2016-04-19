using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFStartupDemo
{
     class BigNit : GameObject
    {
        static BitmapImage bMap1 = null;
        static BitmapImage bMap2 = null;
        static BitmapImage bMap3 = null;
        static MediaPlayer pistolSound = null;
        public static MediaPlayer meltSound = null;
        static public MediaPlayer gameOverSound = null;
        public static List<BigNit> listBigNits = new List<BigNit>();
        //public static int activeNits = 0;
        public int hp;
        public int MAXHP = 50;
        public BigNit()
        {
            G.SetupSound(ref pistolSound, "pistolshotSoft.wav");
            G.SetupSound(ref meltSound, "meltsound.wav");
            G.SetupSound(ref gameOverSound, "GameOver.wav");

            UseImage("meltingsnowman.png", ref bMap3);
            UseImage("snowmanL.png", ref bMap1);
            UseImage("snowmanR.png", ref bMap2);
            
            hp = MAXHP;
            
            Scale = .5;

            //X = G.randD(ScaledWidth / 2.0, G.gameWidth - ScaledWidth / 2.0);
            //SetInMiddle();
            Random rand = new Random();
            int num = rand.Next(2);

            SetSpeed();
            if(G.chance(.5))
            {
                SetRight();
                movingRight = false;
            }
            else 
            {
                SetLeft();
                movingRight = true;
            }
            makeInactive();

            //dX = 300;
            listBigNits.Add(this);
            dY = 0.0;
           // if(G.chance(.5))
            //{
              //  makeInactive();
                //activeNits--;
            //}
            //else { activeNits++; }
            AddToGame();
        }

        public void Kill()
        {
            Melt exp = Melt.getNextAvailable();
            if (exp != null)
            {
                exp.X = this.X;
                exp.Y = this.Y;
            }
            meltSound.Stop();
            meltSound.Play();
            
            makeInactive();
        }
        public static BigNit getNextAvailable()
        {
            foreach (BigNit b in listBigNits)
            {
                if (!b.isActive)
                {
                    return b;
                }
            }
            return null;
        }

        public void SetSpeed()
        {
            if(G.chance(.3))
            {
                acceleration = 2;
            }
            else if(G.chance(.3))
            {
                acceleration = 3.5;
            }
            else
            {
                acceleration = 4.5;
            }
        }

        public void SetInMiddle()
        {
            X = G.gameWidth / 2.0;
            Y = G.gameHeight - (ScaledHeight / 2.0) - 10.0;
        }

        public void SetRight()
        {
            X = G.gameWidth - 20;
            Y = G.gameHeight - (ScaledHeight / 2.0) - 10.0;
            ((Image)element).Source = bMap1;
        }



        static internal void BigNitAttack()
        {
            int numBigNit = 1;
            for (int i = 0; i < numBigNit; i++)
            {
                BigNit n = BigNit.getNextAvailable();
                if (n != null)
                {
                    
                    if(G.chance(.5))
                    {
                        n.SetLeft();
                        n.movingRight = true;
                        n.SetSpeed();
                    }
                    else
                    {
                        n.SetRight();
                        n.movingRight = false;
                        n.SetSpeed();
                    }
                }
            }
        }
        public void SetLeft()
        {
            X = 0;
            Y = G.gameHeight - (ScaledHeight / 2.0) - 10.0;
            ((Image)element).Source = bMap2;
        }

        double gravity = 1.0;
        double friction = 0.0;
        double acceleration = 1.0;

        int frameCount = 0;
        public bool movingRight = false;
        public int sheildFrameCount = 0;
        public bool isSheildOn = false;

        internal override void update()
        {
            if (isActive)
            {
                X += dX;
                if (dY != 0.0) dY += gravity;
                //dY += gravity;
                Y += dY;
                dX *= friction;
                //sheildFrameCount--;
                frameCount++;
                
                if (Y > G.gameHeight - (ScaledHeight / 2.0)-10.0)
                {
                    Y = G.gameHeight - (ScaledHeight / 2.0) -10.0;
                    dY = 0.0;
                }
                else if (Math.Abs(Y-(G.gameHeight - (ScaledHeight / 2.0)-10.0))<0.00000001)
                {
                }
                if (X > G.gameWidth - Width) dX = -Math.Abs(dX);
                if (X < 0) dX = Math.Abs(dX);

                if (movingRight == false)
                {
                    dX -= acceleration;
                    if(X <= -20)
                    {
                        
                        makeInactive();
                        hp = MAXHP;
                    }
                }
                else
                {
                    dX += acceleration;
                    if (X >= G.gameWidth + 20)
                    {
                        makeInactive();
                        //activeNits--;
                        hp = MAXHP;
                    }
                }

                if (hp <= 0)
                {

                    Kill();
                    hp = MAXHP;
                    G.score += 200;
                }
                    

                double maxSpeed = 20.0;

                if (dX > maxSpeed) dX = maxSpeed;
                if (dX < -maxSpeed) dX = -maxSpeed;
            }
        }
    }
}
