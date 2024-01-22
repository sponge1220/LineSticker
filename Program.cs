using LineSticker;

var imageService = new ImageService();

Console.WriteLine("sourceDir:");
var sourceDir = Console.ReadLine();

Console.WriteLine("destDir:");
var destDir = Console.ReadLine();

if (!string.IsNullOrEmpty(sourceDir) && !string.IsNullOrEmpty(destDir))
{
    imageService.ResizeImagesAndCreateCopies(sourceDir, destDir);
}
else
{
    Console.WriteLine("the path provided is invalid。");
}