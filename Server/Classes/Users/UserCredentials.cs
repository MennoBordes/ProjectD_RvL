namespace Server.Classes.Users
{
  public class UserCredentials
  {
    string InstantieNaam;
    string[] InstantieRechten;

    public UserCredentials(string InstantieNaam, string[] InstantieRechten)
    {
      this.InstantieNaam = InstantieNaam;
      this.InstantieRechten = InstantieRechten;
    }

    public string GetInstantieNaam()
    {
      return this.InstantieNaam;
    }

    public string[] GetInstantieRechten()
    {
      return this.InstantieRechten;
    }
  }
}