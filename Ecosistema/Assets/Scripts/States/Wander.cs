using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : State
{
    float randX = 0;
    float randZ = 0;
    float timeToWait = 0f;
    float elapsedTime = 0f;
    bool canMove = true;

     public Wander(Dinosaur dino) : base(dino)
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
   }
   public override void Update()
    {
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
