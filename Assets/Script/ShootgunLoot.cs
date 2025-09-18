using UnityEngine;

public class ShootgunLoot : Interactable
{
    [SerializeField] WeaponManager _weaponManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        _weaponManager.weapon = 2;
        Destroy(gameObject);
    }
}
