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

    [SerializeField] GameObject menuFala;

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
        if (dialogo == 1)
        {
            menuFala.SetActive(!menuFala.activeSelf);
            chat.text = "Oi, eu sou Hestia, o espirito protetor dessa casa, eu que te enviei a carta.";
            mouseMovement.enabled = false;
            playerMovement.enabled = false;
            promptMessage = "";
            Quests.instance.firstTime = false;
        }
        if (dialogo == 2)
        {
            chat.text = "Seu tio de terceiro grau era o protetor da casa, mas ele desapareceu e agora preciso de sua ajuda.";
        }
        if ( dialogo == 3)
        {
            chat.text = "Atualmente a casa se tornou um resquicio do que era, ela perdeu quase totalmente sua magia, sua beleza e sua vida.";
        }
        if (dialogo == 4)
        {
            chat.text = "Mas tem uma maneira de restaurar ela e transformar ela em algo que nunca vi antes.";
        }
        if (dialogo == 5)
        {
            chat.text = "Preciso que salve as pessoas de um reino em colapso e as traga para aqui, com isso a magia da casa aos poucos vai ser restaurada.";
        }
        if (dialogo == 6)
        {
            chat.text = "Para chegar ao reino, entre no espelho";
        }
        if (dialogo == 7)
        {
            menuFala.SetActive(!menuFala.activeSelf);
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
