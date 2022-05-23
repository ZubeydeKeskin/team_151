using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Mechanics
{
    /// <summary>
    /// FirstZone'u başlatır, birinci seviyeye geçer.
    /// </summary>
    
    public class BaslangicZone : MonoBehaviour
    {
        public void next()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}