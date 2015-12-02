using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public class Generate : MonoBehaviour
{
    public List<GameObject> partOfRoads = new List<GameObject>();
    private float lustDistance, firstDistanse;
    public int start, cameraSpeed;
    private int gens = 0;
    private Queue<GameObject> oldPartsOfRoad;
    public bool isAlive = true;
    public Text gameOver;



    void CreateRoad()
    {

        int rand = Random.Range(1, partOfRoads.Count);
        GameObject tmp = Instantiate(partOfRoads[rand], new Vector3(0, 0, gens * 15), partOfRoads[rand].transform.rotation) as GameObject;
        oldPartsOfRoad.Enqueue(tmp);
        gens++;

    }

    // Use this for initialization
    void Start()
    {
        oldPartsOfRoad = new Queue<GameObject>();
        GameObject tmp = (GameObject)Instantiate(partOfRoads[0], new Vector3(0, 0, gens * 15), partOfRoads[0].transform.rotation);
        gens++;
        oldPartsOfRoad.Enqueue(tmp);
        for (int i = 0; i < start; i++)
        {
            CreateRoad();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (oldPartsOfRoad.Count < 10)
            {
                CreateRoad();
            }
            if (Vector3.Distance(transform.position, oldPartsOfRoad.Peek().transform.position) > 19)
            {
                GameObject tmpPart = oldPartsOfRoad.Dequeue();
                Destroy(tmpPart);
            }
        }
        else
        {
            gameOver.text = "GAME OVER";
        }

    }


    void FixedUpdate()
    {
        if (isAlive)
        {
            transform.Translate(new Vector3(0, 0, 0.01f * cameraSpeed));
        }
    }
    void OnGUI()
    {
        if (!isAlive)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Restart Game"))
            {
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 100), "Exit Game"))
            {
                Application.Quit();
            }

        }
    }
}
