using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingForWater : State
{
     float randX = 0;
     float randZ = 0;
     float timeToWait = 0f;
     float elapsedTime = 0f;
     bool canMove = true;

   public LookingForWater(Apatosaurus apato) : base(apato)
   {
        this.apatosaurus = apato;
   }
   
   public override void OnStateEnter()
   {
        randX = 0;
        randZ = 0;
        timeToWait = 200f;
        elapsedTime = 0f;
        canMove = true;
        apatosaurus.lookingForWater = true;
   }

   public override void Update()
    {
      
          if(apatosaurus.water != null)
          {
               SteeringBehaviors.Seek(apatosaurus, apatosaurus.water.transform.position);
               float dist = Vector3.Distance(apatosaurus.transform.position, apatosaurus.water.transform.position);
               if(dist < 3)
               {
                    apatosaurus.SetState(new DrinkingWater(apatosaurus));
               }
          } else {
                if(randX != 0 && randZ != 0)
        {
            SteeringBehaviors.Seek(apatosaurus, new Vector3(randX, 2, randZ));
        }
    //Wander around
        if (canMove == true) {
        randX = Random.Range(apatosaurus.transform.position.x -300f, apatosaurus.transform.position.x +300f);
        randZ = Random.Range(apatosaurus.transform.position.z -300f, apatosaurus.transform.position.z +300f);
        canMove = false;
    } else {
        elapsedTime++;
        if(elapsedTime > timeToWait) {
        elapsedTime = 0f;
        canMove = true;
            }
        }
          }
    }

     public override void OnStateExit()
     {
          apatosaurus.lookingForWater = false;
     }
    
}
