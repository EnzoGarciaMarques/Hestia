using UnityEngine;

public class Moquito : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float speed;
    [SerializeField] GameObject moquito1;
    [SerializeField] GameObject moquito2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log($"distance from player: {distance}, playerPos: {player.transform.position}, EnemyPos: {transform.position}");

        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        if (moquito1 == null && moquito2 == null)
        {
            Destroy(gameObject);
        }

    }      
}
