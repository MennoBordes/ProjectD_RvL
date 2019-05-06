using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server.Classes.Maybe {

  public class ZSM {
    public string Antecedenten_OGR { get; set; }
    public string Aanhoudingen_OGR { get; set; }
    public string ISDMaatregel_OR { get; set; }
    public string Antecedenten_PGR { get; set; }
    public string Sepots_PGR { get; set; }
    public string BezitUitkering_POR { get; set; }
    public string LopendTraject_POG { get; set; }
    public string LaatsteGesprek_POG { get; set; }
  }

  public class Radicalen {
    public string Antecedenten_OGR { get; set; }
    public string Aanhoudingen_OGR { get; set; }
    public string ISDMaatregel_OR { get; set; }
    public string Antecedenten_PGR { get; set; }
    public string Sepots_PGR { get; set; }
    public string OnderzoekRad_PG { get; set; }
    public string MeldingenRad_PO { get; set; }
    public string LopendTraject_POG { get; set; }
    public string LaatsteGesprek_POG { get; set; }
  }
  public class LokalePGA {
    public string Antecedenten_OGR { get; set; }
    public string Antecedenten_PGR { get; set; }
    public string BezitUitkering_POR { get; set; }
    public string ZitInGroepsAanpak_POR { get; set; }
  }
  public class Detentie {
    public string Antecendenten { get; set; }
    public string Aanhoudingen { get; set; }
    public string LopendeDossiers_PGR { get; set; }
    public string BezitUitkering_POR { get; set; }
    public string IdBewijs { get; set; }
    public string LopendTraject_POG { get; set; }
    public string LaatsteGesprek_POG { get; set; }
  }
  public class Data {
    public string Naam { get; set; }
    public string BSN { get; set; }
    public string Geb_Datum { get; set; }
    public ZSM Zsm { get; set; }
    public Radicalen Radicalen { get; set; }
    public LokalePGA LokalePGA { get; set; }
    public Detentie Detentie { get; set; }

    public Data (
      string naam, string bsn, string geb_datum, ZSM Zsm,
      Radicalen Radicalen, LokalePGA LokalePGA, Detentie Detentie) {
      this.Naam = naam;
      this.BSN = bsn;
      this.Geb_Datum = geb_datum;
      this.Zsm = Zsm;
      this.Radicalen = Radicalen;
      this.LokalePGA = LokalePGA;
      this.Detentie = Detentie;
    }
  }

  public class NewDataObject {
    public string Naam { get; set; }
    public string BSN { get; set; }
    public string Geb_Datum { get; set; }
    public ZSM Zsm { get; set; }
    public Radicalen Radicalen { get; set; }
    public LokalePGA LokalePGA { get; set; }
    public Detentie Detentie { get; set; }
  }

  public class testReturn {
    public DataObject Encrypted { get; set; }
    public DataObject Decrypted { get; set; }

    public testReturn (DataObject encrypted, DataObject decrypted) {
      Encrypted = encrypted;
      Decrypted = decrypted;
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

  public class Tupl2 {
    public string keys { get; set; }
    public Data newdata { get; set; }
  }

}