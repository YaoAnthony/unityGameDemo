using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************************************************

**class name: Player control

**description: 用于控制player的攻击，动画切换

**autor: Anthony, Andy

**Create Time: Aug 29 2021

**修改日志:
    1.  Anthony Aug 29 2021
    2.  Anthony Aug 30 2021
    3.  Anthony Aug 31 2021
    4.  Anthony Sep 01 2021

*********************************************************************************/
public class PlayerAttack : MonoBehaviour
{
    private Animator anime;         //动画

    public int swordDamage;       //剑的伤害

    public int existArrow = 3;      //玩家拥有的弓箭数量
    public GameObject projection;   //投抛物
    public bool isAttack = false;   //用来输送是否可以发射子弹的bool值，调用的地方在Shooting界面

    
    
    void Start()
    {
        anime = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack(){

        //检测是否是弓箭手状态
        if(anime.runtimeAnimatorController.name == "Archer_Player"){
            if(Input.GetButtonDown("Attack") && !anime.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
                anime.SetTrigger("Attack");
                isAttack = true;
                existArrow--;
            }
        //检测是否是近战状态
        }else if(anime.runtimeAnimatorController.name == "Sword_Player"){
            if(Input.GetButtonDown("Attack") && !anime.GetCurrentAnimatorStateInfo(0).IsName("A1")){
                anime.SetTrigger("A1");
                //GetComponentInChildren<PlayerSword_sub>().enableDamage();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            other.GetComponent<Enemy>().TakeDamage(swordDamage);
        }    
    }
}
