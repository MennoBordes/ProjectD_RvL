using System;
using System.Collections.Generic;

namespace Server.Classes
{
  public class Data
  {
    public string Naam { get; set; }
    public string BSN { get; set; }
    public string Geb_Datum { get; set; }
    public string Organisatie { get; set; }
    public string Groep { get; set; }
    public string Antecendenten { get; set; }
    public string Aanhoudingen { get; set; }
    public string HeeftISDMaatregel { get; set; }
    public string Sepots { get; set; }
    public string HeeftOnderzoekRad { get; set; }
    public string LopendeDossiers { get; set; }
    public string BezitUitkering { get; set; }
    public string MeldingenRad { get; set; }
    public string ZitInGroepsAanpak { get; set; }
    public string HeeftIdBewijs { get; set; }
    public string LopendTraject { get; set; }
    public string LaatsteGesprek { get; set; }

    public Data(
        string naam, string bsn, string geb_datum, string organisatie, string groep, string antecedenten,
        string aanhoudingen, string heeftisdmaatregel, string sepots, string heeftonderzoekrad, string lopendedossiers,
        string bezituitkering, string meldingenrad, string zitingroepsaanpak, string heeftidbewijs,
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

  public class DataObject
  {
    public string Naam { get; set; }
    public string BSN { get; set; }
    public string Geb_Datum { get; set; }
    public string Organisatie { get; set; }
    public string Groep { get; set; }
    public string Antecendenten { get; set; }
    public string Aanhoudingen { get; set; }
    public string HeeftISDMaatregel { get; set; }
    public string Sepots { get; set; }
    public string HeeftOnderzoekRad { get; set; }
    public string LopendeDossiers { get; set; }
    public string BezitUitkering { get; set; }
    public string MeldingenRad { get; set; }
    public string ZitInGroepsAanpak { get; set; }
    public string HeeftIdBewijs { get; set; }
    public string LopendTraject { get; set; }
    public string LaatsteGesprek { get; set; }
  }

  public class testReturn
  {
    public DataObject Encrypted { get; set; }
    public DataObject Decrypted { get; set; }

    public testReturn(DataObject encrypted, DataObject decrypted)
    {
      Encrypted = encrypted;
      Decrypted = decrypted;
    }
  }

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

  public class Tupl2
  {
    public string keys { get; set; }
    public Data data { get; set; }
  }

}