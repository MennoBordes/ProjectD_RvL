using System;
using System.Security.Cryptography;
using System.Xml;

namespace Server.Classes.Encryption {

    //USE FOR GENERATING PUBLIC AND PRIVATE KEY PAIRS IN XML FORMAT NEEDED BIJ CRYPTO LIBRARY
    public class GenerateKeyPair {

        public string _publicKey { get; set; }
        public string _privateKey { get; set; }

        public GenerateKeyPair () {
            var rsa = new RSACryptoServiceProvider (1024);
            _publicKey = ToXmlString1 (rsa, true);
            _privateKey = ToXmlString1 (rsa, false);
        }

        public string showBoth () {
            return "PUBLICKEY: \n\n" + _publicKey + "\n\n\n" + "PRIVATEKEY: \n\n" + _privateKey;
        }

        public string ToXmlString1 (RSACryptoServiceProvider rsa, bool onlypublic) {
            RSAParameters parameters = rsa.ExportParameters (true);

            if (onlypublic) {
                return string.Format ("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>",
                    Convert.ToBase64String (parameters.Modulus),
                    Convert.ToBase64String (parameters.Exponent));
            }

            return string.Format ("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>",
                Convert.ToBase64String (parameters.Modulus),
                Convert.ToBase64String (parameters.Exponent),
                Convert.ToBase64String (parameters.P),
                Convert.ToBase64String (parameters.Q),
                Convert.ToBase64String (parameters.DP),
                Convert.ToBase64String (parameters.DQ),
                Convert.ToBase64String (parameters.InverseQ),
                Convert.ToBase64String (parameters.D));
        }
    }
}