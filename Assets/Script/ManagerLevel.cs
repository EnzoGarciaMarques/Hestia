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
        lootSpawned=true;
        float nowLoot = Random.Range(1, 6);
        if (nowLoot == 1)
        {
            loot = fire;
        }
        else if (nowLoot == 2)
        {
            loot = ice;
        }
        else if (nowLoot == 3)
        {
            loot = amplifier;
        }
        else if (nowLoot == 4)
        {
            loot = shotgun;
        }
        else if (nowLoot == 5)
        {
            loot = revolver;
        }
        else if (nowLoot == 6)
        {
            loot = sword;
        }

        Instantiate(loot, spawnLoot.transform.position, transform.rotation);
    }
}
