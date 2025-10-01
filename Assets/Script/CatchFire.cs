using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchFire : Interactable
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
        FireBall.instance.magic = 1;
        Destroy(gameObject);
    }
}
