using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private int DestroyObjectInSeconds;

    private void Start()
    {       
        switch (DestroyObjectInSeconds)
        {
            case 1:
                Destroy(gameObject, 1);
                break;
            case 2:
                Destroy(gameObject, 2);
                break;
            case 3:
                Destroy(gameObject, 3);
                break;
            case 4:
                Destroy(gameObject, 4);
                break;
            case 5:
                Destroy(gameObject, 5);
                break;
            case 6:
                Destroy(gameObject, 6);
                break;
            case 7:
                Destroy(gameObject, 7);
                break;
            case 8:
                Destroy(gameObject, 8);
                break;
            case 9:
                Destroy(gameObject, 9);
                break;
            case 10:
                Destroy(gameObject, 10);
                break;
        }
    }
}
