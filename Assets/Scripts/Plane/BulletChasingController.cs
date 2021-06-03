﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

namespace JinGroupUnityBase.Plane
{
    public class BulletChasingController : MoveController
    {
        public GameObject exp;
        
        //exp là Explosion
        public int damage;
        public int time = 0;
        GameObject posTarget;
        public bool enemy;
        Vector2 PlayerPos;
        public static BulletChasingController instance;
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
            if (enemy)
            {
                posTarget = GameObject.Find("Ship1");
                //tìm theo tên 
                PlayerPos = posTarget.transform.position;
                Vector2 direction = new Vector2(posTarget.transform.position.x - transform.position.x, posTarget.transform.position.y - transform.position.y);
                transform.up = direction;
            }
        }
        // Update is called once per frame
        void Update()   
        {
            if (!enemy)
            {
                base.Move(transform.up);
                return;
            }
            else if (this.transform.position.x == PlayerPos.x)
            {
                Destroy(this.gameObject);
            }
            else
            {
                this.transform.position = Vector2.MoveTowards(transform.position, PlayerPos, speed);
            }
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

    }
}
// class đạn đuổi theo mục tiêu đã đc gắn tên 
