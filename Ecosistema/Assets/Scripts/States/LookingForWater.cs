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

    public LookingForWater(Stegosaurus stegu) : base(stegu)
   {
        this.stegosaurus = stegu;
   }

   public LookingForWater(Velociraptor veloci) : base(veloci)
   {
     this.velociraptor = veloci;
   }

   public LookingForWater(Trex rex) : base(rex)
   {
     this.trex = rex;
   }
   
   public override void OnStateEnter()
   {
        randX = 0;
        randZ = 0;
        timeToWait = 200f;
        elapsedTime = 0f;
        canMove = true;

        if(apatosaurus != null)
        {
          apatosaurus.lookingForWater = true;
        } else if(stegosaurus != null)
        {
          stegosaurus.lookingForWater = true;
        } else if(velociraptor != null)
        {
          velociraptor.lookingForWater = true;
        } else if(trex != null)
        {
          trex.lookingForWater = true;
        }
       
   }

   public override void Update()
    {
          if(apatosaurus != null)
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
          
          else if(stegosaurus != null)
          {
               if(stegosaurus.water != null)
               {
                    SteeringBehaviors.Seek(stegosaurus, stegosaurus.water.transform.position);
                    float dist = Vector3.Distance(stegosaurus.transform.position, stegosaurus.water.transform.position);
                    if(dist < 3)
                    {
                         stegosaurus.SetState(new DrinkingWater(stegosaurus));
                    }
               } else {
                    if(randX != 0 && randZ != 0)
                    {
                         SteeringBehaviors.Seek(stegosaurus, new Vector3(randX, 2, randZ));
                    }
                    //Wander around
                    if (canMove == true) {
                         randX = Random.Range(stegosaurus.transform.position.x -300f, stegosaurus.transform.position.x +300f);
                         randZ = Random.Range(stegosaurus.transform.position.z -300f, stegosaurus.transform.position.z +300f);
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

          else if(velociraptor != null)
          {
               if(velociraptor.water != null)
               {
                    SteeringBehaviors.Seek(velociraptor, velociraptor.water.transform.position);
                    float dist = Vector3.Distance(velociraptor.transform.position, velociraptor.water.transform.position);
                    if(dist < 3)
                    {
                         velociraptor.SetState(new DrinkingWater(velociraptor));
                    }
               } else {
                    if(randX != 0 && randZ != 0)
                    {
                         SteeringBehaviors.Seek(velociraptor, new Vector3(randX, 2, randZ));
                    }
                    //Wander around
                    if (canMove == true) {
                         randX = Random.Range(velociraptor.transform.position.x -300f, velociraptor.transform.position.x +300f);
                         randZ = Random.Range(velociraptor.transform.position.z -300f, velociraptor.transform.position.z +300f);
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

          else if(trex != null)
          {
               if(trex.water != null)
               {
                    SteeringBehaviors.Seek(trex, trex.water.transform.position);
                    float dist = Vector3.Distance(trex.transform.position, trex.water.transform.position);
                    if(dist < 3)
                    {
                         trex.SetState(new DrinkingWater(trex));
                    }
               } else {
                    if(randX != 0 && randZ != 0)
                    {
                         SteeringBehaviors.Seek(trex, new Vector3(randX, 2, randZ));
                    }
                    //Wander around
                    if (canMove == true) {
                         randX = Random.Range(trex.transform.position.x -300f, trex.transform.position.x +300f);
                         randZ = Random.Range(trex.transform.position.z -300f, trex.transform.position.z +300f);
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
    }

      public override void OnStateExit()
      {
           if(apatosaurus != null)
           {
                apatosaurus.lookingForWater = false;
           }else if(stegosaurus != null)
           {
                stegosaurus.lookingForWater = false;
           }else if(velociraptor != null)
           {
                velociraptor.lookingForWater = false;
           }else if(trex != null)
           {
                trex.lookingForWater = false;
           }
      }
    
}
