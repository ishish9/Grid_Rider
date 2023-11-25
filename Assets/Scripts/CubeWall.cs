using UnityEngine;

public class CubeWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider hitbox)
    {
        if (hitbox.gameObject.CompareTag("Player"))
        {
            Death_Trigger.instance.Die();
        }
    }
}
