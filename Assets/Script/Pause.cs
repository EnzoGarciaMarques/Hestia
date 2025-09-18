using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    private void Awake()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenus();
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void PauseMenus()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);

        if (PauseMenu.activeSelf == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void Continue()
    {
        PauseMenu.SetActive(false);
    }
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
