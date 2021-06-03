using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float hpenemy;
    public float hpplayer;
    public float hppGao;
    public static HpController instance;
    public Slider slider_hp;
  

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        slider_hp.maxValue = hpplayer;
    }
    void Update()
    {
        //Debug.Log(hpenemy);
        slider_hp.value = hpplayer;
    }
    public void MinusHp(int damage)
    {
        hpenemy -= damage;
    }
    public void MinusHpplayer(int damage)
    {
        hpplayer -= damage;
    }
    public void MiniusHpGao(int damage)
    {
        hppGao -= damage;
    }
    public void PlusHp(int hpItem)
    {
        hpplayer += hpItem;
    }
    public void striker(int damage)
    {
        hpplayer -= damage;
    }
}

