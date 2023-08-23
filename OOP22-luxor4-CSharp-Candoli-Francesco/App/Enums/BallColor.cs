using System.Drawing;

namespace OOP22_luxor4_CSharp_Candoli_Francesco.App.Enums
{

    public enum BallColor
    {
        /// <summary>
        /// Color red.
        /// </summary>
        RED,

        /// <summary>
        /// Color blue.
        /// </summary>
        BLUE,

        /// <summary>
        /// Color green.
        /// </summary>
        GREEN,

        /// <summary>
        /// Color yellow.
        /// </summary>
        YELLOW
    }

    public static class BallColorExtensions
    {
        /// <summary>
        /// Get a random element of the enum.
        /// </summary>
        /// <returns>Random BallColor.</returns>
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
    }
}