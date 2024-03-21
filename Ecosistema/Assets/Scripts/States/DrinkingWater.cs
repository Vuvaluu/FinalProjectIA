using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkingWater : State
{
    public DrinkingWater(Apatosaurus apato) : base (apato)
    {
        this.apatosaurus = apato;
    }

     public DrinkingWater(Stegosaurus stegu) : base (stegu)
    {
        this.stegosaurus = stegu;
    }

    public DrinkingWater(Velociraptor veloci) : base(veloci)
   {
     this.velociraptor = veloci;
   }

    public DrinkingWater(Trex rex) : base(rex)
   {
     this.trex = rex;
   }

    public override void OnStateEnter()
    {
         if(apatosaurus != null)
      {
         apatosaurus.Drink();
      }else if(stegosaurus != null)
      {
         stegosaurus.Drink();
      }else if(velociraptor != null)
      {
         velociraptor.Drink();
      }else if(trex != null)
      {
         trex.Drink();
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
            apatosaurus.water = null;
        }else if(stegosaurus != null)
        {
            stegosaurus.water = null;
        }else if(velociraptor != null)
        {
            velociraptor.water = null;
        }else if(trex != null)
        {
            trex.water = null;
        }
    }
}
