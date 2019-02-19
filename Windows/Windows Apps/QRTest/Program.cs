using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace QRTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            for (var i = 0; i < 100; i++)
            {
                var qrCode = qrEncoder.Encode(string.Format("{0}Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", i));
                var renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);
                using (var stream = new FileStream(string.Format("{0}lbl{1}.bmp", Path.GetTempPath(), i),FileMode.Create))
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Bmp, stream);
            }
        }
    }
}
