using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject Bala;
    [SerializeField] GameObject moquitos;
    [SerializeField] Collider hitboxPulo;
    public Transform Balapos;
    [SerializeField] Transform saida;
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
    float lastAttack;
    [SerializeField] ParticleSystem ps;
    [SerializeField] float tempo;
    Collider col;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (mele.morto == false)
        {
            if (ice == false)
            {
                if (atacando == false)
                {
                    atacando = true;
                    Ataques();
                }
            }
        }
        
    }
    void Ataques()
    {
        float ataque = Random.Range(1, 4);
        if (ataque == 1)
        {
            anim.SetBool("fumaca", true);
            SFXManager.Instance.PlaySoundFXClip(attackFumaca, transform, 1f);
            StartCoroutine(Fumaca());
        }
        if (ataque == 2)
        {
            anim.SetBool("fumaca", true);
            SFXManager.Instance.PlaySoundFXClip(attackMosca, transform, 1f);
            StartCoroutine(moquito());

        }
        if (ataque == 3)
        {
            SFXManager.Instance.PlaySoundFXClip(attackpulo, transform, 1f);
            anim.SetBool("pulando", true);
            col.enabled = false;
            StartCoroutine(Pulo());

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
        Instantiate(Bala, Balapos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("fumaca", false);
        Destroy(Bala.gameObject, 1f);
        yield return new WaitForSeconds(1f);
        float ataque = Random.Range(1, 4);
        atacando = false;
    }
    IEnumerator moquito()
    {
        Instantiate(moquitos, Balapos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("fumaca", false);
        yield return new WaitForSeconds(2f);
        float ataque = Random.Range(1, 4);
        atacando = false;
    }
    IEnumerator Pulo()
    {
        yield return new WaitForSeconds(tempo);
        anim.SetBool("pulando", false);
        col.enabled = true;
        Instantiate(ps, saida.position, ps.transform.rotation);
        hitboxPulo.enabled = true;
        yield return new WaitForSeconds(1f);
        float ataque = Random.Range(1, 4);
        atacando = false;
        hitboxPulo.enabled = false;
    }

}
