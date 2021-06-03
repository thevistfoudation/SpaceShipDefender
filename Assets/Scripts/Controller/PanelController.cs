using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public Text Score1;
    public Text Level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score1.text = " " + GameController.instance.scoreplayer.ToString();

        //if(GameController.instance.scoreplayer <= 0 && GameController.instance.scoreplayer >10)
        //{
        //    Level.text = "Level:" + 1;
        //}
        //if (GameController.instance.scoreplayer <= 10 && GameController.instance.scoreplayer > 100)
        //{
        //    Level.text = "Level: ";
        //}
        //if (GameController.instance.scoreplayer <= 100 && GameController.instance.scoreplayer > 200)
        //{
        //    Level.text = "Level: ";
        //}
        //if (GameController.instance.scoreplayer <= 200 && GameController.instance.scoreplayer > 350)
        //{
        //    Level.text = "Level: ";
        //}

    }
}
