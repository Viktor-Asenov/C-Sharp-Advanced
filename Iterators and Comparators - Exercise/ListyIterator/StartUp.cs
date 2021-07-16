using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "END")
                {
                    break;
                }

                string[] tokens = command.Split();

                if (tokens[0] == "Create")
                {                    
                    listyIterator = new ListyIterator<string>(tokens.Skip(1).ToArray());
                }
                else if (tokens[0] == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (tokens[0] == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                else if (tokens[0] == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (InvalidOperationException exception)
                    {

                        Console.WriteLine(exception.Message);
                    }
                }
            }
        }
    }
}
