using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/********************************************************************************

**class name: Player control

**description: 用于控制player的基础动作，动画切换

**autor: Anthony, Andy

**Create Time: Aug 28 2021

**修改日志:
    1.  Anthony Aug 28 2021
    2.  Anthony Aug 31 2021

*********************************************************************************/
public class PlayerControl : MonoBehaviour
{
    public float runningSpeed;      //用于输入奔跑速度
    public float jumpSpeed;         //用于输入跳跃速度
    public float doubleJumpSpeed;   //用于输入二段跳速度
    public bool haveSword = false;  //是否获得了剑
    public bool haveRow = false;    //是否获得了弓

    //获得不同的动画效果组
    public RuntimeAnimatorController defaultPlayer;
    public RuntimeAnimatorController swordPlayer;
    public RuntimeAnimatorController archerPlayer;
    
    private BoxCollider2D myFeet;   //获得地面碰撞检测
    private Rigidbody2D entity;     //获得本体刚体信息
    private Animator anime;         //获得动画


    //动画检测变量
    private bool isGround;          //此时在地上
    private bool isRunning;         //此时在跑步
    private bool isDoubleJumping;   //此时在double jump
    private bool allowDoubleJump;   //允许double jump
    private int currentState;       //当前持有什么武器
    

    void Start()
    {
        entity = this.GetComponent<Rigidbody2D>();
        anime = this.GetComponent<Animator>();
        myFeet = this.GetComponent<BoxCollider2D>();  
        currentState = 0;     
    }

    
    void Update()
    {
        Run();
        Jump();
        ChangeWeapon();
        EnvironmentCheck();
        Animations();
    }

    void Run(){
        float x = Input.GetAxis("Horizontal");
        entity.velocity = new Vector2(x * runningSpeed, entity.velocity.y);
    }

    void Jump(){
        if(Input.GetButtonDown("Jump")){
            if (isGround){
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                entity.velocity = Vector2.up * jumpVel;
                allowDoubleJump = true;
            }else{
                //此时人在空中
                if(allowDoubleJump){
                    isDoubleJumping = true;
                    Vector2 doubleJumpVel = new Vector2(0.0f, doubleJumpSpeed);
                    entity.velocity = Vector2.up * doubleJumpVel;
                    allowDoubleJump = false;
                }
            }
        } 
        
    }





    void EnvironmentCheck(){
        //检测对象是否在地面上
        //Debug.Log( myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")));
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
    
    void Animations(){
        if(isGround){
            //设置人物动画组
            switch(currentState){
                case 0:
                    anime.runtimeAnimatorController = defaultPlayer as RuntimeAnimatorController;
                break;
                case 1:
                    anime.runtimeAnimatorController = swordPlayer as RuntimeAnimatorController;
                break;
                case 2:
                    anime.runtimeAnimatorController = archerPlayer as RuntimeAnimatorController;
                break;
                default:
                    anime.runtimeAnimatorController = defaultPlayer as RuntimeAnimatorController;
                break;
            }
        }
        //Epsilon意思是无限小
        bool playerHasXSpeed = Mathf.Abs(entity.velocity.x) > Mathf.Epsilon;
        isRunning = playerHasXSpeed;

        //人物转向
        if(playerHasXSpeed){
            if(entity.velocity.x > 0.1f){
                transform.localRotation = Quaternion.Euler(0,0,0);
            }
            if(entity.velocity.x < -0.1f){
                transform.localRotation = Quaternion.Euler(0,180,0);
            }
        }

        if(isGround){
            //在地面上默认不是掉落
            anime.SetBool("Fall", false);

            //是否在跑步
            anime.SetBool("Run",isRunning);


            //如果没有任何行动，播放待命动画
            anime.SetBool("Idle", anime.GetBool("Run") || anime.GetBool("Fall") || anime.GetBool("Jump") ? false : true );
        
        }else{
            //在地面上默认不是待命动画
            anime.SetBool("Idle", false);
            //跳跃检测
            if(!isDoubleJumping){
                anime.SetBool("Jump",  entity.velocity.y > 0.0f ? true : false ); 
                
            }else{
                anime.SetTrigger("isDoubleJump");
                isDoubleJumping = false;
            }

            anime.SetBool("Fall",  entity.velocity.y < 0.0f ? true : false ); 
        }
    }

    void ChangeWeapon(){
        //默认状态
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            currentState = 0;
        }

        //使用剑
        if(Input.GetKeyDown(KeyCode.Alpha2) && haveSword){
            currentState = 1;
        }

        //使用弓
        if(Input.GetKeyDown(KeyCode.Alpha3) && haveRow){
            currentState = 2;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.CompareTag("weaponTriggerBox") && (other.gameObject.name == "bow") )
        {
            GetComponent<PlayerControl>().haveRow = true;
            currentState = 2;
        }

        if(other.gameObject.CompareTag("weaponTriggerBox") && (other.gameObject.name == "sword") )
        {
            GetComponent<PlayerControl>().haveSword = true;
            currentState = 1;
        }
   }
    


    //TODO: 所有物品的获得都会调用这个函数
    // public void itemObtain(int item){

    // }


    // public void weaponObtain(int item){
    //     switch(item){
    //         case 1:
    //             haveSword = true;
    //         break;
    //         case 2:
    //             haveRow = true;
    //         break;
    //         default:
    //             Debug.Log("weapon doesnt exist");
    //         break;
    //     }
    // }
    

}
