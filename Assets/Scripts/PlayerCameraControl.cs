using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraControl : MonoBehaviour
{
    public PlayerFighting FightInfo;
    public GameObject MainCam;
    public GameObject AimCam;
    public GameObject Crosshair;
    public Transform Spot;
    public float dis = 50f;

    // Start is called before the first frame update
    void Start()
    {
        FightInfo = DemoGameManager.demoGM.PFight;
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    public float GetAxisCustom(string axisName)
    {
        if (axisName == "Mouse X")
        {
            if (Input.GetMouseButton(1))
            {
                return UnityEngine.Input.GetAxis("Mouse X");
            }
            else
            {
                return 0;
            }
        }
        else if (axisName == "Mouse Y")
        {
            if (Input.GetMouseButton(1))
            {
                return UnityEngine.Input.GetAxis("Mouse Y");
            }
            else
            {
                return 0;
            }
        }
        return UnityEngine.Input.GetAxis(axisName);
    }

    public void SetCursorPos()
    {
     
        Ray ray = new Ray(Spot.position, Spot.forward);

        Vector3 pos = ray.GetPoint(dis);
        Vector3 screenpos = Camera.main.WorldToScreenPoint(pos);
        Crosshair.transform.position = screenpos;
    }

    public void LateUpdate()
    {
        SetCursorPos();
    }

    // Update is called once per frame
    void Update()
    {
        AimCam.transform.rotation = Camera.main.transform.rotation;
       

        if(FightInfo.CurrentFightMode == PlayerFighting.FightMode.gun)
        {
            MainCam.SetActive(false);
            AimCam.SetActive(true);

            Crosshair.SetActive(true);
        }
        else
        if(FightInfo.CurrentFightMode == PlayerFighting.FightMode.sword)
        {
            MainCam.SetActive(true);
            AimCam.SetActive(false);
            Crosshair.SetActive(false);
        }
    }
}
