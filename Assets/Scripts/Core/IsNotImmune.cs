using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

public class IsNotImmune : Simulation.Event<IsNotImmune>
{
    PlatformerModel model = Simulation.GetModel<PlatformerModel>(); //
    //GameController model2 = Simulation.GetModel<GameController>(); // Uzun yol
    public override void Execute()
    {
        var player = model.player; // Player
        //var player2 = model2.model.player; // Uzun yol
        player.health.immunity = false;
    }
}