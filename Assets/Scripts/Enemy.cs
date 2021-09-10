using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float health = 100f;
    protected Character character;


    protected virtual void Awake()
    {
        character = FindObjectOfType<Character>();
    }
    protected virtual void Update()
    {
        Movement();
    }
    protected virtual void Movement()
    {

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <=0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Actions.HandleScoreChanged?.Invoke();
    }
}
