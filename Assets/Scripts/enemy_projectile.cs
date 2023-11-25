using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_projectile : MonoBehaviour
{
    private float Speed = 20f;
    private Transform player;
    private Rigidbody rb;

    void OnEnable()
    {
        Invoke("Deactivate", 5f);
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector3(direction.x, direction.y, direction.z).normalized * Speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Death_Trigger.instance.TriggerDeath();
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }     
    }


    private void Deactivate()
    {
        //yield return new WaitForSeconds(6);

        gameObject.SetActive(false);
    }

}
