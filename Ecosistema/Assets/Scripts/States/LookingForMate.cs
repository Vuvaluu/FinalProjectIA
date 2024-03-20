using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingForMate : State
{
     float randX = 0;
     float randZ = 0;
     float timeToWait = 0f;
     float elapsedTime = 0f;
     bool canMove = true;

   public LookingForMate(Dinosaur dino) : base(dino)
   {
        this.dinosaur = dino;
   }
   
   public override void OnStateEnter()
   {
        randX = 0;
        randZ = 0;
        timeToWait = 200f;
        elapsedTime = 0f;
        canMove = true;
        dinosaur.lookingForMate = true;
   }

   public override void Update()
    {
      
          if(dinosaur.mate != null)
          {
               SteeringBehaviors.Seek(dinosaur, dinosaur.mate.transform.position);
               float dist = Vector3.Distance(dinosaur.transform.position, dinosaur.mate.transform.position);
               if(dist < 3)
               {
                    dinosaur.SetState(new Breeding(dinosaur));
               }
          } else {
                if(randX != 0 && randZ != 0)
        {
            SteeringBehaviors.Seek(dinosaur, new Vector3(randX, 2, randZ));
        }
    //Wander around
        if (canMove == true) {
        randX = Random.Range(dinosaur.transform.position.x -300f, dinosaur.transform.position.x +300f);
        randZ = Random.Range(dinosaur.transform.position.z -300f, dinosaur.transform.position.z +300f);
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
          dinosaur.lookingForMate = false;
     }
    
}
