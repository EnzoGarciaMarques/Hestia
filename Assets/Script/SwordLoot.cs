using UnityEngine;

public class SwordLoot : Interactable
{
    [SerializeField] GameObject spingarda;
    [SerializeField] GameObject revolver;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact()
    {
        if (WeaponManager.instance.weapon != 3 && WeaponManager.instance.weapon != 0)
        {
            if (WeaponManager.instance.weapon == 1)
            {
                Instantiate(revolver, ManagerLevel.instance.spawnLoot.transform.position, ManagerLevel.instance.transform.rotation);
            }
            else if (WeaponManager.instance.weapon == 2)
            {
                Instantiate(spingarda, ManagerLevel.instance.spawnLoot.transform.position, ManagerLevel.instance.transform.rotation);
            }
        }
        WeaponManager.instance.weapon = 3;
       
        Destroy(gameObject);
    }
}
