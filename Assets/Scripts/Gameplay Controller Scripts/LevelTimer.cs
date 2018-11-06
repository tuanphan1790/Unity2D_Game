using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {

    private Slider slider;

    private GameObject player;

    public float timer = 10f;
    private float timerBurn = 1f;

    private void Awake()
    {
        GetReference();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        if (timer > 0)
        {
            timer -= timerBurn * Time.deltaTime;
            slider.value = timer;
        }
        else
        {
            Destroy(player);
            GameObject.Find("Gameplay Controller").GetComponent<GamePlayController>().PlayerDied();
        }
    }

    void GetReference()
    {
        player = GameObject.Find("Player");
        slider = GameObject.Find("Time Slider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = timer;
        slider.value = timer;
    }
}
