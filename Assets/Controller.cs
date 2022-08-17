using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float rad;

    public GameObject element;


    void Start()
    {
        int elRad = (int)(rad / element.GetComponent<CircleCollider2D>().radius);
        int area = (int)(Mathf.PI * (rad * rad));

        for (int i = 0; i < area; i++)
        {
            Vector3 newT;
            newT = transform.position + new Vector3(i * element.GetComponent<CircleCollider2D>().radius, i* element.GetComponent<CircleCollider2D>().radius); 
            Instantiate(element, newT, Quaternion.identity);

        }
    }



    void Update()
    {
        
    }
}
