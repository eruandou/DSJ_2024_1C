using System;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObject
{
    public interface RPGTag
    {
    }

    public interface EnemyTag : RPGTag
    {
    }

    public interface HeroTag : RPGTag
    {
    }

    public interface ItemTag : RPGTag
    {
    }

    public class DungeonMaster
    {
        private List<RPGEnemy> allEnemies = new();

        public bool TryFly(RPGEnemy enemy, out IFlyingRPGEnemy flyingEnemy)
        {
            flyingEnemy = default;
            if (enemy is IFlyingRPGEnemy flyingRpgEnemy)
            {
                flyingEnemy = flyingRpgEnemy;
            }

            return flyingEnemy != null;
        }

        public bool CanMove(RPGTag tag)
        {
            if (tag is EnemyTag || tag is HeroTag)
            {
                return true;
            }

            return false;
        }
    }

    public class InstaDeathSpell
    {
        public void Use(RPGEnemy enemy)
        {
            enemy.Kill();
        }
    }

    public class Mage : HeroTag
    {
        private float speed;
        private Vector3 currentLocation;

        public void CastSpell(Dragon enemyToKill)
        {
            var instaDeathSpell = new InstaDeathSpell();
            instaDeathSpell.Use(enemyToKill);
        }

        public void Move(Vector3 direction)
        {
            currentLocation += speed * direction;
        }
    }

    public abstract class RPGEnemy : EnemyTag
    {
        protected float health;
        protected string name;

        public event Action OnKill;

        public RPGEnemy(float health, string name)
        {
            this.health = health;
            this.name = name;
        }

        public void Kill()
        {
            health = 0;
        }

        public abstract Type GetCurrentEnemyType();
    }

    public class Dragon : RPGEnemy, IFlyingRPGEnemy
    {
        public Dragon(float health, string name) : base(health, name)
        {
        }

        public void Fly()
        {
        }

        public override Type GetCurrentEnemyType()
        {
            return typeof(Dragon);
        }
    }

    public class Goblin : RPGEnemy
    {
        public Goblin(float health, string name) : base(health, name)
        {
        }

        public void Walk()
        {
        }

        public override Type GetCurrentEnemyType()
        {
            return typeof(Goblin);
        }
    }

    public interface IFlyingRPGEnemy
    {
        void Fly();
    }
}