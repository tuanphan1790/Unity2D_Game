using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour {

    [SerializeField]
    private Transform startPos, endPos;

    private bool collision;

    public float speed = 1f;
    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
		
	}

    void ChangeDirection()
    {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground")); //Xác định đường thẳng nối giữa 2 vị trí có cắt Layer hay không?

        Debug.DrawLine(startPos.position, endPos.position, Color.green);

        if(!collision)
        {
            Vector3 temp = transform.localScale;
            if(temp.x == 1f)
            {
                temp.x = -1f;
            }
            else
            {
                temp.x = 1f;
            }

            transform.localScale = temp;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
        ChangeDirection();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(target.gameObject);
            GameObject.Find("Gameplay Controller").GetComponent<GamePlayController>().PlayerDied();
        }
    }

    void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }
}
