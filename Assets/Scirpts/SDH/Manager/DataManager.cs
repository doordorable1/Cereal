using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public CerealBowlControl CerealBowlControl => cerealBowlControl;
    private CerealBowlControl cerealBowlControl;
    public CerealBowlScore CerealBowlScore => cerealBowlScore;
    private CerealBowlScore cerealBowlScore;

    public int Stage => stage;
    private int stage;
    public int Gold => gold;
    private int gold;
    public int Score => score;
    private int score;

    public void StartGame()
    {
        cerealBowlControl = new();
        cerealBowlScore = new();
        stage = 0;
        gold = 0;
        score = 0;
    }

    public void CalculateScore()
    {
        score = cerealBowlScore.CalculateCerealBowlScore();
    }
}
