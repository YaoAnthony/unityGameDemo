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

*********************************************************************************/
public class PlayerAttack : MonoBehaviour
{
    public int existArrow = 3;

    public GameObject projection;
    private Animator anime;

    public bool isAttack = false;   
    // Start is called before the first frame update
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
        if(anime.runtimeAnimatorController.name == "Archer_Player"){

            if(Input.GetButtonDown("Attack") && !anime.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
                anime.SetTrigger("Attack");
                isAttack = true;
                existArrow--;
            }
            if(anime.GetBool("Shooting")){
                anime.SetBool("shooting",false);
                Invoke("shooting",0.1f);
            }

        }

    }

    void shooting(){
        Instantiate(projection,GameObject.Find("Player").transform.position,GameObject.Find("Player").transform.rotation);
        GameObject.Find("Player").GetComponent<PlayerAttack>().isAttack = false; 
                
    }
}
