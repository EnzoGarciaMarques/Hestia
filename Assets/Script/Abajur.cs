using UnityEngine;

public class Abajur : MonoBehaviour
{
    [SerializeField] GameObject abajurQuebrado;
    [SerializeField] GameObject abajur;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Quests.instance.rescue)
        {
            abajur.SetActive(true);
            abajurQuebrado.SetActive(false);

        }
    }
}
