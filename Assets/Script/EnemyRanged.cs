using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyRanged : MonoBehaviour
{
    [SerializeField] Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, target.position, 10 * Time.deltaTime);
    }
}
