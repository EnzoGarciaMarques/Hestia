using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class RevolverLoot : Interactable
{

    [SerializeField] GameObject spingarda;
    [SerializeField] GameObject espada;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact()
    {
        if (WeaponManager.instance.weapon != 1 && WeaponManager.instance.weapon != 0)
        {
            if (WeaponManager.instance.weapon == 3)
            {
                Instantiate(espada, ManagerLevel.instance.spawnLoot.transform.position, ManagerLevel.instance.transform.rotation);
            }
            else if (WeaponManager.instance.weapon == 2)
            {
                Instantiate(spingarda, ManagerLevel.instance.spawnLoot.transform.position, ManagerLevel.instance.transform.rotation);
            }
        }

        WeaponManager.instance.weapon = 1;
       
        Destroy(gameObject);
    }
}
