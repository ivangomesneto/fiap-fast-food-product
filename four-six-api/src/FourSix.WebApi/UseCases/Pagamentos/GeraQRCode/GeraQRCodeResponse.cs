namespace FourSix.WebApi.UseCases.Pagamentos.GeraQRCode
{
    public class GeraQRCodeResponse
    {
        public GeraQRCodeResponse(string qrCode) => QRCode = qrCode;
        public string QRCode { get; }
    }
}
