using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : Item
{
    private CharacterHealth character;

    private void Awake()
    {
        character = FindObjectOfType<CharacterHealth>();
    }

    public override void Interact()
    {
        base.Interact();
        character.Heal(15);
        RespawnItem(gameObject);
    }



}
