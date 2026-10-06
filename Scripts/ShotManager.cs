using UnityEngine;

public class ShotManager : MonoBehaviour {

    public static ShotManager shm;

    public GameObject[] Shots;

    Transform player;

    public int maxShots;
    public int numberOfShots = 0;
    public int typeOfShot; 

    Animator animator;

    CurrentShotImage shotImage;

    private void Awake()
    {

        if (shm == null)
        {
            shm = this;
        }
        else if (shm != this)
        {
            Destroy(gameObject);
        }

        player = FindObjectOfType<Player>().transform;
        shotImage = FindObjectOfType<CurrentShotImage>();
        animator = player.GetComponent<Animator>();
    }

    void Start () {
        if (CanShot() && Buttons.shotButton && GameManager.inGame)
        {
            Shot();
        }
        typeOfShot = 2;
        maxShots = 1;
    }
	
	
	void Update () {
        if (CanShot() && Buttons.shotButton && GameManager.inGame)
        {
            Shot();
        }
        if (numberOfShots == maxShots
            && GameObject.FindGameObjectsWithTag("Bala").Length == 0
              && GameObject.FindGameObjectsWithTag("BalaFuego").Length == 0
              && GameObject.FindGameObjectsWithTag("Laser").Length == 0
              && GameObject.FindGameObjectsWithTag("Laser3").Length == 0
              )
        {
            numberOfShots = 0;
        }

        if (animator.GetBool("shot") && player.GetComponent<Player>().movementX != 0)
        {
            animator.SetBool("shot", false);
        }
    }

    bool CanShot()
    {

        if (numberOfShots < maxShots)
        {
            return true;
        }

        return false;
    }

    void Shot()
    {
        if (player.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            animator.SetTrigger("shot");
        }

        if (typeOfShot != 4)
        {
            Instantiate(Shots[typeOfShot], player.position, Quaternion.identity);
            numberOfShots++;
        }
        else
        {
            Instantiate(Shots[4], new Vector2(player.position.x + .5f, player.position.y + 1),
                Quaternion.Euler(new Vector3(0, 0, -5)));

            Instantiate(Shots[4], new Vector2(player.position.x, player.position.y + 1),
                Quaternion.identity);

            Instantiate(Shots[4], new Vector2(player.position.x - .5f, player.position.y + 1),
                Quaternion.Euler(new Vector3(0, 0, 5)));

            numberOfShots++;
        }

    }

    public void DestroyShot()
    {

        if (numberOfShots > 0 && numberOfShots < maxShots)
        {
            numberOfShots--;
            Destroy(gameObject, 15);
        }
    }

    public void ChangeShot(int type)
    {

        if (typeOfShot != type)
        {

            switch (type)
            {

                case 0:
                    maxShots = 1;
                    shotImage.CurrentShot("Bala");
                    break;

                case 1:
                    maxShots = 1;
                    shotImage.CurrentShot("BalaFuego");
                    break;

                case 2:
                    maxShots = 1;
                    shotImage.CurrentShot("MultiBala");
                    break;

                case 3:
                    maxShots = 1;
                    shotImage.CurrentShot("Laser");
                    break;

                case 4:
                    maxShots = 1;
                    shotImage.CurrentShot("Laser3");
                    break;
            }

            typeOfShot = type;
            numberOfShots = 0;

        }
    }
}
