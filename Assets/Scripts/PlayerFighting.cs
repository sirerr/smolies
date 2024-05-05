using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighting : MonoBehaviour
{
    public enum FightMode {sword,gun};
    public FightMode CurrentFightMode;
    public PlayerInputMove moves;
    // Start is called before the first frame update
    void Start()
    {
        DemoGameManager.demoGM.PFight = this;
    }
    private void Awake()
    {
        moves = GetComponent<PlayerInputMove>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moves.modepress)
        {
            CurrentFightMode = FightMode.gun;
        }
        else
        {
            CurrentFightMode = FightMode.sword;
        }

    }
}
