
using JetBrains.Annotations;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] float health;
    public int level = 0;
    [SerializeField] float upgradePerLvl;
    [SerializeField] float flame;
    bool flameOn;
    [SerializeField] FireBall fire;
    SwordScript Sword;
    Animator anima;
    public bool dano = false;
    public bool morto = false;
    Collider collide;
    Rigidbody rigid;
    [SerializeField] AudioClip soundDano;
    [SerializeField] AudioClip soundMorte;
    SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = health + upgradePerLvl * level;
        anima = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }
   
    public void TakeDamage(float amount)
    {
        
        print($"{this.gameObject.name} tomou dano");
        if (dano == false && morto == false) {
            SFXManager.Instance.PlaySoundFXClip(soundDano, transform, 1f);
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

    int bla = 1;
    private void Update()
    {
        if (flameOn)
        {
            StartCoroutine(Flametime());

        }

        if (health <= 0 && !morto)
        {
            anima.SetBool("dano", false);
            anima.SetTrigger("morreu");
            SFXManager.Instance.PlaySoundFXClip(soundMorte, transform, 25f);
            morto = true;
            Destroy(gameObject, 2f);
        }
    }
    IEnumerator Flametime()
    {
       
        flameOn = false;
        spriteRenderer.color = Color.red;
        TakeDamage(fire.damage);
        yield return new WaitForSeconds(flame);
        TakeDamage(fire.damage);
        spriteRenderer.color = Color.white;

    }

    IEnumerator TomouDano()
    {   
        dano = true;
        anima.SetBool("dano", true);
        yield return new WaitForSeconds(0.2f);
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
