namespace MaryamProject.Helper;

public static class Utils
{
    public static string GetRandomString(string prefix)
    {
        int randomNumber = new Random().Next(1000, 9999);
        return $"{prefix}/{randomNumber}";
    }
}
