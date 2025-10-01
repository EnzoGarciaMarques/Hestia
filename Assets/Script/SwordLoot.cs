using UnityEngine;

public class SwordLoot : Interactable
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
        WeaponManager.instance.weapon = 3;
        Destroy(gameObject);
    }
}
