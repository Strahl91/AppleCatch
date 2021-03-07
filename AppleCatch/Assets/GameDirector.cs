using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    GameObject ItemGenerator;
    public float time = 60.0f;
    int point = 0;
    public bool GameSwitch
    {
        get { return gameSwitch; }
        set
        {
            if (gameSwitch == false && value == true)
            {
                Debug.Log("Game Start!");
            }

            this.ItemGenerator.GetComponent<ItemGenerator>().ItemSwitch = value;
            gameSwitch = value;
        }
    }

    private bool gameSwitch;

    public GameObject StartPanel;



    public void GetApple(int score)
    {
        this.point += score;
    }

    public void GetBomb()
    {
        this.point /= 2;
    }

void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.ItemGenerator = GameObject.Find("ItemGenerator");
        GameSwitch = false;



        this.timerText.GetComponent<TextMeshProUGUI>().text = 0.0f.ToString("F1");
        this.pointText.GetComponent<TextMeshProUGUI>().text = 0.ToString() + " point";
    }
    public class Parameter
    {
        public float startTime;
        public float endTime;
        public float interval;
        public float speed;
        public int rate;

        public Parameter(float s, float e, float i, float sp, int r)
        {
            startTime = s;
            endTime = e;
            interval = i;
            speed = sp;
            rate = r;
        }
    }

    private Parameter[] ParameterArray = new Parameter[5]
    {
        new Parameter(20.0f, 30.0f,1.0f, -0.03f, 2),
        new Parameter(10.0f, 20.0f,0.8f, -0.04f, 4),
        new Parameter(5.0f, 10.0f,0.8f, -0.05f, 6),
        new Parameter(0.0f, 5.0f,0.7f, -0.04f, 3),
        new Parameter(-10.0f, 0.0f,10000.0f, 0.0f, 0)
    };






    void Update()
    {

        if (GameSwitch == true)
        {
            this.time -= Time.deltaTime;

            foreach (Parameter p in ParameterArray)
            {
                if (p.startTime <= this.time && this.time < p.endTime)
                {
                    this.ItemGenerator.GetComponent<ItemGenerator>().SetParameter(p.interval, p.speed, p.rate);
                }

            }

            
            if (this.time < 0)
            {
                this.time = 0;
                GameSwitch = false;
            }/*
            else if (0 <= this.time && this.time < 5)
            {
                this.ItemGenerator.GetComponent<ItemGenerator>().SetParameter(0.9f, -0.04f, 3);
            }
            else if (5 <= this.time && this.time < 10)
            {
                this.ItemGenerator.GetComponent<ItemGenerator>().SetParameter(0.4f, -0.06f, 6);
            }
            else if (10 <= this.time && this.time < 20)
            {
                this.ItemGenerator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 4);
            }
            else if (20 <= this.time && this.time < 30)
            {
                this.ItemGenerator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 2);
            }*/

            this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");
            this.pointText.GetComponent<TextMeshProUGUI>().text = this.point.ToString() + " point";
        }
    }

    public void GameStart()
    {
        GameSwitch = true;
        StartPanel.SetActive(false);
    }


}
