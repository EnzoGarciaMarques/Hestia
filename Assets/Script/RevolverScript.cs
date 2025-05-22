using System.Collections;
using TMPro;
using UnityEngine;

public class RevolverScript : MonoBehaviour
{
    [SerializeField] float dano;
    [SerializeField] float range;
    [SerializeField] float fireRate;

    [SerializeField] Camera cameras;
    [SerializeField] ParticleSystem particula;
    [SerializeField] int maxAmmo = 6;
    [SerializeField] int reloadTime;
    float ammo;
    float nextTimeToFire = 0f;
    bool isReloading;

    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        ammo = maxAmmo;
    }
    // Update is called once per frame
    void Update()
    {
        text.text = "6/" + ammo;
        if (isReloading)
            return;
        if (ammo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        

    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        ammo = maxAmmo;
        isReloading = false;
    }
    void Shoot ()
    {
        ammo--;
        particula.Play();
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
