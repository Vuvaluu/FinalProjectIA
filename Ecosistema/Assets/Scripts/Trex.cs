using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trex : Dinosaur
{
  
    public Stegosaurus stegosaurus;

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
        if(other.gameObject.CompareTag("Stegosaurus") && lookingForFood == true && stegosaurus == null)
        {
            stegosaurus = other.gameObject.GetComponent<Stegosaurus>();
        }
        if(other.gameObject.CompareTag("Water") && lookingForWater == true && water == null)
        {
            water = other.gameObject.GetComponent<Water>();
        }
        if(other.gameObject.CompareTag("Trex") && lookingForMate == true && mate == null)
        {
            if(other.gameObject.GetComponent <Trex>().GetPriority() == "Horny")
            {
                mate = other.gameObject.GetComponent<Trex>();
            }
        }
    } 

    public void Eat(Stegosaurus stegu)
    {
        stegu.TakeDamage(this);
        currentHunger = currentHunger - 20;
    }
}
