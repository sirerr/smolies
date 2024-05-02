using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGround : MonoBehaviour
{
    public bool PlayerInSpace = false;
    public float EnergyAmount = 10f;
    public PlayerInfo InfoRef;
    public float TransferAmount = .25f;
    public float TranferTimeSpeed = .5f;
   public bool EmptyPower = false;
    public void EnergyExpression()
    {
        if(PlayerInSpace && !EmptyPower)
            StartCoroutine(StartTranfer());
    }

   IEnumerator StartTranfer()
    {
        while(PlayerInSpace && EnergyAmount>0)
        {
            yield return new WaitForSeconds(TranferTimeSpeed);
            InfoRef.playerEnergy += TransferAmount;
            EnergyAmount -= TransferAmount;

        }

        if(EnergyAmount ==0)
        {
            EmptyPower = true;
        }
    }
}
