using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/********************************************************************************

**class name: Player control

**description: 通过监控动画帧数发射箭矢

**autor: Anthony, Andy

**Create Time: Aug 30 2021

**修改日志:
    1.  Anthony Aug 30 2021

*********************************************************************************/
public class shooting : StateMachineBehaviour
{
    private int animeShooting;
    private float clipTime;
    public GameObject arrow;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animeShooting = 0;
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

        if(currentFrame == 14){
            animeShooting++;
        }
        if(animeShooting == 1){
            Instantiate(arrow,GameObject.Find("Player").transform.position,GameObject.Find("Player").transform.rotation);
            GameObject.Find("Player").GetComponent<PlayerAttack>().isAttack = false;  
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    // }
    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

}
