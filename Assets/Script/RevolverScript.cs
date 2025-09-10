using System.Collections;
using TMPro;
using UnityEngine;

public class RevolverScript : MonoBehaviour
{
    [SerializeField] float dano;
    [SerializeField] float range;
    [SerializeField] float fireRate;

    [SerializeField] Camera cameras;

    [SerializeField] int maxAmmo = 6;
    [SerializeField] float reloadTime;

    [SerializeField] AudioClip shotClip;
    [SerializeField] AudioClip reloadClip;
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
        if (ammo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && nextTimeToFire)
        {
            //kaue som de tiro aqui
            SFXManager.Instance.PlaySoundFXClip(shotClip, transform, 1f);

            anima.SetBool("atirando", true);
            StartCoroutine(Tiro());
            nextTimeToFire = false;
            Shoot();
            
        }
        

    }
    IEnumerator Reload()
    {
        //kaue som de reload aqui
        SFXManager.Instance.PlaySoundFXClip(reloadClip, transform, 1f);

        anima.SetBool("recaregando", true);
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        ammo = maxAmmo;
        isReloading = false;
        anima.SetBool("recaregando", false);
    }

    IEnumerator Tiro()
    {
        yield return new WaitForSeconds(0.2f);
        anima.SetBool("atirando", false);
        nextTimeToFire = true;
    }
    void Shoot ()
    {
        ammo--;
        RaycastHit hit;
        if (Physics.Raycast(cameras.transform.position, cameras.transform.forward, out hit, range))
        {
            DamageEnemy damage = hit.transform.GetComponent<DamageEnemy>();
            if (damage != null)
            {
                    damage.TakeDamage(dano);  
            }
        }


    }


}
