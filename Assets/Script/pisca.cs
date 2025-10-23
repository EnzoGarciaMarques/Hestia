using System.Collections;
using UnityEngine;

public class pisca : MonoBehaviour
{
    float timer;
    float tempo;
    float piscadinha;
    [SerializeField] GameObject luz;
    bool apagado = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempo = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > tempo && !apagado)
        {
            timer = 0;
            apagado = true;
            StartCoroutine(Piscada());
        }

    }
    IEnumerator Piscada()
    {
        luz.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        luz.SetActive (true);
        yield return new WaitForSeconds(0.2f);
        luz.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        luz.SetActive(true);
        timer = 0;
        apagado = false;

    }
}
