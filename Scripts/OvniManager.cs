using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvniManager : MonoBehaviour {

    public static OvniManager bm;

    public bool spliting;

    public List<GameObject> ovnis = new List<GameObject>();

    Player player;

    public AudioSource explosion;

    private void Awake()
    {
        if (bm == null)
        {
            bm = this;
        }
        else if (bm != this)
        {
            Destroy(gameObject);
        }

        player = FindObjectOfType<Player>();
    }

    void Start () {
        ovnis.AddRange(GameObject.FindGameObjectsWithTag("Ovni"));
        explosion = GetComponent<AudioSource>();
    }
	
	
	void Update () {
		
        //if(ovnis.Count == 0)
        //{
        //    player.Win();

        //    GameManager.inGame = false;
        //}
	}

    public void StartGame()
    {
        foreach (GameObject item in ovnis)
        {
            if (ovnis.IndexOf(item) % 2 == 0)
            {
                item.GetComponent<Ovni>().right = true;
            }
            else
            {
                item.GetComponent<Ovni>().right = false;
            }

            item.GetComponent<Ovni>().StartForce(item);
        }
    }

    public void LoseGame()
    {
        foreach (GameObject item in ovnis)
        {
            item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            item.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    public void LaPausa()
    {
        foreach (GameObject item in ovnis)
        {
            item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            item.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    public void NoPausa()
    {
        foreach (GameObject item in ovnis)
        {
            item.GetComponent<Rigidbody2D>().isKinematic = false;
            item.GetComponent<Ovni>().NormalSpeedOvni();
        }
    }

    public void DestroyOvni(GameObject ovni, GameObject ovni1, GameObject ovni2)
    {
        Destroy(ovni);
        ovnis.Remove(ovni);
        ovnis.Add(ovni1);
        ovnis.Add(ovni2);
        explosion.Play();
    }

    public void LastOvni(GameObject ovni)
    {
        Destroy(ovni);
        ovnis.Remove(ovni);
        explosion.Play();
    }

    public void Bomb(int maxNumberBalls)
    {
        if (FreezeManager.fm.freeze == false)
        {
            StartCoroutine(BombB(maxNumberBalls));
        }
    }

    public void SlowTime()
    {

        StartCoroutine(TimeSlow());
    }

    List<GameObject> FindOvnis(int typeOfOvnis)
    {

        List<GameObject> OvnisToDestroy = new List<GameObject>();

        for (int i = 0; i < ovnis.Count; i++)
        {
            if (ovnis[i].GetComponent<Ovni>().name.Contains(typeOfOvnis.ToString()) && ovnis[i] != null)
            {
                OvnisToDestroy.Add(ovnis[i]);
            }
        }

        return OvnisToDestroy;
    }

    void ReloadList()
    {
        ovnis.Clear();
        ovnis.AddRange(GameObject.FindGameObjectsWithTag("Ovni"));
    }

    public IEnumerator BombB(int maxNumberBalls)
    {

        ReloadList();

        spliting = true;

        int numberToFind = 1;

        while (numberToFind < maxNumberBalls)
        {

            foreach (GameObject item in FindOvnis(numberToFind))
            {
                item.GetComponent<Ovni>().Split();
                Destroy(item);
            }

            yield return new WaitForSeconds(0.4f);

            ReloadList();

            numberToFind++;
        }

        spliting = false;
    }

    public IEnumerator TimeSlow()
    {
        float time = 0;

        foreach (GameObject item in ovnis)
        {
            if (item != null)
            {
                item.GetComponent<Ovni>().SlowOvni();
            }
        }

        while (time < 3)
        {
            time += Time.deltaTime;
            yield return null;
        }

        foreach (GameObject item in ovnis)
        {
            if (item != null)
            {
                item.GetComponent<Ovni>().NormalSpeedOvni();
            }
        }
    }

}
