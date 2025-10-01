using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] GameObject fireBallPrefab;
    [SerializeField] GameObject iceSpearPrefab;
    [SerializeField] Transform ejectFire;
    [SerializeField] float cooldown;
    [SerializeField] float amplifierCooldown;
    [SerializeField] float velocity;
    bool onCooldown = false;
    public float damage;
    public float magic = 0;
    [SerializeField] AudioClip attack1;
    [SerializeField] AudioClip attack2;
    [SerializeField] AudioClip attack3;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int countdown;
    [SerializeField] Animator magias;
    float timer;
    [SerializeField] PlayerHealth health;

    public static FireBall instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (magic == 0)
        {
            magias.gameObject.SetActive(false);
        }
        else 
        {
            magias.gameObject.SetActive(true);
        }
        magias.SetInteger("magia", (int)magic);
        if (Input.GetKey(KeyCode.Mouse1) && !onCooldown && magic == 1)
        {
            countdown = 6;
            StartCoroutine(Fire());

        }
        if (Input.GetKey(KeyCode.Mouse1) && !onCooldown && magic == 2)
        {
            countdown = 6;
            StartCoroutine(Ice());

        }
        if (Input.GetKey(KeyCode.Mouse1) && !onCooldown && magic == 3)
        {
            countdown = 6;
            StartCoroutine(Amplifier());
            SFXManager.Instance.PlaySoundFXClip(attack3, transform, 1f);
        }
 
    }
    IEnumerator Fire()
    {
        onCooldown = true;
        StartCoroutine(Ui());
        GameObject fireBall = Instantiate(fireBallPrefab, ejectFire.position, Quaternion.identity);
        fireBall.GetComponent<Rigidbody>().AddForce(ejectFire.forward.normalized * velocity, ForceMode.Impulse);
        Destroy(fireBall, 4f);
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }
    IEnumerator Ice()
    {
        onCooldown = true;
        StartCoroutine(Ui());
        GameObject iceSpear = Instantiate(iceSpearPrefab, ejectFire.position, gameObject.transform.rotation);
        iceSpear.GetComponent<Rigidbody>().AddForce(ejectFire.forward.normalized * velocity, ForceMode.Impulse);
        Destroy(iceSpear, 4f);
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }
    IEnumerator Amplifier()
    {
        health.health += 2;
        StartCoroutine(Ui());
        onCooldown = true;
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }
    IEnumerator Ui()
    {
        text.text = countdown.ToString();
        yield return new WaitForSeconds(1);
        countdown -= 1;
        text.text = countdown.ToString();
        yield return new WaitForSeconds(1);
        countdown -= 1;
        text.text = countdown.ToString();
        yield return new WaitForSeconds(1);
        countdown -= 1;
        text.text = countdown.ToString();
        yield return new WaitForSeconds(1);
        countdown -= 1;
        text.text = countdown.ToString();
        yield return new WaitForSeconds(1);
        countdown -= 1;
        text.text = countdown.ToString();
        yield return new WaitForSeconds(1);
        text.text = "";
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider)
        {
            Destroy(gameObject);
        }
    }
    public void takeMagic(float ammount)
    {
        magic = ammount;
    }

}
