using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Monster
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Attack { get; private set; }

        public Monster(string name, int health, int attack)
        {
            Name = name;
            Health = health;
            Attack = attack;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public void AttackHero(Hero hero)
        {
            hero.Health -= Attack;
            if (hero.Health < 0) hero.Health = 0;
            Console.WriteLine($"{Name} атакует вас и наносит {Attack} урона. Ваше здоровье: {hero.Health}");
        }
    }
}
