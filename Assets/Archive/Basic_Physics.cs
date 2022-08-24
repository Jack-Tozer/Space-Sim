using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Physics : MonoBehaviour
{
    public Vector2 initVel;

    public bool Gravity_base;

    public float Multiplier=1f;

    public float Grav_Radius;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = initVel;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] cols = new Collider2D[50];
        ContactFilter2D filt = new ContactFilter2D();
        Physics2D.OverlapCircle(transform.position, Grav_Radius, filt, cols);

        foreach (Collider2D col in cols)
        {
            if (col.gameObject.GetComponent<Basic_Physics>())
            {
                Vector2 force;
                float xTemp = Mathf.Abs(col.gameObject.transform.position.x - transform.position.x);
                float x = xTemp * xTemp;
                float yTemp = Mathf.Abs(col.gameObject.transform.position.y - transform.position.y);
                float y = yTemp * yTemp;

                force = (col.gameObject.transform.position - transform.position) * Mathf.Sqrt(x + y);

                col.gameObject.GetComponent<Rigidbody2D>().AddForce(-force);
            }
        }

    }
}
