using UnityEngine;

public class PortaCorredor : MonoBehaviour
{
    public float loot;

    [SerializeField] GameObject cadeado;
    Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }
    private void Update()
    {
        if (loot == 0)
        {

            cadeado.SetActive(false);
            col.enabled = true;
        }
    }

}
