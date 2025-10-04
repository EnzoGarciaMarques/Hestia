using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAir : MonoBehaviour
{
    public float speed = 7;
    public float shootingRange = 5f;
    public GameObject Bala;
    public Transform Balapos;
    private float timer;
    private GameObject player;
    bool ice = false;
    Animator anim;
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
                        if (timer > 2)
                        {
                            timer = 0;
                            SFXManager.Instance.PlaySoundFXClip(attack, transform, 1f);
                            shoot();
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
    
    void shoot()
    {
        anim.SetBool("ataque", true);
        Quaternion direct = Quaternion.Euler(90, 0, transform.rotation.y); 
        Instantiate(Bala, Balapos.position, direct);
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
