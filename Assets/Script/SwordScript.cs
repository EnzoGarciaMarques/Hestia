using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField] float dano;


    [SerializeField] AudioClip shotClip;
    Animator anima;
    Collider collide;

    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        anima = GetComponent<Animator>();
        collide = GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {

        text.text = "";
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //kaue som de tiro aqui
            SFXManager.Instance.PlaySoundFXClip(shotClip, transform, 1f);

            anima.SetBool("atirando", true);
            collide.enabled = true;
        }
        else
        {
            anima.SetBool("atirando", false);
            collide.enabled = false;


        }
    }

}
