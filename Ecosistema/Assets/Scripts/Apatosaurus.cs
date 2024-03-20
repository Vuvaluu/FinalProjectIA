using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apatosaurus : Dinosaur
{
    public Tree tree;
    
    protected override void Start()
    {
        base.Start();
        lookingForFood = false;
        lookingForWater = false;
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

    protected void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ApatosaurusTree") && lookingForFood == true && tree == null)
        {
            tree = other.gameObject.GetComponent<Tree>();
        }
        if(other.gameObject.CompareTag("Water") && lookingForWater == true && water == null)
        {
            water = other.gameObject.GetComponent<Water>();
        }
        if(other.gameObject.CompareTag("Apatosaurus") && lookingForMate == true && mate == null)
        {
            if(other.gameObject.GetComponent <Apatosaurus>().GetPriority() == "Horny")
            {
                mate = other.gameObject.GetComponent<Apatosaurus>();
            }
        }
    } 

    public void Eat(Tree t)
    {
        t.TakeDamage();
        currentHunger = currentHunger - 50;
    }
}
