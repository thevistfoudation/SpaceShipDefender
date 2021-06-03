using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using JinGroupUnityBase.Plane;
namespace JinGroupUnityBase.Base.Plane
{
    public class PlaneController : MonoBehaviour
    {
        
        public float deltaX, deltaY;
        public Vector3 pos;
        public GameObject exp;
        public GameObject Shield;
        public GameObject BonusGun;
        public GameObject Wing;
        public GameObject Supporter;
        public GameObject GaoCannon;
        Vector2 touchDeltaPosition;
        Touch touch;
        // Start is called before the first frame update
        void Start()
        {
            deltaX = 0;
            deltaY = 0;
            if (Globalvar.StateImage == ShipImage.ship0)
            {
                Sprite sprite = Resources.Load<Sprite>("SPACE2/space_breaker_asset/Ships/Medium/body_01");
                this.transform.GetComponent<SpriteRenderer>().sprite = sprite;
            }
            if (Globalvar.StateImage == ShipImage.ship1)
            {
                Sprite sprite = Resources.Load<Sprite>("SPACE2/space_breaker_asset/Ships/Medium/body_02");
                this.transform.GetComponent<SpriteRenderer>().sprite = sprite;
            }
            if (Globalvar.StateImage == ShipImage.ship2)
            {
                Sprite sprite = Resources.Load<Sprite>("SPACE2/space_breaker_asset/Ships/Medium/body_03");
                this.transform.GetComponent<SpriteRenderer>().sprite = sprite;
            }
            if (Globalvar.StateImage == ShipImage.ship3)
            {
                Sprite sprite = Resources.Load<Sprite>("SPACE2/space_breaker_asset/Ships/Big/body_01");
                this.transform.GetComponent<SpriteRenderer>().sprite = sprite;
            }
            if (Globalvar.StateImage == ShipImage.ship4)
            {
                Sprite sprite = Resources.Load<Sprite>("SPACE2/space_breaker_asset/Ships/Big/body_02");
                this.transform.GetComponent<SpriteRenderer>().sprite = sprite;
            }
            if (Globalvar.StateImage == ShipImage.ship5)
            {
                Sprite sprite = Resources.Load<Sprite>("SPACE2/space_breaker_asset/Ships/Big/body_03");
                this.transform.GetComponent<SpriteRenderer>().sprite = sprite;
            }
        }
        // Update is called once per frame
        void Update()
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            touch1();
        }
        public void move(Vector3 pos)
        {
            this.transform.position = Vector3.Lerp(transform.position, pos, 5);
            // hàm di chuyển
        }
        public void touch1()
        {
            //hàm chạm di chuyển
            if (Input.touchCount > 0)
            {

                touch = Input.GetTouch(0);
                Vector2 touchpos = Camera.main.ScreenToWorldPoint(touch.position);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        deltaX = touchpos.x - transform.position.x;
                        deltaY = touchpos.y - transform.position.y;
                        break;
                    case TouchPhase.Moved:
                        this.transform.position = new Vector2(touchpos.x - deltaX, touchpos.y - deltaY);
                        //rigidbody.MovePosition(new Vector2(touchpos.x - deltaX, touchpos.y - deltaY));
                        break;
                    case TouchPhase.Ended:
                        transform.position = transform.position;
                        //rigidbody.velocity = Vector2.zero;
                        break;
                }
            }
        }

        IEnumerator aha()
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(4f);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "BulletEnemy")
            {
                if (this.GetComponent<HpController>().hpplayer <= 0)
                {
                    //Destroy(gameObject);
                    GameObject go = Instantiate(exp, collision.transform.position, quaternion.identity);
                    Destroy(go, 0.7f);
                    GameController.instance.endgame();
                }
                else
                {
                    this.GetComponent<HpController>().MinusHpplayer(collision.gameObject.GetComponent<BulletEnemyController>().damage);
                }
            }
            if (collision.gameObject.tag == "meteorStrike")
            {
                Destroy(this.gameObject);
                GameObject go = Instantiate(exp, collision.transform.position, quaternion.identity);
                Destroy(go, 0.7f);

                LeanTween.delayedCall(0.7f, () =>
                {
                    GameController.instance.endgame();
                });
               
            }
            if (collision.gameObject.tag == "Enemy")
            {
                if (this.GetComponent<HpController>().hpplayer <= 0)
                {
                    //Destroy(gameObject);
                    GameObject go = Instantiate(exp, collision.transform.position, quaternion.identity);
                    Destroy(go, 0.7f);
                }
                else
                {
                    this.GetComponent<HpController>().MinusHpplayer(collision.gameObject.GetComponent<EnemyController>().damage);
                }
            }

            if (collision.gameObject.tag == "ShieldItem")
            {
                Debug.Log("shield");
                Shield.SetActive(true);
                
                LeanTween.delayedCall(10f, () =>
                {
                    Shield.SetActive(false);
                });
            }
            if (collision.gameObject.tag == "HpItem")
            {
                Debug.Log("HPP");
                this.GetComponent<HpController>().PlusHp(collision.gameObject.GetComponent<HpItemController>().hpItem);
            }
            if (collision.gameObject.tag == "ItemWeapon")
            {
                Debug.Log("Weapon");
                BonusGun.SetActive(true);
                //BonusGun.GetComponent<GunController>().shooot();

                LeanTween.delayedCall(10f, () =>
                {
                    BonusGun.SetActive(false);
                });

            }
            if (collision.gameObject.tag == "SpeedItem")
            {
                Wing.SetActive(true);
                // BackGroundController.instance.scrollspeed = 5.5f;
                LeanTween.delayedCall(10f, () =>
                {
                    Wing.SetActive(false);
                   // BackGroundController.instance.scrollspeed = 5f;
                });
            }

            if (collision.gameObject.tag == "ItemSupporter")
            {
                Supporter.SetActive(true);
                LeanTween.delayedCall(10f, () =>
                {
                    Supporter.SetActive(false);
                });
            }
            if (collision.gameObject.tag == "ItemSp")
            {
                Shield.SetActive(true);
                LeanTween.delayedCall(8f, () =>
                {
                    Shield.SetActive(false);
                });
                BonusGun.SetActive(true);
                //BonusGun.GetComponent<GunController>().shooot();

                LeanTween.delayedCall(8f, () =>
                {
                    BonusGun.SetActive(false);
                });
                Wing.SetActive(true);
                // BackGroundController.instance.scrollspeed = 5.5f;
                LeanTween.delayedCall(8f, () =>
                {
                    Wing.SetActive(false);
                    // BackGroundController.instance.scrollspeed = 5f;
                });
                Supporter.SetActive(true);
                LeanTween.delayedCall(8f, () =>
                {
                    Supporter.SetActive(false);
                });
            }
            if (collision.gameObject.tag == "GaoCannon")
            {
                GaoCannon.SetActive(true);
                GameController.instance.PlayVideo();
            }
        } 

    }

}

