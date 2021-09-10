using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthPanel : MonoBehaviour
{
    [SerializeField] private Image healthbar;
    [SerializeField] private TextMeshProUGUI healthText;


    private void Awake()
    {
        HealthChanged(100);
    }

    private void OnEnable()
    {
        Actions.HandleHealthChanged += HealthChanged;
    }

    private void OnDestroy()
    {
        Actions.HandleHealthChanged -= HealthChanged;
    }

    private void HealthChanged(float health)
    {
        
        healthText.text =health.ToString() + "/100";
        healthbar.fillAmount = (health / 100f);
    }
}
