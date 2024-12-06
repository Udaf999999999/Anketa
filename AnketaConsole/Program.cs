namespace AnketaConsole
{
    internal class Program
    {
        delegate void CoutMessage();
        private static string[] FillPetNames(int petCount)
        {
            string[] petNames = new string[petCount];
            for (int i = 0; i < petCount; i++)
            {
                Console.WriteLine("Enter your " + (i + 1) + " pet's name:");
                petNames[i] = Console.ReadLine();
            }
            return petNames;
        }
        private static string[] FillFavoriteColor(int favoriteColorCount)
        {
            string[] favoriteColors = new string[favoriteColorCount];
            for (int i = 0; i < favoriteColorCount; i++)
            {
                Console.WriteLine("Enter your " + (i + 1) + " favorite color:");
                favoriteColors[i] = Console.ReadLine();
            }
            return favoriteColors;
        }
        private static int CheckCorrectInput(bool isCorrect,int number, string typeVar, CoutMessage coutMessage)
        {
            while (!isCorrect || number <= 0)
            {
                if (!isCorrect) Console.WriteLine("It's not a number");
                if (number <= 0) Console.WriteLine(typeVar + "can't be under 1");
                coutMessage();
                isCorrect = int.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }
        private static void FillAnketa()
        {
            Console.WriteLine("Enter your name:");
            String userName = Console.ReadLine();

            Console.WriteLine("Enter your surname:");
            String surName = Console.ReadLine();

            CoutMessage coutMessage = () => Console.WriteLine("Enter your age:");
            coutMessage();
            int age = 0;
            bool isAgeCorrect = int.TryParse(Console.ReadLine(), out age);
            if (!isAgeCorrect || age <= 0)
            {
                age = CheckCorrectInput(isAgeCorrect, age, "Age", coutMessage);
            }

            Console.WriteLine("Do you have a pet? Yes/No");
            String answer = Console.ReadLine();
            bool havePet = answer == "Yes" ? true : false;
            int petCount = 0;
            if (havePet)
            {
                coutMessage = () => Console.WriteLine("How many pets do you have?");
                coutMessage();
                bool isPetCountCorrect = int.TryParse(Console.ReadLine(), out petCount);
                if (!isPetCountCorrect || petCount <= 0)
                {
                    petCount = CheckCorrectInput(isPetCountCorrect, petCount, "Pet count", coutMessage);
                }
            }
            string[] petNames;
            if (petCount > 0)
            {
                petNames = FillPetNames(petCount);
            }
            
            coutMessage = () => Console.WriteLine("What the count of your favorite colors?");
            coutMessage();
            int favoriteColorCount = 0;
            bool isCorrectFavoriteColorCount = int.TryParse(Console.ReadLine(), out favoriteColorCount);
            if (!isCorrectFavoriteColorCount || favoriteColorCount <= 0)
            {
                favoriteColorCount = CheckCorrectInput(isCorrectFavoriteColorCount, favoriteColorCount, "Favorite colors count", coutMessage);
            }
            string[] favoriteColors;
            if (favoriteColorCount > 0)
            {

                favoriteColors = FillFavoriteColor(favoriteColorCount);
            }




        }
        static void Main(string[] args)
        {
            FillAnketa();
            Console.WriteLine("Hello, World!");
        }
    }
}
