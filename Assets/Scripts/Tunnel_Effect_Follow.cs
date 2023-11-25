using UnityEngine;

public class Tunnel_Effect_Follow : MonoBehaviour
{
    public Transform player;
    public Transform cam;
    [SerializeField] private float MoveWarp;
 
    private void Update()
    {
        cam.transform.position = new Vector3(.5f, .5f, player.transform.position.z + MoveWarp);
    }
}
