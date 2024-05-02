using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraControl : MonoBehaviour
{
    public PlayerFighting FightInfo;
    public GameObject MainCam;
    public GameObject AimCam;

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
            MainCam.SetActive(false);
            AimCam.SetActive(true);
        }
        else
        {
            MainCam.SetActive(true);
            AimCam.SetActive(false);
        }
    }
}
