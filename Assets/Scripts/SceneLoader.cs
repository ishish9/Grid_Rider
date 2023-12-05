using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject LoadingText;

    public void Load_Menu()
    {
        LoadingText.SetActive(true);
        SceneManager.LoadScene("Menu");
    }
    // Single Player Levels
    public void Load_Grid_A()
    {
        LoadingText.SetActive(true);
        SceneManager.LoadScene("Grid_A");
    }

    public void Load_Grid_B()
    {
        LoadingText.SetActive(true);
        SceneManager.LoadScene("Grid_B");
    }

    public void Load_Grid_Fast()
    {
        LoadingText.SetActive(true);
        SceneManager.LoadScene("Grid_Fast");
    }

    public void Load_Grid_Fight()
    {
        LoadingText.SetActive(true);
        SceneManager.LoadScene("Grid_Fight");
    }

    public void Load_Grid_TimesUp()
    {
        LoadingText.SetActive(true);
        SceneManager.LoadScene("Times Up!");
    }

    public void Load_Grid_Barrier_To_Entry()
    {
        LoadingText.SetActive(true);
        SceneManager.LoadScene("Barrier To Entry");
    }
    // MINI GAMES 
    public void Load_Grid_Barrier_Buster()
    {
        LoadingText.SetActive(true);
        SceneManager.LoadScene("Barrier Buster");
    }
    public void Load_Grid_Laser_Sharp()
    {
        LoadingText.SetActive(true);
        SceneManager.LoadScene("Laser Sharp");
    }
    public void Load_Grid_Juggle()
    {
        LoadingText.SetActive(true);
        SceneManager.LoadScene("Juggle");
    }

    // MultiPlayer
    public void Load_Grid_MultiPlayer_1()
    {
        LoadingText.SetActive(true);
        SceneManager.LoadScene("MP_1");
    }
}
