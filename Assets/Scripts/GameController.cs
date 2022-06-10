using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Singleton {get; private set;} = null;
    [SerializeField] private GameState gameState;
    [SerializeField] private Player player;
    [SerializeField] private BoosterController boosterPrefab;
    [SerializeField] private BoosterEffecter effecterPrefab;
    [SerializeField] private BoosterController victoryPrefab;
    [SerializeField] public float sensivity = 1;
    [SerializeField] private float boosterDistance;
    [SerializeField] private float startBoosterDistance;
    [SerializeField] private float marginEffectWidth;
    
    public GameState GameState
    {
        get => gameState;
        set 
        {
            gameState = value;
            if(gameState == GameState.DEFEAT)
            {
                player.Die();
            }   
        }
    }

    private Camera mainCam;
    private List<BoosterController> boosters;
    private Vector2 lastpos;
    private int currentBooster = -1;
    private float halfX;

    void Awake()
    {
        Singleton = this;
        mainCam = Camera.main;

        halfX = mainCam.orthographicSize * Screen.width / (float)Screen.height;
    }
    
    void Start()
    {
        SetupLevel();
        Play();
    }

    void Update()
    {
        ControlBooster();


    }

    private void Play()
    {
        currentBooster = 0;
        foreach(var booster in boosters)
        {
            booster.GetComponent<ObjectMover>().IsMoving = true;
        }
    }

    private void ControlBooster()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
        }
        else if(Input.GetMouseButton(0))
        {
            if(currentBooster >= 0 && currentBooster < boosters.Count) 
            {
                Vector2 curPos = mainCam.ScreenToViewportPoint(Input.mousePosition);
                Vector2 offset = curPos - (Vector2)mainCam.ScreenToViewportPoint(lastpos);
                offset.y = 0;
                boosters[currentBooster].transform.position += (Vector3)(offset * sensivity);

                lastpos = curPos;
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {

        }

        lastpos = Input.mousePosition;       
    }

    private void SetupLevel()
    {
        int numberBooster = 5;
        boosters = new List<BoosterController>(numberBooster);
        
        for(int i = 0; i < numberBooster; ++i)
        {
            // Spawn booster
            var booster = Instantiate(boosterPrefab);
            booster.transform.position = new Vector3(0, startBoosterDistance + i * boosterDistance, 0);

            boosters.Add(booster);

            // Spawn Effect box on the booster
            var effect1 = Instantiate(effecterPrefab, booster.transform);
            effect1.transform.localPosition = new Vector3(Random.Range(-halfX + marginEffectWidth, halfX - marginEffectWidth), 0, 0);
        }

        var victoryObj = Instantiate(victoryPrefab);
        victoryObj.transform.position = new Vector3(0, startBoosterDistance + numberBooster * boosterDistance, 0);
        boosters.Add(victoryObj);
    }

    public void NextBooster()
    {
        currentBooster++;
    }

    public void BoostStraight()
    {

    }
    
    public void BoostLeft()
    {

    }

    public void BoostRight()
    {

    }
}
