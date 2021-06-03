using System.Collections;
using System.Collections.Generic;
using LTAUnityBase.Base.UI;
using UnityEngine;

public enum ShipImage
{
    ship0,
    ship1,
    ship2,
    ship3,
    ship4,
    ship5,
    //ship6,
    //ship7
}
public class MenuController : MonoBehaviour
{

    public ButtonController Btn1, Btn2, Btn3, Btn4, Btn5, Btn6;
    public ButtonController LV1, LV2, LV3, LV4, LV5, LV6, LV7, LV8, LV9, LV10, LV11, LV12;
    // Start is called before the first frame update
    void Start()
    {
        Btn1.OnClick((ButtonController btn) => {
            Globalvar.StateImage = ShipImage.ship0;
        });
        Btn2.OnClick((ButtonController btn) => {
            
            Globalvar.StateImage = ShipImage.ship1;
        });
        Btn3.OnClick((ButtonController btn) => {
            Globalvar.StateImage = ShipImage.ship2;
        });
        Btn4.OnClick((ButtonController btn) => {

            Globalvar.StateImage = ShipImage.ship3;
        });
        Btn5.OnClick((ButtonController btn) => {
            
            Globalvar.StateImage = ShipImage.ship4;
        }); 
        Btn6.OnClick((ButtonController btn) => {
            Globalvar.StateImage = ShipImage.ship5;
        }); 
        //Btn7.OnClick((ButtonController btn) => {
        //    Globalvar.StateImage = ShipImage.ship6;
        //}); 
        //Btn8.OnClick((ButtonController btn) => {
        //    Globalvar.StateImage = ShipImage.ship7;
        //});

        LV1.OnClick((ButtonController btn) => {
            SceneController.OpenScene(AllSceneName.Game1);
        });
        LV2.OnClick((ButtonController btn) => {
            SceneController.OpenScene(AllSceneName.Game1);
        });
       
        LV3.OnClick((ButtonController btn) => {
            SceneController.OpenScene(AllSceneName.Game1);
        });
        LV4.OnClick((ButtonController btn) => {
            SceneController.OpenScene(AllSceneName.Game1);
        });
        LV5.OnClick((ButtonController btn) => {
            SceneController.OpenScene(AllSceneName.Game1);
        });
        LV6.OnClick((ButtonController btn) => {
            SceneController.OpenScene(AllSceneName.Game1);
        });
        LV7.OnClick((ButtonController btn) => {
            SceneController.OpenScene(AllSceneName.Game1);
        });
        LV8.OnClick((ButtonController btn) => {
            SceneController.OpenScene(AllSceneName.Game1);

        });
        LV9.OnClick((ButtonController btn) => {
            SceneController.OpenScene(AllSceneName.Game1);
        });
        LV10.OnClick((ButtonController btn) => {
            SceneController.OpenScene(AllSceneName.Game1);
        });
        LV11.OnClick((ButtonController btn) => {
            SceneController.OpenScene(AllSceneName.Game1);
        });
        LV12.OnClick((ButtonController btn) => {
            SceneController.OpenScene(AllSceneName.Game1);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
