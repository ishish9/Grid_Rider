using UnityEngine;

public class LaserGrid_Mover : MonoBehaviour
{
    public static float ForwardSpeed = 4;

    private void Update()
    {
        transform.position += new Vector3(0, 0, -ForwardSpeed * Time.deltaTime);
    }

    private void Start()
    {
        Destroy(gameObject, 4);
    }
}
