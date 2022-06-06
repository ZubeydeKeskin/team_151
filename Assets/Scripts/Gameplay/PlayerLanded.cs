using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player character lands after being airborne.
    /// </summary>
    /// <typeparam name="PlayerLanded"></typeparam>
    public class PlayerLanded : Simulation.Event<PlayerLanded>
    {
        public PlayerController player;
        //Karakter yere dokununca yaşanacaklar, (şimdilik boş)
        public override void Execute()
        {

        }
    }
}