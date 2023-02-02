namespace HomeWorkLinq1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            Detective detective = new Detective();
            detective.OutputCriminals(database);
        }
    }

    class Database
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public Database()
        {
            _criminals = new List<Criminal>()
            {
                new Criminal("Козлов Григорий Владимирович", true, 178, 70, "Белорус"),
                new Criminal("Бекуев Мовсур Абдурахманович", false, 178, 70, "Белорус"),
                new Criminal("Савинов Юрий Олегович", false, 174, 66, "Русский"),
                new Criminal("Овчинников Дмитрий Валерьевич", true, 186, 94, "Русский"),
                new Criminal("Бойко Владимир Владимирович", false, 190, 101, "Украинец"),
            };
        }

        public void ShowCriminals(int height, int weight, string nationality)
        {
            var criminals = _criminals.Where(criminal => criminal.Height == height).Where(criminal => criminal.Weight == weight).
                Where(criminal => criminal.Nationality == nationality).ToList();

            Console.WriteLine($"Преступники: ");

            foreach(Criminal criminal in criminals)
            {
                Console.WriteLine($"{criminal.Name}");
            }

            Console.ReadKey();
        }
    }

    class Criminal
    {
        public Criminal(string name, bool isInCustody, int height, int weight, string nationality)
        {
            Name = name;
            IsInCustody = isInCustody;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }

        public string Name { get; private set; }

        public bool IsInCustody { get; private set; }

        public int Height { get; private set; }

        public int Weight { get; private set; }

        public string Nationality { get; private set; }
    }

    class Detective
    {
        public Detective()
        {
            Name = Welcome();
        }

        public string? Name { get; private set; }

        public void OutputCriminals(Database database)
        {
            bool isProgramOn = true;

            while(isProgramOn)
            {
                Console.WriteLine("Введите вес преступника: ");
                bool isHeight = int.TryParse(Console.ReadLine(), out int height);

                Console.WriteLine("Введите рост преступника");
                bool isWeight = int.TryParse(Console.ReadLine(), out int weight);

                Console.WriteLine("Введите национальность преступника: ");
                string? nationality = Console.ReadLine();

                if (isHeight && isWeight && nationality != null)
                {
                    database.ShowCriminals(height, weight, nationality);
                }
            }
        }

        private string Welcome()
        {
            Console.WriteLine("Здравствуйте, детектив, как Вас зовут ? : ");

            string? userName = Console.ReadLine();

            if (userName == null)
            {
                return userName = "Аноним";
            }

            return userName;
        }
    }
}