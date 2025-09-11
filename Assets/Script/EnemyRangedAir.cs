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
            float distance = Vector3.Distance(transform.position, player.transform.position);

            // If within shooting range, shoot at intervals
            if (distance < shootingRange)
            {
                timer += Time.deltaTime;
                if (timer > 2)
                {
                    timer = 0;
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
    
    void shoot()
    {
        anim.SetBool("ataque", true);

        Instantiate(Bala, Balapos.position, Quaternion.identity);
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
        ice = true;
        yield return new WaitForSeconds(2);
        ice = false;
    }
}
