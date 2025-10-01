using UnityEngine;

public class ShootgunLoot : Interactable
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        WeaponManager.instance.weapon = 2;
        Destroy(gameObject);
    }
}
