using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dinosaur : MonoBehaviour
{
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected float maxForce;
    [SerializeField] protected float slowingRadius;
    [SerializeField] protected Rigidbody rb;
    
    //UI
    [SerializeField] protected Slider hungerBar;
    [SerializeField] protected Slider breedingBar;
    [SerializeField] protected Slider thirstBar;
    [SerializeField] protected Slider hpBar;

    protected int maxHP;
    protected int damage;
    protected int currentHP;
    protected State currentState;
    
    //Necesidades
    protected int currentHunger, maxHunger;
    protected int currentThirst, maxThirst;
    protected int currentRepUrge, maxRepUrge;

    public Dinosaur mate;
    public Water water;
    public bool lookingForMate;
    public bool lookingForWater;
    public bool lookingForFood;
    protected float timePassed = 0f;
    protected  string priority;
    protected string oldPriority;

    protected virtual void Start()
    {
        damage = 30;
        maxHP = 100;
        maxHunger = 100;
        maxThirst = 100;
        maxRepUrge = 100;
        currentHunger = Random.Range(0, maxHunger/2);
        currentThirst = Random.Range(0, maxThirst/2);
        currentRepUrge = 0;
        currentHP = maxHP;
        hungerBar.maxValue = maxHunger;
        thirstBar.maxValue = maxThirst;
        breedingBar.maxValue = maxRepUrge;
        hpBar.maxValue = maxHP;
        lookingForFood = false;
        lookingForWater = false;
        lookingForMate = false;
    }

    protected virtual void Update()
    {
        currentState.Update();
        hungerBar.value = currentHunger;
        thirstBar.value = currentThirst;
        breedingBar.value = currentRepUrge;
        hpBar.value = currentHP;
        timePassed += Time.deltaTime;

        if(timePassed > 3.0f)
        {
            currentHunger = currentHunger + 2;
            currentThirst = currentThirst + 2;
            currentRepUrge ++;
            timePassed = 0f;
        }

        
        if(currentHunger >= currentThirst && currentHunger >= currentRepUrge)
        {
            priority = "Hungry";
        } else if(currentThirst >= currentHunger && currentThirst >= currentRepUrge)
        {
            priority = "Thirsty";
        } else if(currentRepUrge >= currentHunger && currentRepUrge >= currentThirst)
        {
            priority = "Horny";
        } else {
            priority = "IDLE";
        }
        if(currentHunger >= maxHunger || currentThirst >= maxThirst)
        {
            Die();
        }
    }

    protected void OnCollisionStay(Collision other)
    {
       
        if(other.gameObject.tag == "ApatosaurusTree" || other.gameObject.tag == "StegosaurusTree")
        {
            Physics.IgnoreCollision(other.gameObject.GetComponent <Collider>(), gameObject.GetComponent<Collider>(), true);
             Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        }
        if(other.gameObject.tag == gameObject.tag)
        {
            Physics.IgnoreCollision(other.gameObject.GetComponent <Collider>(), gameObject.GetComponent<Collider>(), true);
             Debug.Log("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
        }

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

    public void StopBeingThirsty()
    {

    }

    public void Drink()
    {
        currentThirst = currentThirst - 20;
    } 

    public void Breeding()
    {
        currentRepUrge = 0; 
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

    public string GetPriority()
    {
        return priority;
    }
}
