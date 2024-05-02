using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ECM2;

public class PlayerInputMove : MonoBehaviour
{
    Animator anim;
    int iswalking;
    int isrunning;
    float isMoving;

    PlayerControls input;
    Vector2 currentmovement;
    bool movepress;
    bool runpress;
    bool jumpress;
    bool fightpress;
    bool floatpress;
    public bool modepress;
    CharacterController controller;
    float StartHeight;
    Quaternion rot;


    public Character CharacterRef;
    private CharacterJump Jumping;
    PlayerInfo playerinfo;

    private void Awake()
    {
        input = new PlayerControls();
        playerinfo = GetComponent<PlayerInfo>();
        controller = GetComponent<CharacterController>();
        Jumping = GetComponentInParent<CharacterJump>();

        input.CharacterControls.Movement.performed += ctx =>
        {
            currentmovement = ctx.ReadValue<Vector2>();
            movepress = currentmovement.x != 0 || currentmovement.y != 0;
        };
        input.CharacterControls.Run.performed += ctx => runpress = ctx.ReadValueAsButton();
        input.CharacterControls.Jump.performed += ctx => jumpress = ctx.ReadValueAsButton();
        input.CharacterControls.Fight.performed += ctx => fightpress = ctx.ReadValueAsButton();
        input.CharacterControls.Floating.performed += ctx => floatpress = ctx.ReadValueAsButton();
        input.CharacterControls.FightMode.performed += ctx => modepress = ctx.ReadValueAsButton();
        

    }

    private void OnEnable()
    {
        input.CharacterControls.Enable();
        CharacterRef.Collided += OnCollided;
    }

    private void OnDisable()
    {
        input.CharacterControls.Disable();
        CharacterRef.Collided -= OnCollided;
    }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        iswalking = Animator.StringToHash("iswalking");
        isrunning = Animator.StringToHash("isrunning");
        isMoving = Animator.StringToHash("speed");
        
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovement();
        JumpPlayer();
       // WalkingOnGround();
        FightPlayer();
        // HandleRotation();
        FloatMove();



    }

    void HandleRotation()
    {
         Vector3 currentpos = transform.position;
         Vector3 newpos = new Vector3(currentmovement.x, 0, currentmovement.y);
        Vector3 CamDirection = Camera.main.transform.forward;
       // CamDirection = new Vector3(CamDirection.x * -1, CamDirection.y, CamDirection.z);
        rot = Quaternion.LookRotation(CamDirection);
        transform.parent.rotation = rot;
    }

    void PlayerMovement()
    {
        anim.SetFloat("inputX", currentmovement.x);
        anim.SetFloat("inputY", currentmovement.y);

        Vector3 movement = Vector3.zero;
        movement += Vector3.forward * currentmovement.y;
        movement += Vector3.right * currentmovement.x;
        
        if(CharacterRef.camera)
        {
            movement = movement.relativeTo(CharacterRef.cameraTransform);
        }

        CharacterRef.SetMovementDirection(movement);
    }



    void JumpPlayer()
    {
   
        if (jumpress)
        {
         //   anim.SetBool("Jump", true);
            Jumping.Jump();
        }
        else
        {
         //   anim.SetBool("Jump", false);
            Jumping.StopJumping();
        }

    }

    void FloatMove()
    {
        if(floatpress && playerinfo.playerEnergy >0)
        {
            if(playerinfo.UseEnergy)
            {
                playerinfo.DecreasePlayerEnergy();
            }

            anim.SetBool("makeFloat", true);
        }
        else
        {
            playerinfo.UseEnergy = true;
            anim.SetBool("makeFloat", false);
        }
    }

    void FightPlayer()
    {
        if (fightpress)
        {
            anim.SetBool("fight", true);
            CharacterRef.SetMovementDirection(Vector3.zero);
        }

        else
        {
            anim.SetBool("fight", false);
        }
        }

    void WalkingOnGround()
    {
        if(CharacterRef.IsOnGround())
        {
            print("on the ground");
        }
        else
        {
            print("off the ground");
        }
    }

    public void OnCollided(ref CollisionResult result)
    {
       

    }

  


}
