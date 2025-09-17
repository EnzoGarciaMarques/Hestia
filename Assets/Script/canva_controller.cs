using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class canva_controller : MonoBehaviour
{
    [SerializeField] GameObject Image;
    [SerializeField] GameObject Image2;
    Animator anim;
    Animator anim2;
    private PlayerControls inputControls;
    private bool passa_cena => inputControls.UI.Submit.IsPressed();
    [SerializeField] int momento = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim2 = Image2.GetComponent<Animator>();
        anim = Image.GetComponent<Animator>();
        SetupInput();
    }

    // Update is called once per frame
    void Update()
    {
        ProximaAnima();
    }

    void SetupInput()
    {
        inputControls = new PlayerControls();
        inputControls.UI.Enable();
    }
    
    void ProximaAnima()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("apertou");
            if (momento == 1)
            {
                momento = 2;
                anim.SetInteger("cut", 2);
                Debug.Log("mudow");
            }
            else if(momento == 2)
            {
                momento = 3;
                anim.SetInteger("cut", 3);
                Debug.Log("mudow");
            }
            else if (momento == 3)
            {
                Debug.Log("moveu");
                anim2.SetTrigger("move");
                momento = 4;
            }
            else if(momento == 4)
            {
                SceneManager.LoadScene("Menu");

            }
        }
    }

}
