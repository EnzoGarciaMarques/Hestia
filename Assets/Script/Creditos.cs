using UnityEngine;
using UnityEngine.UIElements;

public class Creditos : Interactable
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
        Vector3 currentRotation = transform.eulerAngles;
        transform.eulerAngles = new Vector3(currentRotation.x, currentRotation.y, currentRotation.z * -1);
    }
}
