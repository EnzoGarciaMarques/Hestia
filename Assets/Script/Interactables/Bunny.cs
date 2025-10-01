using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Bunny : Interactable
{
    [SerializeField] TextMeshProUGUI chat;

    [SerializeField] float dialogo = 1;
    [SerializeField] string texto1;
    [SerializeField] string texto2;
    [SerializeField] MouseMovement mouseMovement;
    [SerializeField] PlayerMovement playerMovement;
    private string prompt;
    [SerializeField] AudioClip canto;
    [SerializeField] AudioClip risada;
    AudioClip clip;
    bool cantando;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prompt = promptMessage;
        clip = canto;
    }

    // Update is called once per frame
    void Update()
    {
        if (Quests.instance.questCompleted) 
        {
            texto1 = "Brigado amigo!";
            texto2 = "vo faze o bolo";
        }
        if (dialogo == 1)
        {
            clip = risada;
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
            clip = canto;
        }
    }
    protected override void Interact()
    {
        dialogo += 1;
        Quests.instance.getQuest = true;
    }


}
