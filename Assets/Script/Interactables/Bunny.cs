using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [SerializeField] GameObject menuFala;
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
        if (dialogo == 1 && Quests.instance.questCompleted)
        {
            menuFala.SetActive(true);
            chat.text = "Brigado, pelas cenouras.";
            mouseMovement.enabled = false;
            playerMovement.enabled = false;
            promptMessage = "";
        }
        if (dialogo == 2 && Quests.instance.questCompleted)
        {
            chat.text = "Gostou do bolo?";
        }
        if (dialogo == 3 && Quests.instance.questCompleted)
        {
            chat.text = "Sabe, eu nunca provei meu bolo de cenoura. Eu sempre fiz e os outros comiam tudo, sem deixarem nada pra mim.";
        }
        if (dialogo == 4 && Quests.instance.questCompleted)
        {
            chat.text = "No final das contas eu acabo nunca comendo um doce meu...";
        }
        if (dialogo == 5 && Quests.instance.questCompleted)
        {
            SceneManager.LoadScene("Fim");
            menuFala.SetActive(false);
            chat.text = "";
            dialogo = 0;
            mouseMovement.enabled = true;
            playerMovement.enabled = true;
            promptMessage = prompt;
            risadinha = false;
        }
        if (dialogo == 1 && !Quests.instance.questCompleted)
        {
            menuFala.SetActive(true);
            chat.text = "Que lugar lindo";
            mouseMovement.enabled = false;
            playerMovement.enabled = false;
            promptMessage = "";
        }
        if (dialogo == 2 && !Quests.instance.questCompleted)
        {
            chat.text = "Essa cozinha foi feita pra mim, parece que a casa sabia do que eu precisava.";
        }
        if (dialogo == 3 && !Quests.instance.questCompleted)
        {
            chat.text = "Vou fazer um bolo de agradecimento";
        }
        if (dialogo == 4 && !Quests.instance.questCompleted)
        {
            chat.text = "Pode ser de morango o predileto do meu maninho, ou de chocolate o predileto do meu… Ex marido…";
        }
        if (dialogo == 5 && !Quests.instance.questCompleted)
        {
            chat.text = "Tive uma ideia. Vou fazer de cenoura, o predileto do meu pai\r\nOnde posso encontrar essas cenouras?";
        }
        if (dialogo == 6 && !Quests.instance.questCompleted)
        {
            menuFala.SetActive(false);
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
