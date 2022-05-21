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
    /// FirstZone'u başlatır, birinci seviyeye geçer.
    /// </summary>
    
    public class FirstZone : MonoBehaviour
    {
        void OnTriggerStay2D(Collider2D collider)
        {
            if (Input.GetButton("Vertical"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}