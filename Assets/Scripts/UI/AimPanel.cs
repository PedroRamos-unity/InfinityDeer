using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimPanel : MonoBehaviour
{
    [SerializeField] private Image aimImage;

    private void OnEnable()
    {
        Actions.Aim += SetAim;
    }

    private void OnDestroy()
    {
        Actions.Aim -= SetAim;
    }

    private void SetAim(bool isAim)
    {
        aimImage.gameObject.SetActive(isAim);
    }
    
}
