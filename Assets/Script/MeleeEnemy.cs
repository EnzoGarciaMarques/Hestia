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
    [SerializeField] GameObject attackPos;
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
                            if (timer > 2)
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
                            anim.SetBool("Batendo", false);


                        }
                    }
                }
            }
        }
    }

    IEnumerator Punch()
    {
        atacking = true;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Batendo", true);
        RaycastHit hit;
        if (Physics.Raycast(attackPos.transform.position, attackPos.transform.forward, out hit, lenghtAtack))
        {
            PlayerHealth damage = hit.transform.GetComponent<PlayerHealth>();
            if (damage != null)
            {
                damage.DamageTaken(dano);
            }

        }
        yield return new WaitForSeconds(0.5f);
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
