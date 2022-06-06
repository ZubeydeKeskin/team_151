using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

public class IsNotImmune : Simulation.Event<IsNotImmune>
{
    PlatformerModel model = Simulation.GetModel<PlatformerModel>(); // model' ve içindeki elemanları ile bir Obje oluştur
    //GameController model2 = Simulation.GetModel<GameController>(); // Uzun yol
    public override void Execute()// Player hasar aldıktan bir süre sonra, tekrardan hasar alamsını sağlar (Schedule ile)
    {
        var player = model.player; // player verilerini bulunduran (nesne) player'i oluştur, (model Objesinden çek)
        //var player2 = model2.model.player; // Uzun yol
        player.health.immunity = false; // player bir süre sonra hasar almaya başlar
    }
}