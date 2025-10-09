using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class valdir : MonoBehaviour
{
    [SerializeField] private CanvasGroup valdirf;
    private bool fade = false;
    [SerializeField] float intesidade;
    [SerializeField] Image porta;
    [SerializeField] float tempo;
    private bool door = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(vvaldir());
    }

    // Update is called once per frame
    void Update()
    {
        if (fade){
            valdirf.alpha -= Time.deltaTime * intesidade;

        }


    }

    IEnumerator vvaldir()
    {
        yield return new WaitForSeconds(tempo);

        fade = true;
        yield return null;

    }
}
