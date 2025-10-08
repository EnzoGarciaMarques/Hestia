using TMPro;
using UnityEngine;

public class BunnyScared : Interactable
{
    [SerializeField] TextMeshProUGUI chat;

    [SerializeField] float dialogo;
    [SerializeField] MouseMovement mouseMovement;
    [SerializeField] PlayerMovement playerMovement;
    private string prompt;
    Animator animator;

    public static BunnyScared instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
        prompt = promptMessage;
        animator = GetComponent<Animator>();
        animator.SetInteger("humor", 1);
        if (Quests.instance.rescue)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogo == 1)
        {
            chat.text = "Onde eu estou?";
            mouseMovement.enabled = false;
            playerMovement.enabled = false;
            promptMessage = "";
        }
        if (dialogo == 2)
        {
            chat.text = "A última coisa que eu lembro foi dele me deixando, depois eu tava aqui, me escondendo.";
        }
        if (dialogo == 3)
        {
            chat.text = "Casa? Eu vou para ela, muito obrigado.";
        }
        if (dialogo == 4)
        {
            chat.text = "";
            dialogo = 0;
            mouseMovement.enabled = true;
            playerMovement.enabled = true;
            promptMessage = prompt;
            Quests.instance.rescue = true;
        }
    }
    protected override void Interact()
    {
        dialogo += 1;
    }
}
