using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Smoke
{
    // Command interface
    interface ICommand
    {
        void Execute(Dictionary<string, List<object>> data);
    }

    // Command to list all objects of a particular type
    class ListCommand : ICommand
    {
        private readonly string type;
        private readonly bool displayTypes;

        public ListCommand(string type, bool displayTypes = false)
        {
            this.type = type;
            this.displayTypes = displayTypes;
        }

        public void Execute(Dictionary<string, List<object>> data)
        {
            if (data == null)
            {
                Console.WriteLine("Error: data dictionary is null.");
                return;
            }

            if (displayTypes)
            {
                Console.WriteLine("Available types:");
                foreach (var key in data.Keys)
                {
                    Console.WriteLine(key);
                }
                return;
            }

            if (!data.ContainsKey(type))
            {
                Console.WriteLine($"No objects of type '{type}' found.");
                return;
            }

            Console.WriteLine($"List of objects of type '{type}':");
            foreach (var obj in data[type])
            {
                if (obj is Game game)
                {
                    Console.WriteLine($" Name: {game.Name}\n Genre: {game.Genre}\n Author: {string.Join(", ", game.Authors)}\n Reviews: {game.Reviews.Count}\n Mods: {game.Mods.Count}\n Available on: {string.Join(", ", game.Devices)}\n");
                }

                else if (obj is Review review)
                {
                    Console.WriteLine("\nReview:");
                    Console.WriteLine($"Text: {review.Text}");
                    Console.WriteLine($"Rating: {review.Rating}");
                    Console.WriteLine($"Author: {review.Author}\n");
                }
            }
        }
    }


    //FindCommand
    class FindCommand : ICommand
    {
        private readonly string type;
        private readonly List<Requirement> requirements;
        private readonly bool displayTypes;

        public FindCommand(string type, List<Requirement> requirements, bool displayTypes = false)
        {
            this.type = type;
            this.requirements = requirements;
            this.displayTypes = displayTypes;
        }

        public void Execute(Dictionary<string, List<object>> data)
        {
            if (data == null)
            {
                Console.WriteLine("Error: data dictionary is null.");
                return;
            }

            if (displayTypes)
            {
                Console.WriteLine("Available types:");
                foreach (var key in data.Keys)
                {
                    Console.WriteLine(key);
                }
                return;
            }

            if (!data.ContainsKey(type))
            {
                Console.WriteLine($"No objects of type '{type}' found.");
                return;
            }

            Console.WriteLine($"List of objects of type '{type}' that fulfil the requirements:");

            foreach (var obj in data[type])
            {
                bool fulfillRequirements = true;

                foreach (var requirement in requirements)
                {
                    if (!fulfillRequirement(obj, requirement))
                    {
                        fulfillRequirements = false;
                        break;
                    }
                }

                if (fulfillRequirements)
                {
                    if (obj is Game game)
                    {
                        Console.WriteLine($" Name: {game.Name}\n Genre: {game.Genre}\n Author: {string.Join(", ", game.Authors)}\n Reviews: {game.Reviews.Count}\n Mods: {game.Mods.Count}\n Available on: {string.Join(", ", game.Devices)}\n");
                    }


                    else if (obj is Review review)
                    {
                        Console.WriteLine("\nReview:");
                        Console.WriteLine($"Text: {review.Text}");
                        Console.WriteLine($"Rating: {review.Rating}");
                        Console.WriteLine($"Author: {review.Author}\n");
                    }
                }
            }
        }

        private bool fulfillRequirement(object obj, Requirement requirement)
        {
            PropertyInfo property = obj.GetType().GetProperty(requirement.FieldName);

            if (property == null)
            {
                Console.WriteLine($"Error: '{type}' does not have a field '{requirement.FieldName}'.");
                return false;
            }



            object value = null;

            try
            {
                value = Convert.ChangeType(requirement.Value, property.PropertyType);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Error: '{requirement.Value}' is not a valid value for '{property.PropertyType.Name}' field '{requirement.FieldName}'.");
                return false;
            }

            switch (requirement.Operator)
            {
                case "==":
                    return property.GetValue(obj).Equals(value);
                case "<":
                    if (property.PropertyType == typeof(string))
                    {
                        Console.WriteLine($"Error: '<' operator not supported for string field '{requirement.FieldName}'.");
                        return false;
                    }
                    return Comparer<object>.Default.Compare(property.GetValue(obj), value) < 0;
                case ">":
                    if (property.PropertyType == typeof(string))
                    {
                        Console.WriteLine($"Error: '>' operator not supported for string field '{requirement.FieldName}'.");
                        return false;
                    }
                    return Comparer<object>.Default.Compare(property.GetValue(obj), value) > 0;
                default:
                    Console.WriteLine($"Error: '{requirement.Operator}' operator not supported.");
                    return false;
            }
        }
    }

    class Requirement
    {
        public string FieldName { get; }
        public string Operator { get; }
        public string Value { get; }

        public Requirement(string fieldName, string op, string value)
        {
            FieldName = fieldName;
            Operator = op;
            Value = value;
        }
    }



    class AddCommand : ICommand
    {
        private readonly string type;
        private readonly string subtype;

        public AddCommand(string type, string subtype)
        {
            this.type = type;
            this.subtype = subtype;
        }

        public void Execute(Dictionary<string, List<object>> data)
        {
            if (data == null)
            {
                Console.WriteLine("Error: data dictionary is null.");
                return;
            }

            if (!data.ContainsKey(type))
            {
                data.Add(type, new List<object>());
            }

            if (subtype == "base" || subtype == "Secondary")
            {
                Console.WriteLine($"add {type} {subtype}");
                Console.WriteLine("[Available fields: 'Name, Genre, authors, Devices]");
                Console.Write("Name=");
                Console.ReadKey();
                string name = Console.ReadLine();
                Console.Write("Genre=");
                string genre = Console.ReadLine();
                Console.Write("authors=");
                string authors = Console.ReadLine();
                Console.Write("devices=");
                string devices = Console.ReadLine();
              

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(genre) || string.IsNullOrEmpty(authors) || string.IsNullOrEmpty(devices))
                {
                    Console.WriteLine("[Some sensible error message]");
                    return;
                }


                while (true)
                {
                    
                    string input = Console.ReadLine();

                    if (input.Equals("Exit", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("[game creation abandoned]");
                        break;
                    }
                    else if (input.Equals("Done", StringComparison.OrdinalIgnoreCase))
                    {
                        var game = new Game(name, genre, authors.Split(','), new List<Review>(), new List<Mod>(), devices.Split(','));
                        data[type].Add(game);
                        Console.WriteLine("[game created]");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Type 'Done' to save the game or 'Exit' to cancel:");
                    }
                }

            }
        }
    }


    // Command to exit the application
    class ExitCommand : ICommand
    {
        public void Execute(Dictionary<string, List<object>> data)
        {
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }
    }



   

}