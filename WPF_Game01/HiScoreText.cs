//************************************************
//
// (c) Copyright 2015 Dr. Thomas Fernandez
//
// All rights reserved.
//
//************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFStartupDemo
{
    class HiScoreText : GameText
    {
        List<double> hiScore=new List<double>();
        public HiScoreText()
            : base()
        {
            FontFamily = "Arial Black";
            Height = 800.0;
            Width = 1000.0;
            TextAlignment = TextAlignment.Center;
            FontSize = 80;

            Y = 300.0;
            X = G.gameWidth / 10;

            dX = 0.0;
            dY = 0.0;

            Scale = 0.5;

            FontColor = G.randLightColor();
            loadHighScores();
            AddToGame();
        }

        public void addNewScore(double nuScore)
        {
            FontColor = G.randLightColor();
            hiScore.Add(nuScore);
            String s = SetScoreString();
            G.CheckForAlternateContentDir("HighScores.txt");
            File.WriteAllText(G.ContentDir + "HighScores.txt",s);
        }

        private string SetScoreString()
        {
            hiScore.Sort();
            hiScore.Reverse();

            String s = "High Scores:\n";

            for (int i = 0; i < Math.Min(5, hiScore.Count); i++)
            {
                s += hiScore[i].ToString() + "\n";
            }
            Text = s;
            return s;
        }

        private void loadHighScores()
        {
            int counter = 0;
            string line;
            if (File.Exists(G.ContentDir + "HighScores.txt"))
            {
                hiScore.Clear();
                StreamReader file = new StreamReader(G.ContentDir + "HighScores.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (counter != 0)
                    {
                        hiScore.Add(Convert.ToDouble(line));
                    }
                    counter++;
                }
                file.Close();
                SetScoreString();
            }
            else
            {
                ClearHighScores();
            }
            
        }

        public void ClearHighScores()
        {
            hiScore.Clear();
            hiScore.Add(0.0);
            hiScore.Add(0.0);
            hiScore.Add(0.0);
            hiScore.Add(0.0);
            hiScore.Add(0.0);
            File.WriteAllText(G.ContentDir + "HighScores.txt", SetScoreString());
        }

        internal override void update()
        {
            
        }

    }
}
