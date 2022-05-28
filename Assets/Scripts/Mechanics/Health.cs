using System;
using Platformer.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represebts the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {
        // Boolean gösterge, karakterin zarar almasını engeler
        // Ardı ardına alınan hasarları dudurmak için
        public bool immunity;
            
        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHP = 1;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        public int currentHP;
        
        /// <summary>
        /// Gösterilen can değerinin gösterilmesi için fonksiyon
        /// </summary>

        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;

        void Update()
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < currentHP)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }

                if (i < maxHP)
                {
                    hearts[i].enabled = true;
                }else
                {
                    hearts[i].enabled = false;
                }
            }
        }

        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
        }

        /// <summary>
        /// Decrement the HP of the entity. Will trigger a HealthIsZero event when
        /// current HP reaches 0.
        /// </summary>
        public void Decrement()
        {
            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
            if (currentHP == 0) // Health is Zero, Sağlık 0 ise karakter ölümü event'i çağrılır
            {
                Schedule<PlayerDeath>(); // PlayerDeath event.
            }
        }

        /// <summary>
        /// Decrement the HP of the entitiy until HP reaches 0.
        /// </summary>
        public void Die()
        {
            while (currentHP > 0) Decrement();
        }

        void Awake()
        {
            currentHP = maxHP;
        }
    }
}
