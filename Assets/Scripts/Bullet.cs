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
            GameObject bulletImpactPool = ObjectPool.instance.GetPooledObjectBulletImpactEffect();
            if (bulletImpactPool != null)
            {
                bulletImpactPool.transform.position = transform.position;
                bulletImpactPool.SetActive(true);
            }
            gameObject.SetActive(false);
        }

        if (hitbox.gameObject.CompareTag("CubeCollect"))
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.BulletImpact);
            GameObject bulletImpactPool = ObjectPool.instance.GetPooledObjectBulletImpactEffect();
            if (bulletImpactPool != null)
            {
                bulletImpactPool.transform.position = transform.position;
                bulletImpactPool.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }   
}
