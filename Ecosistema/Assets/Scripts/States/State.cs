using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Dinosaur dinosaur;
    protected Apatosaurus apatosaurus;

    public State(Apatosaurus apato)
    {
        apatosaurus = apato;
    }

    public State(Dinosaur dino)
    {
        dinosaur = dino;
    }

   public abstract void Update();

   public virtual void OnStateEnter()
   {

   }
   public virtual void OnStateExit()
   {

   }
}
