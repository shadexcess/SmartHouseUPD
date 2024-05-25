using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace SmartHouse
{
    internal class Room
    {
        private bool fireAlert;
        private bool isLightOn;
        private bool isDoorOpen;

        bool kitchenLightOn = false;
        bool livingRoomLightOn = false;
        bool bathRoomLightOn = false;
        bool bedRoomLightOn = false;

        Service service = new Service();

        public void TurnOnTheLight()
        {
            isLightOn = true;
        }
        public void TurnOffTheLight()
        {
            isLightOn = false;
        }
        public void OpenTheDoor()
        {
            isDoorOpen = true;
        }
        public void CloseTheDoor()
        {
            isDoorOpen = false;
        }
        public void UseService(Service service)
        {
            isDoorOpen = service.IsOpenDoor;
        }
        public void IsOpenDoor(Service service)
        {
            service.IsDoorOpen();
        }

        public void TurnOnLight(string chosenRoom)
        {
            string[] picture;

            if (chosenRoom == "kitchen")
            {
                picture = File.ReadAllLines("KitchenLightOn.txt");
                kitchenLightOn = true;
            }

            else if (chosenRoom == "livingRoom")
            {
                picture = File.ReadAllLines("LivingRoomLightOn.txt");
                livingRoomLightOn = true;
            }

            else if (chosenRoom == "bedRoom")
            {
                picture = File.ReadAllLines("BedRoomLightOn.txt");
                bedRoomLightOn = true;
            }

            else
            {
                picture = File.ReadAllLines("BathRoomLightOn.txt");
                bathRoomLightOn = true;
            }

            foreach (var line in picture)
            {
                Console.WriteLine(line);
            }

            isLightOn = true;
        }

        public void TurnOffLight(string chosenRoom)
        {
            string[] picture;

            if (chosenRoom == "kitchen")
            {
                picture = File.ReadAllLines("KitchenLightOff.txt");
                kitchenLightOn = false;
            }

            else if (chosenRoom == "livingRoom")
            {
                picture = File.ReadAllLines("LivingRoomLightOff.txt");
                livingRoomLightOn = false;
            }

            else if (chosenRoom == "bedRoom")
            {
                picture = File.ReadAllLines("BedRoomLightOff.txt");
                bedRoomLightOn = false;
            }

            else
            {
                picture = File.ReadAllLines("BathRoomLightOff.txt");
                bathRoomLightOn = false;
            }

            foreach (var line in picture)
            {
                Console.WriteLine(line);
            }

            isLightOn = false;
        }

        public void CheckLight(string room)
        {

            if (livingRoomLightOn)
            {
                service.OutputWhereLightOn("living room");
                TurnOnLight("livingRoom");
            }
            else if (bedRoomLightOn)
            {
                service.OutputWhereLightOn("bedroom");
                TurnOnLight("bedRoom");
            }
            else if (bathRoomLightOn)
            {
                service.OutputWhereLightOn("bathroom");
                TurnOnLight("bathRoom");
            }
            else if (kitchenLightOn)
            {
                service.OutputWhereLightOn("kitchen");
                TurnOnLight("kitchen");
            }

            bool anyLightOn = kitchenLightOn || livingRoomLightOn || bedRoomLightOn || bathRoomLightOn;

            if (anyLightOn)
            {
                Thread.Sleep(4000);
                TurnOffAllLights();
                service.PlaySound("LightsOff.wav");
                Console.WriteLine($"The lights in the room were off.");
            }
        }

        public void TurnOffAllLights()
        {
            kitchenLightOn = false;
            livingRoomLightOn = false;
            bathRoomLightOn = false;
            bedRoomLightOn = false;
            string[] picture;

            picture = File.ReadAllLines("KitchenLightOff.txt");

            foreach (var line in picture)
            {
                Console.WriteLine(line);
            }
        }

        private string GetSeason()
        {
            var currentMonth = DateTime.Now.Month;
            string currentSeason;

            if (currentMonth >= 3 && currentMonth <= 5)
            {
                currentSeason = "Spring";
            }
            else if (currentMonth >= 6 && currentMonth <= 8)
            {
                currentSeason = "Summer";
            }
            else if (currentMonth >= 9 && currentMonth <= 11)
            {
                currentSeason = "Autumn";
            }
            else
            {
                currentSeason = "Winter";
            }

            return currentSeason;
        }

        /// <summary>
        /// Метод для виклику інших методів (і присвоєння певної температури), в залежності від поточної пори року
        /// </summary>
        public void ChooseSeason()
        {
            string currentSeason = GetSeason();

            Random rand = new Random();
            float outsideTemp;

            switch (currentSeason)
            {
                case "Spring":
                    outsideTemp = rand.Next(5, 20);
                    service.PlaySound("ThisIsTheTemperatureOutside.wav");
                    Console.WriteLine($"This is the temperature outside at the moment: {outsideTemp}"); 
                    Thread.Sleep(3500);
                    ChangeTemperature(outsideTemp);
                    break;
                case "Summer":
                    outsideTemp = rand.Next(18, 40);
                    service.PlaySound("ThisIsTheTemperatureOutside.wav");
                    Console.WriteLine($"This is the temperature outside at the moment: {outsideTemp}"); 
                    Thread.Sleep(3500);
                    ChangeTemperature(outsideTemp);
                    break;
                case "Autumn":
                    outsideTemp = rand.Next(2, 20);
                    service.PlaySound("ThisIsTheTemperatureOutside.wav");
                    Console.WriteLine($"This is the temperature outside at the moment: {outsideTemp}"); 
                    Thread.Sleep(3500);
                    ChangeTemperature(outsideTemp);
                    break;
                case "Winter":
                    outsideTemp = rand.Next(-20, 3);
                    service.PlaySound("ThisIsTheTemperatureOutside.wav");
                    Console.WriteLine($"This is the temperature outside at the moment: {outsideTemp}"); 
                    Thread.Sleep(3500);
                    ChangeTemperature(outsideTemp);
                    break;
            }
        }

        /// <summary>
        /// Метод для обчислення приблизної поточної температури в домі, в залежності від температури на вулиці
        /// </summary>
        /// <param name="outsideTemp">Температура на вулиці.</param>
        /// <returns>Температура в домі.</returns>
        private float GetInsideTemperature(float outsideTemp)
        {
            // коефіцієнти для формули
            float coefficient1 = 0.3f;
            float coefficient2 = 14f;

            // температура в приміщенні = коеф 1, помножений на зовнішню температуру, плюс коеф 2
            float insideTemp = coefficient1 * outsideTemp + coefficient2;
            service.PlaySound("HereIsTemperatureInside.wav");
            Console.WriteLine($"The temperature in your house right now: {insideTemp} degrees."); 
            Thread.Sleep(3500);
            return insideTemp;
        }

        /// <summary>
        /// Метод для обробки запиту користувача щодо встановлення нового значення температури в домі
        /// </summary>
        /// <returns>Значення температури, яке користувач хоче отримати в домі.</returns>
        private float AskTemperature()
        {
            service.PlaySound("AskTemperatureToSet.wav");
            Console.WriteLine("Your comfort is my command. ");
            Console.WriteLine("What temperature shall we set to make your home a perfect place?");
            float comfortTemp = float.Parse(Console.ReadLine());
            Console.WriteLine();
            return comfortTemp;
        }

        /// <summary>
        /// Метод для зміни температури в домі в залежності від поточної температури в домі
        /// </summary>
        /// <param name="outsideTemp">Поточна температура на вулиці.</param>
        private void ChangeTemperature(float outsideTemp)
        {
            float insideTemp = GetInsideTemperature(outsideTemp);
            float comfortTemp = AskTemperature();
            Random random = new Random();
            int elapsedTime = 0;

            while (Math.Abs(insideTemp - comfortTemp) > 0.5) // Порівнюємо з малою похибкою
            {
                if (insideTemp <= comfortTemp)
                {
                    insideTemp += 0.5f;
                }
                else
                {
                    insideTemp -= 0.5f;
                }

                // генеруємо випадкове число від 1 до 3 (на це число збільшиться час при наступній ітерації)
                int randomMinutes = random.Next(1, 4);
                elapsedTime += randomMinutes;

                Console.WriteLine($"{elapsedTime} minutes later, temperature: {insideTemp:F1}");
                Thread.Sleep(1500);
            }

            Console.WriteLine();
            service.PlaySound("TemperatureWasSet.wav");
            Console.WriteLine("The temperature in your home now creates");
            Console.WriteLine("a picture of comfort, just as you prefer.");
            Console.WriteLine();
        }
    }
}