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
}
