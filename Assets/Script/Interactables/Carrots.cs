using UnityEngine;

public class Carrots : Interactable
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
        Quests.instance.carrots += 1;
        Destroy(gameObject);
    }
}
