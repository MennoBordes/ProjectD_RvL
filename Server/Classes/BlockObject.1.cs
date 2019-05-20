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

  public class Politie {
    public string Antecedenten_Radicalen_OGR { get; set; }
    public string Antecedenten_LokalePGA_OGR { get; set; }
    public string Antecedenten_ZSM_OGR { get; set; }
    public string Antecedenten_Detentie { get; set; }
    public string Aanhoudingen_Radicalen_OGR { get; set; }
    public string Aanhoudingen_Detentie { get; set; }
    public string Aanhoudingen_ZSM_OGR { get; set; }
    public string ISDMaatregel_ZSM_OR { get; set; }
    public string ISDMaatregel_Radicalen_OR { get; set; }

  }

  public class OM {
    public string Antecedenten_ZSM_PGR { get; set; }
    public string Sepots_ZSM_PGR { get; set; }
    public string Antecedenten_Radicalen_PGR { get; set; }
    public string Sepots_Radicalen_PGR { get; set; }
    public string OnderzoekRad_Radicalen_PG { get; set; }
    public string Antecedenten_LokalePGA_PGR { get; set; }
    public string LopendeDossiers_Detentie_PGR { get; set; }

  }

  public class Gemeente {
    public string BezitUitkering_ZSM_POR { get; set; }
    public string MeldingenRad_Radicalen_PO { get; set; }
    public string BezitUitkering_LokalePGA_POR { get; set; }
    public string ZitInGroepsAanpak_LokalePGA_POR { get; set; }
    public string BezitUitkering_Detentie_POR { get; set; }
    public string IdBewijs_Detentie_POR { get; set; }

  }

  public class Reclassering {
    public string LopendTraject_ZSM_POG { get; set; }
    public string LaatsteGesprek_ZSM_POG { get; set; }
    public string LopendTraject_Radicalen_POG { get; set; }
    public string LaatsteGesprek_Radicalen_POG { get; set; }
    public string LopendTraject_Detentie_POG { get; set; }
    public string LaatsteGesprek_Detentie_POG { get; set; }

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
    public Politie Politie { get; set; }
    public OM OM { get; set; }
    public Gemeente Gemeente { get; set; }
    public Reclassering Reclassering { get; set; }

    public Data (
      string naam, string bsn, string geb_datum, Politie Politie,
      OM OM, Gemeente Gemeente, Reclassering Reclassering) {
      this.Naam = naam;
      this.BSN = bsn;
      this.Geb_Datum = geb_datum;
      this.Politie = Politie;
      this.OM = OM;
      this.Gemeente = Gemeente;
      this.Reclassering = Reclassering;
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
    public JObject newdata { get; set; }
  }

}