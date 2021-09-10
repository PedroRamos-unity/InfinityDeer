using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{

    [SerializeField] private GameObject panel;
    private void OnEnable()
    {
        Actions.DisplayPauseMenu += ActivatePausePanel;
        
    }

    private void OnDisable()
    {
        Actions.DisplayPauseMenu -= ActivatePausePanel;
    }

    private void ActivatePausePanel()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Return()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }


}
