using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    int currenHP;
    int maxHP;

    void Start()
    {
        maxHP = 1000;
        currenHP = maxHP;
    }

    public void TakeDamage()
    {
        currenHP = currenHP - 20;
        if(currenHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
