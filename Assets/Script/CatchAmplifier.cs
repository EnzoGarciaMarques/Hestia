using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchAmplifier : Interactable
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
        FireBall.instance.magic = 3;
        Destroy(gameObject);
    }
}
