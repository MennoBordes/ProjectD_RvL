using System;
using System.Collections.Generic;

namespace BlockChain.Classes {
    public class Data {
        public string naam { get; set; }
        public string BSN { get; set; }
        public string geb_datum { get; set; }
        public string organisatie { get; set; }
        public string groep { get; set; }
        public int antecendenten { get; set; }
        public int aanhoudingen { get; set; }
        public bool HeeftISDMaatregel { get; set; }
        public int sepots { get; set; }
        public bool HeeftOnderzoekRad { get; set; }
        public int LopendeDossiers { get; set; }
        public bool BezitUitkering { get; set; }
        public int MeldingenRad { get; set; }
        public bool ZitInGroepsAanpak { get; set; }
        public bool HeeftIdBewijs { get; set; }
        public string LopendTraject { get; set; }
        public string LaatsteGesprek { get; set; }

        public Data (
            string Naam, string BSN1, string Geb_Datum, string Organisatie, string Groep, int Antecedenten,
            int Aanhoudingen, bool HeeftISDMaatregel1, int Sepots1, bool HeeftOnderzoekRad1, int LopendeDossiers1,
            bool BezitUitkering1, int MeldingenRad1, bool ZitInGroepsAanpak1, bool HeeftIdBewijs1,
            string LopendTraject1, string LaatsteGesprek1)

        {
            naam = Naam;
            BSN = BSN1;
            geb_datum = Geb_Datum;
            organisatie = Organisatie;
            groep = Groep;
            antecendenten = Antecedenten;
            aanhoudingen = Aanhoudingen;
            HeeftISDMaatregel = HeeftISDMaatregel1;
            sepots = Sepots1;
            HeeftOnderzoekRad = HeeftOnderzoekRad1;
            LopendeDossiers = LopendeDossiers1;
            BezitUitkering = BezitUitkering1;
            MeldingenRad = MeldingenRad1;
            ZitInGroepsAanpak = ZitInGroepsAanpak1;
            HeeftIdBewijs = HeeftIdBewijs1;
            LopendTraject = LopendTraject1;
            LaatsteGesprek = LaatsteGesprek1;
        }

    }

    public class Block {
        public string hash_code { get; set; }
        public string previous_hash { get; set; }
        public string created_by { get; set; }
        public string timestamp { get; set; }
        public Data data { get; set; }

        public Block (string Hash_code, string Previous_hash, string Created_by, string Timestamp, Data data1) {
            hash_code = Hash_code;
            previous_hash = Previous_hash;
            created_by = Created_by;
            timestamp = Timestamp;
            data = data1;
        }
    }
    public class SendData {
        public string data { get; set; }
        // public SendData (string Data) {
        //     data = Data;
        // }
    }

}