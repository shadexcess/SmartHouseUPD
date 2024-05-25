using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Speech.Recognition;
using System.Threading;

namespace SmartHouse
{
    internal class House
    {
        private LivingRoom livingRoom;
        private Kitchen kitchen;
        private BathRoom bathRoom;
        private Bedroom bedroom;
        private Service service;
        private Room room;

        public House()
        {
            livingRoom = new LivingRoom();
            kitchen = new Kitchen();
            bathRoom = new BathRoom();
            service = new Service();
            bedroom = new Bedroom();
            room = new Room();
        }
        public void MenuGoRoom()
        {
            service.GoToRoom();
        }
        public void OpenDoor()
        {
            room.OpenTheDoor();
        }
        public void CloseDoor()
        {
            room.CloseTheDoor();
        }
        public void IsOpenDoor()
        {
            room.IsOpenDoor(service);
        }
        public void IsGasOpen()
        {
            kitchen.IsGasOn(service);
        }
        public void OptKitchen()
        {
            service.OptionsKitchen();
        }
        public void OpenGas()
        {
            kitchen.GasOn();
        }
        public void CloseGas()
        {
            kitchen.GasOff();
        }
        public void OpenFridgeDoor()
        {
            kitchen.OpenFridgeDoor();
        }
        public void CloseFridgeDoor()
        {
            kitchen.CloseFridgeDoor();
        }
        public void IsDoorFridgeOpen()
        {
            kitchen.IsDoorFridgeOpen(service);
        }
        public void OnTv()
        {
            livingRoom.OnTv();
        }
        public void OffTV()
        {
            livingRoom.OffTV();
        }
        public void IsTVOn()
        {
            livingRoom.IsOnTV(service);
        }
        public void OptLivingroom()
        {
            service.OptionsLivingroom();
        }
        public void OptBedroom()
        {
            service.OptionsBedroom();
        }
        public void OnPC()
        {
            bedroom.OnPC();
        }
        public void OffPC()
        {
            bedroom.OffPC();
        }
        public void IsOnPc()
        {
            bedroom.IsOnPC(service);
        }
        public void OptBathroom()
        {
            service.OptionsBathroom();
        }
        public void OnWater()
        {
            bathRoom.WaterOn();
        }
        public void OffWater()
        {
            bathRoom.WaterOff();
        }
        public void IsWaterOn()
        {
            bathRoom.IsOnWater(service);
        }

        public void CreateDefaultProducts()
        {
            kitchen.CreateDefaultProducts();
        }

        public void AskIfContinueFridge()
        {
            kitchen.AskIfContinueFridge(service);
        }

        public void Greet()
        {
            Random rand = new Random();

            int situation = rand.Next(1, 7);

            if (situation == 1)
            {
                SituationFire();
            }
            else if (situation == 2)
            {
                SituationHotWeather();

            }
            else if (situation == 3)
            {
                SituationSuggestMusic();

            }
            else if (situation == 4)
            {
                SituationSuggestRecipes();
            }
            else if (situation == 5)
            {
                SituationReminder();
            }
            else
            {
                SituationRain();
            }
        }

        public void SituationFire()
        {
            service.PlaySound("SituationFire.wav");
            Console.WriteLine("Greetings, dear homeowner. I must share with you a matter of some urgency.");
            Console.WriteLine("I have noticed that the air outside is a bit polluted due to the fire.");
            Console.WriteLine("For your well-being, I kindly recommend you not to");
            Console.WriteLine("leave the building until the air quality improves.");
            Console.WriteLine();
        }

        public void SituationHotWeather()
        {
            service.PlaySound("SituationHotWeather.wav");
            Console.WriteLine("Ah, the sun does blaze with intensity today, doesn’t it?");
            Console.WriteLine("Perhaps a refreshing cascade of cool water in the form of a shower");
            Console.WriteLine("would provide a soothing respite. If you need to go outside, do not forget");
            Console.WriteLine("to take a bottle of water and try to avoid prolonged exposure to the sun.");
            Console.WriteLine();
        }

        public void SituationSuggestMusic()
        {
            service.PlaySound("SituationSuggestMusic.wav");
            Console.WriteLine("Welcome home! The house has missed your presence.");
            Console.WriteLine("Would you like me to play your favorite music to unwind?");
            string choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                ChooseMusicGenre();
            }
            Console.WriteLine();
        }

        public void SituationSuggestRecipes()
        {
            service.PlaySound("SituationSuggestRecipes.wav");
            Console.WriteLine("Hi there! I’ve noticed that you’ve had a long day.");
            Console.WriteLine("Would you like to try a new recipe for today?");
            Console.WriteLine("I have some interesting ideas.");
            Console.WriteLine("Let me know by entering ‘yes’ if you want to do this.");
            string choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                ///////////
            }
            Console.WriteLine();
        }

        public void SituationReminder()
        {
            service.PlaySound("SituationReminder.wav");
            Console.WriteLine("You're home! I’ve set a gentle reminder for your evening meditation routine.");
            Console.WriteLine("Remember, self-care is important.");
        }

        public void SituationRain()
        {
            service.PlaySound("SituationRain.wav");
            Console.WriteLine("Hello! The weather forecast predicts rain later in the evening.");
            Console.WriteLine("It might be a good idea to bring in the laundry from the clothesline.");
        }

        public void AudioPlay()
        {
            service.PlaySound("SuggestMusicOrNews.wav");
            Console.WriteLine(" How can I enhance your relaxation?");
            Console.WriteLine(" Perhaps the familiar melodies of your favorite playlist,");
            Console.WriteLine(" or the insightful updates from the news?");
            // не озвучувати
            Console.WriteLine(" Enter: ");
            string audioType = Console.ReadLine().ToLower();

            if (audioType == "music" || audioType == "playlist")
            {
                ChooseMusicGenre();
            }

            else if (audioType == "news")
            {
                ChooseNewsType();
            }

            else
            {
                Console.WriteLine("Unknown commad.");
            }
        }

        public void ChooseMusicGenre()
        {
            service.PlaySound("SuggestMusic.wav");
            Console.WriteLine("Excellent! Your playlist is a musical journey.");
            Console.WriteLine("Which path shall we take today - metal, rap, pop, or electronic?");
            Console.WriteLine("Enter: ");
            string musicGenre = Console.ReadLine().ToLower();

            string[] greetings = { "Here you are", "Enjoy the music", "This one's for you", "Let these notes carry you away" };

            Random random = new Random();
            int randomGreetingIndex = random.Next(0, greetings.Length);
            string randomGreeting = greetings[randomGreetingIndex];

            service.PlaySound(randomGreeting + ".wav");
            Thread.Sleep(2500);

            if (musicGenre == "metal")
            {
                service.PlaySound("metal.wav");
            }

            else if (musicGenre == "rap")
            {
                service.PlaySound("rap.wav");
            }

            else if (musicGenre == "pop")
            {
                service.PlaySound("pop.wav");
            }

            else if (musicGenre == "electronic")
            {
                service.PlaySound("electronic.wav");
            }

            else
            {
                string[] genres = { "metal", "rap", "pop", "electronic" };
                int randomGenreIndex = random.Next(0, genres.Length);
                string randomGenre = genres[randomGenreIndex];

                service.PlaySound(randomGenre + ".wav");
            }
        }

        public void ChooseNewsType()
        {
            service.PlaySound("SuggestNews.wav");
            Console.WriteLine("What kind of news do you prefer today: a global perspective");
            Console.WriteLine("with international news, weather forecasts or exciting sports highlights?");
            Console.WriteLine("Enter: ");
            string newsType = Console.ReadLine().ToLower();

            if (newsType == "international")
            {
                service.PlaySound("international.wav");
            }

            else if (newsType == "weather" || newsType == "forecast" || newsType == "weather forecast")
            {
                service.PlaySound("weatherForecast.wav");

            }

            else if (newsType == "sport" || newsType == "sports")
            {
                service.PlaySound("sports.wav");
            }

            else
            {
                string[] types = { "international", "weatherForecast", "sports" };

                Random random = new Random();
                int randomIndex = random.Next(0, types.Length);
                string randomType = types[randomIndex];

                service.PlaySound(randomType + ".wav");
            }
        }

        public void RandomEvent()
        {
            Random rand = new Random();

            int situation = rand.Next(1, 5);

            if (situation == 1)
            {
                service.PlaySound("ArmedPersonDetected.wav");
                Thread.Sleep(15000);
                service.PlaySound("Siren.wav");
                Thread.Sleep(12000);
                service.PlaySound("Arrest.wav");
                Thread.Sleep(8000);

            }
            else if (situation == 2)
            {
                service.PlaySound("international.wav");

            }
            else if (situation == 3)
            {
                service.PlaySound("international.wav");

            }
            else
            {
                service.PlaySound("international.wav");

            }

        }
    }
}