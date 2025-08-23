using UnityEngine;

public class Carrots : Interactable
{
    [SerializeField] Quests quests;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        quests.carrots += 1;
    }
}
