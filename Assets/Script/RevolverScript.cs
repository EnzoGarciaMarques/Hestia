using System.Collections;
using TMPro;
using UnityEngine;

public class RevolverScript : MonoBehaviour
{
    [SerializeField] float dano;
    [SerializeField] float range;
    [SerializeField] float fireRate;
    [SerializeField] float tempoTiro;
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

    [SerializeField] private TrailRenderer bulletTrail;
    [SerializeField] private LayerMask mask;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private ParticleSystem ps;

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
        if (ammo <= 0 && nextTimeToFire || Input.GetKeyDown(KeyCode.R) && nextTimeToFire && ammo < maxAmmo)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetKey(KeyCode.Mouse0) && nextTimeToFire)
        {
            //kaue som de tiro aqui
            SFXManager.Instance.PlaySoundFXClip(shotClip, transform, 0.2f);

            anima.SetBool("atirando", true);
            nextTimeToFire = false;
            StartCoroutine(Tiro());
            Shoot();
            
        }
        

    }
    IEnumerator Reload()
    {
        //kaue som de reload aqui
        SFXManager.Instance.PlaySoundFXClip(reloadClip, transform, 0.2f);

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

        yield return new WaitForSeconds(tempoTiro);
        anima.SetBool("atirando", false);
        nextTimeToFire = true;
    }
    void Shoot ()
    {
        ps.Play();
        ammo--;
        RaycastHit hit;
        if (Physics.Raycast(cameras.transform.position, cameras.transform.forward, out hit, range))
        {
            TrailRenderer trail = Instantiate(bulletTrail, bulletSpawn.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, hit));
            DamageEnemy damage = hit.transform.GetComponent<DamageEnemy>();
            MoquitoDano damage2 = hit.transform.GetComponent<MoquitoDano>();
            if (damage != null)
            {
                    damage.TakeDamage(dano);  
            }
            if (damage2 != null)
            {
                damage2.Hit(dano);
            }
        }


    }

    private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit Hit)
    {
        float time = 0;
        Vector3 startPosition = trail.transform.position;

        while(time < 0.5)
        {
            trail.transform.position = Vector3.Lerp(startPosition, Hit.point, time);
            time += Time.deltaTime / trail.time;

            yield return null;
        }


        trail.transform.position = Hit.point;
        Destroy(trail.gameObject, trail.time);
    }


}
