static class Display
{
    const string Separator = "";
    public const string SubSeparator = "---------------------------------";

    static public string prefixText {get;set;} = "";
    static public string suffixText {get;set;} = "";
    static public string options {get;set;} = "";
    static public string warningText {get;set;} = "";

    public static void UpdateText()
    {
        Console.WriteLine(Separator);
        Console.WriteLine(prefixText);
        Console.WriteLine(SubSeparator);
        Console.WriteLine(suffixText);

        if (options != "")
        {
            Console.WriteLine(SubSeparator);
            Console.WriteLine(options);

            options = "";
        }

        if (warningText != "") 
        {
            Console.WriteLine(SubSeparator);
            Console.WriteLine(warningText);

            warningText = "";
        }

        Console.WriteLine(Separator);
    }
}
