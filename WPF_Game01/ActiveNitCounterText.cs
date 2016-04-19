using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFStartupDemo
{
    //class ActiveNitCounterText:FloatingText
    //{
    //    internal ActiveNitCounterText(string text, double percentageX, double percentageY, double fontSize, Color color)
    //        : base(text,percentageX,percentageY,fontSize,color)
    //    {

    //    }

    //    int frameCounter = 29;
    //    int zeroNitCounter = 0;
    //    internal override void update()
    //    {
    //        frameCounter++;
    //        if(frameCounter>15)
    //        {
    //            frameCounter = 0;
    //            Text = "Nits: "+Nit.activeNitCount.ToString();
    //            if (Nit.activeNitCount == 0)
    //            {
    //                zeroNitCounter++;
    //                if (zeroNitCounter > 5)
    //                {
    //                    zeroNitCounter = 0;
    //                    for (int i = 0; i < 5; i++)
    //                    {
    //                        Nit nuNit = Nit.getNextAvailable();
    //                        if (nuNit != null)
    //                        {
    //                            nuNit.RandomizeGenomes();
    //                            nuNit.energy = 50.0;
    //                            nuNit.X = G.gameWidth;
    //                            nuNit.Y = G.randD(0.0, G.gameHeight);
    //                            Nit.activeNitCount++;
    //                        }
    //                    }
    //                    Nit.extinctionCount++;
    //                    //G.extinctionCounterText.Text = "Extinctions: " + Nit.extinctionCount.ToString();
    //                }
    //            }
    //        }
    //        base.update();
    //    }

    //}
}
