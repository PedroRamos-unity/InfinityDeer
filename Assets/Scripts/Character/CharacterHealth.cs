using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public int Health;
    private Character character;
    private void Awake()
    {
        character = FindObjectOfType<Character>();
        Health = 100;
    }

    public void TakeDamage(int damage)
    {
        SoundManager.instance.PlaySound("Player_TakeDamage",transform.position);
        Health -= damage;
        Actions.HandleHealthChanged?.Invoke(Health);
        character.gameObject.AddComponent<Slow>();
        if(Health <=0)
        {
            Actions.Death?.Invoke();
        }
    }

    public void Heal(int healAmount)
    {
        if(Health + healAmount > 100)
        {
            Health = 100;
        }
        else
        {
            Health += healAmount;
        }
       
        Actions.HandleHealthChanged?.Invoke(Health);
    }


}
