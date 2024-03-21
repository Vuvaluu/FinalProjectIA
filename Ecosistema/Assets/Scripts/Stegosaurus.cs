using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stegosaurus : Dinosaur
{
    public Tree tree;
    protected override void Start()
    {
        base.Start();
        SetState(new Wander(this));

    }

    protected override void Update()
    {
         base.Update();
        if(priority != oldPriority || oldPriority == null)
        {
            switch(priority)
        {
            case "Hungry":
                SetState(new LookingForFood(this));
                oldPriority = "Hungry";
            break;

            case "Thirsty": 
                SetState(new LookingForWater(this));
                oldPriority = "Thirsty";
            break;

            case "Horny":
                SetState(new LookingForMate(this));
                oldPriority = "Horny";
            break;

            case "IDLE":
                SetState(new Wander(this));
                oldPriority = "IDLE";
            break;
        }  
    }
    }

     protected void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("StegosaurusTree") && lookingForFood == true && tree == null)
        {
            tree = other.gameObject.GetComponent<Tree>();
        }
        if(other.gameObject.CompareTag("Water") && lookingForWater == true && water == null)
        {
            water = other.gameObject.GetComponent<Water>();
        }
        if(other.gameObject.CompareTag("Stegosaurus") && lookingForMate == true && mate == null)
        {
            if(other.gameObject.GetComponent <Stegosaurus>().GetPriority() == "Horny")
            {
                mate = other.gameObject.GetComponent<Stegosaurus>();
            }
        }
    } 

      public void Eat(Tree t)
    {
        t.TakeDamage();
        currentHunger = currentHunger - 20;
    }
}
