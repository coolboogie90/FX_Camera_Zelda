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
            print("Chest is opened.");
            Destroy(gameObject);
            Instantiate(content, transform.position, Quaternion.identity);
            onPickup?.Invoke();
        }
    }
}
