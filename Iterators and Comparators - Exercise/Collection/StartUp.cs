using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] commandTokens = command.Split();

                switch(commandTokens[0])
                {
                    case "Create":
                        listyIterator = new ListyIterator<string>(commandTokens.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException exception)
                        {

                            Console.WriteLine(exception.Message);
                        }
                        break;
                    case "PrintAll":
                        string output = string.Empty;

                        foreach (var element in listyIterator)
                        {
                            output += element + " ";
                        }

                        Console.WriteLine(output.TrimEnd());
                        break;
                }
            }
        }
    }
}
