using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField] float dano;
    [SerializeField] float range;
    [SerializeField] float attackTimer;

    [SerializeField] Camera cameras;
    [SerializeField] ParticleSystem particula;

    float nextTimeToSlash = 0f;
    bool isReloading;

    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        text.text = "Melee";
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToSlash)
        {
            nextTimeToSlash = Time.time + 1f / attackTimer;
            Slash();
        }


    }

    void Slash()
    {
        particula.Play();
        RaycastHit hit;
        if (Physics.Raycast(cameras.transform.position, cameras.transform.forward, out hit, range))
        {
            DamageEnemy damage = hit.transform.GetComponent<DamageEnemy>();
            if (damage != null)
            {
                damage.TakeDamage(dano);
            }
        }

    }
}
