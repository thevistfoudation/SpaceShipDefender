using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyController : MoveController
{
    #region Var
    public GameObject exp;
    public GameObject Gun;
    //public GameObject Transhoot;
    public int damage;
    Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    #endregion

    #region Unity Method
    void Start()
    {
       // player = GameObject.Find("Ship").transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        base.MoveDown(transform.up);
        //Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * 100f;
        //rb.rotation = angle;
        //direction.Normalize();
        //movement = direction;
        //this.transform.position = Vector2.MoveTowards(this.transform.position, player.position, 0.01f);
        ////hàm di chuyển kẻ địch theo player 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("trungdan");

           // SoundsController.instance.playSound(AudioIndex.Hit);
            if (this.GetComponent<HpController>().hpenemy <= 0)
            {
                Destroy(gameObject);
                GameObject go = Instantiate(exp, collision.transform.position, quaternion.identity);
                SoundsController.instance.playSound(AudioIndex.Explosion);
               //Instantiate(bullet, TranShoot.transform.position, Quaternio
                Destroy(go, 0.7f);
                GameController.instance.addscore();
                Debug.Log("tan xac ");
            }
           else if(this.GetComponent<HpController>().hpenemy > 0)
            {
                GetComponent<HpController>().hpenemy -= collision.gameObject.GetComponent<BulletController>().damage;
                Debug.Log("Trừ máu");
            }
        }
        if (collision.gameObject.tag == "Deathzone")
        {
            Destroy(this.gameObject);
        }
         if(collision.gameObject.tag == "player")
        {
            Destroy(this.gameObject);
        }
         if (collision.gameObject.tag == "Shield")
        {
            Destroy(this.gameObject);
            //GameObject go = Instantiate(exp, collision.transform.position, quaternion.identity);
            //Destroy(go, 0.7f);
        }
    }
    #endregion
}
