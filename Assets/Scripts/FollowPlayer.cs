using UnityEngine;
 

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject follow;

    [SerializeField]
    float timeOffset;

    [SerializeField]
    Vector2 posOffset;

    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float topLimit;

    private Vector3 velocity;
    void Update()
    {
        //Camera at current position
        Vector3 startPos = transform.position;
        
        //Player current position
        Vector3 endPos = follow.transform.position;
        
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;
        
        //Smooth
        transform.position = Vector3.Lerp(startPos, endPos, timeOffset*Time.deltaTime);

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit), 
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );
    }

    void OnDrawGizmos()
    {
        //draw a box around our camera boundary
        Gizmos.color = Color.red;
        //top
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        //right
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, topLimit));
        //bottom
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        //left
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
    }
}
