//************************************************
//
// (c) Copyright 2015 Dr. Thomas Fernandez
//
// All rights reserved.
//
//************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WPFStartupDemo
{
    class BouncingBall : GameObject
    {
        static BitmapImage bMap = null;

        static BitmapImage bMap2 = null;

        static BitmapImage bMap3 = null;

        static BitmapImage bMap4 = null;

        static BitmapImage bMap5 = null;

        public static List<BouncingBall> list = new List<BouncingBall>();

        public static int ballCount=0;

        public static int startSide=-1;

        public BouncingBall()
        {
            if (list.Count()==0)
            {
                if (G.chance(0.2))
                {
                    startSide = 3;
                }
                else if (G.chance(0.5))
                {
                    startSide = 2;
                }
                else
                {
                    startSide = 1;
                }
            }
            ballCount++;
            if (G.chance(0.2))
            {
                UseImage("Skull.png", bMap);
            }
            else if (G.chance(0.25))
            {
                UseImage("Skull2.png", bMap2);
            }
            else if (G.chance(0.33333))
            {
                UseImage("Skull3.png", bMap3);
            }
            else if (G.chance(0.5))
            {
                UseImage("Skull4.png", bMap4);
            }
            else 
            {
                UseImage("Skull5.png", bMap5);
            }
            Y = 50.0;
            if (startSide==3)
            {
                if (G.chance(0.5))
                {
                    X = G.randD(G.gameWidth + 20.0, G.gameWidth + 100);
                    dX = G.randD(-5.0, -1.0);
                }
                else
                {
                    X = G.randD(-100.0, -20.0);
                    dX = G.randD(1.0, 5.0);
                }
            }
            else if (startSide==2)
            {
                X = G.randD(G.gameWidth + 20.0, G.gameWidth + 100);
                dX = G.randD(-5.0, -1.0);
            }
            else
            {
                X = G.randD(-100.0, -20.0);
                dX = G.randD(1.0, 5.0);
            }
            dY = G.randD(1.0,5.0);
            rotation = G.randD(-5, 5);



            BouncingBall.list.Add(this);

            AddToGame();

        }


        double gravity = 0.1;
        double friction = 0.99999;
        double rotation;

        public string state = "Normal";



        internal override void update()
        {
            if (isActive)
            {
                Angle += rotation;
                switch (state)
                {
                    case "Normal":
                        dY += gravity;
                        if (Y > G.gameHeight - Height / 2.0)
                        {
                            dY = -Math.Abs(dY * 0.98);
                            rotation = G.randD(-10, 10);
                        }
                        if (X > G.gameWidth - Width / 2.0)
                        {
                            dX = -Math.Abs(dX);
                            rotation = G.randD(-20, 20);
                        }
                        if (X < 0.0 + Width / 2.0)
                        {
                            dX = Math.Abs(dX);
                            rotation = G.randD(-20, 20);
                        }

                        dX *= friction;
                        dY *= friction;
                        X += dX;
                        Y += dY;
                        break;
                    case "Hit":
                        if(G.gameEngine.gameNotOver) G.gameEngine.score += G.gameEngine.bonus;
                        ballCount--;
                        if (ballCount <= 0)
                        {
                            GameEngine.bigGameText.startCountDown();
                        }
                        Explosion exp = Explosion.getNextAvailable();
                        if(exp!=null)
                        {
                            exp.X = X;
                            exp.Y = Y;
                        }
                        //for (int i = 0; i < G.randI(0,2); i++)
                        //{
                        //    Bullet obj = Bullet.getNextAvailable();
                        //    if (obj != null)
                        //    {
                        //        obj.frameCount = 20;
                        //        obj.X = X;
                        //        obj.Y = Y;
                        //        obj.dX = G.randD(-10.0, 10.0);
                        //        obj.dY = G.randD(-10.0, 10.0);
                        //    }
                        //}
                        makeInactive();
                        state = "Normal";
                        break;
                }
            }
        }




    }
}
