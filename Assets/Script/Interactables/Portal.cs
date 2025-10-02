using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Interactable 
{
    [SerializeField] MouseMovement mouseMovement;
    [SerializeField] PlayerMovement playerMovement;
    float dialogo;
    [SerializeField] TextMeshProUGUI chat;
    string prompt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prompt = promptMessage;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogo == 1)
        {
            chat.text = "Fale com o Fogo antes";
            mouseMovement.enabled = false;
            playerMovement.enabled = false;
            promptMessage = "";
        }
        if (dialogo == 2)
        {
            dialogo = 0;
            mouseMovement.enabled = true;
            playerMovement.enabled = true;
            promptMessage = prompt;
            chat.text = "";
        }
    }
    protected override void Interact()
    {
        if (Quests.instance.firstTime)
        {
            dialogo++;
        }
        else 
        {
            SceneManager.LoadScene("corredor");
        }
    }
}
