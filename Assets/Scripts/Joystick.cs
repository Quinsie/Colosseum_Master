using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    RectTransform m_rectBack;
    RectTransform m_rectJoystick;

    public Transform  player, enemy;
    public Animator anim;
    float m_fRadius;
    float m_fSpeed = 5.0f;
    float fSqr;
    Vector3 vecNormal, vec;
    public static Vector3 m_vecMove;

    bool m_bTouch = false;


    void Start()
    {
        m_rectBack = GetComponent<RectTransform>();
        m_rectJoystick = transform.Find("Joystick").GetComponent<RectTransform>();

        // JoystickBackground의 반지름입니다.
        m_fRadius = m_rectBack.rect.width * 0.5f;
    }

    void Update()
    {
        Camera.main.transform.position = player.position + Vector3.up * 1.715f*2 +(player.position - enemy.position).normalized * 2.695f*2;
        Camera.main.transform.rotation = Quaternion.Euler(new Vector3(10, Quaternion.LookRotation(enemy.position - player.position).eulerAngles.y, 0));
        m_vecMove = player.right * vecNormal.x * m_fSpeed * Time.deltaTime * fSqr + player.forward * vecNormal.y * m_fSpeed * Time.deltaTime * fSqr;
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("roll"))
            player.rotation = Quaternion.Euler(new Vector3(0, Quaternion.LookRotation(enemy.position - player.position).eulerAngles.y, 0));
        else
            player.rotation = Quaternion.Euler(new Vector3(0, Quaternion.LookRotation(SkillBtn.dir).eulerAngles.y, 0));
        if (m_bTouch && !anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt 0") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Roll") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Guard"))
        {
            player.position += m_vecMove.normalized * 0.05f;
            anim.SetFloat("Rot", Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg-90);
        }
    }

    void OnTouch(Vector2 vecTouch)
    {
        vec = new Vector2(vecTouch.x - m_rectBack.position.x, vecTouch.y - m_rectBack.position.y);


        // vec값을 m_fRadius 이상이 되지 않도록 합니다.
        vec = Vector2.ClampMagnitude(vec, m_fRadius);
        m_rectJoystick.localPosition = vec;

        // 조이스틱 배경과 조이스틱과의 거리 비율로 이동합니다.
        fSqr = (m_rectBack.position - m_rectJoystick.position).sqrMagnitude / (m_fRadius * m_fRadius);

        // 터치위치 정규화
        vecNormal = vec.normalized;
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        m_bTouch = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        m_bTouch = true;
        anim.SetInteger("Move", 1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 원래 위치로 되돌립니다.
        m_rectJoystick.localPosition = Vector2.zero;
        m_bTouch = false;
        anim.SetInteger("Move", 0);
    }
}