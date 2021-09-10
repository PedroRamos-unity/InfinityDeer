using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : TimedEffect
{
    protected override void Awake()
    {
        base.Awake();
        duration = 1f;
    }

    protected override void Start()
    {
        base.Start();
    }


    protected override void ApplyEffect()
    {
        character.SetSpeed(1f);
    }
    protected override void EndEffect()
    {
        character.SetSpeed(character.defaultSpeed);
        base.EndEffect();
    }
}
