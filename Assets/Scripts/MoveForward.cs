using UnityEngine;

public class MoveForward : MonoBehaviour
{
    int speed = -6;
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
