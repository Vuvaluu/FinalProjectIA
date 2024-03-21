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

   public LookingForMate(Apatosaurus apato) : base(apato)
   {
        this.apatosaurus = apato;
   }

   public LookingForMate(Stegosaurus stegu) : base(stegu)
   {
        this.stegosaurus = stegu;
   }
   
   public LookingForMate(Velociraptor veloci) : base(veloci)
   {
     this.velociraptor = veloci;
   }

   public LookingForMate(Trex rex) : base(rex)
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
          apatosaurus.lookingForMate = true;
        }else if(stegosaurus != null)
        {
          stegosaurus.lookingForMate =  true;
        }else if(velociraptor != null) 
        {
          velociraptor.lookingForFood = true;
        }else if(trex != null) 
        {
          trex.lookingForFood = true;
        }
   }

   public override void Update()
    {
          if(apatosaurus != null)
          {
               if(apatosaurus.mate != null)
               {
                    SteeringBehaviors.Seek(apatosaurus, apatosaurus.mate.transform.position);
                    float dist = Vector3.Distance(apatosaurus.transform.position, apatosaurus.mate.transform.position);
                    if(dist < 3)
                    {
                         apatosaurus.SetState(new Breeding(apatosaurus));
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
               if(stegosaurus.mate != null)
               {
                    SteeringBehaviors.Seek(stegosaurus, stegosaurus.mate.transform.position);
                    float dist = Vector3.Distance(stegosaurus.transform.position, stegosaurus.mate.transform.position);
                    if(dist < 3)
                    {
                         stegosaurus.SetState(new Breeding(stegosaurus));
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
               if(velociraptor.mate != null)
               {
                    SteeringBehaviors.Seek(velociraptor, velociraptor.mate.transform.position);
                    float dist = Vector3.Distance(velociraptor.transform.position, velociraptor.mate.transform.position);
                    if(dist < 3)
                    {
                         velociraptor.SetState(new Breeding(velociraptor));
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
               if(trex.mate != null)
               {
                    SteeringBehaviors.Seek(trex, trex.mate.transform.position);
                    float dist = Vector3.Distance(trex.transform.position, trex.mate.transform.position);
                    if(dist < 3)
                    {
                         trex.SetState(new Breeding(trex));
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
               apatosaurus.lookingForMate = false;
          }else if(stegosaurus != null)
          {
               stegosaurus.lookingForMate = false;
          }else if(velociraptor != null)
          {
               velociraptor.lookingForMate = false;
          }
          else if(trex != null)
          {
               trex.lookingForMate = false;
          }
     }
    
}
