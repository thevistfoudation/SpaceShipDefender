using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JinGroupUnityBase.Base.Plane
{
    public class BackGroundController : MonoBehaviour
    {
        public static BackGroundController instance;
        #region Var
        [SerializeField]
        public float scrollspeed;
        Vector2 startPos;
        #endregion
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        #region Unity Method
        void Start()
        {
            startPos = transform.position;
        }

        void Update()
        {
            float newPos = Mathf.Repeat(Time.time * scrollspeed, 10);
            transform.position = startPos - Vector2.up * newPos;
        }
        #endregion
    }
}
//tạo 2 mảng background khác nhau rồi ad scripts vào cả hai mảng 
