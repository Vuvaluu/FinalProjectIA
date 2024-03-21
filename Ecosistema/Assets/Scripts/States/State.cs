using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    protected Dinosaur dinosaur;
    protected Apatosaurus apatosaurus;
    protected Stegosaurus stegosaurus;
    protected Velociraptor velociraptor;
    protected Trex trex;

    public State(Apatosaurus apato)
    {
        apatosaurus = apato;
    }

    public State(Stegosaurus stegu)
    {
        stegosaurus = stegu;
    }

    public State(Velociraptor veloci)
    {
        velociraptor = veloci;
    }

    public State(Dinosaur dino)
    {
        dinosaur = dino;
    }

    public State(Trex rex)
    {
        trex = rex;
    }

   public abstract void Update();

   public virtual void OnStateEnter()
   {

   }
   public virtual void OnStateExit()
   {

   }
}
