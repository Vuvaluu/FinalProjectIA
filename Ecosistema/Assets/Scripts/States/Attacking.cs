using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : State
{
   
  public Attacking(Apatosaurus apato) : base(apato)
   {
     this.apatosaurus = apato;
   }

   public Attacking(Stegosaurus stegu) : base(stegu)
   {
     this.stegosaurus = stegu;
   }

   public Attacking(Velociraptor veloci) : base(veloci)
   {
     this.velociraptor = veloci;
   }

   public Attacking(Trex rex) : base(rex)
   {
     this.trex = trex;
   }


  public override void OnStateEnter()
  {
    if(apatosaurus != null)
    {
      if(apatosaurus.tree != null)
      {
        apatosaurus.Eat(apatosaurus.tree);
      }
    } else if(stegosaurus != null)
    {
      if(stegosaurus.tree != null)
      {
        stegosaurus.Eat(stegosaurus.tree);
      }
    } else if(velociraptor != null)
    {
      if(velociraptor.apatosaurus != null)
      {
        velociraptor.Eat(velociraptor.apatosaurus);
      }
    }else if(trex != null)
    {
      if(trex.stegosaurus != null)
      {
        trex.Eat(trex.stegosaurus);
      }
    }
    
  }

  public override void Update()
  {
    if(apatosaurus != null)
    {
      apatosaurus.SetState(new Wander(apatosaurus));
    }else if(stegosaurus != null)
    {
      stegosaurus.SetState(new Wander(stegosaurus));
    }else if(velociraptor != null)
    {
      velociraptor.SetState(new Wander(velociraptor));
    }else if(trex != null)
    {
      trex.SetState(new Wander(trex));
    }
  }

   public override void OnStateExit()
   {
     if(apatosaurus != null)
        {
             apatosaurus.tree = null;
         }else if(stegosaurus != null)
         {
             stegosaurus.tree = null;
         }else if(velociraptor != null)
         {
             velociraptor.apatosaurus = null;
         }else if(trex != null)
         {
             trex.stegosaurus = null;
         }
   }
}
