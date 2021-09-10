using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : Item
{
    private Character character;
    private void Awake()
    {
        character = FindObjectOfType<Character>();    
    }

    public override void Interact()
    {
        character.EquipedWeapon.InteractWithAmmoBox();
        RespawnItem(gameObject);
    }
}
