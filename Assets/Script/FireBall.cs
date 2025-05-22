using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] GameObject fireBallPrefab;
    [SerializeField] Transform ejectFire;
    [SerializeField] float cooldown;
    [SerializeField] float velocity;
    bool onCooldown = false;
    public float damage;
    public int level = 0;
    [SerializeField] float upgradePerLevel;
    void Start()
    {
        damage = damage + upgradePerLevel * level;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && !onCooldown)
        {
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        onCooldown = true;
        GameObject fireBall = Instantiate(fireBallPrefab, ejectFire.position, Quaternion.identity);
        fireBall.GetComponent<Rigidbody>().AddForce(ejectFire.forward.normalized * velocity, ForceMode.Impulse);
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider)
        {
            Destroy(gameObject);
        }
    }
}
