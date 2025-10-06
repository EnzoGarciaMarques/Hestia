using System.Collections;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Bunny : Interactable
{
    [SerializeField] TextMeshProUGUI chat;

    [SerializeField] float dialogo;
    [SerializeField] string texto1;
    [SerializeField] string texto2;
    [SerializeField] MouseMovement mouseMovement;
    [SerializeField] PlayerMovement playerMovement;
    private string prompt;
    [SerializeField] AudioClip risada;
    [SerializeField] GameObject canto;
    AudioClip clip;
    bool cantando;
    bool risadinha = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prompt = promptMessage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Quests.instance.rescue)
        {
            canto.SetActive(true);
        }
        if (Quests.instance.questCompleted) 
        {
            texto1 = "Brigado amigo!";
            texto2 = "vo faze o bolo";
        }
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
            Quests.instance.getQuest = true;
            risadinha = false;
        }
    }
    protected override void Interact()
    {
        dialogo += 1;
        if (!risadinha) 
        {
            SFXManager.Instance.PlaySoundFXClip(risada, transform, 1f);
            risadinha = true;
        }
        
        if (Quests.instance.carrots == 5 && Quests.instance.getQuest == true)
        {
            Quests.instance.questCompleted = true;
        }
    }


}
