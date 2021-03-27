using barcode.Services;
using Xunit;

namespace test.Services
{
    public class BarcodeClassifierTest
    {
        
        /**
         * DPD (1696 je oznaka za DPD Slovenija):
- 16962006545199
- 16962006545200
- 16962006545198
- 16962006545197
GLS:
- GL10011580724790001030003A0N
Pošta:
- PS001533346SI
- PS001533828SI
- PS001638355AT
UPS:
- UP598893476NL
- UP757404386BE
         */

        
        [Theory]
        [InlineData("16962006545199","DPD")]
        [InlineData("16962006545200","DPD")]
        [InlineData("16962006545198","DPD")]
        [InlineData("16962006545197","DPD")]
        [InlineData("GL10011580724790001030003A0N","GLS")]
        [InlineData("GL10011580724790001030004A0N","GLS")]
        [InlineData("PS001533346SI","PS")]
        [InlineData("PS001533828SI","PS")]
        [InlineData("PS001638355AT","PS")]
        [InlineData("UP598893476NL","UPS")]
        [InlineData("UP757404386BE","UPS")]
        [InlineData("753948F9834F7749","UNKNOWN")]
        [InlineData("jhfyrufhe7e83yeh","UNKNOWN")]
        public void ClassificationTheory(string code, string carrier)
        {
            Assert.Equal(carrier, new BarcodeClassifier().Classify(code));
        }
        
        
        
    }
}