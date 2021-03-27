using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace barcode.Services
{
    public class BarcodeClassifier: IBarcodeClassifier
    {
        private readonly Dictionary<string,string> rules = new Dictionary<string,string>();

        public BarcodeClassifier()
        {
            rules.Add("PS", "PS.*");
            rules.Add("DPD","1696.*");
            rules.Add("GLS","GL.*");
            rules.Add("UPS","UP.*");

        }

        public string Classify(string code)
        {
            foreach (var kv in rules)
            {
                if (Regex.IsMatch(code, kv.Value)) return kv.Key;
            }

            return "UNKNOWN";
        }
    }
}
