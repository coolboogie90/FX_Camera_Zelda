using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    public GameObject content;
    public UnityEvent onPickup;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject, 5f);
            Instantiate(content, transform.position, transform.rotation);
            onPickup?.Invoke();
        }
    }
}
