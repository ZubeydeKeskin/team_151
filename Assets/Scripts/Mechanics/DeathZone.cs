using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// DeathZone components mark a collider which will schedule a
    /// PlayerEnteredDeathZone event when the player enters the trigger.
    /// </summary>
    public class DeathZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>(); // collide eden obje PlayerController (karakterimiz) ise p'ye atanır 
            if (p != null) // p boş değilse çalışır.
                           // [(collider.gameObject.CompareTag("Player") olarak düşünülebilir, Karakter=PlayerController)]
            {
                p.health.currentHP = 1;
                Schedule<PlayerDeath>();
            } 
            /*
            if (collider.gameObject.CompareTag("Player"))
            {
                p.health.currentHP = 1;
                Schedule<PlayerDeath>();
            }
            */
        }
    }
}