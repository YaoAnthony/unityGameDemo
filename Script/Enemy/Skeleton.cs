using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************************************************

**class name: Player control

**description: 该class 用于定义骷髅剑士的行为

**autor: Anthony, Andy

**Create Time: Aug 30 2021

**修改日志:
    1.  Anthony Aug 30 2021


*********************************************************************************/
public class Skeleton : Enemy
{
    const float G = 9.8f;
    private Animator anime;         //获得动画
    private Rigidbody2D entity;     //获得刚体
    private bool isRunning;         //检测是否entity正在跑步
    void Start() {
        base.Start();
        anime = this.GetComponent<Animator>();
        entity = this.GetComponent<Rigidbody2D>();
        isRunning = false;
    }

    void Update(){
        base.Update();


        if(observePlayer())
            findAndAttack();
        else
            Animation();
        
        
    }
    /*
    --------------------------------------    .敌人行为篇    -------------------------------------------
    */

   /*
        行为: 前往(x,~)位置
       
        图示:   .....x........Enemy......
    
        方案: 给定x坐标, 计算距离直接前往
    */
    void Goto(Vector2 pos){
        float x = pos.x - transform.position.x < 0 ? -1 : 1;
        entity.velocity = new Vector2(x * speed, entity.velocity.y);          
    }

   /*
        行为: 决策是否能跳过位于面前(~ + 1,~)的墙(高度为h)

        图示:   ___
                  |
                  |__Enemy

        方案: 获得本体的jump speed, 根据公式V^2 / 2g 计算本体最高跳跃的高度是否低于h
    */
    bool HighPlaceJump(float h){
        float entityJumpHeight = jumpSpeed * jumpSpeed / (2 * G);
        return h < entityJumpHeight;
    }


    /*
        行为: 决策是否能跳过位于面前(~ + 1,~)的墙(高度为h)

        图示:   ___
                  |
                  |__Enemy

        方案: 如果能跳上去，给一个跳跃的力
    */



    /*
    --------------------------------------    索引敌人篇    -------------------------------------------
    */


    //依靠搜索半径搜索敌人
    public override bool observePlayer(){
        Vector2 playerPos = GameObject.FindWithTag("Player").transform.position;
        return Vector2.Distance(transform.position, playerPos) < observeRange;
    }

    //发现敌人，依靠算法搜索靠近敌人最短距离
    public void findAndAttack(){

    }
    /*
    --------------------------------------    动画调控    -------------------------------------------
    */

    void Animation(){

    }

    void TurningAround(){
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
    }
    public override void damageAnimation(){

    }





















    
    
    // public float flashTime;

    // private SpriteRenderer sp;
    // private Color orginalColor;

    // public float startWaitingTime;
    // private float waitingTime;
    // public float attackTime;
    // public float startAttackTime;
    // private Transform enTransform;
    // private Transform leftPos;
    // private Transform rightPos;
    // private Rigidbody2D entity;
    // private PolygonCollider2D collider2D;
    // private Animator anime;
    


    // private bool isRunning;
    // private float attackRange = 2;
   
    // public void Start()
    // {
    //     base.Start();
        
    //     entity = this.GetComponent<Rigidbody2D>();
    //     anime = this.GetComponent<Animator>();
    //     collider2D = GetComponent<PolygonCollider2D>();
        
    // }

    
    // public void Update()
    // {
    //     base.Update();

    //     ObservePalyer();

    //     bool playerHasXSpeed = Mathf.Abs(entity.velocity.x) > Mathf.Epsilon;
    //     isRunning = playerHasXSpeed;

    //     //人物转向
    //     if(playerHasXSpeed){
    //         if(entity.velocity.x > 0.1f){
    //             transform.localRotation = Quaternion.Euler(0,0,0);
    //         }
    //         if(entity.velocity.x < -0.1f){
    //             transform.localRotation = Quaternion.Euler(0,180,0);
    //         }
    //     }

    //     Animation();
    // }


    // private Vector2 GetRandomPos(){
    //     return new Vector2(Random.Range(leftPos.position.x, rightPos.position.x),this.transform.position.y);
    // }

    // void ObservePalyer(){

    //     Vector2 playerPos = GameObject.FindWithTag("Player").transform.position;
        
    //     if( Vector2.Distance(transform.position, playerPos) < observeRange ){
    //         if(Mathf.Abs(playerPos.x - transform.position.x) > attackRange){
    //             Goto(playerPos);
    //         }else{
    //             entity.velocity = new Vector2(0, entity.velocity.y);
    //             //Attack();
    //         }
            
    //     }
    // }

    // void Goto(Vector2 otherPos){
    //     //是否在同一个平面
    //     if(Mathf.Abs(otherPos.y - transform.position.y) < 1){ 
    //         float x = otherPos.x - transform.position.x < 0 ? -1 : 1;
    //         entity.velocity = new Vector2(x * speed, entity.velocity.y);   
    //     }
    // }

    // void Animation(){
    //     //是否在跑步
    //     anime.SetBool("Run",isRunning);
    // }

    // void Attack(){
    //     anime.SetTrigger("Attack");
    //     StartCoroutine(StartAttack());
    // }

    // IEnumerator StartAttack(){
    //     yield return new WaitForSeconds(startAttackTime);
    //     collider2D.enabled = true;
    //     StartCoroutine(disableHitBox());
    // }
    // IEnumerator disableHitBox(){
        
    //     yield return new WaitForSeconds(attackTime);
    //     collider2D.enabled = false;
    // }

    // private void OnTriggerEnter(Collider other) {
    //     if(other.gameObject.CompareTag("Player")){

    //     }
    // }
}
