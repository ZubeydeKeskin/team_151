using System.Runtime.CompilerServices;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    /// <typeparam name="EnemyCollision"></typeparam>
    public class PlayerEnemyCollision : Simulation.Event<PlayerEnemyCollision>
    {
        public EnemyController enemy;
        public PlayerController player;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var willHurtEnemy = (player.Bounds.center.y - 0.1f) >= enemy.Bounds.max.y; 
            // Eğer ki karakter düşmanın kafasının üstünde ise hasar verebilir

            if (willHurtEnemy)// Hasar verilebilirse
            {
                var enemyHealth = enemy.GetComponent<Health>();//Düşmanın can değeri alınır
                if (enemyHealth != null)//Can değeri boş değil ise
                {
                    enemyHealth.Decrement();// Can bir azalır
                    if (!enemyHealth.IsAlive)// Can 0'mı diye kontrol edilir
                    {
                        Schedule<EnemyDeath>().enemy = enemy;// Düşman öldürülür
                        player.Bounce(2); // Karakter zıplar
                    }
                    else // Düşman canı 0 değilse düşmanın üzerinden yükseğe zıplar
                    {
                        player.Bounce(7); // Karakter yükseğe zıplar
                    }
                }
                else
                {
                    Schedule<EnemyDeath>().enemy = enemy;// Düşman can değeri boş ise gene de düşman öldürülür
                    player.Bounce(2); // Karakter zıplar
                }
            }
            else
            {
                Schedule<PlayerDeath>(); // Eğer düşman hasar görmüyorsa ve çarpışma yaşandıysa karakter hasar alır
            }
        }
    }
}