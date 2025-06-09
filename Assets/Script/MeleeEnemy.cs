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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
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
            }
        }

        
    }


    IEnumerator Punch()
    {
        atacking = true;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, lenghtAtack))
        {
            print("Pegou");
        }
        yield return new WaitForSeconds(1);
        atacking = false;
    }

}
