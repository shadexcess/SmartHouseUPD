using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SmartHouse
{
    internal class Fridge
    {
        private bool fridgeDoor;
        public static List<Fridge> products; // список для зберігання продуктів
        private string type; // тип продукту (фрукт, м'ясо)
        private string name; // назва продукту (яблуко, свинина)
        private int dateExpiration; // строк придатності (скільки днів залишилось)
        private string message; // для виведення повідомлення
        private int lastIndex; // індекс останнього продукту такого ж типу

        public Fridge()
        {
            fridgeDoor = false;
            type = "";
            name = "";
            dateExpiration = 0;
            message = "";
            lastIndex = -1;
        }

        public int LastIndex
        {
            get
            {
                return lastIndex;
            }
            set
            {
                lastIndex = value;
            }
        }

        public List<Fridge> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }


        public void OpenFridgeDoor()
        {
            fridgeDoor = true;
        }

        public void CloseFridgeDoor()
        {
            fridgeDoor = false;
        }

        public void UseService(Service service)
        {
            fridgeDoor = service.IsFridgeDoor;
        }

        public void IsOpenFridge(Service service)
        {
            service.IsDoorFridgeOpen();
        }

        /// <summary>
        /// Метод для створення об'єктів, що позначають продукти в холодильнику
        /// </summary>
        public void CreateDefaultProducts()
        {
            products = new List<Fridge>
            {
               new Fridge { type = "Fruit", name = "Apples", dateExpiration = 5, },
               new Fridge { type = "Fruit", name = "Peaches", dateExpiration = 4, },
               new Fridge { type = "Fruit", name = "Lemons", dateExpiration = 3, },
               new Fridge { type = "Vegetable", name = "Tomatoes", dateExpiration = 2, },
               new Fridge { type = "Vegetable", name = "Carrots", dateExpiration = 5, },
               new Fridge { type = "Meat", name = "Pork", dateExpiration = 1, },
               new Fridge { type = "Fish", name = "Salmon", dateExpiration = 1, },
               new Fridge { type = "Fish", name = "Tuna", dateExpiration = 2, },
               new Fridge { type = "Dairy", name = "Milk", dateExpiration = 1, },
               new Fridge { type = "Dairy", name = "Cheese", dateExpiration = 4, }
            };
        }

        /// <summary>
        /// Метод для виведення на консоль вмісту холодильника
        /// </summary>
        /// <param name="products">Список продуктів.</param>
        public void ShowProducts(List<Fridge> products)
        {
            message += string.Format("|{0,10}|{1,10}|{2,15}|\n", "Type", "Name", "Expiration date");
            foreach (Fridge product in products)
            {
                message += string.Format("|{0,10}|{1,10}|{2,15}|\n", product.type, product.name, product.dateExpiration);
            }
            message += "\n";
        }


        /// <summary>
        /// Метод для перевірки чи є введений продукт в холодильнику
        /// </summary>
        /// <param name="products">Список продуктів.</param>
        public void CheckProducts(List<Fridge> products, string inputType, string inputName)
        {
            bool productFound = false;

            foreach (Fridge product in products)
            {
                if (product.type.ToLower() == inputType.ToLower() && product.name.ToLower() == inputName.ToLower())
                {
                    message = "\n The product is in the fridge.\n";
                    productFound = true;
                    break;
                }
            }

            if (!productFound)
            {
                message = "\n The product is not in the fridge.\n";
            }
        }

        /// <summary>
        /// Метод для того створення нового продукту
        /// </summary>
        /// <returns>Новий продукт у списку.</returns>
        public Fridge CreateProduct(string inputType, string inputName, int inputDate)
        {
            return new Fridge { type = inputType, name = inputName, dateExpiration = inputDate };
        }

        /// <summary>
        /// Метод для знаходження індексу останнього продукта такого ж типу
        /// </summary>
        /// <param name="newProduct"></param>
        public int FindLastProductOfType(Fridge newProduct)
        {
            // Знайдемо останнє місце в списку, де зустрічається продукт з введеним типом
            for (int i = products.Count - 1; i >= 0; i--)
            {
                if (products[i].type == newProduct.type)
                {
                    lastIndex = i;
                    break;
                }
            }
            return lastIndex;
        }

        /// <summary>
        /// Метод для того, щоб покласти продукт в холодильник
        /// </summary>
        /// <param name="newProduct"></param>
        public void PutProduct(Fridge newProduct, int lastIndex)
        {
            // якщо продукт з таким типом не знайдено, додамо новий продукт в кінець списку
            if (lastIndex == -1)
            {
                products.Add(newProduct);
            }
            else
            {
                // інакше додамо новий продукт після останнього продукту з таким типом
                products.Insert(lastIndex + 1, newProduct);
            }

            message = "\n The product has been added to the fridge.\n";
        }

        /// <summary>
        /// Метод для взяття продукту із холодильника
        /// </summary>
        public void TakeProducts(string inputType, string inputName)
        {
            bool productFound = false;

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].type.ToLower() == inputType.ToLower() && products[i].name.ToLower() == inputName.ToLower())
                {
                    products.Remove(products[i]);
                    message = "\n The product has been removed from the fridge.\n";
                    productFound = true;
                    break;
                }
            }

            if (!productFound)
            {
                message = "\n The product is not in the fridge.\n";
            }
        }

        /// <summary>
        /// Метод для виведення назв страв
        /// </summary>
        /// <returns>1, якщо є доступні страви, 0 - якщо немає.</returns>
        public bool ShowRecipes()
        {
            List<string> productNames = new List<string>();

            // збираємо імена всіх продуктів у список
            for (int i = 0; i < products.Count; i++)
            {
                productNames.Add(products[i].name);
            }

            // перевіряємо, чи є в холодильнику певні продукти
            if (productNames.Contains("Pork") && productNames.Contains("Tomatoes"))
            {
                message += "\n 1. Baked pork with tomatoes\n";
            }
            if (productNames.Contains("Apples") && productNames.Contains("Peaches"))
            {
                message += "\n 2. Fresh salad with apples and peaches\n";

            }
            if (productNames.Contains("Salmon") && productNames.Contains("Lemons"))
            {
                message += "\n 3. Baked salmon with lemon\n";

            }
            else
            {
                message += "\n There is not enough food to cook anything.\n";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Метод для обробки введеного користувачем запиту щодо страви
        /// </summary>
        /// <returns>Рядок, який позначає назву страви та назву текстового файлу з рецептом.</returns>
        public string ChooseRecipes(int recipe)
        {
            switch (recipe)
            {
                case 1:
                    return "Baked pork with tomatoes";
                case 2:
                    return "Fresh salad with apples and peaches";
                case 3:
                    return "Baked salmon with lemon";
                default:
                    return "Unknown choice";
            }
        }

        /// <summary>
        /// Метод для виведення на консоль рецепту обраної користувачем страви
        /// </summary>
        /// <param name="suggestedRecipe">Рядок, який позначає назву страви та назву текстового файлу з рецептом.</param>
        /// <returns>Детальний опис рецепту, або ж повідомлення, що рецептів не знайдено.</returns>
        public void DetailedRecipes(string suggestedRecipe)
        {
            string fileName = suggestedRecipe + ".txt";
            if (File.Exists(fileName))
            {
                message = File.ReadAllText(fileName);
            }
            else
            {
                message = "\n Recipe was not found.\n";
            }
        }

        public void ShowMessage(Service service)
        {
            service.FridgeMessage = message;
            service.ShowFridgeMessage();
        }
    }
}
