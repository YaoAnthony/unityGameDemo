using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************************************************

**class name: Sword chopping attack

**description: 通过监控动画帧数使得武器落到怪物身上才造成伤害

**autor: Anthony, Andy

**Create Time: Sep 02 2021

**修改日志:
    1.  Anthony Sep 02 2021

*********************************************************************************/
public class SwordAttack : StateMachineBehaviour
{
    private int animeChopping;
    private float clipTime;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //动画进入
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animeChopping = 0;
    }

    

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //当前动画机播放时长
        float currentTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        //动画片段长度
        float length = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        
        clipTime = currentTime / length;
        //获取动画片段帧频
        float frameRate = animator.GetCurrentAnimatorClipInfo(0)[0].clip.frameRate;
        //计算动画片段总帧数
        float totalFrame = length / (1 / frameRate);
        //计算当前播放的动画片段运行至哪一帧
        int currentFrame = (int)(Mathf.Floor(totalFrame * clipTime) % totalFrame);

        if(currentFrame == 4){
            animeChopping++;
        }
        if(animeChopping == 1){
            GameObject.Find("Player").GetComponentInChildren<PlayerSword_sub>().enableDamage();    
        }
        
    }
}
