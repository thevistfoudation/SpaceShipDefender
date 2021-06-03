using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JinGroupUnityBase.Base.Plane;

public class GameController : MonoBehaviour
{
    public int scoreplayer;
    public static GameController instance;
    public Text score;
    public GameObject panelover;
    public GameObject panelWin;
    public GameObject panelPause;
    public GameObject panelSetting;
    public GameObject player;
    public GameObject Video;
    public GameObject vid;
    public GameObject GaoCannon;
    public GameObject Boss;
    public GameObject Gate1;
    public GameObject Caution;
    public GameObject Rocket;
    public GameObject ButtonShoot;
    public Button shoot;
    public GameObject Sound;
    public int coin;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       // _coin();
        Time.timeScale = 1;
        scoreplayer = 0;
        coin = JsonUtility.FromJson<inven>(PlayerPrefs.GetString("DATA")).coin;
        Debug.Log("coin :" +coin  );
        Debug.Log("SOluongitem1: " + JsonUtility.FromJson<inven>(PlayerPrefs.GetString("DATA")).item1);
    }
    // Update is called once per frame
    void Update()
    {
        wingame();
        //endgame();
        score.text = "score : " + scoreplayer.ToString();
        if (scoreplayer >= 0 && scoreplayer <= 250)
        {
            GunController.instance.BulletLevel = 1;
        }
        if (scoreplayer > 250 && scoreplayer <= 550)
        {
            GunController.instance.BulletLevel = 1.5f;
        }
        if (scoreplayer > 550 && scoreplayer <= 950)
        {
            GunController.instance.BulletLevel = 2;
        }
        if (scoreplayer > 950 && scoreplayer <= 1650)
        {
            GunController.instance.BulletLevel = 2.5f;
        }
        if (scoreplayer > 1650 && scoreplayer <= 1700)
        {
            Caution.SetActive(true);
            LeanTween.delayedCall(3f, () =>
            {
                Caution.SetActive(false);
            });
            GaoCannon.SetActive(true);
            GunController.instance.BulletLevel = 3f;
        }
        if (scoreplayer > 1700 && scoreplayer <= 2000) 
        {
            Gate1.SetActive(false);
            Boss.SetActive(true);
        }
    }
    public void ShootRocket()
    {
        Debug.Log("ban chiu chiu");
        Instantiate(Rocket);
        ButtonShoot.SetActive(false);
        shoot.interactable = false;
        LeanTween.delayedCall(30f, () =>
            {
                 ButtonShoot.SetActive(true);
                shoot.interactable = true;
            });
    }
    public void playSound()
    {
        Sound.SetActive(false);
    }
    public void Exit()
    {
        panelSetting.SetActive(false);
    }
    public void Setting()
    {
        panelSetting.SetActive(true);
    }
    public void addscore()
    {
        scoreplayer += 10;
    }
    public void endgame()
    {
        panelover.SetActive(true);
       // save();
        Time.timeScale = 0;
    }
    public void Playagain()
    {
        SceneManager.LoadScene(0);
    }
    public void wingame()
    {
        if (Boss.GetComponent<HpController>().hpenemy <= 0)
        {
            scoreplayer += 1000;
            panelWin.SetActive(true);
            Time.timeScale = 0;
        }
    }
    //public void restart()
    //{
    //    SceneManager.LoadScene(0);
    //}
    public void Play()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }
    public void PlayVideo()
    {
        vid.SetActive(true);
        Video.SetActive(true);
        Time.timeScale = 0;
        LeanTween.delayedCall(5f, () =>
        {
            vid.SetActive(false);
           // Debug.Log("shutdown");
            Video.SetActive(false);
           // Debug.Log("shutdown2");
            Time.timeScale = 1;
            
        }).setIgnoreTimeScale(true);
    }
    //void save()
    //{
    //    data _data = new data
    //    {
    //        score = scoreplayer,
            
    //    };
    //    PlayerPrefs.SetString("DATA", JsonUtility.ToJson(_data));
    //}
    //void gettt(string js)
    //{
    //    scoreplayer =  JsonUtility.FromJson<data>(PlayerPrefs.GetString("DATA")).score;
    //}
    //class data
    //{
    //    public int score,coin;
    //}
    public void buy(int n)
    {
        switch(n)
        {
            case 1: // mua item 1
              int _item1 =  JsonUtility.FromJson<inven>(PlayerPrefs.GetString("DATA")).item1 += 1;
              int _coin =   JsonUtility.FromJson<inven>(PlayerPrefs.GetString("DATA")).coin -= 1000;

                inven iv = new inven
                {
                    coin = _coin,
                    item1 = _item1
                };

                PlayerPrefs.SetString("DATA", JsonUtility.ToJson(iv));
                break;
        }
    }
    void showinven(string js)
    {
        int coin = JsonUtility.FromJson<inven>(js).coin;
        int item1 = JsonUtility.FromJson<inven>(js).item1;
        int item2 = JsonUtility.FromJson<inven>(js).item2;
    }

    class inven
    {
        public int coin;
        public int item1, item2;
    }
    void _coin()
    {
        inven iv = new inven
        {
            coin = 10000,
        };
        PlayerPrefs.SetString("DATA", JsonUtility.ToJson(iv));
    }
}


