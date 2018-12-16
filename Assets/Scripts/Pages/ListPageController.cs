using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ListPageController : MonoBehaviour
{
  public ListController scrollList;
  public InputField searchText;


  public void OnDoSearch()
  {
    Debug.Log("search: " + searchText.text);

    string searchTerm = searchText.text.ToLower();
    // FIlter function
    System.Func<Place, bool> filter = p =>
    {
      return p.Name.ToLower().Contains(searchTerm);
    };

    StartCoroutine(scrollList.ApplyFilter(filter));
  }

  public void OnDoFilter(Dropdown change)
  {
    // Filter all
    if (change.value == 0)
    {
      StartCoroutine(scrollList.ApplyFilter(null));
      return;
    };

    var option = change.options[change.value];

    string filterTerm = option.text.ToLower();
    Debug.Log("filter: " + filterTerm);

    // FIlter function
    System.Func<Place, bool> filter = p =>
    {
      return p.Catalog.ToLower() == filterTerm;
    };

    StartCoroutine(scrollList.ApplyFilter(filter));
  }
}
