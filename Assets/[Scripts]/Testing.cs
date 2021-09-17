using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Testing : MonoBehaviour
{
    [SerializeField]
    Text StatDisplay;

    private void Start()
    {
        //Initializes the lists inside the static class
        for (int i = 0; i < (int)PlayerStatType.STATCOUNT; i++)
        {
            PlayerStats._modifiers[i] = new List<int>();
        }
    }

    public void GenerateRandomUserData()
    {
        FlushPlayerData();
        for (int i = 0; i < (int)PlayerStatType.STATCOUNT; i++ )
        {
            PlayerStats._stats[i] = Random.Range(0, 100);
            int randomMods = Random.Range(0, 5);
            for (int j = 0; j < randomMods; j++)
            {
                PlayerStats._modifiers[i].Add(Random.Range(-10, 10));
            }
        }
    }

    public void DisplayUserData()
    {
        string output = "";
        for (int i = 0; i < (int)PlayerStatType.STATCOUNT; i++)
        {
            output += ((PlayerStatType)i).ToString() + $": {PlayerStats._stats[i]}";
            int modifierCount = PlayerStats._modifiers[i].Count;
            if (modifierCount > 0)
            {
                foreach (int mod in PlayerStats._modifiers[i])
                {
                    output += $" + {mod}";
                }
            }
            output += "\n";
        }
        StatDisplay.text = output;
    }

    public void FlushPlayerData()
    {
        for (int i = 0; i < (int)PlayerStatType.STATCOUNT; i++)
        {
            PlayerStats._stats[i] = 0;
            if (PlayerStats._modifiers[i].Count > 0)
            {
                PlayerStats._modifiers[i].Clear();
            }
        }
    }

    public void WritePlayerData(string fname)
    {
        StreamWriter sw = new StreamWriter(Application.dataPath + Path.DirectorySeparatorChar + $"{fname}" + ".txt");
        for (int i = 0; i < (int)PlayerStatType.STATCOUNT; i++)
        {
            int modifierCount = PlayerStats._modifiers[i].Count;
            string line = $"{PlayerStats._stats[i]},{PlayerStats._modifiers[i].Count}";
            if (modifierCount > 0)
            {
                foreach (int mod in PlayerStats._modifiers[i])
                {
                    line += $",{mod}";
                }
            }
            sw.WriteLine(line);
        }
        sw.Close();
    }

    public void ReadPlayerData(string fname)
    {
        //TODO
    }
}
