export interface PoliceType  {
    WhoAmI : 'Politie'
    Antecedenten_Radicalen? : string
    Antecedenten_LokalePGA? : string
    Antecedenten_ZSM? : string
    Antecedenten_Detentie? : string
    Aanhoudingen_Radicalen? : string
    Aanhoudingen_Detentie? : string
    Aanhoudingen_ZSM? : string
    ISDMaatregel_ZSM? : string
    ISDMaatregel_Radicalen? : string

    Naam: string
    BSN: string
    Geb_Datum: string
};
  

export interface OMType {
  WhoAmI : 'OM'
  Antecedenten_ZSM? : string
  Sepots_ZSM? : string
  Antecedenten_Radicalen? : string
  Sepots_Radicalen? : string
  OnderzoekRad_Radicalen? : string
  Antecedenten_LokalePGA? : string
  LopendeDossiers_Detentie? : string

  Naam: string
  BSN: string
  Geb_Datum: string
}

export interface GemeenteType {
  WhoAmI: 'Gemeente'
  BezitUitkering_ZSM? : string
  MeldingenRad_Radicalen? : string
  BezitUitkering_LokalePGA? : string
  ZitInGroepsAanpak_LokalePGA? : string
  BezitUitkering_Detentie? : string
  IdBewijs_Detentie? : string

  Naam: string
  BSN: string
  Geb_Datum: string
}

export interface ReclasseringType {
  WhoAmI : 'Reclassering'
  LopendTraject_ZSM? : string
  LaatsteGesprek_ZSM? : string
  LopendTraject_Radicalen? : string
  LaatsteGesprek_Radicalen? : string
  LopendTraject_Detentie? : string
  LaatsteGesprek_Detentie? : string

  Naam: string
  BSN: string
  Geb_Datum: string
}