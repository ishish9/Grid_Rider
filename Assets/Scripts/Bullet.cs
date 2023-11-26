using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public GameObject bulletexplode;
    [SerializeField] private AudioClips ScriptableAudioClips;
 
    private void OnTriggerEnter(Collider hitbox)
    {
        if (hitbox.gameObject.CompareTag("CubeWall"))
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.BulletImpact);
            Instantiate(bulletexplode, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

        if (hitbox.gameObject.CompareTag("CubeCollect"))
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.BulletImpact);
            Instantiate(bulletexplode, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }   
}
