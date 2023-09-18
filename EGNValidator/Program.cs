using Euroins.Tools.Validators;

var generator = new EgnValidator();
while (true)
{
    Console.WriteLine("Insert Egn");
    string? v = Console.ReadLine();

    try
    {
        EgnValidator.EGNInfo eGNInfo = generator.Parse(v);
        Console.WriteLine(eGNInfo);

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}