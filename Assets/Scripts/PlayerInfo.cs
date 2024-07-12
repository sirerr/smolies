using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public float playerhealth = 0f;
    public float playerhealthlimit = 100f;
    public float playerEnergy = 0f;
    public float playerEnergyLimit = 100f;
    public PlayerInputMove playerinput;
    public bool UseEnergy = true;
    public float DecreaseEnergySpeed = .25f;

    // Start is called before the first frame update
    private void Awake()
    {
      
    }

    void Start()
    {
        DemoGameManager.demoGM.PInfo = this;
        playerhealth = playerhealthlimit;
      
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameManager();
        if(playerhealth<playerhealthlimit)
        {
            playerhealth += .01f;
        }
    }

    public void UpdateGameManager()
    {
        DemoGameManager.demoGM.PlayerHealth = playerhealth;
        DemoGameManager.demoGM.PlayerEnergy = playerEnergy;
    }

    public void DecreasePlayerEnergy()
    {
        StartCoroutine(DecreaseEnergy());
    }

    IEnumerator DecreaseEnergy()
    {
        UseEnergy = false;
        while(!UseEnergy)
        {
            yield return new WaitForSeconds(DecreaseEnergySpeed);
            playerEnergy -= DecreaseEnergySpeed;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("efloor"))
        {

            EnergyGround ground = col.GetComponent<EnergyGround>();
            ground.InfoRef = this;
            ground.PlayerInSpace = true;
            ground.EnergyExpression();
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("efloor"))
        {
            EnergyGround ground = col.GetComponent<EnergyGround>();
            ground.PlayerInSpace = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        
        if(collision.transform.CompareTag("enemy"))
        {
            playerhealth = playerhealth -3f;
        }
    }
}
