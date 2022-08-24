using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Base_Particle
{
    // Start is called before the first frame update
    void Start()
    {
        m_state = ParticleState.liquid;
        m_temp = 20f;
        m_size = 1;
        mass = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckNearby();
    }


    public override void TempCheck()
    {
     
    }
    public override void CheckNearby()
    {
        Collider2D[] cols = new Collider2D[50];
        ContactFilter2D filt = new ContactFilter2D();
        Physics2D.OverlapCircle(transform.position, 10, filt, cols);

        foreach (Collider2D col in cols)
        {
            if (col.gameObject.GetComponent<Base_Particle>())
            {
                Vector2 force;
                float xTemp = Mathf.Abs(col.gameObject.transform.position.x - transform.position.x);
                float x = xTemp * xTemp;
                float yTemp = Mathf.Abs(col.gameObject.transform.position.y - transform.position.y);
                float y = yTemp * yTemp;

                force = ((col.gameObject.transform.position - transform.position) * Mathf.Sqrt(x + y)).normalized;

                float distance = Vector2.Distance(transform.position, col.gameObject.transform.position);

                force *= (-9.8f) * ((col.gameObject.GetComponent<Base_Particle>().mass * this.mass) / (distance * distance));



                col.gameObject.GetComponent<Rigidbody2D>().AddForce(force);
            }
        }

    }
}

