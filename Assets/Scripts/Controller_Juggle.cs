using UnityEngine;
using UnityEngine.InputSystem;

public class Controller_Juggle : MonoBehaviour
{
    [SerializeField] private float ForwardSpeed;
    [SerializeField] private float RestartSpeed;
    [SerializeField] private AudioClips ScriptableAudioClips;
    [SerializeField] private GameObject Prefab;
    private float Projectilespeed = 20f;
    [SerializeField] private float ProjectilespeedCustom;
    private bool MovementAllowed = true;
    public int MovementStep = 0;
    public int UpDownStep = 0;
    [SerializeField] private bool WeaponEnabled;
    [SerializeField] private bool CustomProjectileSpeed;
    ActionMap_1 actionsWrapper;

    private void Awake()
    {
        actionsWrapper = new ActionMap_1();
        actionsWrapper.Player.Fire.performed += OnFire;
        actionsWrapper.Player.Left.performed += OnMoveLeft;
        actionsWrapper.Player.Right.performed += OnMoveRight;
        actionsWrapper.Player.Up.performed += OnMoveUp;
        actionsWrapper.Player.Down.performed += OnMoveDown;
    }

    private void Start()
    {
        AudioManager.Instance.PlaySoundEffectsLooped1(ScriptableAudioClips.Hover);
        if (CustomProjectileSpeed)
        {
            ChangeProjectileSpeed();
        }
    }
    // Menu OFF
    public void OnEnable()
    {
        actionsWrapper.Player.Enable();
        MovementAllowed = true;
    }
    // Menu ON
    public void OnDisable()
    {
        actionsWrapper.Player.Disable();
        MovementAllowed = false;
    }
    // Check if Movement Allowed
    public bool MovementAllowedStatus()
    {
        return MovementAllowed;
    }
    public void TurnMovementOn()
    {
        MovementAllowed = true;
        actionsWrapper.Player.Enable();
    }
    public void TurnMovementOff()
    {
        MovementAllowed = false;
        actionsWrapper.Player.Disable();
    }
    //// Left Movement Controls

    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (MovementStep == -3)
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ReachedEnd);
        }

        else
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
            MovementStep--;
            transform.position += new Vector3(-1, 0, 0);            
        }
    }

    //// Right Movement Controls
    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (MovementStep == 3)
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ReachedEnd);
        }

        else
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
            MovementStep++;
            transform.position += new Vector3(1, 0, 0);            
        }             
    }
    // Up Movement
    public void OnMoveUp(InputAction.CallbackContext context)
    {
        if (UpDownStep == 3)
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ReachedEnd);
        }

        else
        {
            UpDownStep++;
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
            transform.position += new Vector3(0, 0, 1);
        }
    }

    // Down Movement
    public void OnMoveDown(InputAction.CallbackContext context)
    {
        if (UpDownStep == -3)
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ReachedEnd);
        }

        else
        {
            UpDownStep--;
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
            transform.position += new Vector3(0, 0, -1);
        }
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
    // FireWeapon for on screen button
    public void FireButton()
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
        //Vector2 moveVector = actionsWrapper.Player.Move.ReadValue<Vector2>();     

        // Move Player Forward
        if (MovementAllowed)
        {
            transform.position += new Vector3(0, 0, ForwardSpeed * Time.deltaTime);
        }
    }

    // On Screen Controls

    public void Up()
    {
        if (UpDownStep == 3)
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ReachedEnd);
        }

        else
        {
            UpDownStep++;
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
            transform.position += new Vector3(0, 0, 1);
        }
    }

    public void Down()
    {
        if (UpDownStep == -3)
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ReachedEnd);
        }

        else
        {
            UpDownStep--;
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
            transform.position += new Vector3(0, 0, -1);
        }
    }

    public void Right()
    {
        if (MovementStep == 3)
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ReachedEnd);
        }
        else
        {
            MovementStep++; 
            transform.position += new Vector3(1, 0, 0);
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
        }
    }

    public void Left()
    {
        if (MovementStep == -3)
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.ReachedEnd);
        }
        else
        {
            MovementStep--;    
            transform.position += new Vector3(-1, 0, 0);          
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Move);
        }
    }

    public void ChangeProjectileSpeed()
    {
        Projectilespeed = ProjectilespeedCustom;
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
