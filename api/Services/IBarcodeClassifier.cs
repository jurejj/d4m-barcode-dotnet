namespace barcode.Services
{
    public interface IBarcodeClassifier
    {
        string Classify(string code);
    }
}