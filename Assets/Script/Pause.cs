using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    public bool pause = false;
    private void Awake()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
            pause = true;
        }
        else
        {
            Time.timeScale = 1f;
            pause = false;
        }
    }
    public void Continue()
    {
        PauseMenus();
    }
    public void Exit()
    {
        SceneManager.LoadScene("cutscene_inicial");
        Destroy(Quests.instance.gameObject);
        Destroy(sensivity.instance.gameObject);
        Destroy(gameObject);
        Destroy(PlayerHealth.instance.sfx.gameObject);
        Destroy(PlayerHealth.instance.music.gameObject);
        Destroy(PlayerHealth.instance.canvas.gameObject);
        Destroy(PlayerHealth.instance.sound.gameObject);
        Destroy(BunnyScared.instance.gameObject);
    }
}
