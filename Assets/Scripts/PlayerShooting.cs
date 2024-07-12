using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    PlayerFighting pfighting;
    public enum FireMode {oneshot,auto};
    public FireMode CurrentFireMode;
     

    public float WaitTime = .5f;
    public bool FirstShot = true;
    bool GetTime = false;
    float quickTime;

    //weapon info
    public GameObject bullet;
    public float bulletspeed = 100f;
    public Transform CreatePoint;
    public int AmmoCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        pfighting = GetComponent<PlayerFighting>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireWeapon()
    {
        
        if (!GetTime)
        { 
            quickTime = Time.time;
            if (FirstShot)
            {
                ObjectCreation();
                FirstShot = false;
            }
            

            GetTime = true;
        }

       // DemoGameManager man = DemoGameManager.demoGM;

        if(AmmoCount>0 && pfighting.CurrentFightMode == PlayerFighting.FightMode.gun )
        {
            switch (CurrentFireMode)
            {
                case FireMode.auto:
                    if (Time.time >= quickTime + WaitTime)
                    {
                        ObjectCreation();
                       // manager.PlayerEnergy--;
                        GetTime = false;
                    }

                    break;
                case FireMode.oneshot:
                     


                    break;
            }
        }

      
    }

    void ObjectCreation()
    {


        GameObject obj = Instantiate(bullet, CreatePoint.position, Quaternion.identity);
        Rigidbody rbody = obj.GetComponent<Rigidbody>();
        rbody.AddForce(CreatePoint.forward * bulletspeed, ForceMode.Acceleration);
        AmmoCount--;
    }

}
