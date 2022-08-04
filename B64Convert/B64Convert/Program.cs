byte[] buffer;
if (Console.IsInputRedirected)
{
    buffer = System.Text.UTF8Encoding.UTF8.GetBytes(Console.In.ReadToEnd());
}
else
{
    if (File.Exists(args.FirstOrDefault()))
    {
        buffer = File.ReadAllBytes(args.FirstOrDefault());
    }
    else
    {
        Console.Error.WriteLine("File not found...");
        Environment.Exit(1);
        return;
    }
}

if (buffer == null || buffer.Length == 0)
{
    Console.Error.WriteLine("No content received...");
    Environment.Exit(1);
    return;
}
var fileContent = Convert.ToBase64String(buffer);
Console.Out.WriteLine(fileContent);