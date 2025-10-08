using System.Collections;
using UnityEngine;

public class Globo : Interactable
{
    public Vector3 anguloRotacao = new Vector3(0, 0, 360);
    public Space espacoRotacao = Space.Self;
    bool giro = false;
    [SerializeField] float tempo;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (giro)
        {
            transform.Rotate(anguloRotacao * Time.deltaTime, espacoRotacao);
        }
    }
    protected override void Interact()
    {
        StartCoroutine(Girar());
    }

    IEnumerator Girar()
    {
        giro = true;
        yield return new WaitForSeconds(tempo);
        giro = false;
    }
}
