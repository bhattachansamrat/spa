namespace Spa.Services.Abstract
{
    public interface IEncryption
    {
        string CreateSalt();
        string EncryptPassword(string password, string salt);
    }
}
