using UnityEngine;

public class RevolverLoot : Interactable
{
    [SerializeField] PortaCorredor level;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact()
    {
        level.loot -= 1;
        WeaponManager.instance.weapon = 1;
        Destroy(gameObject);
    }
}
