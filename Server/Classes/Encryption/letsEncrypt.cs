using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Server.Classes.Encryption {
    public class LetsEncrypt {
        public string _publicKey;
        public string encryptedbytes;

        public UnicodeEncoding _encoder = new UnicodeEncoding ();

        public DataObject Encrypteddataobject { get; set; }

        public LetsEncrypt (Data data, string keys) {

            _publicKey = keys;

            List<string> values = new List<string> ();

            foreach (var prop in data.GetType ().GetProperties ()) {
                values.Add (prop.GetValue (data, null).ToString ());
            }

            List<string> encryptedvalues = new List<string> ();

            foreach (var item in values) {
                encryptedvalues.Add (Encrypt (item, _publicKey));
            }

            DataObject dataobject = new DataObject ();
            //INSTANTIE: politie (P)
            if (keys == "<RSAKeyValue><Modulus>vR/y8Z+LblM64thdCBkayA/lb5n2VPitqnQ8kxMEDS1YhxDqH2cl1/UhKpXDkTwKWYTZzaXafUq2P+QnJycnq3uNuRi0R/9ujMuoOLrHEpoDXEgZoEpMQcbxSMmRbialoo5EQV25vk1WUPEsOblTN87olDy6v5eny8KWhlvk7Ak=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>") {
                dataobject.Naam = encryptedvalues.ElementAt (0);
                dataobject.BSN = encryptedvalues.ElementAt (1);
                dataobject.Geb_Datum = encryptedvalues.ElementAt (2);
                dataobject.Organisatie = encryptedvalues.ElementAt (3);
                dataobject.Groep = encryptedvalues.ElementAt (4);
                dataobject.Antecendenten = encryptedvalues.ElementAt (5);
                dataobject.Aanhoudingen = encryptedvalues.ElementAt (6);
                dataobject.HeeftISDMaatregel = encryptedvalues.ElementAt (7);
                dataobject.Sepots = encryptedvalues.ElementAt (8);
                dataobject.HeeftOnderzoekRad = encryptedvalues.ElementAt (9);
                dataobject.LopendeDossiers = encryptedvalues.ElementAt (10);
                dataobject.BezitUitkering = encryptedvalues.ElementAt (11);
                dataobject.MeldingenRad = encryptedvalues.ElementAt (12);
                dataobject.ZitInGroepsAanpak = encryptedvalues.ElementAt (13);
                dataobject.HeeftIdBewijs = encryptedvalues.ElementAt (14);
                dataobject.LopendTraject = encryptedvalues.ElementAt (15);
                dataobject.LaatsteGesprek = encryptedvalues.ElementAt (16);
            }
            // OM (O)
            else if (keys == "<RSAKeyValue><Modulus>2aTQ/p354qiaH4eSuNLZMkP9uOKuFf4In6fZ+K0gbqVcBvT259SJyMl+VtPTY8wqbd1GeK49TvAAZq9P/ukVK+fMWHCRDf52z0SDUwsGupC472yQ8zMuPj6QlK0m8dyeN7WoYQ7UiDReo3jr1vzMRqVnlrqcTxi3t7oNs09dj9M=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>") {
                dataobject.Naam = encryptedvalues.ElementAt (0);
                dataobject.BSN = encryptedvalues.ElementAt (1);
                dataobject.Geb_Datum = encryptedvalues.ElementAt (2);
                dataobject.Organisatie = encryptedvalues.ElementAt (3);
                dataobject.Groep = encryptedvalues.ElementAt (4);
                dataobject.Antecendenten = encryptedvalues.ElementAt (5);
                dataobject.Aanhoudingen = encryptedvalues.ElementAt (6);
                dataobject.HeeftISDMaatregel = encryptedvalues.ElementAt (7);
                dataobject.Sepots = encryptedvalues.ElementAt (8);
                dataobject.HeeftOnderzoekRad = encryptedvalues.ElementAt (9);
                dataobject.LopendeDossiers = encryptedvalues.ElementAt (10);
                dataobject.BezitUitkering = encryptedvalues.ElementAt (11);
                dataobject.MeldingenRad = encryptedvalues.ElementAt (12);
                dataobject.ZitInGroepsAanpak = encryptedvalues.ElementAt (13);
                dataobject.HeeftIdBewijs = encryptedvalues.ElementAt (14);
                dataobject.LopendTraject = encryptedvalues.ElementAt (15);
                dataobject.LaatsteGesprek = encryptedvalues.ElementAt (16);
            }
            // Gemeente (G)
            else if (keys == "<RSAKeyValue><Modulus>49v5PxsXU/kuEXS+slKCnkHIFhjylnRj+xlRqCEIO8LofTmddJRDg1t0vPIViEL8T/kNoFe+iaXLhna29mNk94qYk01WTChZR248DYK4PmT70cQx+Pkel1e3QqtWLLCvd5wRmcgkKH5+VyrVgurvWGPB0XWcY+hxlAoGLG2EGwc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>") {
                dataobject.Naam = encryptedvalues.ElementAt (0);
                dataobject.BSN = encryptedvalues.ElementAt (1);
                dataobject.Geb_Datum = encryptedvalues.ElementAt (2);
                dataobject.Organisatie = encryptedvalues.ElementAt (3);
                dataobject.Groep = encryptedvalues.ElementAt (4);
                dataobject.Antecendenten = encryptedvalues.ElementAt (5);
                dataobject.Aanhoudingen = encryptedvalues.ElementAt (6);
                dataobject.HeeftISDMaatregel = encryptedvalues.ElementAt (7);
                dataobject.Sepots = encryptedvalues.ElementAt (8);
                dataobject.HeeftOnderzoekRad = encryptedvalues.ElementAt (9);
                dataobject.LopendeDossiers = encryptedvalues.ElementAt (10);
                dataobject.BezitUitkering = encryptedvalues.ElementAt (11);
                dataobject.MeldingenRad = encryptedvalues.ElementAt (12);
                dataobject.ZitInGroepsAanpak = encryptedvalues.ElementAt (13);
                dataobject.HeeftIdBewijs = encryptedvalues.ElementAt (14);
                dataobject.LopendTraject = encryptedvalues.ElementAt (15);
                dataobject.LaatsteGesprek = encryptedvalues.ElementAt (16);
            }
            // Reclassering (R)
            else if (keys == "<RSAKeyValue><Modulus>2rMDhhT5FQauqgOpZ2vZT2WxKcYw4USY020PtmX3Be7wMlDpWYbFauUTdcGOQLz0ampff+mMQc90NlkW+IBTPzS9Mq6OFpxmmKQHzstueJkW1owX20T5hs2Mc2ImYU0j0gGD33AnM9BzyIjiGognomG6pMBx6MAOmrCwXu9fkus=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>") {
                dataobject.Naam = encryptedvalues.ElementAt (0);
                dataobject.BSN = encryptedvalues.ElementAt (1);
                dataobject.Geb_Datum = encryptedvalues.ElementAt (2);
                dataobject.Organisatie = encryptedvalues.ElementAt (3);
                dataobject.Groep = encryptedvalues.ElementAt (4);
                dataobject.Antecendenten = encryptedvalues.ElementAt (5);
                dataobject.Aanhoudingen = encryptedvalues.ElementAt (6);
                dataobject.HeeftISDMaatregel = encryptedvalues.ElementAt (7);
                dataobject.Sepots = encryptedvalues.ElementAt (8);
                dataobject.HeeftOnderzoekRad = encryptedvalues.ElementAt (9);
                dataobject.LopendeDossiers = encryptedvalues.ElementAt (10);
                dataobject.BezitUitkering = encryptedvalues.ElementAt (11);
                dataobject.MeldingenRad = encryptedvalues.ElementAt (12);
                dataobject.ZitInGroepsAanpak = encryptedvalues.ElementAt (13);
                dataobject.HeeftIdBewijs = encryptedvalues.ElementAt (14);
                dataobject.LopendTraject = encryptedvalues.ElementAt (15);
                dataobject.LaatsteGesprek = encryptedvalues.ElementAt (16);
            } else {
                dataobject = null;
            }

            Encrypteddataobject = dataobject;
        }

        public DataObject showEncrypted () {
            return Encrypteddataobject;
        }
        // public string GetKeyString (RSAParameters publicKey) {

        //     var stringWriter = new System.IO.StringWriter ();
        //     var xmlSerializer = new System.Xml.Serialization.XmlSerializer (typeof (RSAParameters));
        //     xmlSerializer.Serialize (stringWriter, publicKey);
        //     return stringWriter.ToString ();
        // }

        public string Encrypt (string textToEncrypt, string publicKeyString) {
            var bytesToEncrypt = Encoding.UTF8.GetBytes (textToEncrypt);

            using (var rsa = new RSACryptoServiceProvider (2048)) {
                try {
                    FromXmlString1 (rsa, publicKeyString.ToString ());
                    var encryptedData = rsa.Encrypt (bytesToEncrypt, true);
                    var base64Encrypted = Convert.ToBase64String (encryptedData);
                    return base64Encrypted;
                } finally {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        public void FromXmlString1 (RSACryptoServiceProvider rsa, string xmlString) {
            RSAParameters parameters = new RSAParameters ();

            XmlDocument xmlDoc = new XmlDocument ();
            xmlDoc.LoadXml (xmlString);

            if (xmlDoc.DocumentElement.Name.Equals ("RSAKeyValue")) {
                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes) {
                    switch (node.Name) {
                        case "Modulus":
                            parameters.Modulus = Convert.FromBase64String (node.InnerText);
                            break;
                        case "Exponent":
                            parameters.Exponent = Convert.FromBase64String (node.InnerText);
                            break;
                        case "P":
                            parameters.P = Convert.FromBase64String (node.InnerText);
                            break;
                        case "Q":
                            parameters.Q = Convert.FromBase64String (node.InnerText);
                            break;
                        case "DP":
                            parameters.DP = Convert.FromBase64String (node.InnerText);
                            break;
                        case "DQ":
                            parameters.DQ = Convert.FromBase64String (node.InnerText);
                            break;
                        case "InverseQ":
                            parameters.InverseQ = Convert.FromBase64String (node.InnerText);
                            break;
                        case "D":
                            parameters.D = Convert.FromBase64String (node.InnerText);
                            break;
                    }
                }
            } else {
                throw new Exception ("Invalid XML RSA key.");
            }

            rsa.ImportParameters (parameters);
        }

    }

}