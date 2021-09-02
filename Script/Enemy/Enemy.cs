using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************************************************

**class name: Player control

**description: 该abstract class用于定义所有敌人的基础属性,并对其伤害系统做一个简单的评判

**autor: Anthony, Andy

**Create Time: Aug 30 2021

**修改日志:
    1.  Anthony Aug 30 2021
    2.  Anthony Sep 01 2021

*********************************************************************************/
public abstract class Enemy : MonoBehaviour
{
    
    public int health;                      //血条
    public int damage;                      //伤害
    public float speed;                     //速度
    public float jumpSpeed;                 //跳跃速度
    public float observeRange;              //侦查玩家直径
    public GameObject bloodEffect;

    private SpriteRenderer spriteRenderer;  //渲染层控制
    private Color orginalColor;             //动画渲染最初的颜色
    private float flashTime = 0.2f;         //收到伤害的红色渲染时间



   public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        orginalColor = spriteRenderer.color;
    }

    public void Update()
    {
        
        
    }

    public void TakeDamage(int damage){
        this.health -= damage;
        basicAnime();   //该entity变红一瞬间
        damageAnimation();
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
    }

    void basicAnime(){
        spriteRenderer.color = Color.red;
        Invoke("reset",flashTime);
    }

    void reset(){
        spriteRenderer.color = orginalColor;
    }
    public abstract void damageAnimation();

    public abstract bool observePlayer();

    // void FlashColor(float time){
    //     sp.color = Color.red;
    //     Invoke("ResetColor", time);
    // }

    // void ResetColor(){
    //     sp.color = orginalColor;
    // }
}
