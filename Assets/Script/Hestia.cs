using TMPro;
using UnityEngine;

public class Hestia : Interactable
{
    [SerializeField] TextMeshProUGUI chat;

    [SerializeField] float dialogo = 1;
    [SerializeField] string texto1;
    [SerializeField] string texto2;
    [SerializeField] MouseMovement mouseMovement;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Quests quests;
    private string prompt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prompt = promptMessage;
        if (quests.firstTime) 
        {
            Interact();
            quests.firstTime = false;
        
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (dialogo == 1)
        {
            chat.text = texto1;
            mouseMovement.enabled = false;
            playerMovement.enabled = false;
            promptMessage = "";
        }
        if (dialogo == 2)
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
