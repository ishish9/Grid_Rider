using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private AudioClips audioClips;
    [SerializeField] private Transform parentTransform;
    public delegate void Damage(float d);
    public static event Damage OnLaserDamage;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            OnLaserDamage(34);

            for (int j = 0; j < parentTransform.childCount; j++)
            {
                parentTransform.GetChild(j).gameObject.GetComponent<Collider>().enabled = false;               
            }
            AudioManager.Instance.PlaySoundEffects(audioClips.LaserHit);
        }
    }
}
