using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioClip PauseClip;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject GraphicsUI;
    [SerializeField] private GameObject PostPross;
    ActionMap_1 actionsWrapper2;
    public UnityEvent PausePlayerEvent;
    public UnityEvent UnPausePlayerEvent;
    public UnityEvent SelectMenuButton;
    [SerializeField] private bool MainMenu;


    private void Awake()
    {
        actionsWrapper2 = new ActionMap_1();
        actionsWrapper2.Menu.MenuButton.performed += OnMenuActivated;     
    }

    private void Start()
    {
        if (PausePlayerEvent == null)
        {
            PausePlayerEvent = new UnityEvent();
        }
        if (UnPausePlayerEvent == null)
        {
            UnPausePlayerEvent = new UnityEvent();
        }
        if (SelectMenuButton == null)
        {
            SelectMenuButton = new UnityEvent();
        }
    }

    private void OnEnable()
    {
        actionsWrapper2.Menu.Enable();
    }

    private void OnDisable()
    {
        actionsWrapper2.Menu.Disable();
    }

    public void OnMenuActivatedButton()
    {
        // Activates Menu //
        if (menuUI.activeSelf == false)
        {
            AudioManager.Instance.PlaySoundEffects(PauseClip);
            GraphicsUI.SetActive(false);
            menuUI.gameObject.SetActive(true);
            AudioManager.Instance.MasterVolumeControl(0.4f);
            PausePlayerEvent.Invoke();
        }


        // Deactivates Menu //        
        else
        {
            if (MainMenu)
            {
                SelectMenuButton.Invoke();
            }
            if (PlayerPrefs.GetInt("musicOnOff") == 0)
            {
                AudioManager.Instance.MusicOff();
            }
            else
            {
                AudioManager.Instance.MusicOn();
            }
            AudioManager.Instance.PlaySoundEffects(PauseClip);
            AudioManager.Instance.MasterVolumeControl(0.9f);
            menuUI.gameObject.SetActive(false);
            UnPausePlayerEvent.Invoke();
        }
    }

    public void OnMenuActivated(InputAction.CallbackContext context)
    {      
     // Activates Menu //
        if (menuUI.activeSelf == false)
        {
            AudioManager.Instance.PlaySoundEffects(PauseClip);
            GraphicsUI.SetActive(false);
            menuUI.gameObject.SetActive(true);
            AudioManager.Instance.MasterVolumeControl(0.4f);
            PausePlayerEvent.Invoke();
        }

       
        // Deactivates Menu //        
        else
        {
            if (MainMenu)
            {
                SelectMenuButton.Invoke();
            }
            if (PlayerPrefs.GetInt("musicOnOff") == 0)
                {
                    AudioManager.Instance.MusicOff();
                }
                else
                {
                    AudioManager.Instance.MusicOn();
                }
            AudioManager.Instance.PlaySoundEffects(PauseClip);
            AudioManager.Instance.MasterVolumeControl(0.9f);
            menuUI.gameObject.SetActive(false);
            UnPausePlayerEvent.Invoke();
        }
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void LowSetting()
    {
        PostPross.SetActive(false);
        QualitySettings.SetQualityLevel(0, true);
    }

    public void MediumSetting()
    {
        PostPross.SetActive(true);
        QualitySettings.SetQualityLevel(1, true);
    }

    public void HighSetting()
    {
        PostPross.SetActive(true);
        QualitySettings.SetQualityLevel(2, true);
    }

    public void VeryHighSetting()
    {
        PostPross.SetActive(true);
        QualitySettings.SetQualityLevel(3, true);
    }
}