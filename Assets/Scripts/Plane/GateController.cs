using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JinGroupUnityBase.Base.Plane {
    public class GateController : MonoBehaviour
    {

        #region Var
        public GameObject[] poinSpawn;
        //mảng cái cổng thả
        public GameObject[] poinSpawn1;
        //mảng các cổng thả item
       
        public GameObject[] enemy;
        // tập hợp enemy
        public GameObject[] item;
        // tập hợp các Item
       
        #endregion


        #region Unity Method

        void Start()
        {
            StartCoroutine(Spawn());
            StartCoroutine(spawnItem());
           
        }
        IEnumerator Spawn()
        {//hàm thả random tự do quân địch bay xuống (ko chịu tác dụng của trọng lực)
            while (true)
            {
                int randomIndex = Random.Range(0, enemy.Length);
                int randomIndex1 = Random.Range(0, poinSpawn.Length);
                GameObject instantiatedObject = Instantiate(enemy[randomIndex], poinSpawn[randomIndex1].transform.position, Quaternion.identity) as GameObject;
                yield return new WaitForSeconds(1f);
            }
        }
        IEnumerator spawnItem()
        { //hàm random thả tự do item rơi xuống(chịu tác dụng của trọng lực )
            while (true)
            {
                int randomIndex = Random.Range(0, item.Length);
                int randomIndex1 = Random.Range(0, poinSpawn1.Length);
                GameObject instantiatedObject = Instantiate(item[randomIndex], poinSpawn1[randomIndex1].transform.position, Quaternion.identity) as GameObject;
                yield return new WaitForSeconds(5f);
            }
        }
      
        
    }
    #endregion
}

