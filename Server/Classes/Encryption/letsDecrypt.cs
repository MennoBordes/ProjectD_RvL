using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Server.Classes.Encryption {
    public class LetsDecrypt {

        public string _privateKey;

        public string encryptedbytes;

        public UnicodeEncoding _encoder = new UnicodeEncoding ();

        public DataObject Decrypteddataobject { get; set; }

        public LetsDecrypt (Data data, string key) {

            _privateKey = key;

            List<string> values = new List<string> ();

            foreach (var prop in data.GetType ().GetProperties ()) {
                values.Add (prop.GetValue (data, null).ToString ());
            }

            List<string> decryptedvalues = new List<string> ();

            foreach (var item in values) {
                decryptedvalues.Add (Decrypt (item, _privateKey));
            }

            DataObject dataobject = new DataObject ();

            dataobject.Naam = decryptedvalues.ElementAt (0);
            dataobject.BSN = decryptedvalues.ElementAt (1);
            dataobject.Geb_Datum = decryptedvalues.ElementAt (2);
            dataobject.Organisatie = decryptedvalues.ElementAt (3);
            dataobject.Groep = decryptedvalues.ElementAt (4);
            dataobject.Antecendenten = decryptedvalues.ElementAt (5);
            dataobject.Aanhoudingen = decryptedvalues.ElementAt (6);
            dataobject.HeeftISDMaatregel = decryptedvalues.ElementAt (7);
            dataobject.Sepots = decryptedvalues.ElementAt (8);
            dataobject.HeeftOnderzoekRad = decryptedvalues.ElementAt (9);
            dataobject.LopendeDossiers = decryptedvalues.ElementAt (10);
            dataobject.BezitUitkering = decryptedvalues.ElementAt (11);
            dataobject.MeldingenRad = decryptedvalues.ElementAt (12);
            dataobject.ZitInGroepsAanpak = decryptedvalues.ElementAt (13);
            dataobject.HeeftIdBewijs = decryptedvalues.ElementAt (14);
            dataobject.LopendTraject = decryptedvalues.ElementAt (15);
            dataobject.LaatsteGesprek = decryptedvalues.ElementAt (16);

            Decrypteddataobject = dataobject;
        }

        public DataObject showDecrypted () {
            return Decrypteddataobject;
        }

        public string Decrypt (string textToDecrypt, string publicKeyString) {
            var bytesToDescrypt = Encoding.UTF8.GetBytes (textToDecrypt);

            using (var rsa = new RSACryptoServiceProvider (2048)) {
                try {

                    // server decrypting data with public key                    
                    FromXmlString1 (rsa, _privateKey);

                    var resultBytes = Convert.FromBase64String (textToDecrypt);
                    var decryptedBytes = rsa.Decrypt (resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString (decryptedBytes);
                    return decryptedData.ToString ();
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