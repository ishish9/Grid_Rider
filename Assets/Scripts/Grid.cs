using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private float GridSpeed;

    void Awake()
    {
        Vector3 StartPosition = transform.position;
    }

    void Update()
    {
        transform.position += new Vector3(GridSpeed * Time.deltaTime,0,0);
    }
}
