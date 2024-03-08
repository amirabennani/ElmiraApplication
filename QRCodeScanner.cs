using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Mobile;

namespace ElmiraApplication
{
    public static class QRCodeScanner
    {
        public static async Task<string> ScanQRCodeAsync()
        {
            var scanner = new MobileBarcodeScanner();
            var result = await scanner.Scan();

            return result?.Text;
        }
    }
}
