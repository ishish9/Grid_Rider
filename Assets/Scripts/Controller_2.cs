using UnityEngine;
using UnityEngine.InputSystem;

public class Controller_2 : MonoBehaviour
{
    [SerializeField] private float ForwardSpeed;
    [SerializeField] private float RestartSpeed;
    [SerializeField] private AudioClips ScriptableAudioClips;
    [SerializeField] private Score script1;
    [SerializeField] private CameraControls script2;
    [SerializeField] private GameObject Prefab;
    private float Projectilespeed = 20f;
    private bool MovementAllowed = true;
    public int MovementStep = 0;
    [SerializeField] private bool WeaponEnabled;
    ActionMap_1 actionsWrapper;

    private void Awake()
    {
        actionsWrapper = new ActionMap_1();
        actionsWrapper.Player.Fire.performed += OnFire;
        actionsWrapper.Player.Left.performed += OnMoveLeft;
        actionsWrapper.Player.Right.performed += OnMoveRight;
    }

    private void Start()
    {
        AudioManager.Instance.PlaySoundEffectsLooped1(ScriptableAudioClips.Hover);
    }

    public void OnEnable()
    {
        actionsWrapper.Player.Enable();
        MovementAllowed = true;
    }

    public void OnDisable()
    {
        actionsWrapper.Player.Disable();
        MovementAllowed = false;
    }
    public bool MovementAllowedStatus()
    {
        return MovementAllowed;
    }
    public void TurnMovementOn()
    {
        MovementAllowed = true;
        actionsWrapper.Player.Enable();
    }

    // Fire Weapon
    public void OnFire(InputAction.CallbackContext context)
    {
        if (WeaponEnabled)
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ShotFired);
            var bullet = Instantiate(Prefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * Projectilespeed;
        }
    }

    void Update()
    {
        // Move Forward
        if (MovementAllowed)
        {
            transform.position += new Vector3(0, 0, ForwardSpeed * Time.deltaTime);
        }
    }

    //// Left Movement Controls ////
    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        switch (MovementStep)
        {
            case 0:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -1:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -2:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -3:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, -1, 0);
                transform.Rotate(0f, 0f, -90f);
                script2.LeftCameraVector();
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Rotate);
                break;
            case -4:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -5:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -6:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -7:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -8:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -9:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -10:
                // MovementStep = MovementStep - 1;
                //transform.position = transform.position + new Vector3(1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ReachedEnd);
                break;
            case -11:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -12:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -13:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -14:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 1:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 2:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 3:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 4:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 1, 0);
                transform.Rotate(0f, 0f, -90f);
                script2.LeftCameraVector2();
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ReachedEnd);
                break;
            case 5:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, 1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 6:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, 1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 7:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, 1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 8:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, 1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 9:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, 1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 10:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, 1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 11:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(1, 1, 0);
                transform.Rotate(0f, 0f, -90f);
                script2.LeftCameraVectorB();
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 12:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, 1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
        }
    }

    //// Right Movement Controls ////
    public void OnMoveRight(InputAction.CallbackContext context)
    {
        switch (MovementStep)
        {
            case 0:
                MovementStep += 1;
                transform.position += new Vector3(1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 1:
                MovementStep += 1;
                transform.position += new Vector3(1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 2:
                MovementStep += 1;
                transform.position += new Vector3(1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 3:
                MovementStep += 1;
                transform.position += new Vector3(1, 0 + -1, 0);
                transform.Rotate(0f, 0f, 90f);
                script2.RightCameraVector();
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Rotate);
                break;
            case 4:
                MovementStep += 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 5:
                MovementStep += 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 6:
                MovementStep += 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 7:
                MovementStep += 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 8:
                MovementStep += 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 9:
                MovementStep += 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 10:
                // MovementStep += 1;
                //transform.position = transform.position + new Vector3(-1, 1, 0);
                //transform.Rotate(0f, 0f, 90f);
                //script2.RightCameraVectorB();
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ReachedEnd);
                break;
            case 11:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 12:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 13:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 14:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 15:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 16:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 17:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 18:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -1:
                MovementStep += 1;
                transform.position += new Vector3(1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -2:
                MovementStep += 1;
                transform.position += new Vector3(1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -3:
                MovementStep += 1;
                transform.position += new Vector3(1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -4:
                MovementStep += 1;
                transform.position += new Vector3(1, 1, 0);
                transform.Rotate(0f, 0f, 90f);
                script2.RightCameraVector2();
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Rotate);
                break;
            case -5:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -6:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -7:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -8:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -9:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -10:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -11:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -12:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;

        }
    }


    public void Right()
    {
        switch (MovementStep)
        {
            case 0:
                MovementStep += 1;
                transform.position += new Vector3(1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 1:
                MovementStep += 1;
                transform.position += new Vector3(1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 2:
                MovementStep += 1;
                transform.position += new Vector3(1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 3:
                MovementStep += 1;
                transform.position += new Vector3(1, 0 + -1, 0);
                transform.Rotate(0f, 0f, 90f);
                script2.RightCameraVector();
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Rotate);
                break;
            case 4:
                MovementStep += 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 5:
                MovementStep += 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 6:
                MovementStep += 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 7:
                MovementStep += 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 8:
                MovementStep += 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 9:
                MovementStep += 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 10:
                //MovementStep += 1;
                //transform.position = transform.position + new Vector3(-1, -1, 0);
                //transform.Rotate(0f, 0f, 90f);
                //script2.RightCameraVectorB();
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ReachedEnd);
                break;
            case 11:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 12:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 13:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 14:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 15:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 16:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 17:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 18:
                MovementStep += 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -1:
                MovementStep += 1;
                transform.position += new Vector3(1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -2:
                MovementStep += 1;
                transform.position += new Vector3(1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -3:
                MovementStep += 1;
                transform.position += new Vector3(1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -4:
                MovementStep += 1;
                transform.position += new Vector3(1, 1, 0);
                transform.Rotate(0f, 0f, 90f);
                script2.RightCameraVector2();
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Rotate);
                break;
            case -5:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -6:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -7:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -8:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -9:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -10:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -11:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -12:
                MovementStep += 1;
                transform.position += new Vector3(0, +1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;

        }
    }

    public void Left()
    {
        switch (MovementStep)
        {
            case 0:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -1:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -2:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -3:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, -1, 0);
                transform.Rotate(0f, 0f, -90f);
                script2.LeftCameraVector();
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Rotate);
                break;
            case -4:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -5:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -6:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -7:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -8:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -9:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, -1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -10:
                //MovementStep = MovementStep - 1;
                //transform.position = transform.position + new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ReachedEnd);
                break;
            case -11:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -12:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -13:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case -14:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 1:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 2:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 3:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 0, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 4:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(-1, 1, 0);
                transform.Rotate(0f, 0f, -90f);
                script2.LeftCameraVector2();
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Rotate);
                break;
            case 5:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, 1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 6:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, 1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 7:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, 1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 8:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, 1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 9:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, 1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 10:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, 1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 11:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(1, 1, 0);
                transform.Rotate(0f, 0f, -90f);
                script2.LeftCameraVectorB();
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
            case 12:
                MovementStep = MovementStep - 1;
                transform.position += new Vector3(0, 1, 0);
                AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
                break;
        }
    }

    public void Shoot()
    {
        AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ShotFired);
        var bullet = Instantiate(Prefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * Projectilespeed;
    }

    public void StartPlayer()
    {
        ForwardSpeed = RestartSpeed;
    }

    public void StopPlayer()
    {
        ForwardSpeed = 0;
    }

    public void IncreaseSpeed(float NewSpeed)
    {
        ForwardSpeed = NewSpeed;
    }   
}
