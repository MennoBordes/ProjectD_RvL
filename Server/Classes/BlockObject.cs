using System;
using System.Collections.Generic;

namespace Server.Classes {
    public class Data {
        public string Naam { get; set; }
        public string BSN { get; set; }
        public string Geb_Datum { get; set; }
        public string Organisatie { get; set; }
        public string Groep { get; set; }
        public int Antecendenten { get; set; }
        public int Aanhoudingen { get; set; }
        public bool HeeftISDMaatregel { get; set; }
        public int Sepots { get; set; }
        public bool HeeftOnderzoekRad { get; set; }
        public int LopendeDossiers { get; set; }
        public bool BezitUitkering { get; set; }
        public int MeldingenRad { get; set; }
        public bool ZitInGroepsAanpak { get; set; }
        public bool HeeftIdBewijs { get; set; }
        public string LopendTraject { get; set; }
        public string LaatsteGesprek { get; set; }

        public Data (
            string naam, string bsn, string geb_datum, string organisatie, string groep, int antecedenten,
            int aanhoudingen, bool heeftisdmaatregel, int sepots, bool heeftonderzoekrad, int lopendedossiers,
            bool bezituitkering, int meldingenrad, bool zitingroepsaanpak, bool heeftidbewijs,
            string lopendtraject, string laatstegesprek)

        {
            Naam = naam;
            BSN = bsn;
            Geb_Datum = geb_datum;
            Organisatie = organisatie;
            Groep = groep;
            Antecendenten = antecedenten;
            Aanhoudingen = aanhoudingen;
            HeeftISDMaatregel = heeftisdmaatregel;
            Sepots = sepots;
            HeeftOnderzoekRad = heeftonderzoekrad;
            LopendeDossiers = lopendedossiers;
            BezitUitkering = bezituitkering;
            MeldingenRad = meldingenrad;
            ZitInGroepsAanpak = zitingroepsaanpak;
            HeeftIdBewijs = heeftidbewijs;
            LopendTraject = lopendtraject;
            LaatsteGesprek = laatstegesprek;
        }

    }

    public class Block {
        public string Hash_Code { get; set; }
        public string Previous_Hash { get; set; }
        public string Created_By { get; set; }
        public string Timestamp { get; set; }
        public Data Data { get; set; }

        public Block (string hash_code, string previous_hash, string created_by, string timestamp, Data data) {
            Hash_Code = hash_code;
            Previous_Hash = previous_hash;
            Created_By = created_by;
            Timestamp = timestamp;
            Data = data;
        }
    }

}