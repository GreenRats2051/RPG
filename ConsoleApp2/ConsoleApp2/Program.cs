using ConsoleApp2;
using System.Threading;

Console.WriteLine("Добро пожаловать в RPG-игру!");
Hero hero = CreateHero();

int monstersToDefeat = 15;
int defeatedMonsters = 0;
Random random = new Random();

while (defeatedMonsters < monstersToDefeat)
{
    Monster monster = GenerateMonster(random);
    Console.WriteLine($"\nВы встретили монстра: {monster.Name} (Здоровье: {monster.Health}, Сила атаки: {monster.Attack})");

    while (monster.Health > 0 && hero.Health > 0)
    {
        hero.AttackMonster(monster);
        if (monster.Health <= 0)
        {
            Console.WriteLine($"Вы победили монстра {monster.Name}!");
            defeatedMonsters++;
            hero.GainExperience(random.Next(10, 21));
            hero.RestoreHealth();
            break;
        }

        monster.AttackHero(hero);
        if (hero.Health <= 0)
        {
            Console.WriteLine("Вы погибли! Игра окончена.");
            return;
        }
    }
}

Console.WriteLine("Поздравляем! Вы победили 15 монстров!");

static Hero CreateHero()
{
    Console.Write("Введите имя вашего героя: ");
    string name = Console.ReadLine();

    Console.WriteLine("Выберите класс персонажа (1 - Воин, 2 - Маг, 3 - Лучник): ");
    int classChoice = int.Parse(Console.ReadLine());

    Hero hero = classChoice switch
    {
        1 => new Hero(name, "Воин", 100, 20, 0.1),
        2 => new Hero(name, "Маг", 80, 25, 0.2),
        3 => new Hero(name, "Лучник", 90, 15, 0.15),
        _ => throw new ArgumentException("Неверный выбор класса")
    };

    return hero;
}

static Monster GenerateMonster(Random random)
{
    string[] monsterNames = { "Гоблин", "Скелет", "Зомби", "Орк", "Дракон" };
    string name = monsterNames[random.Next(monsterNames.Length)];
    int health = random.Next(30, 101);
    int attack = random.Next(5, 21);
    return new Monster(name, health, attack);
}