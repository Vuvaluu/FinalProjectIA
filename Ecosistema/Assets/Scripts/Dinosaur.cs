using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    protected float maxSpeed;
    protected float maxForce;
    protected float slowingRadius;

    protected int maxHP;
    protected int damage;
    protected int currentHP;

    protected Rigidbody rb;

    protected virtual void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        
    }

    public void TakeDamage(Dinosaur enemy)
    {
        currentHP = currentHP - enemy.GetDamage();
        if(currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetCurrentHP() 
    {
        return currentHP;
    }

    public float GetMaxSpeed()
    {
        return maxSpeed;
    }

    public float GetMaxForce()
    {
        return maxForce;
    }

    public float GetSlowingRadius()
    {
        return slowingRadius;
    }

}
