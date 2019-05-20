using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Server.Classes.Maybe;

namespace Server.Classes.Encryption {
    public class LetsEncrypt {
        public string _publicKey;
        public string encryptedbytes;

        public UnicodeEncoding _encoder = new UnicodeEncoding ();

        public JObject Encrypteddataobject { get; set; }

        public LetsEncrypt (JObject newdata, string keys) {
            _publicKey = keys;

            JObject testObject = new JObject ();
            foreach (var item in newdata) {
                if (item.Key == "Naam" || item.Key == "BSN" || item.Key == "Geb_datum") {
                    testObject.Add (item.Key, Encrypt (item.Value.ToString (), _publicKey));
                }
                if (item.Key == "Politie" || item.Key == "OM" || item.Key == "Gemeente" || item.Key == "Reclassering") {
                    JObject jObj = JObject.FromObject (item.Value);
                    JObject testObjectZRLD = new JObject ();
                    foreach (var testObjectInner in jObj) {
                        testObjectZRLD.Add (testObjectInner.Key, Encrypt (testObjectInner.Value.ToString (), _publicKey));
                    }
                    testObject.Add (item.Key, testObjectZRLD);
                }
            }
            Encrypteddataobject = testObject;
        }

        public JObject showEncrypted () {
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