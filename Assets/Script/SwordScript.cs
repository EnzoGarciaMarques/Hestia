using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField] float dano;
    [SerializeField] float range;
    [SerializeField] float fireRate;

    Camera cameras;
    [SerializeField] ParticleSystem particula;

    [SerializeField] AudioClip shotClip;
    [SerializeField] AudioClip reloadClip;
    Animator anima;
    float nextTimeToFire = 0f;
    FireBall magic;
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
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            //kaue som de tiro aqui
            SFXManager.Instance.PlaySoundFXClip(shotClip, transform, 1f);

            anima.SetBool("atirando", true);
            collide.enabled = true;
            StartCoroutine(Attack());
            nextTimeToFire = Time.time + 1f / fireRate;

        }


    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.2f);
        anima.SetBool("atirando", false);
        collide.enabled = false;
    }
}
