using UnityEngine;

public class Abajur : MonoBehaviour
{
    [SerializeField] bool abajurQuebrado;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Quests.instance.rescue)
        {
            if (abajurQuebrado)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive (true);
            }
        }
    }
}
