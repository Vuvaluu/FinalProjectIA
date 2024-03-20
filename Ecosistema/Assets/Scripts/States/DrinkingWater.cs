using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkingWater : State
{
    public DrinkingWater(Apatosaurus apato) : base (apato)
    {
        this.apatosaurus = apato;
    }

    public override void OnStateEnter()
    {
        apatosaurus.Drink();
    }

    public override void Update()
    {
        apatosaurus.SetState(new Wander(apatosaurus));
    }

    public override void OnStateExit()
    {

    }
}
