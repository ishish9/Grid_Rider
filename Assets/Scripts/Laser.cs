using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Laser : MonoBehaviour
{
    [SerializeField] private AudioClip LaserHitClip;
    [SerializeField] private Transform parentTransform;

    private void OnTriggerEnter(Collider collision)
    {     
        if (collision.CompareTag("Player"))
        {
            for (int j = 0; j < parentTransform.childCount; j++)
            {
                parentTransform.GetChild(j).gameObject.GetComponent<Collider>().enabled = false;               
            }
            AudioManager.Instance.PlaySoundEffects(LaserHitClip);
            //Debug.Log("YOU DIED!");
        }
    }
}
