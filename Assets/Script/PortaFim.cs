using UnityEngine;
using UnityEngine.SceneManagement;

public class PortaFim : Interactable
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
        PlayerHealth.instance.Dead();
    }
}
