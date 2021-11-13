using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCreation : MonoBehaviour
{
    [Header("Character Creation Defaults")]
    [SerializeField]
<<<<<<< Updated upstream
    int[] statValues = new int[(int)PlayerStatType.STATCOUNT];
=======
    int[] newCharacterStats = new int[(int)PlayerStatType.STATCOUNT];

>>>>>>> Stashed changes
    [SerializeField]
    int[] baseCharacterStats = new int[(int)PlayerStatType.STATCOUNT];

    [SerializeField]
    int pointsAvailable = 0;
    int pointsUsed = 0;

    [Header("UI Elements")]
    [SerializeField]
    Text[] StatDisplayText = new Text[(int)PlayerStatType.STATCOUNT];

    [SerializeField]
    Text AvailablePointsText;

    private void Start()
    {
        if (GameStatics._fileLoaded) LoadFromPlayer();
        else LoadDefaultCharacter();
        DisplayValues();
    }

    private void DisplayValues()
    {
        int i = 0;
        foreach (Text text in StatDisplayText)
        {
<<<<<<< Updated upstream
            int skillModifier = 0;
            foreach (int mod in modifiers[i]) { skillModifier += mod; }
            StatDisplayText[i].text = (statValues[i] + skillModifier).ToString();
=======
            text.text = $"{newCharacterStats[i++]}";
>>>>>>> Stashed changes
        }
        AvailablePointsText.text = $"{pointsAvailable}";
    }

    public void IncrementStat(int type)
    {
        if (pointsAvailable > 0)
        {
            pointsAvailable--;
            pointsUsed++;
            newCharacterStats[type] += GameStatics._statIncrementValues[type];
            DisplayValues();
        }
    }

    public void LoadFromPlayer()
    {
        for (int i = 0; i < (int)PlayerStatType.STATCOUNT; i++)
        {
<<<<<<< Updated upstream
            statValues[i] = PlayerStats._stats[i];
            foreach(int mod in PlayerStats._modifiers[i]) statValues[i] += mod;
=======
            baseCharacterStats[i] = newCharacterStats[i] = GameStatics._currentPlayerStats[i];
>>>>>>> Stashed changes
        }
        pointsAvailable = GameStatics._playerUpgradePoints;
        Debug.Log($"Loaded from {GameStatics._currentSaveFileName}");
    }

    public void LoadDefaultCharacter()
    {
        for (int i = 0; i < (int)PlayerStatType.STATCOUNT; i++)
        {
            baseCharacterStats[i] = newCharacterStats[i] = GameStatics._currentPlayerStats[i] = GameStatics._statMinValues[i];
        }
        pointsAvailable = GameStatics._playerUpgradePoints = 3;
        Debug.Log("Default Character Loaded");
    }

    public void SaveToStatics()
    {
        for (int i = 0; i < (int)PlayerStatType.STATCOUNT; i++)
        {
            GameStatics._currentPlayerStats[i] = newCharacterStats[i];
        }
        GameStatics._playerUpgradePoints = pointsAvailable;
        Debug.Log("PlayerStats updated");
    }
<<<<<<< Updated upstream
=======

    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
   
>>>>>>> Stashed changes
    public void Revert()
    {
        pointsAvailable += pointsUsed;
        pointsUsed = 0;
        for (int i = 0; i < (int)PlayerStatType.STATCOUNT; i++)
        {
            newCharacterStats[i] = baseCharacterStats[i];
        }
        DisplayValues();
    }
}
