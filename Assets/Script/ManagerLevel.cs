using UnityEngine;

public class ManagerLevel : MonoBehaviour
{
    public float inimigos;
    [SerializeField] bool lootSpawned = false;
    GameObject loot;
    [SerializeField] public GameObject spawnLoot;
    [SerializeField] GameObject fire;
    [SerializeField] GameObject ice;
    [SerializeField] GameObject amplifier;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject revolver; 
    [SerializeField] GameObject sword;
    [SerializeField] GameObject cadeado;
    Collider col;
    public static ManagerLevel instance;
    private void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
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
                spawnerLoot();
            }
            else
            {
                Loot();
            }

        }
        else if (nowLoot == 2)
        {

            if (FireBall.instance.magic != 2)
            {
                loot = ice;
                spawnerLoot();
            }
            else
            {
                Loot();
            }
        }
        else if (nowLoot == 3)
        {
            if (FireBall.instance.magic != 3)
            {
                loot = amplifier;
                spawnerLoot();
            }
            else
            {
                Loot();
            }
        }
        else if (nowLoot == 4)
        {
            if (WeaponManager.instance.weapon != 2)
            {
                loot = shotgun;
                spawnerLoot();
            }
            else
            {
                Loot();
            }
        }
        else if (nowLoot == 5)
        {
            if (WeaponManager.instance.weapon != 1)
            {
                loot = revolver;
                spawnerLoot();
            }
            else
            {
                Loot();
            }
        }
        else if (nowLoot == 6)
        {
            if (WeaponManager.instance.weapon != 3)
            {
                loot = sword;
                spawnerLoot();
            }
            else
            {
                Loot();
            }
        }
    }

    void spawnerLoot()
    {
        Instantiate(loot, spawnLoot.transform.position, transform.rotation);
    }
}
