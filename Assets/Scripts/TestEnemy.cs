using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestEnemy : MonoBehaviour
{
    public int LifeCount = 0;
    public float RotateSpeed = 10f;
    //enemy health
    public TMP_Text CurrentLifeCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, RotateSpeed * Time.deltaTime, Space.World);
        CurrentLifeCounter.text = LifeCount.ToString("F0");
    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.transform.CompareTag("sword") || col.transform.CompareTag("bullet"))
        {
            //print("this is a hit test");
            LifeCount--;
        }
    }
}
