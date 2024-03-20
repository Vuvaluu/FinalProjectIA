using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : State
{
   
   public Attacking(Apatosaurus apato) : base(apato)
   {
     this.apatosaurus = apato;
   }

   public override void Update()
   {
    if(apatosaurus.tree != null)
    {
        apatosaurus.Eat(apatosaurus.tree);
    } else {
        apatosaurus.SetState(new LookingForFood(apatosaurus));
    }
   }

}
