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

  private PlacesCollection currentData;

  void Start()
  {
    Scroll.OnFill += OnFillItem;
    Scroll.OnHeight += OnHeightItem;

    StartCoroutine(this._LoadFromDataSource());
  }

  void OnFillItem(int index, GameObject item)
  {
    ListItemController itemController = item.GetComponentInChildren<ListItemController>();
    Place place = currentData.Places[index];

    // Async load
    StartCoroutine(itemController.LoadItem(place));
  }

  int OnHeightItem(int index)
  {
    return 120;
  }

  IEnumerator _LoadFromDataSource()
  {
    // Waiting data load complete 
    yield return PlacementDataSource.WaitingDataReady();

    // Load data to list
    this.currentData = PlacementDataSource.GetPlacesCollection();
    Scroll.InitData(currentData.Places.Length);
  }

  public IEnumerator ApplyFilter(System.Func<Place, bool> filter)
  {
    // Waiting data load complete 
    yield return PlacementDataSource.WaitingDataReady();

    // Load data to list
    this.currentData = PlacementDataSource.GetPlacesCollectionWithFilter(filter);
    Scroll.ApplyDataTo(currentData.Places.Length, 0, InfiniteScroll.Direction.Bottom);
  }
}
