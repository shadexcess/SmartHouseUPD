using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SmartHouse
{
    internal class Kitchen : Room
    {
        private bool isWaterOn;
        private bool isGasOn;
        private bool isLightOn;
        private Fridge fridge;
        Service service = new Service();
        public Kitchen()
        {
            fridge = new Fridge();
        }
        public void GasOn()
        {
            isGasOn = true;
        }
        public void GasOff()
        {
            isGasOn = false;
        }

        public void UseService(Service service)
        {
            isGasOn = service.IsGasOpen;
        }
        public void IsGasOn(Service service)
        {
            service.IsGasOn();
        }
        public void OpenFridgeDoor()
        {
            fridge.OpenFridgeDoor();
        }
        public void CloseFridgeDoor()
        {
            fridge.CloseFridgeDoor();
        }
        public void IsDoorFridgeOpen(Service service)
        {
            fridge.IsOpenFridge(service);
        }

        public void CreateDefaultProducts()
        {
            fridge.CreateDefaultProducts();
        }


        /// <summary>
        /// Метод для запиту в користувача, чи хоче він, щоб команди вивелись на консоль
        /// </summary>
        private int AskIfToShowCommands(Service service, string showDetailed)
        {
            if (showDetailed == "yes")
            {
                fridge.Message = "\n";
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Метод для виведення вмісту текстового файлу з командами на консоль
        /// </summary>
        private void ShowCommands(Service service)
        {
            var commands = File.ReadAllLines("FridgeCommands.txt");
            foreach (var command in commands)
            {
                fridge.Message += command;
                fridge.Message += "\n";
            }
            fridge.ShowMessage(service);
            fridge.Message = "\n";
        }

        /// <summary>
        /// Метод для пошуку введеної користувач команди в текстовому файлі
        /// </summary>
        /// <returns>Рядок, який відповідає обраній команді.</returns>
        private string ExecuteCommand(string command)
        {
            var commands = File.ReadAllLines("FridgeCommands.txt");

            foreach (var cmd in commands)
            {
                if (cmd.ToLower().Contains(command))
                {
                    return cmd;
                }
            }

            return null;
        }

        /// <summary>
        /// Метод для вибору команди, яку виконати
        /// </summary>
        private void ChooseCommand(Service service)
        {
            var command = ExecuteCommand(service.AskToTypeCommand());

            switch (command)
            {
                case " Show products in the fridge.":
                    fridge.Message = "";
                    fridge.Message += "\n There are products in the fridge: \n";
                    service.Speak(fridge.Message);
                    fridge.ShowProducts(fridge.Products);
                    fridge.ShowMessage(service);
                    break;
                case " Check if the product is in the fridge.":
                    fridge.Message = "";
                    fridge.Message += "\n You want to see if this product is in the fridge? \n";
                    fridge.Message += " Enter the type and name of the product:";
                    service.Speak(fridge.Message);
                    fridge.ShowMessage(service);
                    fridge.CheckProducts(fridge.Products, service.GetProductType(), service.GetProductName());
                    service.Speak(fridge.Message);
                    fridge.ShowMessage(service);
                    break;
                case " Put product into the fridge.":
                    fridge.Message = "";
                    fridge.Message += "\n You want to put a new product in the fridge.\n ";
                    fridge.Message += " Do it and enter the type, name and date expiration of the product:";
                    service.Speak(fridge.Message);
                    fridge.ShowMessage(service);
                    Fridge newProduct = fridge.CreateProduct(service.GetProductType(), service.GetProductName(), service.GetDateExpiration());
                    fridge.PutProduct(newProduct, fridge.FindLastProductOfType(newProduct));
                    service.Speak(fridge.Message);
                    fridge.ShowMessage(service);
                    break;
                case " Take product from the fridge.":
                    fridge.Message = "";
                    fridge.Message += "\n You want to take a product from the fridge? \n";
                    fridge.Message += " Enter the type and name of the product:";
                    service.Speak(fridge.Message);
                    fridge.ShowMessage(service);
                    fridge.TakeProducts(service.GetProductType(), service.GetProductName());
                    service.Speak(fridge.Message);
                    fridge.ShowMessage(service);
                    break;
                case " Suggest some recipes based on products in the fridge.":
                    service.PlaySound("HereAreRecipes.wav");
                    fridge.Message += "\n It was a hard working day, wasn't it? \n";
                    fridge.Message += " Here are recipes for dishes that can be cooked using the products in the fridge: \n";
                    bool thereAreRecipes = fridge.ShowRecipes();
                    fridge.ShowMessage(service);
                    if (thereAreRecipes)
                    {
                        string suggestedRecipe = fridge.ChooseRecipes(service.GetRecipe());
                        fridge.DetailedRecipes(suggestedRecipe);
                        fridge.ShowMessage(service);
                    }
                    break;
                default:
                    fridge.Message = " Unknown command.";
                    service.Speak(fridge.Message);
                    fridge.ShowMessage(service);
                    break;
            }
        }

        /// <summary>
        /// Метод для виклику методу для вибору команди для виконання, поки користувач цього хоче
        /// </summary>
        public void AskIfContinueFridge(Service service)
        {

            if (AskIfToShowCommands(service, service.OutputAskIfToShowCommandsFridge()) == 1)
            {
                ShowCommands(service);
            }

            do
            {
                ChooseCommand(service);

            } while (service.OutputAskIfContinueFridge());
        }
    }
}