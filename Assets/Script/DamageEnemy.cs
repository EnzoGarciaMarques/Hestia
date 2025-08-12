
using JetBrains.Annotations;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] float health;
    public int level = 0;
    [SerializeField] float upgradePerLvl;
    [SerializeField] float flametime;
    bool flameOn;
    [SerializeField] FireBall fire;
    SwordScript Sword;
    Animator anima;
    public bool dano = false;


    private void Awake()
    {
        health = health + upgradePerLvl * level;
        anima = GetComponent<Animator>();
    }
    public void TakeDamage(float amount)
    {
        if (dano == false) {
            if (fire.amplifier == true)
            {
                health -= amount * 2;
            }
            else
            {
                health -= amount;
            }
            StartCoroutine(TomouDano());
        }

    }
    private void Update()
    {
        if (flameOn)
        {
            StartCoroutine(Flametime());

        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Flametime()
    {
        TakeDamage(fire.damage);
        yield return new WaitForSeconds(flametime);
        TakeDamage(fire.damage);
        flameOn = false;
    }

    IEnumerator TomouDano()
    {
        dano = true;
        anima.SetBool("dano", true);
        yield return new WaitForSeconds(3f);
        anima.SetBool("dano", false);
        dano = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            Destroy(other.gameObject);
            flameOn = true;
        }
    }
}
