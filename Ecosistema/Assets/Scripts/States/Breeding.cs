using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breeding : State
{
   public Breeding(Apatosaurus apato) : base(apato)
   {
        this.apatosaurus = apato;
   }

    public Breeding(Stegosaurus stegu) : base(stegu)
   {
        this.stegosaurus = stegu;
   }

   public Breeding(Velociraptor veloci) : base(veloci)
   {
     this.velociraptor = veloci;
   }

    public Breeding(Trex rex) : base(rex)
   {
     this.trex = rex;
   }

   public override void OnStateEnter()
   {
      if(apatosaurus != null)
      {
          if(apatosaurus.mate != null)
         {
            Vector3 middlePoint = (apatosaurus.transform.position + apatosaurus.mate.transform.position)/2f;
            PopulationGenerator.Instance.SpawnApatosaurus(middlePoint);
            apatosaurus.Breeding();
         }
      }else if(stegosaurus != null)
      {
         if(stegosaurus.mate != null)
         {
            Vector3 middlePoint = (stegosaurus.transform.position + stegosaurus.mate.transform.position)/2f;
            PopulationGenerator.Instance.SpawnStegosaurus(middlePoint);
            stegosaurus.Breeding();
         }
      }else if(velociraptor != null)
      {
         if(velociraptor.mate != null)
         {
            Vector3 middlePoint = (velociraptor.transform.position + velociraptor.mate.transform.position)/2f;
            PopulationGenerator.Instance.SpawnVelociraptor(middlePoint);
            velociraptor.Breeding();
         }
      }else if(trex != null)
      {
         if(trex.mate != null)
         {
            Vector3 middlePoint = (trex.transform.position + trex.mate.transform.position)/2f;
            PopulationGenerator.Instance.SpawnTrex(middlePoint);
            trex.Breeding();
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
         apatosaurus.mate = null;
      }else if(stegosaurus != null)
      {
         stegosaurus.mate = null;
      }else if(velociraptor != null)
      {
         velociraptor.mate = null;
      }else if(trex != null)
      {
         trex.mate = null;
      }
   }
}
