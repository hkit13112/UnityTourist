using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class PlacementDataSource
{
  static PlacesCollection data;

  private static IEnumerator _LoadDataFromFile()
  {
    string path = Application.streamingAssetsPath + "/MyJson.json";
    string jsonstring = File.ReadAllText(path);
    data = JsonUtility.FromJson<PlacesCollection>(jsonstring);
    yield return null;
  }

  private static IEnumerator _LoadDataFromJsonUrl()
  {
    // todo: load data from link
    yield return null;
  }

  public static IEnumerator WaitingDataReady()
  {
    if (data == null)
      yield return _LoadDataFromFile();
  }

  public static PlacesCollection GetPlacesCollection()
  {
    Debug.Assert(data != null, "Data have not been loaded. Please check WaitingDataReady first");
    return data;
  }

  public static Place GetPlaceByIndex(int index)
  {
    Debug.Assert(data != null, "Data have not been loaded. Please check WaitingDataReady first");
    Debug.Assert(index >= 0 && index < data.Places.Length, "Index out of range");
    return data.Places[index];
  }
}
