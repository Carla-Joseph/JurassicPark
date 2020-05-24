using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace JurassicPark
{
    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);


            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, this answer is not valid.");
                return 0;
            }
        }

        static DateTime PromptForDateTime(string prompt)
        {

            Console.Write(prompt);
            var input = Console.ReadLine();
            var date = DateTime.Parse(input);
            return date;
        }
        static void Main(string[] args)
        {

            var irritator = new Dinosaur
            {
                Name = "Irritator",
                DietType = "Herbivore",
                DateAcquired = new DateTime(1995, 06, 30),
                Weight = 198,
                EnclosureNumber = 5,
            };


            var camarasaurus = new Dinosaur
            {
                Name = "Camarasaurus",
                DietType = "Herbivore",
                DateAcquired = new DateTime(2003, 03, 28),
                Weight = 13069,
                EnclosureNumber = 11,
            };


            var shanag = new Dinosaur
            {
                Name = "Shanag",
                DietType = "Carnivore",
                DateAcquired = new DateTime(1874, 11, 05),
                Weight = 44,
                EnclosureNumber = 8,
            };


            var mussaurus = new Dinosaur
            {
                Name = "Mussaurus",
                DietType = "Herbivore",
                DateAcquired = new DateTime(1956, 04, 22),
                Weight = 198,
                EnclosureNumber = 1,
            };


            var polacanthus = new Dinosaur
            {
                Name = "Polacanthus",
                DietType = "Carnivore",
                DateAcquired = new DateTime(2016, 06, 09),
                Weight = 6233,
                EnclosureNumber = 10,
            };


            var listOfDinosaurs = new List<Dinosaur>();

            listOfDinosaurs.Add(irritator);
            listOfDinosaurs.Add(camarasaurus);
            listOfDinosaurs.Add(shanag);
            listOfDinosaurs.Add(mussaurus);
            listOfDinosaurs.Add(polacanthus);


            var userChoseToExit = false;

            while (userChoseToExit == false)
            {
                Console.WriteLine("Choose from the following options. How would you like to proceed? ");

                Console.WriteLine("(V)iew the list of dinosaurs.");

                Console.WriteLine("(A)dd a dinosaur.");

                Console.WriteLine("(R)emove a dinosaur");

                Console.WriteLine("(T)ransfer dinosaur to new enclosure.");

                Console.WriteLine("(E)xit the application.");

                Console.WriteLine();

                var option = PromptForString("Choice: ");


                if (option == "V")
                {
                    Console.WriteLine();
                    Console.WriteLine("Here is a list of the dinosaurs: ");
                    Console.WriteLine();

                    listOfDinosaurs.Sort((ls1, ls2) => DateTime.Compare(ls1.DateAcquired, ls2.DateAcquired));

                    listOfDinosaurs.ForEach(l => Console.WriteLine(l.Description()));
                }


                if (option == "A")
                {
                    Console.WriteLine();
                    var dinosaurToAddName = PromptForString("What is the name of the dinosaur? ");

                    var dinosaurToAddWeight = PromptForInteger("What is the weight of the dinosaur? ");

                    var dinosaurToAddDate = PromptForDateTime("When was the dinosaur acquired? ");

                    var dinosaurToAddDiet = PromptForString("Is the dinosaur a carnivore or herbivore? ");

                    var dinosaurToAddEnclosure = PromptForInteger("Where is the dinosaur residing? Please enter a number? ");

                    var newDino = new Dinosaur
                    {
                        Name = dinosaurToAddName,
                        DietType = dinosaurToAddDiet,
                        Weight = dinosaurToAddWeight,
                        EnclosureNumber = dinosaurToAddEnclosure,
                    };

                    listOfDinosaurs.Add(newDino);

                }

                if (option == "R")
                {
                    Console.WriteLine();
                    var dinoToRemove = PromptForString("What is the name of the dinosaur you would like to remove? ");

                    var dinoRemoving = listOfDinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == dinoToRemove);

                    listOfDinosaurs.Remove(dinoRemoving);
                }



                if (option == "T")
                {
                    Console.WriteLine();
                    var dinosaurToTransfer = PromptForString("What is the name of the dinosaur you would like to transfer? ");

                    var dinoTransfering = listOfDinosaurs.FirstOrDefault(dino => dino.Name == dinosaurToTransfer);

                    if (dinoTransfering == null)
                    {
                        Console.WriteLine("We could not find the dinosaur.");
                    }
                    else
                    {
                        var dinoFound = dinoTransfering.Description();

                        var dinosaurNewEnclosure = PromptForInteger("What is the new enclosure? ");

                        dinoTransfering.EnclosureNumber = dinosaurNewEnclosure;
                    }
                }

                if (option == "E")
                {
                    userChoseToExit = true;
                }
            }
        }
    }
}