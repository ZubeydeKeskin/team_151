using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{

    /// <summary>
    /// This event is triggered when the player character enters a trigger with a VictoryZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredVictoryZone"></typeparam>
    public class PlayerEnteredVictoryZone : Simulation.Event<PlayerEnteredVictoryZone>
    {
        public VictoryZone victoryZone;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            model.player.animator.SetTrigger("victory");
            model.player.controlEnabled = false;
            
            SceneManager.LoadScene(1); //Karakteri ana ekrana gönder
            
            //Elindeki skoru oynanılan bölüm için kaydet (Score.cs içinde)
            if (SceneManager.GetActiveScene().buildIndex == 2)//Bolum_1
            {
                if (Score.instanceScore >= Score.firstZone)
                {
                    Score.firstZone = Score.instanceScore;
                }
            } else if (SceneManager.GetActiveScene().buildIndex == 3)//Bolum_2
            {
                if (Score.instanceScore >= Score.secondZone)
                {
                    Score.secondZone = Score.instanceScore;
                }
            }else if (SceneManager.GetActiveScene().buildIndex == 4)//Bolum_3
            {
                if (Score.instanceScore >= Score.thirdZone)
                {
                    Score.thirdZone = Score.instanceScore;
                }
            }
            Score.totalScore = Score.firstZone + Score.secondZone + Score.thirdZone;
            Score.instanceScore = 0; // Anlık Skoru sıfırla
            
        }
    }
}