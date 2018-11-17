using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mopsicus.InfiniteScroll;
public class ListController : MonoBehaviour
{

  [SerializeField]
  private InfiniteScroll Scroll;

  [SerializeField]
  private int Count = 100;

  void Start()
  {
    Scroll.OnFill += OnFillItem;
    Scroll.OnHeight += OnHeightItem;

    StartCoroutine(this._LoadFromDataSource());
  }

  void OnFillItem(int index, GameObject item)
  {
    ListItemController itemController = item.GetComponentInChildren<ListItemController>();
    Place place = PlacementDataSource.GetPlaceByIndex(index);

    // Async load
    StartCoroutine(itemController.LoadItem(place));
  }

  int OnHeightItem(int index)
  {
    return 100;
  }

  IEnumerator _LoadFromDataSource()
  {
    // Waiting data load complete 
    yield return PlacementDataSource.WaitingDataReady();

    // Load data to list
    PlacesCollection data = PlacementDataSource.GetPlacesCollection();
    Scroll.InitData(data.Places.Length);
  }

}
