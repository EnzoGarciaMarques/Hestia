    using System.Collections;
using TMPro;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] float dano;
    [SerializeField] float range;
    [SerializeField] float fireRate;

    [SerializeField] Camera cameras;
    [SerializeField] ParticleSystem particula;
    [SerializeField] int maxAmmo = 6;
    [SerializeField] float reloadTime;


    Animator anima;
    float ammo;
    bool nextTimeToFire = true;
    bool isReloading;
    FireBall magic;


    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        ammo = maxAmmo;
        anima = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        text.text = ammo + "";
        if (isReloading)
            return;
        if (Input.GetKeyDown(KeyCode.R) && !anima.GetBool("atirando"))
        {
            StartCoroutine(Reload());
            return;
        }

        if(ammo <= 0)
        {
            StartCoroutine (Reloadtiro());
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && nextTimeToFire)
        {
            //kaue som de tiro aqui

            anima.SetBool("atirando", true);
            StartCoroutine(Tiro());
            nextTimeToFire = false;
            Shoot();

        }


    }
    IEnumerator Reload()
    {
        //kaue som de reload aqui

        anima.SetBool("recarregando", true);
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        ammo = maxAmmo;
        isReloading = false;
        anima.SetBool("recarregando", false);
    }

    IEnumerator Reloadtiro()
    {
        yield return new WaitForSeconds(reloadTime);
        //kaue som de reload aqui
        anima.SetBool("recarregando", true);
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        ammo = maxAmmo;
        isReloading = false;
        anima.SetBool("recarregando", false);
    }

    IEnumerator Tiro()
    {
        yield return new WaitForSeconds(1.29f);
        anima.SetBool("atirando", false);
        nextTimeToFire = true;  
    }
    void Shoot()
    {
        ammo--;
        particula.Play();
        RaycastHit hit;
        RaycastHit hit2;
        RaycastHit hit3;
        RaycastHit hit4;
        RaycastHit hit5;
        if (Physics.Raycast(cameras.transform.position, cameras.transform.forward, out hit, range))
        {
            DamageEnemy damage = hit.transform.GetComponent<DamageEnemy>();
            if (damage != null)
            {
                damage.TakeDamage(dano);
            }
        }
        if (Physics.Raycast(cameras.transform.position, cameras.transform.forward+new Vector3(.2f, 0f, 0f), out hit2, range))
        {
            DamageEnemy damage = hit2.transform.GetComponent<DamageEnemy>();
            if (damage != null)
            {
                damage.TakeDamage(dano);
            }
        }
        if (Physics.Raycast(cameras.transform.position, cameras.transform.forward + new Vector3(-.2f, 0f, 0f), out hit3, range))
        {
            DamageEnemy damage = hit3.transform.GetComponent<DamageEnemy>();
            if (damage != null)
            {
                damage.TakeDamage(dano);
            }
        }
        if (Physics.Raycast(cameras.transform.position, cameras.transform.forward + new Vector3(0f, .2f, 0f), out hit4, range))
        {
            DamageEnemy damage = hit4.transform.GetComponent<DamageEnemy>();
            if (damage != null)
            {
                damage.TakeDamage(dano);
            }
        }
        if (Physics.Raycast(cameras.transform.position, cameras.transform.forward + new Vector3(0f, -.2f, 0f), out hit5, range))
        {
            DamageEnemy damage = hit5.transform.GetComponent<DamageEnemy>();
            if (damage != null)
            {
                damage.TakeDamage(dano);
            }
        }




    }
}
