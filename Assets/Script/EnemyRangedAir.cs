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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
       float distance = Vector2.Distance(transform.position, player.transform.position);
        
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
        // If not within shooting range, chase the player
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
    
    void shoot()
    {
        Instantiate(Bala, Balapos.position, Quaternion.identity);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bala"))
        {
            Destroy(gameObject);

            Destroy(other.gameObject);
        }
    }
}
