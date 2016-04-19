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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFStartupDemo
{
    class BigGameText : GameText
    {
        static MediaPlayer getReadySound = null;
        static MediaPlayer areYouReadySound = null;
        static MediaPlayer lookOutSound = null;
        static MediaPlayer headsUpSound = null;

        public BigGameText():base()
        {
            G.SetupSound(ref getReadySound, "getReady.wav");
            G.SetupSound(ref areYouReadySound, "AreYouReady.wav");
            G.SetupSound(ref lookOutSound, "LookOut.wav");
            G.SetupSound(ref headsUpSound, "HeadsUp.wav");

            getReadySound.Volume = 0.3;
            areYouReadySound.Volume = 0.3;
            lookOutSound.Volume = 0.3;
            headsUpSound.Volume = 0.3;

            FontFamily = "Arial Black";
            Height = 500.0;
            Width = 1000.0;
            TextAlignment = TextAlignment.Center;
            Text = "Halloween Attack";
            FontSize = 100;

            Y = G.gameHeight * 0.125;
            X = G.gameWidth / 2.0;

            dX = 0.0;
            dY = 0.0;

            Scale = 0.5;
            ((TextBlock)(element)).Foreground = new SolidColorBrush(G.randLightColor());

            AddToGame();
        }


        public bool countDown = false;

        public int count = 0;

        public void startCountDown()
        {
            FontSize = 100;
            count = 10;
            countDown = true;
            frameCount = 0;
            frameCountReset = 50;
            Text = count.ToString();
        }

        int frameCount = 0;
        int frameCountReset = 60;
        internal override void update()
        {
            if (isActive)
            {
                if (countDown)
                {
                    frameCount++;
                    Scale *= 1.005;
                    Y += 1.8;
                    if (frameCount > frameCountReset)
                    {
                        frameCountReset *= 6;
                        frameCountReset /= 7;
                        count--;
                        if(count==5)
                        {
                            PlayRandomReadySound();
                        }
                        FontColor = G.randLightColor();
                        Text = count.ToString();
                        frameCount = 0;
                    }
                }
                if ((Text == "Game Over!\nEsc to play again")  && (Scale < 2.0))
                {
                    Scale *= 1.01;
                    if(Scale>=2.0)
                    {
                        Shooter.gameOverSound.Stop();
                        Shooter.gameOverSound.Play();
                    }
                    Y += 3.2;
                }
            }
        }

        private static void PlayRandomReadySound()
        {
            int r = G.randI(4);
            switch (r)
            {
                case 0:
                    getReadySound.Stop();
                    getReadySound.Play();
                    break;
                case 1:
                    areYouReadySound.Stop();
                    areYouReadySound.Play();
                    break;
                case 2:
                    lookOutSound.Stop();
                    lookOutSound.Play();
                    break;
                case 3:
                    headsUpSound.Stop();
                    headsUpSound.Play();
                    break;
            }
        }

    }
}
