using UnityEngine;

public class CatchIce : Interactable
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
        magic.magic = 2;
        Destroy(gameObject);
    }
}
