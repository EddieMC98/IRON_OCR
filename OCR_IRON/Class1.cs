using System;
using IronOcr;

namespace OCR_IRON
{
    public class IRON_OCR
    {
        public string LeerImagen(string PathFile) {
            var Ocr = new IronTesseract();
            var text = string.Empty;
            
            // Configure for speed
            Ocr.Configuration.BlackListCharacters = "~`$#^*_}{][|\\";
            Ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.Auto;
            Ocr.Configuration.TesseractVersion = TesseractVersion.Tesseract5;
            Ocr.Configuration.EngineMode = TesseractEngineMode.TesseractAndLstm;
            Ocr.Language = OcrLanguage.Spanish;
            using (var Input = new OcrInput(PathFile))
            {
                Input.Deskew();  // use if image not straight
                Input.DeNoise(); // use if image contains digital noise
                var Result = Ocr.Read(Input);
                text = Texto_OCR(Result.Text);
            }
            return text;
        }

        public static string Texto_OCR(string texto_imagen)
        {
            var palabras = texto_imagen.Split("\n");
            var texto_requerido = "";
            foreach (var item in palabras)
            {
                if (item.StartsWith("Banco"))
                {
                    int found = item.IndexOf("Banco");
                    var aux = item.Substring(found + 6);
                    texto_requerido += aux + "\n";
                }
                if (item.Contains("CUENTA"))
                {
                    int found = item.IndexOf("CUENTA");
                    var aux = item.Substring(found + 12, 15);
                    texto_requerido += aux + "\n";
                }
                if (item.Contains("CHEQUE"))
                {
                    int found = item.IndexOf("CHEQUE");
                    var aux = item.Substring(found + 13, 6);
                    texto_requerido += aux + "\n";
                }
                if (item.StartsWith("GT"))
                {
                    int found = item.IndexOf("GT");
                    var aux = item.Substring(found);
                    texto_requerido += aux + "\n";
                }
            }
            texto_requerido += palabras[palabras.Length - 1].Substring(3) + "\n";
            return texto_requerido.Trim();
        }
    }
}
