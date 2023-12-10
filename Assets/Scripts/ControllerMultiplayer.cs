using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class ControllerMultiplayer : MonoBehaviour
{
    [SerializeField] private float ForwardSpeed = 1f;
    [SerializeField] private float MovementSpeed = 450f;
    [SerializeField] private float AccelerationSpeed = 180f;
    [SerializeField] private float JumpSpeed;
    [SerializeField] private float JumpEndSpeed;
    [SerializeField] private float JumpStartTime;
    private float JumpTime;
    [SerializeField] private AudioClips ScriptableAudioClips;
    [SerializeField] private GameObject Prefab;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private ParticleSystem spark;
    private float Projectilespeed = 20f;
    public int MovementStep = 0;
    [SerializeField] private bool WeaponEnabled;
    [SerializeField] private bool JumpEnabled;
    private bool MovementAllowed = true;
    private bool PlayerIsGrounded = true;
    private bool HasJumped = false;
    ActionMap_1 actionsWrapper;
    private Vector2 move;
    private bool Button_Left;
    private bool Button_Right;


    private void Awake()
    {
        actionsWrapper = new ActionMap_1();
        actionsWrapper.PlayerMultiplayer.Fire.performed += OnFire;
        actionsWrapper.PlayerMultiplayer.Jump.started += OnJump;
        actionsWrapper.PlayerMultiplayer.Jump.canceled += OnJumpEnd;
        actionsWrapper.PlayerMultiplayer.Accelerate.performed += OnAccelerate;
    }

    private void Start()
    {
        AudioManager.Instance.PlaySoundEffectsLooped1(ScriptableAudioClips.Hover);
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        move = actionsWrapper.PlayerMultiplayer.Move.ReadValue<Vector2>();// * (PlayerSpeed * Time.deltaTime);
        if (move == Vector2.left || Button_Left == true)
        {
            rb.AddForce(Vector2.left * MovementSpeed * Time.deltaTime, ForceMode.Force);
        }
        else if (move == Vector2.right || Button_Right == true)
        {
            rb.AddForce(Vector2.right * MovementSpeed * Time.deltaTime);
        }

        // Move Forward
        if (MovementAllowed)
        {
            rb.AddForce(Vector3.forward * ForwardSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }
    // Menu OFF
    public void OnEnable()
    {
        actionsWrapper.PlayerMultiplayer.Enable();
    }
    // Menu ON
    public void OnDisable()
    {
        actionsWrapper.PlayerMultiplayer.Disable();
    }
    // Check if Movement Allowed
    public bool MovementAllowedStatus()
    {
        return MovementAllowed;
    }
    public void TurnMovementOn()
    {
        MovementAllowed = true;
        actionsWrapper.PlayerMultiplayer.Enable();
    }
    public void TurnMovementOff()
    {
        MovementAllowed = false;
        actionsWrapper.PlayerMultiplayer.Disable();
    }  

    // Accelerate
    public void OnAccelerate(InputAction.CallbackContext context)
    {
        if (MovementAllowed)
        {
            rb.AddForce(Vector3.forward * AccelerationSpeed * Time.deltaTime);
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

    // Jump
    public void OnJump(InputAction.CallbackContext context)
    {
        if (PlayerIsGrounded)
        {
            PlayerIsGrounded = false;
            if (context.started)
            {
                Debug.Log("Pressed");
                JumpTime = JumpStartTime;
                rb.AddForce(new Vector3(0, JumpSpeed, 0), ForceMode.Impulse);
            }
        }       
    }

    public void OnJumpEnd(InputAction.CallbackContext context)
    {
        if (!PlayerIsGrounded)
        {         
            if (context.canceled)
            {
                Debug.Log("Continue Press");               
                rb.AddForce(new Vector3(0, JumpEndSpeed, 0), ForceMode.Impulse);        
            }
        }
    }

    // On Screen Controls
    public void Right( bool boolean)
    {
        Button_Right = boolean;
    }

    public void Left(bool boolean)
    {
        Button_Left = boolean;
    }

    public void Jump()
    {
        if (PlayerIsGrounded)
        {
            PlayerIsGrounded = false;         
            Debug.Log("Pressed");
            JumpTime = JumpStartTime;
            rb.AddForce(new Vector3(0, JumpSpeed, 0), ForceMode.Impulse);           
        }
    }
    public void JumpRelease()
    {
        if (!PlayerIsGrounded)
        {          
             Debug.Log("Continue Press");
             rb.AddForce(new Vector3(0, JumpEndSpeed, 0), ForceMode.Impulse);           
        }
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

    private IEnumerator boost()
    {
        rb.AddForce(Vector3.forward * 2700f * Time.deltaTime);
        yield return new WaitForSeconds(3);
        rb.AddForce(Vector3.forward * 100f * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider hitbox)
    {
        if (hitbox.gameObject.CompareTag("Boost"))
        {
            Debug.Log("BOOOOST");
            boost();           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CubeWall"))
        {
            AudioManager.Instance.PlaySoundEffects(ScriptableAudioClips.Collision);
            Instantiate(spark, transform.position, Quaternion.identity);
        }
        // Ground Check for Jumping

        if (collision.gameObject.tag == "Ground")
        {
            PlayerIsGrounded = true;
            if (HasJumped == true)
            {
                HasJumped = false;
                //AudioManager.Instance.PlaySound(ReturnToGroundClip);
            }
        }
    }
}
