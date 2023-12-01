using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject PickUpEffect;

    [SerializeField] private GameObject Shield;
    [SerializeField] private GameObject Torpedo;
    [SerializeField] private GameObject HSM;
    [SerializeField] private GameObject Bomb;
    private void OnTriggerEnter(Collider hitbox)
    {
        if (hitbox.CompareTag("Player"))
        {
            PickUp(hitbox);
        }       
    }

    private void PickUp(Collider player)
    {
        Instantiate(PickUpEffect, transform.position, Quaternion.identity);
        Debug.Log("Picked Up");
        Destroy(gameObject);
    }
}
