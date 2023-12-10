using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private AudioClip LaserHitClip;
    [SerializeField] private Transform parentTransform;
    public delegate void Damage(float d);
    public static event Damage OnLaserDamage;

    private void OnTriggerEnter(Collider collision)
    {
        OnLaserDamage(34);

        if (collision.CompareTag("Player"))
        {
            for (int j = 0; j < parentTransform.childCount; j++)
            {
                parentTransform.GetChild(j).gameObject.GetComponent<Collider>().enabled = false;               
            }
            AudioManager.Instance.PlaySoundEffects(LaserHitClip);
        }
    }
}
