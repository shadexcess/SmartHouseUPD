using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Speech.Synthesis;
using System.Media;
using System.Threading;

namespace SmartHouse
{
    internal class Service
    {
        private bool isOpenDoor;
        private bool isGasOpen;
        private bool isFridgeDoor;
        private bool isOnTelevision;
        private bool isOnPC;
        private bool isOnWater;
        private string fridgeMessage;
        private SpeechSynthesizer synthesizer;
        private SoundPlayer sound = new SoundPlayer();

        public bool IsOpenDoor => isOpenDoor;
        public bool IsGasOpen => isGasOpen;
        public bool IsFridgeDoor => isFridgeDoor;
        public bool IsOnTelevision => isOnTelevision;
        public bool IsOnPC => isOnPC;
        public bool IsOnWater => isOnWater;

        public string FridgeMessage
        {
            get
            {
                return fridgeMessage;
            }
            set
            {
                fridgeMessage = value;
            }
        }

        public Service()
        {
            isOpenDoor = false;
            isGasOpen = false;
            isFridgeDoor = false;
            isOnTelevision = false;
            isOnPC = false;
            isOnWater = false;
            fridgeMessage = "";
            synthesizer = new SpeechSynthesizer();

        }

        public void GoToRoom()
        {
            Console.WriteLine("0. Leave house");
            Console.WriteLine("1. Go to kitchen");
            Console.WriteLine("2. Go to livingroom");
            Console.WriteLine("3. Go to bedroom");
            Console.WriteLine("4. Go to Bathroom");
            Console.WriteLine("5. Turn on audio");
            Console.WriteLine("6. Turn off audio");
        }

        public void IsDoorOpen()
        {
            if (isOpenDoor == false)
            {
                Console.WriteLine("OOps.. the door is closed, please open the door to press any key");
                Console.ReadKey();
                Console.WriteLine("Welcome in room!");
            }
        }

        public void IsGasOn()
        {
            if (isGasOpen == false)
            {
                Console.WriteLine("OOps.. the gas is closed, please open the gas, press any key");
                Console.ReadKey();
                Console.WriteLine("Cooking...");
            }
        }
        public void IsDoorFridgeOpen()
        {
            if (isFridgeDoor == false)
            {
                Console.WriteLine("OOps.. the fridge door is closed, please open the fridge door, press any key");
                Console.ReadKey();
                Console.WriteLine("Welcome to fridge!");
            }
        }
        public void OptionsKitchen()
        {
            Console.WriteLine("KITCHEN");
            Console.WriteLine("0. Go another room");
            Console.WriteLine("1. To cook a food");
            Console.WriteLine("2. Open the fridge");
            Console.WriteLine("3. Turn on the light");
            Console.WriteLine("4. Turn off the light");
            Console.WriteLine("5. Set the temperature");
        }
        public void OptionsLivingroom()
        {
            Console.WriteLine("LIVINGROOM");
            Console.WriteLine("0. Go another room");
            Console.WriteLine("1. On TV");
            Console.WriteLine("2. Turn on the light");
            Console.WriteLine("3. Turn off the light");
            Console.WriteLine("4. Set the temperature");
        }
        public void IsOnTV()
        {
            if (isOnTelevision == false)
            {
                Console.WriteLine("OOps.. the TV is off, please on the TV, press any key");
                Console.ReadKey();
                Console.WriteLine("Welcome to TV!");
            }
        }
        public void IsOnComputer()
        {
            if (isOnPC == false)
            {
                Console.WriteLine("OOps.. the PC is off, please on the PC, press any key");
                Console.ReadKey();
                Console.WriteLine("Welcome to PC!");
            }
        }
        public void OptionsBedroom()
        {
            Console.WriteLine("BEDROOM");
            Console.WriteLine("0. Go another room");
            Console.WriteLine("1. On PC");
            Console.WriteLine("2. Turn on the light");
            Console.WriteLine("3. Turn off the light");
            Console.WriteLine("4. Set a temperature");
        }
        public void OptionsBathroom()
        {
            Console.WriteLine("BATHROOM");
            Console.WriteLine("0. Go another room");
            Console.WriteLine("1. Take a shower");
            Console.WriteLine("2. Turn on the light");
            Console.WriteLine("3. Turn off the light");
            Console.WriteLine("4. Set a temperature");
        }
        public void IsWaterOn()
        {
            if (isOnWater == false)
            {
                Console.WriteLine("OOps.. the water is off, please on the water, press any key");
                Console.ReadKey();
                Console.WriteLine("You took a shower!");
            }
        }

        public void ShowFridgeMessage()
        {
            Console.WriteLine(fridgeMessage);
        }

        public string GetProductType()
        {
            Console.Write(" Enter product type: ");
            string inputType = Console.ReadLine();
            return inputType;
        }

        public string GetProductName()
        {
            Console.Write(" Enter product name: ");
            string inputName = Console.ReadLine();
            return inputName;
        }

        public int GetDateExpiration()
        {
            Console.Write(" Enter product date expiration: ");
            int inputDate = Convert.ToInt32(Console.ReadLine());
            return inputDate;
        }

        public int GetRecipe()
        {
            Console.Write(" What dish would you like this time? Enter a number: ");
            int recipe = Convert.ToInt32(Console.ReadLine());
            return recipe;
        }

        public bool OutputAskIfContinueFridge()
        {
            Console.WriteLine(" Do you want to continue working with voice commands? Enter 'yes' or 'no':");
            string continueWorking = Console.ReadLine().ToLower();

            if (continueWorking == "yes")
            {
                return true;
            }

            return false;
        }

        public string OutputAskIfToShowCommandsFridge()
        {
            Console.WriteLine(" Do you want to see a list of commands I can execute?");
            Console.WriteLine(" Enter yes or no here: ");

            string showDetailed = Console.ReadLine().ToLower();
            return showDetailed;
        }

        public string AskToTypeCommand()
        {
            Console.WriteLine(" Type a command:");
            string command = Console.ReadLine().ToLower();
            return command;
        }

        public void Speak(string message)
        {
            // Creating an object for speech synthesis
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();

            // Set language and voice
            synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult, 0, new System.Globalization.CultureInfo("en-US"));

            synthesizer.Speak(message);

            // Closing the speech synthesis object       
            synthesizer.Dispose();
        }

        public void ShowLocation(string room)
        {
            string[] picture;

            if (room == "kitchen") 
            {
                picture = File.ReadAllLines("KitchenLocation.txt");
            }

            else if (room == "livingRoom")
            { 
                picture = File.ReadAllLines("LivingRoomLocation.txt");
            }

            else if (room == "bedRoom")
            {
                picture = File.ReadAllLines("BedRoomLocation.txt");
            }

            else
            {
                picture = File.ReadAllLines("BathRoomLocation.txt");
            }

            foreach (var line in picture) 
            {
                Console.WriteLine(line);
            }
        }

        public void OutputWhereLightOn(string room)
        {
            PlaySound("OutputWhereLightOn.wav");
            Console.WriteLine($"You forgot to switch off the lights in the {room}. It will turn off automatically in a moment.");
            Thread.Sleep(2500);
        }

        public void PlaySound(string fileName)
        {
            sound.SoundLocation = fileName;
            sound.Play();
        }

        public void StopSound()
        {
            if (sound != null)
            {
                sound.Stop();
            }
        }
    }
}