using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField] float dano;
    bool somToca = false;

    [SerializeField] AudioClip shotClip;
    Animator anima;
    Collider collide;
    bool nextTimeToFire = true;
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
        if (Input.GetKey(KeyCode.Mouse0) && nextTimeToFire)
        {
            if (!somToca)
            {
                //kaue som de tiro aqui
                StartCoroutine(Music());
            }

            anima.SetBool("atirando", true);
            collide.enabled = true;
            nextTimeToFire = false;
            StartCoroutine(Ataque());
        }
    }
    IEnumerator Music()
    {
        somToca = true;
        SFXManager.Instance.PlaySoundFXClip(shotClip, transform, 1f);
        yield return new WaitForSeconds(1f);
        somToca = false;

    }
    IEnumerator Ataque()
    {

        yield return new WaitForSeconds(1f);
        anima.SetBool("atirando", false);
        collide.enabled = false;
        nextTimeToFire = true;
    }

}
