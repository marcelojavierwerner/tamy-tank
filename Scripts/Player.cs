using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speedX = 4.0f;

    //public float speedY = 4.0f; //Revisar

    public float movementX = 0;

    public float horizontal = 0;

    //public float vertical = 0; //Revisar

    //public float movementY = 0; //Revisar

    float newX;

    Rigidbody2D rb;

    Animator animator;

    LifeManager lm;

    SpriteRenderer sr;

    public AudioSource motor;

    public bool rightWall;

    public bool leftWall;

    public GameObject shield;

    public bool blink;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        lm = FindObjectOfType<LifeManager>();
    }

    void Start () {
        
	}
	
	
	void Update () {

        if (GameManager.inGame)
        {

            movementX = horizontal * speedX;

            animator.SetInteger("velX", Mathf.RoundToInt(movementX));

            if (movementX < 0)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.inGame)
        {
            if (leftWall)
            {
                if (horizontal == -1) //Cambiar boton
                {
                    speedX = 0;
                }
                else if (horizontal != 0)
                {
                    speedX = 4;
                }
            }
            if (rightWall)
            {
                if (horizontal == 1)
                {
                    speedX = 0;
                }
                else if (horizontal != 0)
                {
                    speedX = 4;
                }
            }

            rb.MovePosition(rb.position + Vector2.right * movementX * Time.fixedDeltaTime);

            newX = Mathf.Clamp(transform.position.x, -7.15f, 7.15f);

            transform.position = new Vector2(newX, transform.position.y);

        }
    }

    public void Win()
    {
        shield.SetActive(false);
        animator.SetBool("win", true);
    }

    private void OnBecameInvisible()
    {
        if (lm.lifes <= 0)
        {
            //Aca iria el panel tambien
            GameManager.gm.StartGameOver();
        }
        else
        {
            Invoke("ReloadLevel", 0.5f);
        }
    }

    public void ReloadLevel()
    {
        lm.SubstracLifes();

        lm.RestartLifesDoll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.inGame && !FreezeManager.fm.freeze)
        {
            if (other.gameObject.tag == "Ovni" || other.gameObject.tag == "Hexagon")
            {

                if (shield.activeInHierarchy)
                {

                    shield.SetActive(false);

                    StartCoroutine(Blinking());

                }
                else
                {
                    if (!blink)
                    {
                        StartCoroutine(Lose());
                    }   
                }
            }
        }

        if (!GameManager.inGame && (other.gameObject.tag == "Right" || other.gameObject.tag == "Left"))
        {
            sr.flipX = !sr.flipX;
            rb.velocity /= 3;
            rb.velocity *= -1;
            rb.AddForce(Vector3.up * 5, ForceMode2D.Impulse);
        }



    }
    

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Left")
        {
            leftWall = true;
        }
        else if (other.gameObject.tag == "Right")
        {
            rightWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Left")
        {
            leftWall = false;
        }
        else if (other.gameObject.tag == "Right")
        {
            rightWall = false;
        }
    }

    public IEnumerator Blinking()
    {

        blink = true;

        for (int i = 0; i < 8; i++)
        {
            if (blink && GameManager.inGame)
            {
                sr.color = new Color(1, 1, 1, 0);
                yield return new WaitForSeconds(0.2f);
                sr.color = new Color(1, 1, 1, 1);
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                break;
            }
        }

        blink = false;
    }

    public void Loses()
    {
        StartCoroutine(Lose());
    }

    IEnumerator Lose()
    {
        GameManager.inGame = false;
        animator.SetBool("lose", true);
        OvniManager.bm.LoseGame();
        HexagonManager.hm.LoseGame();
        lm.LifeLose();

        yield return new WaitForSeconds(1);

        rb.isKinematic = false; //Lanzarlo pantalla

        if (transform.position.x < 0) //Lanzarlo pantalla
        {
            rb.AddForce(new Vector2(-10, 10), ForceMode2D.Impulse); //Lanzarlo pantalla
        }
        else
        {
            rb.AddForce(new Vector2(10, 10), ForceMode2D.Impulse); //Lanzarlo pantalla
        }
    }
}


