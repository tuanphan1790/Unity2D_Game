using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour {

    public float forceY = 300f;

    private Rigidbody2D myBody;
    private Animator anim;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        forceY = Random.Range(250f, 500f);
        myBody.AddForce(new Vector2(0, forceY));
        anim.SetBool("Attack", true);

        yield return new WaitForSeconds(0.7f);

        StartCoroutine(Attack());
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            Destroy(target.gameObject);
            GameObject.Find("Gameplay Controller").GetComponent<GamePlayController>().PlayerDied();
        }

        if(target.tag == "Ground")
        {
            anim.SetBool("Attack", false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
