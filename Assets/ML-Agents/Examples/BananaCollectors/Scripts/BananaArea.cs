using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class BananaArea : Area
{
    public GameObject banana;
    public GameObject badBanana;
    public int numBananas;
    public int numBadBananas;
    public bool respawnBananas;
    public float range;
    public Vector3[] vector;
    public Quaternion[] euler;
    public Vector3[] vectorBad;
    public Quaternion[] eulerBad;

    // Use this for initialization
    void Start()
    {
        vector= new Vector3[numBananas];
        euler =new Quaternion[numBananas];
        for (int i = 0; i < numBananas; i++)
        {
        vector[i]=new Vector3(Random.Range(-range, range), 1f,Random.Range(-range, range)) + transform.position;
        euler[i]=Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 90f));
    }

        vectorBad= new Vector3[numBadBananas];
        eulerBad =new Quaternion[numBadBananas];
        for (int i = 0; i < numBadBananas; i++)
        {
        vectorBad[i]=new Vector3(Random.Range(-range, range), 1f,Random.Range(-range, range)) + transform.position;
        eulerBad[i]=Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 90f));
    }

        respawnBananas= true;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateBanana(int numBana, GameObject bananaType)
    {
        for (int i = 0; i < numBana; i++)
        {
            GameObject bana = Instantiate(bananaType, vector[i],
                                          euler[i]);
            bana.GetComponent<BananaLogic>().respawn = respawnBananas;
            bana.GetComponent<BananaLogic>().myArea = this;
            bana.GetComponent<BananaLogic>().vector=vector[i];
        }
    }

    void CreateBadBanana(int numBana, GameObject bananaType)
    {
        for (int i = 0; i < numBana; i++)
        {
            GameObject bana = Instantiate(bananaType, vectorBad[i],
                                          eulerBad[i]);
            bana.GetComponent<BananaLogic>().respawn = respawnBananas;
            bana.GetComponent<BananaLogic>().myArea = this;
            bana.GetComponent<BananaLogic>().vector=vectorBad[i];
        }
    }

    public void ResetBananaArea(GameObject[] agents)
    {
        foreach (GameObject agent in agents)
        {
            if (agent.transform.parent == gameObject.transform)
            {
                agent.transform.position = new Vector3(Random.Range(-range, range), 2f,
                                                       Random.Range(-range, range))
                    + transform.position;
                agent.transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0, 360)));
            }
        }

        CreateBanana(numBananas, banana);
        CreateBadBanana(numBadBananas, badBanana);
    }

    public override void ResetArea()
    {
    }
}
