using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private int Health;
    [SerializeField] private float ShieldSpeed;
    [SerializeField] private float RotateSpeed;
    [SerializeField] private LevelSpeed levelSpeed;
    [SerializeField] private AudioClip ShieldImpactClip;
    [SerializeField] private AudioSource ShieldImpactSound;
    [SerializeField] private AudioSource ShieldDestroyedSound;
    [SerializeField] private GameObject ShieldExplode;
    private int HitCount;

    void Update()
    {
        transform.Rotate(0.0f, RotateSpeed * Time.deltaTime, 0.0f, Space.Self);
        transform.position += new Vector3(levelSpeed.ReturnShieldSpeed() * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter(Collider hitbox)
    {
        Health -= 1;
        ShieldImpactSound.PlayOneShot(ShieldImpactClip, 1f);
        ShieldImpactSound.Play();
        if (hitbox.gameObject.CompareTag("Bullet") && Health <= 0)
        {
            HitCount = 5;
            ShieldDestroyedSound.Play();
            Instantiate(ShieldExplode, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        } 
        if (hitbox.gameObject.CompareTag("Player"))
        {
            ShieldDestroyedSound.Play();
            Death_Trigger.instance.TriggerDeath();
            Instantiate(ShieldExplode, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
