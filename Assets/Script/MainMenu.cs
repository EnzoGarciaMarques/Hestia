using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string levelName;
    [SerializeField] GameObject painelMenu;
   
    public void Play()
    {
        SceneManager.LoadScene(levelName);
        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
