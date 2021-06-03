using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
public class BulletEnemyController : MoveController
{
    public int damage;
    public GameObject exp;
    public static BulletEnemyController instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        base.MoveDown(transform.up);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject go = Instantiate(exp, collision.transform.position, quaternion.identity);
            Destroy(go, 0.7f);
        }
        if (collision.gameObject.tag == "GaoCannon")
        {
            Destroy(this.gameObject);
            //  GameObject go = Instantiate(exp, collision.transform.position, quaternion.identity);
            // Destroy(go, 0.7f);
        }
        if (collision.gameObject.tag == "Shield")
        {
            Destroy(this.gameObject);
            Debug.Log("hihigạdgjh");
            //GameObject go = Instantiate(exp, collision.transform.position, quaternion.identity);
            //Destroy(go, 0.7f);

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
