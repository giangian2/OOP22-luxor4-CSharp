using System.Drawing;

namespace OOP22_luxor4_CSharp_Candoli_Francesco.App.Enums
{

    /*
    * Enum that represents all possible colors of a ball,
    * it uses Color class.
    */
    public enum BallColor
    {
        RED,
        BLUE,
        GREEN,
        YELLOW
    }

    public static class BallColorExtensions
    {
        /*
        * Get a random element of the enum.
        */ 
        public static Color GetRandomColor()
        {
            BallColor[] colors = (BallColor[])Enum.GetValues(typeof(BallColor));
            BallColor choosen = colors[new Random().Next(colors.Length)];
            Color choosenColor = choosen switch
            {
                BallColor.RED => System.Drawing.Color.Red,
                BallColor.BLUE => System.Drawing.Color.Blue,
                BallColor.GREEN => System.Drawing.Color.Green,
                BallColor.YELLOW => System.Drawing.Color.Yellow,
                _ => throw new NotImplementedException(),
            };
            return choosenColor;
        }

        /** 
        * Return the color of the enum element.
        */
        public static Color GetBallColor(BallColor bc) {
        Color color = bc switch
            {
                BallColor.RED => System.Drawing.Color.Red,
                BallColor.BLUE => System.Drawing.Color.Blue,
                BallColor.GREEN => System.Drawing.Color.Green,
                BallColor.YELLOW => System.Drawing.Color.Yellow,
                _ => throw new NotImplementedException(),
            };
            return color;
        }
    }
}