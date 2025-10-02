using UnityEngine;

public class ManagerLevel : MonoBehaviour
{
    public float inimigos;
    [SerializeField] bool lootSpawned = false;
    GameObject loot;
    [SerializeField] GameObject spawnLoot;
    [SerializeField] GameObject fire;
    [SerializeField] GameObject ice;
    [SerializeField] GameObject amplifier;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject revolver; 
    [SerializeField] GameObject sword;
    [SerializeField] GameObject cadeado;
    Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }
    private void Update()
    {
        if (inimigos == 0 && !lootSpawned)
        {
            Loot();
            cadeado.SetActive(false);
            col.enabled = true;
        }
    }
    void Loot()
    {
        lootSpawned = true;
        float nowLoot = Random.Range(1, 7);
        if (nowLoot == 1)
        {
            if (FireBall.instance.magic != 1)
            {
                loot = fire;
            }
            else
            {
                lootSpawned = false;
            }

        }
        else if (nowLoot == 2)
        {

            if (FireBall.instance.magic != 2)
            {
                loot = ice;
            }
            else
            {
                lootSpawned = false;
            }
        }
        else if (nowLoot == 3)
        {
            if (FireBall.instance.magic != 3)
            {
                loot = amplifier;
            }
            else
            {
                lootSpawned = false;
            }
        }
        else if (nowLoot == 4)
        {
            if (WeaponManager.instance.weapon != 2)
            {
                loot = shotgun;
            }
            else
            {
                lootSpawned = false;
            }
        }
        else if (nowLoot == 5)
        {
            if (WeaponManager.instance.weapon != 1)
            {
                loot = revolver;
            }
            else
            {
                lootSpawned = false;
            }
        }
        else if (nowLoot == 6)
        {
            if (WeaponManager.instance.weapon != 3)
            {
                loot = sword;
            }
            else
            {
                lootSpawned = false;
            }
        }
        if (lootSpawned == true) 
        { 
            Instantiate(loot, spawnLoot.transform.position, transform.rotation);
        }
    }
}
