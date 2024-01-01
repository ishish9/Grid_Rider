using System;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private int Health;
    [SerializeField] private AudioClips ScriptableAudioClips;
    [SerializeField] private GameObject BarrierDestroyedEffect;
    [SerializeField] private string BarrierColor;
    [SerializeField] private bool BarrierBusterMiniGame;
    public delegate void Score(int num);
    public static event Score OnScore;

    private void OnTriggerEnter(Collider hitbox)
    {
        Health--;
        AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.BarrierHit);
        if (Health <= 0)
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.BarrierDestroyed);
            Instantiate(BarrierDestroyedEffect, transform.position, Quaternion.identity);

            if (BarrierBusterMiniGame)
            {
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.BarrierDestroyedMiniGame);
                OnScore(1);
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        if (hitbox.gameObject.CompareTag("Player"))
        {
            if (BarrierBusterMiniGame)
            {
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.BarrierDestroyed);
                Instantiate(BarrierDestroyedEffect, transform.position, Quaternion.identity);
                var health = transform.GetComponent<Barrier_Spawned>();
                health.CallDamage(20);
                Destroy(gameObject);
            }
            else
            {
                Death_Trigger.instance.Die();
            }
        }
    }

    private void OnEnable()
    {
        switch (BarrierColor)
        {
            case "Green":
                Health = 2;
                break;

            case "Yellow":
                Health = 4;
                break;

            case "Orange":
                Health = 6;
                break;

            case "Red":
                Health = 8;
                break;

            case "Purple":
                Health = 9;
                break;
        }
    }
}
