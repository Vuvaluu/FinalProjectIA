using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkingWater : State
{
    public DrinkingWater(Apatosaurus apato) : base (apato)
    {
        this.apatosaurus = apato;
    }

   public override void Update()
    {
        apatosaurus.Drink();
    }

    public override void OnStateExit()
    {
        apatosaurus.lookingForWater = false;
    }
}
