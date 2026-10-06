using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public static GameManager gm;

    public static bool inGame;

    Player player;
    LifeManager lm;
    Flags flags;

    //public GameObject panel;
    public GameObject panelWin;
    //PanelPoints panelPoints;

    public GameObject ready;
    public GameObject gameOver;
    public GameObject pauseObject;
    public GameObject noPause;

    public int ovnisDestroyed = 0;
    public int hexagonsDestroyed = 0;
    //public int flagsCatched = 0;

    Image progressBar;
    Text levelText;
    //int currentLevel = 1;

    public Text timeText;
    public float time = 100;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
        else if (gm != this)
        {
            Destroy(gameObject);
        }

        player = FindObjectOfType<Player>();
        lm = FindObjectOfType<LifeManager>();
        flags = FindObjectOfType<Flags>();

        progressBar = GameObject.FindGameObjectWithTag("Progress").GetComponent<Image>();
        levelText = GameObject.FindGameObjectWithTag("Level").GetComponent<Text>();
    }

    void Start () {
        StartCoroutine(GameStart());
        ScoreManager.sm.UpdateHiScore();
        gameOver.SetActive(false);
        progressBar.fillAmount = 0;
    }
	

	void Update () {
        
        if (FlagManager.fms.arg.activeInHierarchy && FlagManager.fms.ara.activeInHierarchy &&
            FlagManager.fms.ale.activeInHierarchy && FlagManager.fms.bra.activeInHierarchy &&
            FlagManager.fms.chi.activeInHierarchy && FlagManager.fms.chn.activeInHierarchy &&
            FlagManager.fms.din.activeInHierarchy && FlagManager.fms.egi.activeInHierarchy &&
            FlagManager.fms.esp.activeInHierarchy && FlagManager.fms.fra.activeInHierarchy &&
            FlagManager.fms.hol.activeInHierarchy && FlagManager.fms.irk.activeInHierarchy &&
            FlagManager.fms.irn.activeInHierarchy && FlagManager.fms.isr.activeInHierarchy &&
            FlagManager.fms.ita.activeInHierarchy && FlagManager.fms.jap.activeInHierarchy &&
            FlagManager.fms.kdn.activeInHierarchy && FlagManager.fms.kds.activeInHierarchy &&
            FlagManager.fms.mex.activeInHierarchy && FlagManager.fms.por.activeInHierarchy &&
            FlagManager.fms.qat.activeInHierarchy && FlagManager.fms.rsa.activeInHierarchy &&
            FlagManager.fms.rus.activeInHierarchy && FlagManager.fms.usa.activeInHierarchy &&
            FlagManager.fms.uru.activeInHierarchy && FlagManager.fms.ind.activeInHierarchy &&
            FlagManager.fms.col.activeInHierarchy && FlagManager.fms.gre.activeInHierarchy &&
            FlagManager.fms.per.activeInHierarchy && FlagManager.fms.aus.activeInHierarchy &&
            !ready.activeInHierarchy)
        {
            inGame = false;
            player.Win();
            lm.LifeWin();
            OvniManager.bm.LoseGame();
            panelWin.SetActive(true);

            StartCoroutine(GameWin());
        }
        //if (OvniManager.bm.ovnis.Count == 0 && HexagonManager.hm.hexagons.Count == 0)
        //{
        //    inGame = false;
        //
        //    player.Win();
        //
        //    lm.LifeWin();
        //
        //    panel.SetActive(true);
        //
        //    panelPoints = panel.GetComponent<PanelPoints>();
        //}
        if (OvniManager.bm.ovnis.Count == 0 && HexagonManager.hm.hexagons.Count == 0 && EnemiesSpawn.bs.free)
        {
            EnemiesSpawn.bs.NewEnemies();
        }
        if (inGame)
        {
           time -= Time.deltaTime;
           timeText.text = "TIME " + time.ToString("f0");
        }
        if (timeText.text == "TIME 0")
        {

            if (lm.lifes <= 0)
            {
                //panel.SetActive(true); //Habria que acomodarlo
                //panelPoints = panel.GetComponent<PanelPoints>(); //Aca iria el panel tambien
                StartGameOver();
            }
            else
            {
                player.Loses();
                player.ReloadLevel();
            }
        }
    }

    public void UpdateOvnisDestroyed()
    {
        ovnisDestroyed++;
        
        if (ovnisDestroyed % Random.Range(5, 15) == 0 && OvniManager.bm.ovnis.Count > 0)
        {
            flags.InstaciateFlag();
        }

    }

    public void UpdateHexagonDestroyed()
    {
        hexagonsDestroyed++;
        
        if (hexagonsDestroyed % Random.Range(3, 8) == 0 && HexagonManager.hm.hexagons.Count > 0)
        {
            flags.InstaciateFlag();
        }

    }

    //public void NextLevel()
    //{
    //    lm.RestartLifesDoll();

    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    public void StartGameOver()
    {
        if (gm != null)
        {
            StartCoroutine(GameOver());
        }
    }

    public void GamePause()
    {     
        StartCoroutine(Pausa());
    }

    public void NoGamePause()
    {
        StartCoroutine(NoPausa());
    }

    public IEnumerator GameStart()
    {
        yield return new WaitForSeconds(3);

        ready.SetActive(false);

        inGame = true;

        //OvniManager.bm.StartGame(); //Esto no iria en Panic

        //HexagonManager.hm.StartGame(); //Esto no iria en Panic

        EnemiesSpawn.bs.NewEnemies();

        
    }

    public IEnumerator GameOver()
    {
        gameOver.SetActive(true);

        yield return new WaitForSeconds(2);

        GameObject destroy = FindObjectOfType<DontDestroy>().gameObject;
        {
            Destroy(destroy);
        }

        SceneManager.LoadScene(4);
    }

    public IEnumerator GameWin()
    {
        yield return new WaitForSeconds(7);

        GameObject destroy = FindObjectOfType<DontDestroy>().gameObject;
        {
            Destroy(destroy);
        }

        SceneManager.LoadScene(3);
    }

    public IEnumerator Pausa()
    {
        pauseObject.SetActive(true);
        inGame = false;
        OvniManager.bm.LaPausa();
        noPause.SetActive(true);
        yield return new WaitForSeconds(0.1f);
    }

    public IEnumerator NoPausa()
    {
        pauseObject.SetActive(false);
        inGame = true;
        OvniManager.bm.NoPausa();
        noPause.SetActive(false);
        yield return new WaitForSeconds(0.1f);
    }

    public int AleatoryNumber()
    {
        return Random.Range(0, 3);
    }

    public void PanicProgress()
    {
        progressBar.fillAmount += 0.1f;

        if (progressBar.fillAmount == 1)
        {
            progressBar.fillAmount = 0;

            ScoreManager.sm.currentLevel++;
            //currentLevel++;

            time = 100;

            EnemiesSpawn.bs.IncreaseDificulty();

            if (ScoreManager.sm.currentLevel < 10)
            {
                levelText.text = "LEVEL 0" + ScoreManager.sm.currentLevel.ToString();
            }
            else
            {
                levelText.text = "LEVEL " + ScoreManager.sm.currentLevel.ToString();
            }

            FindObjectOfType<BackgroundsChange>().BackGroundChange();
        }
    }
}
