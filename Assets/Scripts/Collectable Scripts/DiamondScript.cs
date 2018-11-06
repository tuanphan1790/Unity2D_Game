using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (DoorScript.instance != null)
        {
            DoorScript.instance.collectTableCount++;
            Debug.Log(DoorScript.instance.collectTableCount);
        }
	}

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            Destroy(gameObject);
            if(DoorScript.instance !=null)
            {
                DoorScript.instance.DecrementCollectables();
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
