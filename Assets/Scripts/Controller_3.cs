using UnityEngine;

public class Controller_3 : MonoBehaviour
{
    [SerializeField] private float ForwardSpeed;
    [SerializeField] private AudioClip Rotateclip;
    [SerializeField] private AudioClip FireClip;
    [SerializeField] private Score script1;
    [SerializeField] private CameraControls script2;
    [SerializeField] private CameraControls_E script3;
    [SerializeField] private GameObject Prefab;
    [SerializeField] private Transform[] StepLocations;
    private float Projectilespeed = 20f;
    public int MovementStep = 0;
    private bool isGrounded;
    private bool onLeft;
    private bool onRight;
    [SerializeField] private bool GridECamera;

    void Update()
    {
        // Fire Weapon
        if (Input.GetKeyDown("space"))
        {
            AudioManager.Instance.PlaySoundEffects(FireClip);
            var bullet = Instantiate(Prefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * Projectilespeed;
        }
        Vector3 oldPosition = transform.position;

        //// Controls
        if (Input.GetKeyDown("right"))
        {
            MovementStep += 1;
            switch (MovementStep)
            {
                case 0:
                    script3.ChangeOffset(-5, 2, 0);
                    break;
                case 1:
                    script3.ChangeOffset(-5, 0, -2);
                    break;
                case 2:
                    script3.ChangeOffset(-5, -2, 0);
                    break;
                case 3:
                    script3.ChangeOffset(-5, 0, 2);
                    break;
                case 4:
                    script3.ChangeOffset(-5, 2, 0);
                    break;
            }
            if (MovementStep >= StepLocations.Length) 
            {
                MovementStep = 0;
            }
            var locater = new Vector3(oldPosition.x, StepLocations[MovementStep].position.y, StepLocations[MovementStep].position.z) ;
            transform.position = oldPosition = locater;
  
            if (GridECamera)
            {
                //script3.RightCameraVectorGridE();
                script3.RightControlCam();
            }
            else
            {
                script2.RightCameraVectorGridE();
            }
            AudioManager.Instance.PlaySoundEffects(Rotateclip);
            }

        if (Input.GetKeyDown("left"))
        {
            MovementStep -= 1;
            switch (MovementStep)
            {
                case 0:
                    script3.ChangeOffset(-5, 2, 0);
                    break;
                case 1:
                    script3.ChangeOffset(-5, 0, -2);
                    break;
                case 2:
                    script3.ChangeOffset(-5, -2, 0);
                    break;
                case 3:
                    script3.ChangeOffset(-5, 0, 2);
                    break;
                case -1:
                    script3.ChangeOffset(-5, 0, 2);
                    break;
            }
            if (MovementStep < 0)
            {
                MovementStep = StepLocations.Length -1;
            }
            var locater = new Vector3(oldPosition.x, StepLocations[MovementStep].position.y, StepLocations[MovementStep].position.z);
            transform.position = oldPosition = locater;

            if (GridECamera)
            {
                //script3.LeftCameraVectorGridE();
                script3.LeftControlCam();
            }
            else
            {
                script2.LeftCameraVectorGridE();
            }
            AudioManager.Instance.PlaySoundEffects(Rotateclip);
        }
        // Move Forward
        oldPosition.x += ForwardSpeed * Time.deltaTime;
    }

    public void Right()
    {
        Vector3 oldPosition = transform.position;

        MovementStep += 1;
        switch (MovementStep)
        {
            case 0:
                script3.ChangeOffset(-5, 2, 0);
                break;
            case 1:
                script3.ChangeOffset(-5, 0, -2);
                break;
            case 2:
                script3.ChangeOffset(-5, -2, 0);
                break;
            case 3:
                script3.ChangeOffset(-5, 0, 2);
                break;
            case 4:
                script3.ChangeOffset(-5, 2, 0);
                break;
        }
        if (MovementStep >= StepLocations.Length)
        {
            MovementStep = 0;
        }
        var locater = new Vector3(oldPosition.x, StepLocations[MovementStep].position.y, StepLocations[MovementStep].position.z);
        transform.position = oldPosition = locater;

        if (GridECamera)
        {
            //script3.RightCameraVectorGridE();
            script3.RightControlCam();
        }
        else
        {
            script2.RightCameraVectorGridE();
        }
        AudioManager.Instance.PlaySoundEffects(Rotateclip);
    
}

    public void Left()
    {
        Vector3 oldPosition = transform.position;

        MovementStep -= 1;
        switch (MovementStep)
        {
            case 0:
                script3.ChangeOffset(-5, 2, 0);
                break;
            case 1:
                script3.ChangeOffset(-5, 0, -2);
                break;
            case 2:
                script3.ChangeOffset(-5, -2, 0);
                break;
            case 3:
                script3.ChangeOffset(-5, 0, 2);
                break;
            case -1:
                script3.ChangeOffset(-5, 0, 2);
                break;
        }
        if (MovementStep < 0)
        {
            MovementStep = StepLocations.Length - 1;
        }
        var locater = new Vector3(oldPosition.x, StepLocations[MovementStep].position.y, StepLocations[MovementStep].position.z);
        transform.position = oldPosition = locater;

        if (GridECamera)
        {
            //script3.LeftCameraVectorGridE();
            script3.LeftControlCam();
        }
        else
        {
            script2.LeftCameraVectorGridE();
        }
        AudioManager.Instance.PlaySoundEffects(Rotateclip);    
}

    public void StartPlayer()
    {
        ForwardSpeed = 2;
    }

    public void StopPlayer()
    {
        ForwardSpeed = 0;
    }

    public void IncreaseSpeed(float NewSpeed)
    {
        ForwardSpeed = NewSpeed;
    }

    public void Shoot()
    {
        AudioManager.Instance.PlaySoundEffects(FireClip);
        var bullet = Instantiate(Prefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * Projectilespeed;
    }
}
