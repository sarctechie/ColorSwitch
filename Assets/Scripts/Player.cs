using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce= 10f;
    public Rigidbody2D circle;
    public string currentColor;
    public SpriteRenderer sr;
    public Color Cyan;
    public Color Yellow;
    public Color Magenta;
    public Color Violet;
    public static int score=0;
    public Text scoreText;
    public GameObject[] Obstacle;
    public GameObject ColorChanger;

    void Start()
    {
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")||Input.GetMouseButtonDown(0))
        {
            circle.velocity= Vector2.up*jumpForce;
        }

        scoreText.text=score.ToString();
    }

     private void OnTriggerEnter2D(Collider2D collision) 
     {
            if(collision.tag=="Scored")
        {
            score++;
            Destroy(collision.gameObject);
            int randomNumber= Random.Range(0,3);
            if(randomNumber==0)
            Instantiate(Obstacle[0], new Vector2(transform.position.x, transform.position.y+7f), transform.rotation);
            if(randomNumber==1)
            Instantiate(Obstacle[1], new Vector2(transform.position.x, transform.position.y+7f), transform.rotation);
            if(randomNumber==2)
            Instantiate(Obstacle[2], new Vector2(transform.position.x, transform.position.y+10f), transform.rotation);


            return;
        }
        

        if(collision.tag== "ColorChanger")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            Instantiate(ColorChanger, new Vector2(transform.position.x, transform.position.y+7f), transform.rotation);
            return;
        }

                if(collision.tag!=currentColor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            score=0;
        }

    }

    void SetRandomColor()
    {
        int rand= Random.Range(0,4);

        switch (rand)
        {
            case 0:
            currentColor="Cyan";
            sr.color=Cyan;
            break;
            case 1:
            currentColor="Yellow";
            sr.color=Yellow;
            break;
            case 2:
            currentColor="Magenta";
            sr.color=Magenta;
            break;
            case 3:
            currentColor="Violet";
            sr.color=Violet;
            break;
        }
    }
}
