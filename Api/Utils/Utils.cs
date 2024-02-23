using System.Text;
using System.Security.Cryptography;


namespace Api.Utils
{
    public static class Utils
    {
        public static string ToSHA1(this string value)
        {
            SHA1 sHA = SHA1.Create();
            ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
            byte[] bytes = aSCIIEncoding.GetBytes(value ?? "");
            return BitConverter.ToString(sHA.ComputeHash(bytes)).ToLower().Replace("-", "");
        }
    }
}
