using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public GameObject bulletexplode;
    [SerializeField] private AudioClips ScriptableAudioClips;
 
    private void OnTriggerEnter(Collider hitbox)
    {
        Destroy(gameObject, 5f);
        if (hitbox.gameObject.CompareTag("CubeWall"))
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.BulletImpact);
            Instantiate(bulletexplode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (hitbox.gameObject.CompareTag("CubeCollect"))
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.BulletImpact);
            Instantiate(bulletexplode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
