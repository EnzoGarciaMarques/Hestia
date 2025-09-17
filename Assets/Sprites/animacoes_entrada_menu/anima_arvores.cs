using System.Collections;
using UnityEngine;

public class anima_arvores : MonoBehaviour
{
    Animator anima;
    [SerializeField] GameObject arvore;
    [SerializeField] GameObject arvore1;
    [SerializeField] GameObject arvore2;
    [SerializeField] GameObject arvore3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anima = GetComponent<Animator>();
        Debug.Log("setou");
        StartCoroutine(Cadencia());

    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator Cadencia()
    {
        arvore2.GetComponent<Animator>().SetTrigger("go");
        yield return new WaitForSeconds(2);
        arvore1.GetComponent<Animator>().SetTrigger("go");
        yield return new WaitForSeconds(2);
        arvore.GetComponent<Animator>().SetTrigger("go");
        yield return new WaitForSeconds(2);
        arvore3.GetComponent<Animator>().SetTrigger("go");

    }


}
