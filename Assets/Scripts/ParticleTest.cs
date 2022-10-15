using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ParticleTest : MonoBehaviour
{
    Animator anim0, anim;
    Slider hpbar0, hpbar, stembar;
    public float dmg;
    private void Start()
    {
        anim0 = GameObject.Find("GloryArmor_01").GetComponent<Animator>();
        anim = GameObject.Find("armored_Barbarian_joinedAnim_LOD0").GetComponent<Animator>();
        hpbar0 = GameObject.Find("Hp_player").GetComponent<Slider>();
        hpbar = GameObject.Find("Hp_enemy").GetComponent<Slider>();
        stembar = GameObject.Find("Stemina_player").GetComponent<Slider>();
    }
    void Clear()
    {
        //시네마틱 재생
    }
    void Die()
    {
        //시네마틱 재생
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.layer == 6 && !anim0.GetCurrentAnimatorStateInfo(0).IsTag("Hurt"))
        {
            if ((anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2 0") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2 0 0") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2 0 0 0") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3 0") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3 0 0") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3 0 0 0")))
            {
                if (!anim0.GetBool("Guard"))
                {
                    anim0.SetBool("Attack1", false);
                    anim0.SetBool("Attack1 0", false);
                    anim0.SetBool("Attack1 0 0", false);
                    anim0.SetBool("Attack1 0 0 0", false);
                    anim0.SetBool("Guard", false);
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2 0") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2 0 0") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2 0 0 0"))
                        anim0.SetTrigger("Hurt");
                    else
                        anim0.SetTrigger("Hurt1");
                    if (hpbar0.value > 0)
                    {
                        hpbar0.value -= dmg;
                    }
                    else
                    {
                        hpbar0.value = 0;
                        Die();
                    }
                }
                else
                {
                    //넉백+스테미너 소모
                    print("막음");
                    if (stembar.value > 0)
                    {
                        stembar.value -= 0.5f;
                        SkillBtn.delay = 500;
                    }
                    else
                    {
                        stembar.value = 0;
                    }
                }
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
            {
                if (!anim0.GetCurrentAnimatorStateInfo(0).IsName("jump"))
                {
                    anim0.SetBool("Attack1", false);
                    anim0.SetBool("Attack1 0", false);
                    anim0.SetBool("Attack1 0 0", false);
                    anim0.SetBool("Attack1 0 0 0", false);
                    anim0.SetBool("Guard", false);
                    anim0.SetTrigger("Hurt");
                    if (hpbar0.value > 0)
                    {
                        hpbar0.value -= dmg;
                    }
                    else
                    {
                        hpbar0.value = 0;
                        Die();
                    }
                }
                else
                {
                    //넉백+스테미너 소모
                    print("점프로 피함");
                }
            }
            else
            {
                anim0.SetBool("Attack1", false);
                anim0.SetBool("Attack1 0", false);
                anim0.SetBool("Attack1 0 0", false);
                anim0.SetBool("Attack1 0 0 0", false);
                anim0.SetBool("Guard", false);
                anim0.SetTrigger("Hurt");
                if (hpbar0.value > 0)
                {
                    hpbar0.value -= dmg;
                }
                else
                {
                    hpbar0.value = 0;
                    Die();
                }
            }
        }
        if (other.gameObject.layer == 7 && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Hurt") && (anim0.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || anim0.GetCurrentAnimatorStateInfo(0).IsName("Attack1 0") || anim0.GetCurrentAnimatorStateInfo(0).IsName("Attack1 0 0") || anim0.GetCurrentAnimatorStateInfo(0).IsName("Attack1 0 0 0") || anim0.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || anim0.GetCurrentAnimatorStateInfo(0).IsName("Attack3") || anim0.GetCurrentAnimatorStateInfo(0).IsName("Attack4")))
        {
            print("타격");
            if (anim0.GetCurrentAnimatorStateInfo(0).IsName("Attack4"))
                anim.SetTrigger("Hurt");
            else
                anim.SetTrigger("Hurt1");
            if (hpbar.value > 0)
                hpbar.value -= dmg;
            else
            {
                hpbar.value = 0;
                Clear();
            }
        }
    }
}
