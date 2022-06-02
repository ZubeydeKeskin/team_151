using Platformer.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// SecondZone'u başlatır, ikinci seviyeye geçer.
    /// </summary>
    
    public class ThirdZone : MonoBehaviour
    {
        void OnTriggerStay2D(Collider2D collider)
        { 
            if (Input.GetButton("Vertical") && Keys.key2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
            }
        }
    }
}