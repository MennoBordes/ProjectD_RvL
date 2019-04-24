using System;

namespace BlockChain.Classes
{
  public class LoginCredentials
  {
    string IP, RSA;
    DateTime Date;
    public LoginCredentials(string ip, string rsa, DateTime Date)
    {
      this.IP = ip;
      this.RSA = rsa;
      this.Date = Date;
    }

    public string GetIP()
    {
      return this.IP;
    }

    public string GetRSA()
    {
      return this.RSA;
    }

    public string GetDate(){
      return this.Date.ToString();
    }
  }
}
