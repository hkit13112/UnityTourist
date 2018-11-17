using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Place
{
  public string Name, Addr, Catalog, ImgUrl;
}

[System.Serializable]
public class PlacesCollection
{
  public Place[] Places;
}