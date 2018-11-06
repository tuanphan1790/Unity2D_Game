using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(1, 4));
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(Attack());
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(target.gameObject);
            GameObject.Find("Gameplay Controller").GetComponent<GamePlayController>().PlayerDied();
        }

    }
}
