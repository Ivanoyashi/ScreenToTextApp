using IronOcr;
using System.Drawing;
using System.Threading.Tasks;

namespace ScreenToTextApp.Recognition
{
    /// <summary>
    /// a class for recognizing text in an image
    /// </summary>
    public class TextRecognizer
    {
        private readonly IronTesseract _ocrRecognizer;

        public TextRecognizer()
        {
            this._ocrRecognizer = new();
            this._ocrRecognizer.AddSecondaryLanguage(OcrLanguage.RussianBest);
        }

        /// <summary>
        /// Getting text from image
        /// </summary>
        /// <param name="bmp">Image</param>
        /// <returns>Recognized text</returns>
        public async Task<string> RecognizeAsync(Bitmap bmp)
        {
            var result = await RecognizeBaseAsync(bmp);

            return result.Text;
        }

        private async Task<OcrResult> RecognizeBaseAsync(Bitmap bmp)
        {
            using var input = new OcrInput();

            input.AddImage(bmp);

            //Input.DeNoise(); 
            //Input.Binarize();
            //Input.ToGrayScale();
            input.EnhanceResolution(250);

            var result = await this._ocrRecognizer.ReadAsync(input);

            bmp.Dispose();

            return result;
        }
    }
}
