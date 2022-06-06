using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player is spawned after dying.
    /// </summary>
    public class PlayerSpawn : Simulation.Event<PlayerSpawn>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            player.collider2d.enabled = true;
            player.controlEnabled = false;
            if (player.audioSource && player.respawnAudio)
                player.audioSource.PlayOneShot(player.respawnAudio);
            
            
            
            player.health.currentHP = player.health.maxHP; //Karakterin canı maksimum can değerine eşitlenir
            //Score.totalScore -= Score.instanceScore; 
            Score.instanceScore = 0; // Anlık skor sıfırlanı
            
            player.Teleport(model.spawnPoint.transform.position); // Canlanma noktasında yeniden doğar
            player.jumpState = PlayerController.JumpState.Grounded; // Karakter, yerde olarak ayarlanır
            player.animator.SetBool("dead", false); // Animasyon ölüm animasyonu bitirlir
            model.virtualCamera.m_Follow = player.transform; //Kamera konumu tekrardan player'a getilirir
            model.virtualCamera.m_LookAt = player.transform;
            Simulation.Schedule<EnablePlayerInput>(2f);//Karakter tekrardan girdi alabilri hale gelir
            
        }
    }
}