using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Server.Classes.Users
{
  public class UserCredentials
  {
    private string InstantieNaam;
    private string InstantieRechten;

    public UserCredentials(string InstantieNaam, string InstantieRechten)
    {
      this.InstantieNaam = InstantieNaam;
      this.InstantieRechten = InstantieRechten;
    }

    public string GetInstantieNaam()
    {
      return this.InstantieNaam;
    }

    public string GetInstantieRechten()
    {
      return this.InstantieRechten;
    }

    public List<string> GetAllUserCredentials()
    {
      List<string> Temp = new List<string>(){
        GetInstantieNaam(),
        GetInstantieRechten()
      };
      return Temp;
    }
  }
}