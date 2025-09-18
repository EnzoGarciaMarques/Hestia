using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchFire : Interactable
{
    [SerializeField] FireBall magic;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact()
    {
        magic.magic = 1;
        Destroy(gameObject);
    }
}
