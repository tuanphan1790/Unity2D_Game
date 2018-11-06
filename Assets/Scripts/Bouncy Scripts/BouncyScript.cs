using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyScript : MonoBehaviour {

    public float force = 500f;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    // Use this for initialization
    void Start () {
		
	}

    IEnumerator AnimateBouncy()
    {
        anim.Play("Up");
        yield return new WaitForSeconds(0.5f);
        anim.Play("Down");
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            target.gameObject.GetComponent<PlayerScript>().BoucePlayerWithBouncy(force);
            StartCoroutine(AnimateBouncy());
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
