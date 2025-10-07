using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject Bala;
    [SerializeField] GameObject moquitos;
    [SerializeField] GameObject hitboxPulo;
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
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

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
                            if (ataque == 1)
                            {
                                SFXManager.Instance.PlaySoundFXClip(attackFumaca, transform, 1f);
                                StartCoroutine(Fumaca());
                            }
                            else if (ataque == 2)
                            {
                                SFXManager.Instance.PlaySoundFXClip(attackMosca, transform, 1f);
                                StartCoroutine(moquito());

                            }
                            else if ( ataque == 3)
                            {
                                SFXManager.Instance.PlaySoundFXClip(attackpulo, transform, 1f);
                                StartCoroutine(Pulo());
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
        if (other.gameObject.CompareTag("ground") && pulando)
        {
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
        anim.SetBool("fumaca", true);
        atacando = true;
        Instantiate(Bala, Balapos.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        anim.SetBool("fumaca", false);
        atacando = false;
    }
    IEnumerator moquito()
    {
        anim.SetBool("mosca", true);
        atacando = true;
        Instantiate(moquitos, Balapos.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        anim.SetBool("mosca", false);
        atacando = false;
    }
    IEnumerator Pulo()
    {
        atacando = true;
        pulando = true;
        Vector3 aberto = new Vector3(transform.position.x, 50, transform.position.z);
        transform.position = aberto;
        rb.useGravity = true;
        yield return new WaitForSeconds(2);
        atacando = false;
    }
    IEnumerator PuloHitbox()
    {
        hitboxPulo.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        hitboxPulo.SetActive(false);
    }

}
