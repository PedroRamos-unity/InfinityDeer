using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float sensibility;

    private float mouseX, mouseY, xRotation;

    private Character character;
    private void Awake()
    {
        character = FindObjectOfType<Character>();
    }
    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensibility * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensibility * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        character.transform.Rotate(Vector3.up * mouseX);
        
    }
}
