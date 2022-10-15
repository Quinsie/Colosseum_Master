using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBtn : MonoBehaviour
{
    public Transform player, enemy;
    public Animator anim;
    public RectTransform attackBtn;
    public Text guard, roll, jump;
    public Slider stembar;
    public static Vector3 dir;
    public static int delay;

    // Update is called once per frame
    void Update()
    {
        if (delay > 0)
            delay--;
        if(delay==0)
            stembar.value += 0.01f;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
            anim.SetBool("Attack1", false);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1 0"))
            anim.SetBool("Attack1 0", false);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1 0 0"))
            anim.SetBool("Attack1 0 0", false);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1 0 0 0"))
            anim.SetBool("Attack1 0 0 0", false);
    }
    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "Attack":
                guard.text = "특수공격1";
                roll.text = "특수공격2";
                jump.text = "특수공격3";
                break;
            case "Guard":
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt 0") && !anim.GetCurrentAnimatorStateInfo(0).IsName("jump") && !anim.GetCurrentAnimatorStateInfo(0).IsName("roll"))
                {
                    anim.SetBool("Attack1", false);
                    anim.SetBool("Attack1 0", false);
                    anim.SetBool("Attack1 0 0", false);
                    anim.SetBool("Attack1 0 0 0", false);
                    anim.SetBool("Guard", true);
                }
                break;
            case "Jump":
                if (stembar.value >= 0.1f && !anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt 0") && !anim.GetCurrentAnimatorStateInfo(0).IsName("jump") && !anim.GetCurrentAnimatorStateInfo(0).IsName("guard") && !anim.GetCurrentAnimatorStateInfo(0).IsName("roll"))
                {
                    anim.SetBool("Attack1", false);
                    anim.SetBool("Attack1 0", false);
                    anim.SetBool("Attack1 0 0", false);
                    anim.SetBool("Attack1 0 0 0", false);
                    anim.SetBool("Jump", true);
                    if (stembar.value > 0)
                    {
                        stembar.value -= 0.1f;
                        delay = 500;
                    }
                    else
                    {
                        stembar.value = 0;
                    }
                }
                break;
            case "Roll":
                if (stembar.value >= 0.2f && !anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt 0") && !anim.GetCurrentAnimatorStateInfo(0).IsName("roll") && !anim.GetCurrentAnimatorStateInfo(0).IsName("jump"))
                {
                    dir = Joystick.m_vecMove;
                    anim.SetBool("Attack1", false);
                    anim.SetBool("Attack1 0", false);
                    anim.SetBool("Attack1 0 0", false);
                    anim.SetBool("Attack1 0 0 0", false);
                    anim.SetTrigger("Roll");
                    if (stembar.value > 0)
                    {
                        stembar.value -= 0.2f;
                        delay = 500;
                    }
                    else
                    {
                        stembar.value = 0;
                    }
                }
                break;
        }
    }
    public void ButtonUp(string type)
    {
        switch (type)
        {
            case "Attack":
                guard.text = "방어";
                roll.text = "회피";
                jump.text = "점프";
                if ((attackBtn.position - (Vector3)Input.mousePosition).magnitude > 100)
                {
                    float rot = Mathf.Atan2(((Vector3)Input.mousePosition - attackBtn.position).y, ((Vector3)Input.mousePosition - attackBtn.position).x) * Mathf.Rad2Deg - 90;
                    if (stembar.value >= 0.4f && rot > -30 && rot < 30 && (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("walk_left") || anim.GetCurrentAnimatorStateInfo(0).IsName("walk_right") || anim.GetCurrentAnimatorStateInfo(0).IsName("walk_backward") || anim.GetCurrentAnimatorStateInfo(0).IsName("walk_forward")))
                    {
                        print("특3");
                        anim.SetTrigger("Attack4");
                        if (stembar.value > 0)
                        {
                            stembar.value -= 0.4f;
                            delay = 500;
                        }
                        else
                        {
                            stembar.value = 0;
                        }
                    }
                    if (stembar.value >= 0.2f && rot < 90 && rot > 30 && (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("walk_left") || anim.GetCurrentAnimatorStateInfo(0).IsName("walk_right") || anim.GetCurrentAnimatorStateInfo(0).IsName("walk_backward") || anim.GetCurrentAnimatorStateInfo(0).IsName("walk_forward")))
                    {
                        print("특2");
                        anim.SetTrigger("Attack3");
                        if (stembar.value > 0)
                        {
                            stembar.value -= 0.2f;
                            delay = 500;
                        }
                        else
                        {
                            stembar.value = 0;
                        }
                    }
                    if (stembar.value >= 0.3f && rot > -270 && rot < -210 && (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("walk_left") || anim.GetCurrentAnimatorStateInfo(0).IsName("walk_right") || anim.GetCurrentAnimatorStateInfo(0).IsName("walk_backward") || anim.GetCurrentAnimatorStateInfo(0).IsName("walk_forward")))
                    {
                        print("특1");
                        anim.SetTrigger("Attack2");
                        if (stembar.value > 0)
                        {
                            stembar.value -= 0.3f;
                            delay = 500;
                        }
                        else
                        {
                            stembar.value = 0;
                        }
                    }
                }
                else
                {
                    print("일");
                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1 0") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1 0 0") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1 0 0 0"))
                        anim.SetBool("Attack1", true);
                    else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
                        anim.SetBool("Attack1 0", true);
                    else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1 0"))
                        anim.SetBool("Attack1 0 0", true);
                    else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1 0 0"))
                        anim.SetBool("Attack1 0 0 0", true);
                }
                break;
            case "Guard":
                anim.SetBool("Guard", false);
                break;
        }
    }
}
