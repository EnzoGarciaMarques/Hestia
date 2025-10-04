using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchAmplifier : Interactable
{
    [SerializeField] GameObject fogo;
    [SerializeField] GameObject gelo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        if (FireBall.instance.magic != 3 && FireBall.instance.magic != 0)
        {
            if (WeaponManager.instance.weapon == 1)
            {
                Instantiate(fogo, ManagerLevel.instance.spawnLoot.transform.position, ManagerLevel.instance.transform.rotation);
            }
            else if (WeaponManager.instance.weapon == 2)
            {
                Instantiate(gelo, ManagerLevel.instance.spawnLoot.transform.position, ManagerLevel.instance.transform.rotation);
            }
        }
        FireBall.instance.magic = 3;
        Destroy(gameObject);
    }
}
