using UnityEngine;

public class HealthBarrier : MonoBehaviour
{
    [SerializeField] private AudioClip GetHealth;
    [SerializeField] private AudioClip impactBarrierClip;
    [SerializeField] private GameObject ImpactBarrierEffect;

    private int HeartHealth = 10;
    public delegate void Health(float health);
    public static event Health GiveHealth;
    private float StepTimer = 3;
    private int stepsTaken;

    private void Update()
    {
        if (StepTimer > 0)
        {
            StepTimer -= Time.deltaTime;
        }
        else
        {
            Move();
        }

        if (stepsTaken == 13)
        {
            AudioManager.Instance.PlaySoundEffects(impactBarrierClip);
            Instantiate(ImpactBarrierEffect, transform.position, Quaternion.identity);
            DestroyObject(gameObject);
        }
    }
    private void OnTriggerEnter(Collider hitbox)
    {
        HeartHealth -= 2;
        if (HeartHealth <= 0)
        {
            AudioManager.Instance.PlaySoundEffects(GetHealth);
            GiveHealth(20);
            Destroy(gameObject);
        }

        if (hitbox.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySoundEffects(GetHealth);
            GiveHealth(20);
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position += new Vector3(0, 0, -1);
        StepTimer = 3f;
        stepsTaken += 1;
    }
}
