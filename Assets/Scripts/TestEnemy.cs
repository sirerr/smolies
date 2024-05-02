using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public int LifeCount = 0;
    public float RotateSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, RotateSpeed * Time.deltaTime, Space.World); 
    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.transform.CompareTag("sword"))
        {
            LifeCount--;
        }
    }
}
