    using System.Collections;
using TMPro;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] float dano;
    [SerializeField] float range;
    [SerializeField] float fireRate;
    [SerializeField] float spread;
    [SerializeField] Camera cameras;
    [SerializeField] int maxAmmo = 6;
    [SerializeField] float reloadTime;
    [SerializeField] float ammountShoot;
    [SerializeField] AudioClip shotClip;
    [SerializeField] AudioClip reloadClip;
    Animator anima;
    float ammo;
    bool nextTimeToFire = true;
    bool isReloading;
    FireBall magic;
    //[SerializeField] Animator weaponUi;


    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        ammo = maxAmmo;
        anima = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        text.text = ammo.ToString();
        if (isReloading)
            return;
        if (Input.GetKeyDown(KeyCode.R) && !anima.GetBool("atirando") && ammo < 2)
        {
            StartCoroutine(Reload());
            return;
        }

        if(ammo <= 0)
        {
            StartCoroutine (Reload());
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
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        ammountShoot--;
        RaycastHit hit;
        Vector3 direction = cameras.transform.forward + new Vector3(x, y, 0);
        if (Physics.Raycast(cameras.transform.position, direction, out hit, range))
        {
            DamageEnemy damage = hit.transform.GetComponent<DamageEnemy>();
            if (damage != null)
            {
                damage.TakeDamage(dano);
            }
        }
        if(ammountShoot > 0)
        {
            Shoot();
        }
    }
}
