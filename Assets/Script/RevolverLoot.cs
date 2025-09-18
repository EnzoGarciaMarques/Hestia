using UnityEngine;

public class RevolverLoot : Interactable
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
        _weaponManager.weapon = 1;
        Destroy(gameObject);
    }
}
