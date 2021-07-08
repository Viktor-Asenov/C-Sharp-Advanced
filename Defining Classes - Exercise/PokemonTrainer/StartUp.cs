using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string command = Console.ReadLine();

            while (command != "Tournament")
            { 
                string[] pokemonData = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = pokemonData[0];
                string pokemonName = pokemonData[1];
                string element = pokemonData[2];
                int pokemonHealth = int.Parse(pokemonData[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName);
                }
                
                Pokemon pokemon = new Pokemon(pokemonName, element, pokemonHealth);

                trainers[trainerName].Pokemons.Add(pokemon);

                command = Console.ReadLine();
            }

            while (true)
            {
                command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string element = command;

                foreach (var trainer in trainers.Values)
                {
                    if (trainer.Pokemons.Any(p => p.Element == element))    
                    {
                        trainer.GiveBadge();
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.RemoveHealth());

                        if (trainer.Pokemons.Any(p => p.Health <= 0))
                        {
                            trainer.Pokemons.RemoveAll(p => p.Health <= 10);
                        }
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(b => b.Value.Badges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
