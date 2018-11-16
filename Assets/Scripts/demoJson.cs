using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class demoJson : MonoBehaviour
{

    string path;
    string jsonstring;


    void Start()
    {
        path = Application.streamingAssetsPath + "/MyJson.json";
        jsonstring = File.ReadAllText(path);

        Debug.Log(jsonstring);

        PlacesCollection myplaces = JsonUtility.FromJson<PlacesCollection>(jsonstring);
        for (int i = 0; i < myplaces.Places.Length; i++)
        {
            Debug.Log(myplaces.Places[i].Name);
            Debug.Log(myplaces.Places[i].Addr);
            Debug.Log(myplaces.Places[i].Catalog);
        }
    }

}
[System.Serializable]
public class Place
{
    public string Name, Addr, Catalog;
}

[System.Serializable]
public class PlacesCollection
{
    public Place[] Places;
}