using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishLine : MonoBehaviour
{
    [SerializeField] UnityEvent Finish;

    private void OnTriggerEnter(Collider other)
    {
        Finish!.Invoke();
    }
}

   

