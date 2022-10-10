using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class MapController : MonoBehaviour
{
    public List<GameObject> Objects;
    public GameObject map;

    private void Awake()
    {
        MapReader();
    }

    private void MapReader()
    {

        string fileName = "Assets/Maps/" + SceneManager.GetActiveScene().name + ".CSV";
        StreamReader streamReader = new StreamReader(fileName);

        string data;
        int key = -1;

        if (streamReader != null)
        {
            for (int i = 0; i < 10; i++)
            {
                data = streamReader.ReadLine();
                if (data != null)
                {
                    string[] split_data = data.Split(',');
                    for (int j = 0; j < split_data.Length; j++)
                    {
                        if (split_data[j] != "")
                        {
                            Vector3 pos = new Vector3(j - 8.0f, -i + 1.2f, 0);
                            int obj = Convert.ToInt32(split_data[j]);

                            switch (obj)
                            {
                                case -1:
                                    key = 0; // blank
                                    break;

                                case 10:
                                    key = 1; // left map block
                                    break;

                                case 20:
                                    key = 2; // middle map block
                                    break;

                                case 30:
                                    key = 3; // right map block
                                    break;

                                case 50:
                                    key = 4; // jelly item
                                    break;

                                case 100:
                                    key = 5; // yellow item
                                    break;

                                case 300:
                                    key = 6; // pink item
                                    break;

                                case -10:
                                    key = 7; // spike
                                    break;

                                case 0:
                                    key = 8; // finish;
                                    break;
                            }

                            Instantiate(Objects[key], pos, Quaternion.identity).transform.SetParent(map.transform);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
        else
        {
            Debug.Log("no Data");
        }
    }
}
