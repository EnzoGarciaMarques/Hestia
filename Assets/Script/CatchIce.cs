using UnityEngine;

public class CatchIce : Interactable
{
    [SerializeField] GameObject fogo;
    [SerializeField] GameObject cura;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact()
    {
        if (FireBall.instance.magic != 2 && FireBall.instance.magic != 0)
        {
            if (WeaponManager.instance.weapon == 3)
            {
                Instantiate(cura, ManagerLevel.instance.spawnLoot.transform.position, ManagerLevel.instance.transform.rotation);
            }
            else if (WeaponManager.instance.weapon == 1)
            {
                Instantiate(fogo, ManagerLevel.instance.spawnLoot.transform.position, ManagerLevel.instance.transform.rotation);
            }
        }
        FireBall.instance.magic = 2;
        Destroy(gameObject);
    }
}
