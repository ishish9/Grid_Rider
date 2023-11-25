using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private GameObject Shield;
    [SerializeField] private GameObject Torpedo;
    [SerializeField] private GameObject HSM;
    [SerializeField] private GameObject Bomb;
    private void OnTriggerEnter(Collider hitbox)
    {
        if (hitbox.gameObject.CompareTag("Shield"))
        {
            Instantiate(Shield, transform.position, Quaternion.identity);
        }
        else if (hitbox.gameObject.CompareTag("Torpedo"))
        {
            Instantiate(Torpedo, transform.position, Quaternion.identity);
        }
    }
}
