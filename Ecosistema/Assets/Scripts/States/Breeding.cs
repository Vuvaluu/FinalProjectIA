using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breeding : State
{
   public Breeding(Apatosaurus apato) : base(apato)
   {
        this.apatosaurus = apato;
   }

   public override void OnStateEnter()
   {
      if(apatosaurus.mate != null)
      {
         Vector3 middlePoint = (apatosaurus.transform.position + apatosaurus.mate.transform.position)/2f;
         PopulationGenerator.Instance.SpawnApatosaurus(middlePoint);
         apatosaurus.Breeding();
      }
   }

   public override void Update()
   {
    
   }
}
