using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************************************************

**class name: player sword sub script

**description: 用于控制刀剑类武器的范围帧

**autor: Anthony, Andy

**Create Time: Aug 28 2021

**修改日志:
    1.  Anthony Sep 01 2021

*********************************************************************************/
public class PlayerSword_sub : MonoBehaviour
{
    private PolygonCollider2D collider2D;

    private float time = 0.1f;

    void Start()
    {
        collider2D = this.GetComponent<PolygonCollider2D>();
    }


    public void enableDamage(){
        StartCoroutine(StartAttack());
    }

    IEnumerator StartAttack(){
        yield return new WaitForSeconds(time);
        collider2D.enabled = true;
        StartCoroutine(disableHitBox());
    }

    IEnumerator disableHitBox(){
        yield return new WaitForSeconds(time);
        collider2D.enabled = false;
    }




}
