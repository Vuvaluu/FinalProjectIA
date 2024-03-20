using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected float maxForce;
    [SerializeField] protected float slowingRadius;
    
    protected int maxHP;
    protected int damage;
    protected int currentHP;
    [SerializeField] protected Rigidbody rb;
    protected State currentState;

    //Necesidades
    protected int currentHunger, maxHunger;
    protected int currentThirst, maxThirst;
    protected int currentRepUrge, maxRepUrge;

    public Dinosaur mate;
    public bool lookingForMate;

    protected virtual void Start()
    {
        currentHP = maxHP;
        maxHunger = 100;
        maxThirst = 100;
        maxRepUrge = 100;
        currentHunger = Random.Range(0, maxHunger/2);
        currentThirst = Random.Range(0, maxThirst/2);
        currentRepUrge = 0;
    }

    protected virtual void Update()
    {
        currentState.Update();
    }

    public void TakeDamage(Dinosaur enemy)
    {
        currentHP = currentHP - enemy.GetDamage();
        if(currentHP <= 0)
        {
            Die();
        }
    }

    protected void CheckHealth(){
        if(currentHunger <= 0)
        {
            Die();
        }
        if(currentThirst <= 0)
        {
            Die();
        }
    }
    
    public void SetState(State state)
    {
        if (currentState != null) {
            currentState.OnStateExit();
        }
        currentState = state;
        Debug.Log(gameObject.name + " current state: " + state.GetType().Name);
        if (currentState != null) {
            currentState.OnStateEnter();
        }
    }

    public void Drink()
    {
        currentThirst--;
    } 

    protected void Die()
    {
        Destroy(gameObject);
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
