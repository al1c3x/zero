using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : tSingleton<GameManager>, IDataPersistence
{
    private int playerScore = 0;
    [HideInInspector] public int _highScore = 0;
    [HideInInspector] public float _longestTimeSurvived = 0.0f;
    private Dictionary<ECollectible, int> collectibleUpgradeLevel = new Dictionary<ECollectible, int>();
    private float gameTime = 0.0f;

    private List<float> SpeedUpgradeEquivalents = new List<float>();
    private List<float> MultiplierUpgradeEquivalents = new List<float>();
    private List<float> DepleteUpgradeEquivalents = new List<float>();

    protected override void Awake()
    {
        base.Awake();

        //for now, upgrade values are reset every new playthrough
        //values are defaulted at 1

        collectibleUpgradeLevel[ECollectible.SpeedCollectible] = 1;
        collectibleUpgradeLevel[ECollectible.MultiplierCollectible] = 1;
        collectibleUpgradeLevel[ECollectible.SlowDepleteCollectible] = 1;

    }

    void Start()
    {

    }
    
    public void ResetPlayerScore()
    { 
        playerScore = 0; 
        gameTime = 0.0f; 
    }

    public void SetPlayerScore(int score)
    { 
        playerScore = score; 
    }
    public int GetPlayerScore()
    { 
        return playerScore; 
    }

    public Dictionary<ECollectible, int> GetUpgradeDictionary()
    {
        return collectibleUpgradeLevel;
    }

    public float GetGameTime()
    {
        return gameTime;
    }

    public void SetGameTime(float timeVal)
    {
        gameTime = timeVal;
    }

    public float GetSpeedUpgradeEquivalent(int upgradeLevel)
    {
        return upgradeLevel * 1.5f;
    }

    public float GetMultiplierUpgradeEquivalent(int upgradeLevel)
    {
        return upgradeLevel;
    }

    public float GetSlowDepleteUpgradeEquivalent(int upgradeLevel)
    {
        switch(upgradeLevel)
        {
            case 1:
                return 0.005f;
                break;
            case 2:
                return 0.003f;
                break;
            case 3:
                return 0.001f;
                break;
            case 4:
                return 0.00085f;
                break;
            case 5:
                return 0.00075f;
                break;
        }

        //dummy return
        return 1.0f;
    }

    public void LoadData(GameData data)
    {
        _highScore = data._highScore;
        _longestTimeSurvived = data._longestTimeSurvived;

        for (int i = 0; i < collectibleUpgradeLevel.Count; i++)
        {
            if (data.powerupLevels.ContainsKey(i))
                collectibleUpgradeLevel[(ECollectible) i] = data.powerupLevels[i];
        }
    }

    public void SaveData(GameData data)
    {
        if (playerScore > data._highScore)
            data._highScore = playerScore;
        if (gameTime > data._longestTimeSurvived)
            data._longestTimeSurvived = gameTime;
        
        for (int i = 0; i < collectibleUpgradeLevel.Count; i++)
        {
            data.powerupLevels.Remove(i);
        }
        for (int i = 0; i < collectibleUpgradeLevel.Count; i++)
        {
            data.powerupLevels.Add(i, collectibleUpgradeLevel[(ECollectible)i]);
        }
    }
}
