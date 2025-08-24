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
    [SerializeField] int maxAmmo = 6;
    [SerializeField] float reloadTime;

    [SerializeField] AudioClip shotClip;
    [SerializeField] AudioClip reloadClip;
    Animator anima;
    float ammo;
    float nextTimeToFire = 0f;
    bool isReloading;
    FireBall magic;


    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        ammo = maxAmmo;
        anima = GetComponent<Animator>();
        cameras = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        
        text.text = "Infinite";
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            //kaue som de tiro aqui
            SFXManager.Instance.PlaySoundFXClip(shotClip, transform, 1f);

            anima.SetBool("atirando", true);
            StartCoroutine(Tiro());
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();

        }


    }

    IEnumerator Tiro()
    {
        yield return new WaitForSeconds(0.2f);
        anima.SetBool("atirando", false);
    }
    void Shoot()
    {
        particula.Play();
        RaycastHit hit;
        //if (Physics.OverlapBox())
        //{
            //DamageEnemy damage = hit.transform.GetComponent<DamageEnemy>();
            //if (damage != null)
            //{
                //damage.TakeDamage(dano);
            //}
        //}

    }
}
