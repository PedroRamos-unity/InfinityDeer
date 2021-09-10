using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEffect : MonoBehaviour
{
    protected float duration;
    protected float repeatTime;

    protected Character character;

    protected virtual void Awake()
    {
        character = FindObjectOfType<Character>();
    }

    protected virtual void Start()
    {
        InvokeRepeating("ApplyEffect", 0, repeatTime);
        Invoke("EndEffect", duration);
    }
    protected virtual void ApplyEffect()
    {

    }

    protected virtual void EndEffect()
    {
        CancelInvoke();
        Destroy(this);
    }
}
