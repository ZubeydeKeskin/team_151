using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died or damaged
    /// Oyuncu öldürülür ya da hasar alır
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        //Player hasar almasayı, ya da ölmesi burada oynatılır
        public override void Execute()
        {
            var player = model.player;
            if (player.health.IsAlive && (player.health.currentHP <= 1) && !player.health.immunity)
            //Karakterin canı 1 ya da daha azsa + Player hasar alabiliyorsa, karakter ölüdürülür
            {
                player.health.Die();
                model.virtualCamera.m_Follow = null;
                model.virtualCamera.m_LookAt = null;
                // player.collider.enabled = false;
                player.controlEnabled = false;

                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);
                player.animator.SetTrigger("hurt"); //Player hasar alma anismasyonu oynatılır
                player.animator.SetBool("dead", true);
                Simulation.Schedule<PlayerSpawn>(2);
            }
            else if (!player.health.immunity)//Karakterin canı daha falza ve hasar alabiliyorsa canı azalır
            {
                if (player.audioSource && player.ouchAudio) // Eğerki ses kaynağı ve kayıtlı hasar sesi varsa oynatılır
                    player.audioSource.PlayOneShot(player.ouchAudio); // hasar alma sesi oynatılır
                player.animator.SetTrigger("hurt"); // Player hasar alma animasyonu oynatılır
                player.health.currentHP--; //Can azalır
                
                
                Simulation.Schedule<IsNotImmune>(3); //3 saniye sonra tekrardan hasar alınabilir hale gelir
                
                player.health.immunity = true; //Karakter hasar almaz hale gelir
            }
        }
    }
}