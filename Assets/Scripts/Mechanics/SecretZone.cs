using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// DeathZone components mark a collider which will schedule a
    /// PlayerEnteredDeathZone event when the player enters the trigger.
    /// </summary>
    
    public class SecretZone : MonoBehaviour
    {
        private bool found = false;
        public TextMeshProUGUI notification;
        float timeLeft = 5.0f;
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (!found)
            {
                notification.text = "Gizli Bir Oda Buldun!";
                found = true;
            }
        }
        void Update()
        {
            if (found && (timeLeft >= 0))
            {
                timeLeft -= Time.deltaTime;
                if(timeLeft < 0)
                {
                    notification.text = "";
                }
            }
        }
    }
    
}