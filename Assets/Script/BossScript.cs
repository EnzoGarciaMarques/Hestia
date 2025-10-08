using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject Bala;
    [SerializeField] GameObject moquitos;
    [SerializeField] Collider hitboxPulo;
    public Transform Balapos;
    private float timer;
    bool pulando;
    bool atacando;
    bool ice = false;
    Animator anim;
    public DamageEnemy mele;
    [SerializeField] AudioClip attackMosca;
    [SerializeField] AudioClip attackFumaca;
    [SerializeField] AudioClip attackpulo;
    SpriteRenderer spriteRenderer;
    Rigidbody rb;
    Collider col;
    float lastAttack;
    [SerializeField] ParticleSystem ps;
    [SerializeField] float gravity = -9.81f * 2;
    bool gravidade;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

    }
    // Update is called once per frame
    void Update()
    {
        if (mele.morto == false)
        {
            if (mele.dano == false)
            {
                if (ice == false)
                {
                    if (atacando == false)
                    {
                        timer += Time.deltaTime;
                        if (timer > 2)
                        {
                            timer = 0;
                            float ataque = Random.Range(1, 4);
                            if (ataque == 1 && lastAttack != 1)
                            {
                                anim.SetBool("fumaca", true);
                                SFXManager.Instance.PlaySoundFXClip(attackFumaca, transform, 1f);
                                lastAttack = ataque;
                                StartCoroutine(Fumaca());
                            }
                            else if (ataque == 2 && lastAttack != 2)
                            {
                                anim.SetBool("mosca", true);
                                SFXManager.Instance.PlaySoundFXClip(attackMosca, transform, 1f);
                                lastAttack = ataque;
                                StartCoroutine(moquito());

                            }
                            else if ( ataque == 3 && lastAttack != 3)
                            {
                                //aqui
                                SFXManager.Instance.PlaySoundFXClip(attackpulo, transform, 1f);
                                Vector3 aberto = new Vector3(transform.position.x, 50, transform.position.z);
                                transform.position = aberto;
                                col.isTrigger = false;
                                rb.useGravity = true;
                                atacando = true;
                                pulando = true;
                                lastAttack = ataque;
                            }
                        }
                    }
                    
                }
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ice"))
        {
            Destroy(other.gameObject);
            StartCoroutine(Freeze());
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && pulando)
        {
            rb.useGravity = false;
            col.isTrigger = true;
            Instantiate(ps, transform.transform.position, ps.transform.rotation);
            pulando = false;
            StartCoroutine(PuloHitbox());

        }
    }
    IEnumerator Freeze()
    {
        spriteRenderer.color = Color.blue;
        ice = true;
        yield return new WaitForSeconds(2);
        ice = false;
        spriteRenderer.color = Color.white;
    }

    IEnumerator Fumaca()
    {
        atacando = true;
        Instantiate(Bala, Balapos.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        anim.SetBool("fumaca", false);
        atacando = false;
    }
    IEnumerator moquito()
    {
        atacando = true;
        Instantiate(moquitos, Balapos.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        anim.SetBool("mosca", false);
        atacando = false;
    }
    IEnumerator PuloHitbox()
    {
        hitboxPulo.enabled = true;
        yield return new WaitForSeconds(0.25f);
        atacando = false;
        hitboxPulo.enabled = false;
    }

}
