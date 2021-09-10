using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private Guns gunToPickUp;

    private Camera cam;

    
    private void Awake()
    {
        
    }

    protected virtual void Update()
    {
        if(cam == null)
        {
            cam = FindObjectOfType<Camera>();
        }
        else
        {
            Ray ray = cam.ViewportPointToRay(Vector3.one / 2f);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 5f))
            {
                var hitGun = hitInfo.collider.GetComponent<Guns>();
                if (hitGun == null)
                {
                    gunToPickUp = null;
                }

                else if (hitGun != null)
                {
                    gunToPickUp = hitGun;
                    Actions.DisplayPickUpMessage?.Invoke("Press F to pick up " + gunToPickUp.name);
                    if(Input.GetKeyDown(KeyCode.F))
                    {
                        gunToPickUp.OnPickUp(gunToPickUp);
                    }
                }

                var item = hitInfo.collider.GetComponent<Item>();
                if(item != null)
                {
                    Actions.DisplayPickUpMessage?.Invoke("Press F to interact");
                    if(Input.GetKeyDown(KeyCode.F))
                    {
                        item.Interact();
                    }
                }

            }

            else
            {
                gunToPickUp = null;
                Actions.DisplayPickUpMessage?.Invoke(null);
            }
        }
        
    }   



}