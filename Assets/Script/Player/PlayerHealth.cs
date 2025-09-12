using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    public Transform camTransform;


    public float shakeDuration = 0f;

    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;


    private void Start()
    {
        originalPos = camTransform.localPosition;
    }
    private void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }
    public void DamageTaken(float amount)
    {
        Debug.Log("tomou");
        shakeDuration = 1;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            DamageTaken(10);
        }
        if (other.gameObject.CompareTag("EnemySlash"))
        {
            DamageTaken(10);
        }
    } 

}
