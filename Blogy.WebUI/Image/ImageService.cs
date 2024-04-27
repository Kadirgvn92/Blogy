namespace Blogy.WebUI.Image;

public static class ImageService
{
    public static string GetRandomImage()
    {
        // Belirtilen klasördeki tüm resim dosyalarını alın
        string[] imageFiles = Directory.GetFiles("wwwroot/users", "*.png");


        // Rasgele bir resim dosyası seçmek için rasgele bir indeks oluşturun
        Random rnd = new Random();
        int index = rnd.Next(imageFiles.Length);

        // Seçilen rasgele resim dosyasının adını döndürün
        return Path.GetFileName(imageFiles[index]);
    }
}
