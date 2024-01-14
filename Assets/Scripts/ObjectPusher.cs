using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPusher : MonoBehaviour
{
    public float pushForce = 10f;  // Adjust the force as needed

    private LayerMask pushableLayers;

    void Awake()
    {
        pushableLayers = LayerMask.GetMask("Ball");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  
        {
            TryPushObject();
        }
    }

    void TryPushObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, pushableLayers))
        {
            Rigidbody targetRigidbody = hit.collider.GetComponent<Rigidbody>();

            if (targetRigidbody != null)
            {
              
                Vector3 pushDirection = ray.direction;

                targetRigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;

                targetRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);

                targetRigidbody.angularVelocity *= 0.9f;
                targetRigidbody.velocity *= 0.9f;
            }
        }
    }
}
