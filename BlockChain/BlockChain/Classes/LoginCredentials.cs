namespace BlockChain.Classes
{
  public class LoginCredentials
  {
    string IP, RSA;
    public LoginCredentials(string ip, string rsa)
    {
      this.IP = ip;
      this.RSA = rsa;
    }

    public string GetIP()
    {
      return this.IP;
    }

    public string GetRSA()
    {
      return this.RSA;
    }
  }
}
