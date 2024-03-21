using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingForFood : State
{
     float randX = 0;
     float randZ = 0;
     float timeToWait = 0f;
     float elapsedTime = 0f;
     bool canMove = true;

   public LookingForFood(Apatosaurus apato) : base(apato)
   {
        this.apatosaurus = apato;
   }
   
   public LookingForFood(Stegosaurus stegu) : base(stegu)
   {
     this.stegosaurus = stegu;
   }

   public LookingForFood(Velociraptor veloci) : base(veloci)
   {
     this.velociraptor = veloci;
   }

    public LookingForFood(Trex rex) : base(rex)
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
          apatosaurus.lookingForFood = true;
        } else if(stegosaurus != null)
        {
           stegosaurus.lookingForFood = true;
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
               if(apatosaurus.tree != null)
               {
                    SteeringBehaviors.Seek(apatosaurus, apatosaurus.tree.transform.position);
                    float dist = Vector3.Distance(apatosaurus.transform.position, apatosaurus.tree.transform.position);
                    if(dist < 3)
                    {
                         apatosaurus.SetState(new Attacking(apatosaurus));
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
               if(stegosaurus.tree != null)
               {
                    SteeringBehaviors.Seek(stegosaurus, stegosaurus.tree.transform.position);
                    float dist = Vector3.Distance(stegosaurus.transform.position, stegosaurus.tree.transform.position);
                    if(dist < 3)
                    {
                         stegosaurus.SetState(new Attacking(stegosaurus));
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
               if(velociraptor.apatosaurus != null)
               {
                    SteeringBehaviors.Seek(velociraptor, velociraptor.apatosaurus.transform.position);
                    float dist = Vector3.Distance(velociraptor.transform.position, velociraptor.apatosaurus.transform.position);
                    if(dist < 3)
                    {
                         velociraptor.SetState(new Attacking(velociraptor));
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
               if(trex.stegosaurus != null)
               {
                    SteeringBehaviors.Seek(trex, trex.stegosaurus.transform.position);
                    float dist = Vector3.Distance(trex.transform.position, trex.stegosaurus.transform.position);
                    if(dist < 3)
                    {
                         trex.SetState(new Attacking(trex));
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
               apatosaurus.lookingForFood = false;
          }

          else if(stegosaurus != null)
          {
               stegosaurus.lookingForFood = false;
          }

          else if(velociraptor != null)
          {
               velociraptor.lookingForFood = false;
          }

          else if(trex != null)
          {
               trex.lookingForFood = false;
          }
     } 
}
