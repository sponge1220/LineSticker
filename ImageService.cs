using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace LineSticker;

public class ImageService
{
    public void ResizeImagesAndCreateCopies(string sourceDir, string destDir, int width = 370, int height = 320)
    {
        if (!Directory.Exists(destDir))
        {
            Directory.CreateDirectory(destDir);
        }

        var fileCount = 0;
        foreach (var file in Directory.GetFiles(sourceDir))
        {
            var extension = Path.GetExtension(file).ToLower();
            if (extension != ".jpg" && extension != ".jpg" && extension != ".png" && extension != ".bmp") continue;

            using var image = Image.Load(file);
            image.Mutate(x => x.Resize(width, height));
            fileCount++;

            var newFileName = Path.Combine(destDir, fileCount.ToString("D2") + ".png");
            image.Save(newFileName);
        }

        var resizedFiles = Directory.GetFiles(destDir).OrderBy(f => f).Take(2).ToArray();
        if (resizedFiles.Length < 2) return;

        CreateCopy(resizedFiles[0], destDir, "main.png", 240, 240);
        CreateCopy(resizedFiles[1], destDir, "tab.png", 96, 74);
    }

    private void CreateCopy(string filePath, string destDir, string newFileName, int width, int height)
    {
        using var image = Image.Load(filePath);
        image.Mutate(x => x.Resize(width, height));

        var newFilePath = Path.Combine(destDir, newFileName);
        image.Save(newFilePath);
    }
}