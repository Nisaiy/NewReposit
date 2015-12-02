using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float playerSpeed;
    private int count;
    public Text countText;

    void countCoins()
    {
        countText.text = "Coins:" + count;
    }

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countCoins();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0, 0);

        rb.AddForce(movement * playerSpeed);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            countCoins();
            if (count > HighScore.score)
            {
                HighScore.score = count;
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("DeadlyObstecles"))
        {
            Generate gener = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Generate>() as Generate;

            gener.isAlive = false;
        }

    }
}
