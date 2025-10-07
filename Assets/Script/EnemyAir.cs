using System.Collections;
using UnityEngine;

public class EnemyAir : MonoBehaviour
{
    public float speed = 7;
    public float shootingRange = 5f;
    public GameObject Bala;
    private float timer;
    private GameObject player;
    bool ice = false;
    Animator anim;
    [SerializeField] float y;
    public DamageEnemy mele;
    [SerializeField] AudioClip attack;
    SpriteRenderer spriteRenderer;
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

                    // If within shooting range, shoot at intervals
                    if (distance < shootingRange)
                    {
                        timer += Time.deltaTime;
                        if (timer > 3)
                        {
                            timer = 0;
                            SFXManager.Instance.PlaySoundFXClip(attack, transform, 1f);
                            shoot();
                        }
                        anim.SetBool("voando", false);
                        anim.SetBool("atirando", true);

                    }
                    else
                    {
                        Vector3 direction = (player.transform.position - transform.position).normalized;
                        transform.position += direction * speed * Time.deltaTime;
                        anim.SetBool("voando", true);
                        anim.SetBool("atirando", false);


                    }
                }
            }
        }

    }

    void shoot()
    {
        Instantiate(Bala, transform.position, Quaternion.identity);
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
