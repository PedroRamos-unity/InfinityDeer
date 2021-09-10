using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;

    private void OnEnable()
    {
        Actions.HandleAmmoChanged += HandleAmmoChange;
    }

    private void OnDestroy()
    {
        Actions.HandleAmmoChanged -= HandleAmmoChange;
    }

    private void HandleAmmoChange(Guns weapon)
    {
        if(weapon == null)
        {
            ammoText.text = "";
        }
        else
        {
            ammoText.text = weapon.BulletsLeft + " / " + weapon.BulletsInMagazine;
        }
        
    }


}
