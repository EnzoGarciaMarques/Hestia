using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : Interactable
{
    [SerializeField] string fase;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact()
    {
        SceneManager.LoadScene(fase);
    }
}
