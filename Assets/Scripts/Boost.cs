using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Boost : MonoBehaviour
{
    [SerializeField] private AudioClip boostClip;
    private void OnTriggerEnter(Collider hitbox)
    {
        if (hitbox.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySoundEffects(boostClip);
        }
       // AudioManager.Instance.PlaySoundEffects(boostClip);
    }
}
