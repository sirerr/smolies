using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HubUI : MonoBehaviour
{
    public TMP_Text PlayerHealth;
    public TMP_Text PlayerEnergy;
     


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerGUI();
        
    }

    public void PlayerGUI()
    {
        PlayerHealth.text = DemoGameManager.demoGM.PlayerHealth.ToString("F0");
        PlayerEnergy.text = DemoGameManager.demoGM.PlayerEnergy.ToString("F0");
    }
}
