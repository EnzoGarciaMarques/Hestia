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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ice == false) {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            print(distance);
            if (!atacking)
            {
                if (distance < meleeRange)
                {
                    timer += Time.deltaTime;
                    if (timer > 1)
                    {
                        timer = 0;
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


    IEnumerator Punch()
    {
        atacking = true;
        yield return new WaitForSeconds(1 / 2);
        anim.SetBool("Batendo", true);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, lenghtAtack))
        {
            print("Pegou");
        }
        yield return new WaitForSeconds(1/2);
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
        ice = true ;
        yield return new WaitForSeconds(2);
        ice = false ;
    }
}
