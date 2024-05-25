using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    internal class Menu
    {
        private int choice;
        private int kitchenChoice;
        private int livingroomChoice;
        private int bedroomChoice;
        private int bathroomChoice;

        House house = new House();
        Service service = new Service();
        Room room = new Room();
        bool isFirstTime = true;

        public Menu()
        {
            choice = -1;
            kitchenChoice = -1;
            livingroomChoice = -1;
            bedroomChoice = -1;
            bathroomChoice = -1;
        }

        public void Options()
        {
            Console.WriteLine("Welcome to SMART HOUSE!");
            house.Greet();
            while (choice != 0)
            {
                Random rand = new Random();
                int chance = rand.Next(1, 101);
                if (chance <= 20 && !isFirstTime)
                {
                    house.RandomEvent();
                }
                house.MenuGoRoom();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    case 1:
                        room.CheckLight("kitchen");
                        house.IsOpenDoor();
                        house.OpenDoor();
                        house.CloseDoor();
                        service.ShowLocation("kitchen");
                        while (kitchenChoice != 0)
                        {
                            house.OptKitchen();
                            kitchenChoice = Convert.ToInt32(Console.ReadLine());
                            switch (kitchenChoice)
                            {
                                case 0:
                                    Console.WriteLine("Exiting kitchen");
                                    break;
                                case 1:
                                    house.IsGasOpen();
                                    house.OpenGas();
                                    house.CloseGas();
                                    break;
                                case 2:
                                    house.IsDoorFridgeOpen();
                                    house.OpenFridgeDoor();
                                    house.CloseFridgeDoor();
                                    house.CreateDefaultProducts();
                                    house.AskIfContinueFridge();
                                    break;
                                case 3:
                                    room.TurnOnLight("kitchen");
                                    break;
                                case 4:
                                    room.TurnOffLight("kitchen");
                                    break;
                                case 5:
                                    room.ChooseSeason();
                                    break;
                                default:
                                    Console.WriteLine("Invalid input");
                                    break;
                            }
                            isFirstTime = false;
                        }
                        break;
                    case 2:
                        room.CheckLight("living room");
                        house.IsOpenDoor();
                        house.OpenDoor();
                        house.CloseDoor();
                        service.ShowLocation("livingRoom");
                        while (livingroomChoice != 0)
                        {
                            house.OptLivingroom();
                            livingroomChoice = Convert.ToInt32(Console.ReadLine());
                            switch (livingroomChoice)
                            {
                                case 0:
                                    Console.WriteLine("Exiting livingroom");
                                    break;
                                case 1:
                                    house.IsTVOn();
                                    house.OnTv();
                                    house.OffTV();
                                    break;
                                case 2:
                                    room.TurnOnLight("livingRoom");
                                    break;
                                case 3:
                                    room.TurnOffLight("livingRoom");
                                    break;
                                case 4:
                                    room.ChooseSeason();
                                    break;
                                default:
                                    Console.WriteLine("Invalid input");
                                    break;
                            }
                            isFirstTime = false;

                        }
                        break;
                    case 3:
                        room.CheckLight("bedroom");
                        house.IsOpenDoor();
                        house.OpenDoor();
                        house.CloseDoor();
                        service.ShowLocation("bedRoom");
                        while (bedroomChoice != 0)
                        {
                            house.OptBedroom();
                            bedroomChoice = Convert.ToInt32(Console.ReadLine());
                            switch (bedroomChoice)
                            {
                                case 0:
                                    Console.WriteLine("Exiting bedroom");
                                    break;
                                case 1:
                                    house.IsOnPc();
                                    house.OnPC();
                                    house.OffPC();
                                    break;
                                case 2:
                                    room.TurnOnLight("bedRoom");
                                    break;
                                case 3:
                                    room.TurnOffLight("bedRoom");
                                    break;
                                case 4:
                                    room.ChooseSeason();
                                    break;
                                default:
                                    Console.WriteLine("Invalid input");
                                    break;
                            }
                            isFirstTime = false;

                        }
                        break;
                    case 4:
                        room.CheckLight("bathroom");
                        house.IsOpenDoor();
                        house.OpenDoor();
                        house.CloseDoor();
                        service.ShowLocation("bathRoom");
                        while (bathroomChoice != 0)
                        {
                            house.OptBathroom();
                            bathroomChoice = Convert.ToInt32(Console.ReadLine());
                            switch (bathroomChoice)
                            {
                                case 0:
                                    Console.WriteLine("Exiting bathroom");
                                    break;
                                case 1:
                                    house.IsWaterOn();
                                    house.OnWater();
                                    house.OffWater();
                                    break;
                                case 2:
                                    room.TurnOnLight("bathRoom");
                                    break;
                                case 3:
                                    room.TurnOffLight("bathRoom");
                                    break;
                                case 4:
                                    room.ChooseSeason();
                                    break;
                                default:
                                    Console.WriteLine("Invalid input");
                                    break;
                            }
                            isFirstTime = false;

                        }
                        break;
                    case 5:
                        house.AudioPlay();
                        break;
                    case 6:
                        service.StopSound();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}