using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioClip PauseClip;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject GraphicsUI;
    [SerializeField] private GameObject PostPross;
    [SerializeField] private Button lowButton;
    [SerializeField] private Button mediumButton;
    [SerializeField] private Button highButton;
    [SerializeField] private Button veryHighButton;
    ActionMap_1 actionsWrapper2;
    [Header("Note: Make Event Select Menu 'No' Button ")]
    public UnityEvent PausePlayerEvent;
    [Header("Note: Make Event Select 'Restart' Button ")]
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

    // Highlights button of currently selected graphics settings.
    public void SelectGraphicsButton()
    {
        if (PlayerPrefs.GetInt("PlayerHasSetQualityLevel") == 1)
        {
            switch (PlayerPrefs.GetInt("QualitySetting"))
            {
                case 0:
                    lowButton.Select();
                    break;
                case 1:
                    mediumButton.Select();
                    break;
                case 2:
                    highButton.Select();
                    break;
                case 3:
                    veryHighButton.Select();
                    break;
            }
        }
        else
        {
            mediumButton.Select();
        }
    }

    public void LowSetting()
    {
        PostPross.SetActive(false);
        QualitySettings.SetQualityLevel(0, true);
        PlayerPrefs.SetInt("PlayerHasSetQualityLevel", 1);
        PlayerPrefs.SetInt("QualitySetting", 0);
        PlayerPrefs.Save();
    }

    public void MediumSetting()
    {
        PostPross.SetActive(true);
        QualitySettings.SetQualityLevel(1, true);
        PlayerPrefs.SetInt("PlayerHasSetQualityLevel", 1);
        PlayerPrefs.SetInt("QualitySetting", 1);
        PlayerPrefs.Save();
    }

    public void HighSetting()
    {
        PostPross.SetActive(true);
        QualitySettings.SetQualityLevel(2, true);
        PlayerPrefs.SetInt("PlayerHasSetQualityLevel", 1);
        PlayerPrefs.SetInt("QualitySetting", 2);
        PlayerPrefs.Save();
    }

    public void VeryHighSetting()
    {
        PostPross.SetActive(true);
        QualitySettings.SetQualityLevel(3, true);
        PlayerPrefs.SetInt("PlayerHasSetQualityLevel", 1);
        PlayerPrefs.SetInt("QualitySetting", 3);
        PlayerPrefs.Save();
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}