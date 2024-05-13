using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


[System.Serializable] public class score
{
    public score(string n, float t)
    {
        name = n;
        time = t;

    }
    public string name;
    public float time;
}

public class ScoreList : MonoBehaviour
{

    public List<score> scores = new List<score>();
    public string fileName;
    public GameObject input;
    public GameObject finalpanel;
    public GameObject leaderboard;
    public GameObject lbPrefab;


    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(fileName))
        {
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                while (true)
                {
                    try
                    {
                        string name = reader.ReadString();
                        float time = reader.ReadSingle();

                        scores.Add(new score(name, time));
                    }

                    catch
                    {
                        break;
                    }

                   
                }
            }
        }
    }

   // Update is called once per frame
    void Update()
    {
        
    }

    public void NewEntry()
    {
        string name = input.GetComponent<TMP_InputField>().text;



        float time = Time.time - GameData.gamePlayStart;

        scores.Insert(0, new score(name, time));

        int offset = 0;
        foreach(score score in scores)
        {
            GameObject temp = Instantiate(lbPrefab);
            Transform[] children = temp.GetComponentsInChildren<Transform>();
            children[1].GetComponent<TextMeshProUGUI>().text = score.name;
            children[2].GetComponent<TextMeshProUGUI>().text = score.time.ToString("F2");

            temp.transform.SetParent(leaderboard.transform);
            RectTransform rtrans = temp.GetComponent<RectTransform>();
            rtrans.anchorMin = new Vector2(0.5f, 0.5f);
            rtrans.anchorMax = new Vector2(0.5f, 0.5f);
            rtrans.pivot = new Vector2(0.5f, 0.5f);
            rtrans.localPosition = new Vector3(0, offset, 0);

            offset -= 35;
        }

        finalpanel.SetActive(false);
        leaderboard.SetActive(true);
    }

    private void OnDestroy()
    {
        using(BinaryWriter write = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
        {
            foreach(score score in scores)
            {
                write.Write(score.name);
                write.Write(score.time);
            }

        }

    }
}