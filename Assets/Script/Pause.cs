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
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseMenus();
        }
    }

    private void PauseMenus()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);

        if (PauseMenu.activeSelf == true)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void Continue()
    {
        PauseMenus();
    }
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
        Destroy(Quests.instance.gameObject);
        Destroy(gameObject);
        Destroy(PlayerHealth.instance.sfx.gameObject);
        Destroy(PlayerHealth.instance.music.gameObject);
        Destroy(PlayerHealth.instance.canvas.gameObject);
        Destroy(PlayerHealth.instance.sound.gameObject);
    }
}
