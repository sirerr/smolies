using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoGameManager : MonoBehaviour
{
    public static DemoGameManager demoGM;
    public float PlayerHealth = 0f;
    public float PlayerEnergy = 0f;
    public PlayerInfo PInfo;
    public PlayerFighting PFight;
    public void Awake()
    {
        demoGM = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
