using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server.Classes.NewBlock
{
  public class Block
  {
    public string Hash_Code { get; set; }
    public string Previous_Hash { get; set; }
    public string Created_By { get; set; }
    public string Timestamp { get; set; }
    public Data Data { get; set; }

    public Block(string hash_code, string previous_hash, string created_by, string timestamp, Data data)
    {
      Hash_Code = hash_code;
      Previous_Hash = previous_hash;
      Created_By = created_by;
      Timestamp = timestamp;
      Data = data;
    }
  }

  public class Data
  {
    public Politie Politie { get; set; }
    public OM OM { get; set; }
    public Gemeente Gemeente { get; set; }
    public Reclassering Reclassering { get; set; }

    public Data(
      Politie Politie,
      OM OM, Gemeente Gemeente, Reclassering Reclassering)
    {

      this.Politie = Politie;
      this.OM = OM;
      this.Gemeente = Gemeente;
      this.Reclassering = Reclassering;
    }
  }

  public class Politie
  {
    public string WhoAmI { get; set; }
    public string Antecedenten_Radicalen { get; set; }
    public string Antecedenten_LokalePGA { get; set; }
    public string Antecedenten_ZSM { get; set; }
    public string Antecedenten_Detentie { get; set; }
    public string Aanhoudingen_Radicalen { get; set; }
    public string Aanhoudingen_Detentie { get; set; }
    public string Aanhoudingen_ZSM { get; set; }
    public string ISDMaatregel_ZSM { get; set; }
    public string ISDMaatregel_Radicalen { get; set; }
    public string Naam { get; set; }
    public string BSN { get; set; }
    public string Geb_Datum { get; set; }

  }

  public class OM
  {
    public string WhoAmI { get; set; }

    public string Antecedenten_ZSM { get; set; }
    public string Sepots_ZSM { get; set; }
    public string Antecedenten_Radicalen { get; set; }
    public string Sepots_Radicalen { get; set; }
    public string OnderzoekRad_Radicalen { get; set; }
    public string Antecedenten_LokalePGA { get; set; }
    public string LopendeDossiers_Detentie { get; set; }
    public string Naam { get; set; }
    public string BSN { get; set; }
    public string Geb_Datum { get; set; }

  }

  public class Gemeente
  {
    public string WhoAmI { get; set; }

    public string BezitUitkering_ZSM { get; set; }
    public string MeldingenRad_Radicalen { get; set; }
    public string BezitUitkering_LokalePGA { get; set; }
    public string ZitInGroepsAanpak_LokalePGA { get; set; }
    public string BezitUitkering_Detentie { get; set; }
    public string IdBewijs_Detentie { get; set; }
    public string Naam { get; set; }
    public string BSN { get; set; }
    public string Geb_Datum { get; set; }

  }

  public class Reclassering
  {
    public string WhoAmI { get; set; }

    public string LopendTraject_ZSM { get; set; }
    public string LaatsteGesprek_ZSM { get; set; }
    public string LopendTraject_Radicalen { get; set; }
    public string LaatsteGesprek_Radicalen { get; set; }
    public string LopendTraject_Detentie { get; set; }
    public string LaatsteGesprek_Detentie { get; set; }
    public string Naam { get; set; }
    public string BSN { get; set; }
    public string Geb_Datum { get; set; }
  }

}