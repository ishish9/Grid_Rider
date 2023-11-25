using UnityEngine;

public class CameraControls_E : MonoBehaviour
{
    [SerializeField] private Transform ObjectToFollow;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Controller_3 controller3;
    private bool isFinal_Trigger;
    private bool ChangeCam = false;
    public float ChangeAngle;
    float r;
    float y = 90;

    void Update()
    {
        if (ChangeCam)
        {

        }
        Vector3 desiredp = ObjectToFollow.position + offset;
        Vector3 smoothedp = Vector3.Lerp(transform.position, desiredp, smoothSpeed * Time.deltaTime);
        transform.position = smoothedp;

        float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, ChangeAngle, ref r, .25f);
        transform.rotation = Quaternion.Euler(0, y, Angle);
    }

    public void ChangeOffset(float x, float y, float z)
    {
        offset = new Vector3(x, y, z);
    }

    public void RightControlCam()
    {
        ChangeAngle += -90;
    }

    public void LeftControlCam()
    {
        ChangeAngle += 90;
    }

    public void SmoothSpeedStart()
    {
        smoothSpeed = 3;
    }

    public void ChangeCameraVector()
    {
        offset = new Vector3(5, 0, 0);
        y = -90;
        isFinal_Trigger = true;
    }

    public void ResetCameraVector()
    {
        offset = new Vector3(0, 2, -5);
        y += 90;
        isFinal_Trigger = false;
    }

    public bool isFinalCheck()
    {
        if (isFinal_Trigger == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RightCameraVector()
    {
        offset = new Vector3(2, 0, -5);
        //transform.Rotate(0, 0, -90f, Space.Self);
        ChangeAngle += -90f;
    }

    public void RightCameraVector2()
    {
        offset = new Vector3(0, 2, -5);
        //transform.Rotate(0, 0, -90f, Space.Self);
        ChangeAngle += -90f;
    }

    public void RightCameraVectorB()
    {
        offset = new Vector3(0, -2, -5);
        //transform.Rotate(0, 0, -90f, Space.Self);
        ChangeAngle += -90f;
    }

    public void LeftCameraVector()
    {
        offset = new Vector3(-2, 0, -5);
        //transform.Rotate(0, 0, 90f, Space.Self);
        ChangeAngle += 90f;
    }

    public void LeftCameraVector2()
    {
        offset = new Vector3(0, 2, -5);
        //transform.Rotate(0, 0, 90f, Space.Self);
        ChangeAngle += 90f;
    }

    public void LeftCameraVectorB()
    {
        offset = new Vector3(2, 0, -5);
        //transform.Rotate(0, 0, 90f, Space.Self);
        ChangeAngle += 90f;
    }

    public void LeftReset()
    {
        offset = new Vector3(0, 2, -5);
        ChangeAngle += -90f;
    }

    public void RighttReset()
    {
        offset = new Vector3(0, 2, -5);
        ChangeAngle += 90f;
    }

    public void RightCameraVectorGridE()
    {
        offset = new Vector3(.5f, 0, -5);
        //transform.Rotate(0, 0, -90f, Space.Self);
        ChangeAngle += -90f;
    }

    public void LeftCameraVectorGridE()
    {
        offset = new Vector3(-.5f, 0, -5);
        //transform.Rotate(0, 0, 90f, Space.Self);
        ChangeAngle += 90f;
    }

    public void CameraPosition0()
    {
        offset = new Vector3(.5f, 0, -5);
        //transform.Rotate(0, 0, -90f, Space.Self);
        ChangeAngle += -90f;
    }

    public void CameraPosition1()
    {
        offset = new Vector3(-.5f, 0, -5);
        //transform.Rotate(0, 0, 90f, Space.Self);
        ChangeAngle += 90f;
    }

    public void CameraPosition2()
    {
        offset = new Vector3(.5f, 0, -5);
        //transform.Rotate(0, 0, -90f, Space.Self);
        ChangeAngle += -90f;
    }

    public void CameraPosition3()
    {
        offset = new Vector3(-.5f, 0, -5);
        //transform.Rotate(0, 0, 90f, Space.Self);
        ChangeAngle += 90f;
    }
}