using System.Collections;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public float speed = 7;
    public float meleeRange = 5f;
    bool atacking = false;
    [SerializeField] int lenghtAtack;
    private float timer;
    private GameObject player;
    Animator anim;
    bool ice = false;
    [SerializeField] AudioClip attack;
    public DamageEnemy mele;
    SpriteRenderer spriteRenderer;
    [SerializeField] float dano;
    [SerializeField] Transform attackPos;
    [SerializeField] Transform bate1;
    [SerializeField] Transform bate2;
    [SerializeField] float y;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 voar = new Vector3(transform.position.x, y, transform.position.z);
        transform.position = voar;
        if (mele.morto == false)
        {
            if (mele.dano == false)
            {
                if (ice == false)
                {
                    float distance = Vector3.Distance(transform.position, player.transform.position);
                    Debug.Log($"distance from player: {distance}, playerPos: {player.transform.position}, EnemyPos: {transform.position}");
                    if (!atacking)
                    {
                        if (distance < meleeRange)
                        {
                            timer += Time.deltaTime;
                            if (timer > 1)
                            {
                                timer = 0;
                                SFXManager.Instance.PlaySoundFXClip(attack, transform, 1f);
                                StartCoroutine(Punch());

                            }
                        }
                        else
                        {
                            Vector3 direction = (player.transform.position - transform.position).normalized;
                            transform.position += direction * speed * Time.deltaTime;


                        }
                    }
                }
            }
        }
        if (mele.morto == true)
        {
            Destroy(attackPos.gameObject);
        }
    }

    IEnumerator Punch()
    {
        atacking = true;
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("Batendo", true);
        attackPos.position = bate1.position;
        yield return new WaitForSeconds(0.50f);
        anim.SetBool("Batendo", false);
        attackPos.position = bate2.position;
        atacking = false;
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
}
