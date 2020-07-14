using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Applel : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject colletd;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            colletd.SetActive(true);

            GameController.instance.totalScore += score;
            GameController.instance.UpdateScoreText();
            Destroy(gameObject, 0.25f);
        }
    }
}
