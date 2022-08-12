using System;

namespace result5_6_1
{
    class Program
    {
        static void Main(string[] args)
        {


            ShowUser(EnterUser());

            Console.ReadKey();
        }
        static (string name, string lastName, int age, string[] arrayPets, string[] arrayColors, bool getPet) EnterUser()
        {
            (string name, string lastName, int age, string[] arrayPets, string[] arrayColors, bool getPet) user;

            do
            {
                Console.WriteLine("Введите имя");
                user.name = Console.ReadLine();
            } while (int.TryParse(user.name, out int a) && double.TryParse(user.name, out double b));  // name


            do
            {
                Console.WriteLine("Введите фамилию");
                user.lastName = Console.ReadLine();
            } while (int.TryParse(user.lastName, out int a) && double.TryParse(user.lastName, out double b));  // lastName

            string age;
            int intage;

            do
            {
                Console.WriteLine("Введите возраст цифрами");
                age = Console.ReadLine();
            } while (CheckNum(age, out intage));  //age

            user.age = intage;

            user.getPet = false;
            string pet;
            int amountPet = 0;
            int intAmounPet;

            do
            {
                Console.WriteLine("Наличие питомца: да, нет");
                pet = Console.ReadLine();
            } while (!pet.Equals("да") && !pet.Equals("нет"));

            if (pet == "да")
            {
                user.getPet = true;
                do
                {
                    Console.WriteLine("Введите количество питомцев");
                    pet = Console.ReadLine();
                } while (CheckNum(pet, out intAmounPet));
                amountPet = intAmounPet;
            }
            else if (pet == "нет")
            {
                user.getPet = false;
            }

            user.arrayPets = CreateArrayPets(amountPet);

            string colors;
            int intAmountColors;
            int amountColors = 0;

            do
            {
                Console.WriteLine("Введите количество любимых цветов");
                colors = Console.ReadLine();
            } while (CheckNum(colors, out intAmountColors));  // amountColors

            amountColors = intAmountColors;

            user.arrayColors = CreateArrayColors(intAmountColors);

            return user;

        }

        static void ShowUser((string name, string lastName, int age, string[] arrayPets, string[] arrayColors, bool getPet) user)
        {
            Console.Clear();
            Console.WriteLine($"Имя: {user.name}, Фамилия: {user.lastName}, Возраст: {user.age}");

            Console.Write("Питомцы: \t");
            if (user.getPet == true)
            {
                foreach (var item in user.arrayPets)
                {
                    Console.Write(item + "|");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Отсутствуют");
            }

            Console.Write("Любимые цвета:\t");

            foreach (var item in user.arrayColors)
            {
                Console.Write(item + "|");
            }

        }

        static string[] CreateArrayPets(int num)
        {
            var result = new string[num];
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Ввидите кличку " + (i + 1) + " питомца");
                result[i] = Console.ReadLine();
            }

            return result;
        }
        static string[] CreateArrayColors(int num)
        {
            var result = new string[num];
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Ввидите " + (i + 1) + " любимый цвет");
                result[i] = Console.ReadLine();
            }

            return result;
        }
        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }
            }
            {
                corrnumber = 0;
                return true;
            }
        }

    }
}
