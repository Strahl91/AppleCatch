using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bananaPrefab;
    public GameObject bombPrefab;
    public bool ItemSwitch = false;
    float span = 1.0f;
    float delta = 0;
    int ratio = 2;
    float speed = -0.03f;

    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }

    void Update()
    {

        if (ItemSwitch == true)
        {
            this.delta += Time.deltaTime;
        }

        if (this.delta > this.span && ItemSwitch == true)
        {
            this.delta = 0;
            GameObject item;
            GameObject Prefab;

            int dice = Random.Range(1, 11);

            if (dice <= this.ratio)
            {
                Prefab = bombPrefab;
            }
            else if (dice <= 5)
            {
                Prefab = bananaPrefab;
            }
            else
            {
                Prefab = applePrefab;
            }

            item = Instantiate(Prefab) as GameObject;

            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
    }
}
