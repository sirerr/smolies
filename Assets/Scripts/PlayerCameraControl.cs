using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraControl : MonoBehaviour
{
    public PlayerFighting FightInfo;
    public Camera MainCam;
    public Camera AimCam;

    // Start is called before the first frame update
    void Start()
    {
        FightInfo = DemoGameManager.demoGM.PFight;
    }

    // Update is called once per frame
    void Update()
    {
        if(FightInfo.CurrentFightMode == PlayerFighting.FightMode.gun)
        {
            MainCam.enabled = false;
            AimCam.enabled =true;
        }
        else
        if(FightInfo.CurrentFightMode == PlayerFighting.FightMode.sword)
        {
            MainCam.enabled = true;
            AimCam.enabled = false;
        }
    }
}
