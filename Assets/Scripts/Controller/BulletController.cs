
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletController : MoveController
{
    public int damage;
    public GameObject exp;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        base.Move(transform.up);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            //GameObject go = Instantiate(exp, collision.transform.position, quaternion.identity);
           // Destroy(go, 0.7f);

        }
        if (collision.gameObject.tag == "Deathzone")
        {
            Destroy(gameObject);

        }
      
    }
    public void rotate(float angel)
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * angel);
    }

}
