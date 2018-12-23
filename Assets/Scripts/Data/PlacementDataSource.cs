using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class PlacementDataSource
{
  public static PlacesCollection data;

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

  public static PlacesCollection GetPlacesCollectionWithFilter(System.Func<Place, bool> filter = null)
  {
    if (filter == null) return GetPlacesCollection();

    Debug.Assert(data != null, "Data have not been loaded. Please check WaitingDataReady first");
    PlacesCollection cloneData = new PlacesCollection();
    List<Place> filteredData = new List<Place>();
    foreach (Place item in data.Places)
    {
      if (filter(item)) filteredData.Add(item);
    }
    cloneData.Places = filteredData.ToArray();
    return cloneData;
  }

  public static Place GetPlaceById(int index)
  {
    Debug.Assert(data != null, "Data have not been loaded. Please check WaitingDataReady first");
    Debug.Assert(index >= 0 && index < data.Places.Length, "Index out of range");
    return data.Places[index];
  }
}
