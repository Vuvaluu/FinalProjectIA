using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SteeringBehaviors
{
  
  public static void Seek(Dinosaur agent, Vector3 target)
  {
    Vector3 desiredVel = target - agent.transform.position;
    desiredVel.Normalize();
    desiredVel *= agent.GetMaxSpeed();
    desiredVel = Arrival(agent, target, desiredVel);
    Rigidbody rb = agent.GetComponent<Rigidbody>();
    Vector3 steeringForce = desiredVel - rb.velocity;
    steeringForce = Vector3.ClampMagnitude(steeringForce, agent.GetMaxForce());
    steeringForce /= rb.mass;
    rb.velocity = Vector3.ClampMagnitude((rb.velocity + steeringForce) , agent.GetMaxForce());   
  }

  public static void Flee(Dinosaur agent, Transform target)
  {
    Vector3 desiredVel = target.position - agent.transform.position;
    desiredVel.Normalize();
    desiredVel *= agent.GetMaxSpeed();
    desiredVel = Arrival(agent, target.position, desiredVel);
    Rigidbody rb = agent.GetComponent<Rigidbody>();
    Vector3 steeringForce = desiredVel - rb.velocity;
    steeringForce = Vector3.ClampMagnitude(steeringForce, agent.GetMaxForce());
    steeringForce = steeringForce * -1;
    steeringForce /= rb.mass;
    rb.velocity = Vector3.ClampMagnitude((rb.velocity + steeringForce) , agent.GetMaxForce());
  }

  public static Vector3 Arrival(Dinosaur agent, Vector3 target, Vector3 desiredVel)
  {
   float distance = Vector3.Distance(agent.transform.position, target);
         if(distance <= agent.GetSlowingRadius())
      {
          desiredVel.Normalize();
          desiredVel *= agent.GetMaxSpeed() * (distance / agent.GetSlowingRadius());
      }
      return desiredVel;
  }

  public static void Wander(Dinosaur agent)
  {
    int randX = 0;
    int randZ = 0;
    float timeToWait = 0f;
    float elapsedTime = 0f;
    bool canMove = true;
    float time = Time.time;
    // Wander around
    if (canMove == true) {
    randX = Random.Range(-10, 10);
    randZ = Random.Range(-10, 10);
    Seek(agent, new Vector3(randX, 0, randZ));
     canMove = false;
} else {
    timeToWait = Random.Range(5, 20);
    if(time > elapsedTime) {
    elapsedTime = time + timeToWait;
    canMove = true;
        }
    }
  }
}
