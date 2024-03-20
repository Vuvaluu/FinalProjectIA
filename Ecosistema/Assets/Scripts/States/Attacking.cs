using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : State
{
   
  public Attacking(Apatosaurus apato) : base(apato)
   {
     this.apatosaurus = apato;
   }

  public override void OnStateEnter()
  {
    if(apatosaurus.tree != null)
    {
        apatosaurus.Eat(apatosaurus.tree);
    }
  }

  public override void Update()
  { 
    apatosaurus.SetState(new Wander(apatosaurus));
  }

  public override void OnStateExit()
  {

  }
}
