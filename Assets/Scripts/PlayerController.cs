using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dist = 2f;
    public Transform movePoint;
    private Animator anim;

    public LayerMask noMove;
    public LayerMask items;
    public LayerMask chest;
    public bool chestActive;
    public bool mirrored;
    public bool complete;
    [SerializeField] private Key key;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        anim = GetComponent<Animator>();
        movePoint.parent = null;
        if (mirrored) dist = -dist;
    }

    // Update is called once per frame
    void Update()
    {
        if(!complete)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal") * dist, 0f, 0f), .2f, noMove))
                    {
                        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal") * dist, 0f, 0f), .2f, items))
                        {
                            key.Enable();
                        }

                        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal") * dist, 0f, 0f), .2f, chest))
                        {
                            chestActive = true;
                            levelManager.checkKey();
                        }
                        else
                        {
                            chestActive = false;
                            anim.SetBool("isMoving", true);
                            anim.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal") * dist);
                            anim.SetFloat("Vertical", 0);
                            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * dist, 0f, 0f);
                        }
                    }
                    else
                    {
                        anim.SetBool("isMoving", false);
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") * dist, 0f), .2f, noMove))
                    {
                        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") * dist, 0f), .2f, items))
                        {
                            Debug.Log("Key obtained");
                            key.Enable();
                        }

                        if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") * dist, 0f), .2f, chest))
                        {
                            chestActive = true;
                            levelManager.checkKey();
                        }
                        else
                        {
                            chestActive = false;
                            anim.SetBool("isMoving", true);
                            movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * dist, 0f);
                        }
                        anim.SetFloat("Horizontal", 0);
                        anim.SetFloat("Vertical", Input.GetAxisRaw("Vertical") * dist);
                    }
                    else
                    {
                        anim.SetBool("isMoving", false);
                    }
                }
                else
                {
                    anim.SetBool("isMoving", false);
                }
            }
        }
    }

    public void levelComplete()
    {
        complete = true;
        anim.SetBool("isMoving",false);
    }
    
    
}
