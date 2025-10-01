using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;
    [SerializeField] float rotatez;
    [SerializeField] float rotatey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Quests.instance.rescue == true) 
        {
            Vector3 aberto = new Vector3(x, y, z);
            transform.position = aberto;
            Vector3 currentRotation = transform.eulerAngles;
            transform.eulerAngles = new Vector3(currentRotation.x, rotatey, rotatez);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
