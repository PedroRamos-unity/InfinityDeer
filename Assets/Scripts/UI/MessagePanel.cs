using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessagePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;

    private void OnEnable()
    {
        Actions.DisplayPickUpMessage += SetText;
    }

    private void OnDestroy()
    {
        Actions.DisplayPickUpMessage -= SetText;
    }

    private void SetText(string message)
    {
        messageText.text = message;
    }

}
