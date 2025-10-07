using TMPro;
using UnityEngine;

public class BunnyScared : Interactable
{
    [SerializeField] TextMeshProUGUI chat;

    [SerializeField] float dialogo;
    [SerializeField] string texto1;
    [SerializeField] string texto2;
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
        if (Quests.instance.rescue)
        {
            texto1 = "Brigado amigo!";
            texto2 = "vo la para a casa";
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
            Quests.instance.rescue = true;
        }
    }
    protected override void Interact()
    {
        dialogo += 1;
    }
}
