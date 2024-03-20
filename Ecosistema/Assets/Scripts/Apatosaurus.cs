using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apatosaurus : Dinosaur
{
    public Tree tree;
    public Water water;
    public bool lookingForFood;
    public bool lookingForWater;
    //public 

    protected override void Start()
    {
        base.Start();
        lookingForFood = false;
        lookingForWater = false;
        SetState(new LookingForWater(this));
    }

   
    protected override void Update()
    {
        base.Update();
    }

    protected void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ApatosaurusTree") && lookingForFood == true && tree == null)
        {
            Debug.Log("iuu");
            tree = other.gameObject.GetComponent<Tree>();
        }
        if(other.gameObject.CompareTag("Water") && lookingForWater == true && water == null)
        {
            water = other.gameObject.GetComponent<Water>();
        }
        if(other.gameObject.CompareTag("Apatosaurus") && lookingForMate == true && mate == null)
        {
             mate = other.gameObject.GetComponent<Apatosaurus>();
        }
    } 

    public void Eat(Tree t)
    {
        t.TakeDamage();
        currentHunger--;
    }
}
