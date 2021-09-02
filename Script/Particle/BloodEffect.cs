using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************************************************

**class name: Blood Effect

**description: 敌人收到伤害扣血

**autor: Anthony, Andy

**Create Time: Sep 02 2021

**修改日志:
    1.  Anthony Sep 02 2021

*********************************************************************************/
public class BloodEffect : MonoBehaviour
{
    public float timeToDestory;

    void Start()
    {
        Destroy(gameObject,timeToDestory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
