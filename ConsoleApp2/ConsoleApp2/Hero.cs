using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Hero
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public double CriticalChance { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        private int maxHealth;
        private int healthRestores;

        public Hero(string name, string heroClass, int health, int attack, double criticalChance)
        {
            Name = name;
            Class = heroClass;
            Health = health;
            maxHealth = health;
            Attack = attack;
            CriticalChance = criticalChance;
            Experience = 0;
            Level = 1;
            healthRestores = 3;
        }

        public void AttackMonster(Monster monster)
        {
            Random random = new Random();
            int damage = Attack;
            if (random.NextDouble() < CriticalChance)
            {
                damage = (int)(damage * 1.5);
                Console.WriteLine("Критический удар!");
            }
            monster.TakeDamage(damage);
            Console.WriteLine($"Вы атаковали {monster.Name} и нанесли {damage} урона.");
        }

        public void GainExperience(int amount)
        {
            Experience += amount;
            Console.WriteLine($"Вы получили {amount} опыта. Всего опыта: {Experience}");
            LevelUp();
        }

        private void LevelUp()
        {
            if (Experience >= Level * 100)
            {
                Level++;
                Experience -= Level * 100;
                Console.WriteLine($"Поздравляем! Вы достигли уровня {Level}!");
                UpgradeStats();
            }
        }

        private void UpgradeStats()
        {
            Console.WriteLine("Выберите, какую характеристику хотите улучшить (1 - Здоровье, 2 - Сила атаки, 3 - Шанс критического удара): ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    maxHealth += 20;
                    Health = maxHealth;
                    Console.WriteLine("Вы увеличили здоровье!");
                    break;
                case 2:
                    Attack += 5;
                    Console.WriteLine("Вы увеличили силу атаки!");
                    break;
                case 3:
                    CriticalChance += 0.05;
                    Console.WriteLine("Вы увеличили шанс критического удара!");
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        public void RestoreHealth()
        {
            if (healthRestores > 0)
            {
                Health = Math.Min(Health + 20, maxHealth);
                healthRestores--;
                Console.WriteLine($"Вы восстановили здоровье! Текущее здоровье: {Health}. Осталось восстановлений: {healthRestores}.");
            }
            else
            {
                Console.WriteLine("У вас больше нет восстановлений здоровья.");
            }
        }
    }
}
