using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform player1;
    public Transform player2;
    public Transform movePoint1;
    public Transform movePoint2;

    public LayerMask noMove;

    // Start is called before the first frame update
    void Start()
    {
        movePoint1.parent = null;
        movePoint2.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        player1.transform.position = Vector3.MoveTowards(player1.transform.position,movePoint1.position,moveSpeed*Time.deltaTime);
        player2.transform.position = Vector3.MoveTowards(player2.transform.position,movePoint2.position,moveSpeed*Time.deltaTime);

        if (Vector3.Distance(player1.transform.position, movePoint1.position) <= 0.05f && Vector3.Distance(player2.transform.position, movePoint2.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!checkMoveH())
                {
                    movePoint1.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    movePoint2.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!checkMoveV())
                {
                    movePoint1.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    movePoint2.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
    }

    public bool checkMoveH()
    {
        bool h1 = Physics2D.OverlapCircle(movePoint1.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, noMove);
        bool h2 = Physics2D.OverlapCircle(movePoint2.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, noMove);

        return h1 || h2;
    }
    
    public bool checkMoveV()
    {
        bool v1 = Physics2D.OverlapCircle(movePoint1.position + new Vector3(0f,Input.GetAxisRaw("Vertical"), 0f), .2f, noMove);
        bool v2 = Physics2D.OverlapCircle(movePoint2.position + new Vector3(0f,Input.GetAxisRaw("Vertical"), 0f), .2f, noMove);

        return v1 || v2;
    }
    
}
