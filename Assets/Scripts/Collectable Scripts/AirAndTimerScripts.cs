using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAndTimerScripts : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            if(gameObject.name == "Air")
            {
                GameObject.Find("Gameplay Controller").GetComponent<AirTimer>().air += 10;
            }

            if(gameObject.name == "Timer")
            {
                GameObject.Find("Gameplay Controller").GetComponent<LevelTimer>().timer += 10;
            }

            Destroy(gameObject);
        }
    }
}
