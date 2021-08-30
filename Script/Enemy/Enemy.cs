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


*********************************************************************************/
public abstract class Enemy : MonoBehaviour
{
    
    public int health;      //血条
    public int damage;      //伤害
    public float speed;     //速度
    public float jumpSpeed; //跳跃速度
    public float observeRange; //侦查玩家直径



   public void Start()
    {
        // sp = GetComponent<SpriteRenderer>();
        // orginalColor = sp.color;
        
    }

    public void Update()
    {
        
        if(health <= 0)
            Destroy(gameObject); 
    }

    public void TakeDamage(int damage){
        this.health -= damage;
        damageAnimation();
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
