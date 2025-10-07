using UnityEngine;

public class MoquitoDano : MonoBehaviour
{
    float health = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Hit(float ammount)
    {
        health -= ammount;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            Hit(20);
        }
    }
}
