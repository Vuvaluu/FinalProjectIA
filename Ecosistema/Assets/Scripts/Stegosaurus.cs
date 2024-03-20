using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stegosaurus : Dinosaur
{
    
   protected int currentPoopingUrge, maxPoopingUrge;

    protected override void Start()
    {
        base.Start();
        maxPoopingUrge = 100;
        currentPoopingUrge = Random.Range(0, maxPoopingUrge/2);
    }

    void Update()
    {
        
    }
}
