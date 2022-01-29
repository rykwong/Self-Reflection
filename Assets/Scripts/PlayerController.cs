using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dist = 2f;
    public Transform movePoint;
    private Animator anim;

    public LayerMask noMove;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,movePoint.position,moveSpeed*Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal")*dist, 0f, 0f),
                    .2f, noMove))
                {
                    anim.SetBool("isMoving",true);
                    anim.SetFloat("Horizontal",Input.GetAxisRaw("Horizontal"));
                    anim.SetFloat("Vertical",0);
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal")*dist, 0f, 0f);
                }
                else
                {
                    anim.SetBool("isMoving",false);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f,Input.GetAxisRaw("Vertical")*dist, 0f),
                    .2f, noMove))
                {
                    anim.SetBool("isMoving",true);
                    anim.SetFloat("Horizontal",0);
                    anim.SetFloat("Vertical",Input.GetAxisRaw("Vertical"));
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical")*dist, 0f);
                }
                else
                {
                    anim.SetBool("isMoving",false);
                }
            }
            else
            {
                anim.SetBool("isMoving",false);
            }
        }

    }
}
