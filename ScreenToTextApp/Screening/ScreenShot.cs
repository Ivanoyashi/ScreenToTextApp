using System.Drawing;
using System.Windows.Forms;

namespace ScreenToTextApp.Screening
{
    /// <summary>
    /// Work with screen image
    /// </summary>
    public class ScreenShot
    {
        public static Bitmap GetScreenShot()
        {
            var bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            using (var gr = Graphics.FromImage(bmp))
                gr.CopyFromScreen(0, 0, 0, 0, new Size(bmp.Width, bmp.Height));

            return bmp;
        }

        /// <summary>
        /// Getting the selected part of the screen
        /// </summary>
        public static Bitmap GetSelectedArea(Rectangle selectedArea, Image fullScreen)
        {
            var bmp = new Bitmap(selectedArea.Width, selectedArea.Height);

            using (var gr = Graphics.FromImage(bmp))
                gr.DrawImage(fullScreen, -selectedArea.Left, -selectedArea.Top);

            return bmp;
        }
    }
}
