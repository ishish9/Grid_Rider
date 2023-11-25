using UnityEngine;

public class LaserGrid_Mover : MonoBehaviour
{
    private int ForwardSpeed = 5;
    private void Update()
    {
        transform.position += new Vector3(0, 0, -ForwardSpeed * Time.deltaTime);
    }
}
