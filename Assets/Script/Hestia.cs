using TMPro;
using UnityEngine;

public class Hestia : Interactable
{
    [SerializeField] TextMeshProUGUI chat;

    [SerializeField] float dialogo;
    [SerializeField] string texto1;
    [SerializeField] string texto2;
    [SerializeField] string textoFirstTime;
    [SerializeField] string textoFirstTime2;
    [SerializeField] MouseMovement mouseMovement;
    [SerializeField] PlayerMovement playerMovement;
    private string prompt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prompt = promptMessage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Quests.instance.firstTime)
        {
            promptMessage = "Aperte E para conversar";
        }
        if (Quests.instance.firstTime && dialogo == 1)
        {

            chat.text = textoFirstTime;
            mouseMovement.enabled = false;
            playerMovement.enabled = false;
            promptMessage = "";

        }
        if (Quests.instance.firstTime && dialogo == 2)
        {
            chat.text = "";
            dialogo = 0;
            mouseMovement.enabled = true;
            playerMovement.enabled = true;
            promptMessage = prompt;
            Quests.instance.firstTime = false;

        }


        if (dialogo == 1 && !Quests.instance.firstTime)
        {
            chat.text = texto1;
            mouseMovement.enabled = false;
            playerMovement.enabled = false;
            promptMessage = "";
        }
        if (dialogo == 2 && !Quests.instance.firstTime)
        {
            chat.text = texto2;
        }
        if (dialogo == 3)
        {
            chat.text = "";
            dialogo = 0;
            mouseMovement.enabled = true;
            playerMovement.enabled = true;
            promptMessage = prompt;
        }
    }
    protected override void Interact()
    {
        dialogo += 1;
    }
}
