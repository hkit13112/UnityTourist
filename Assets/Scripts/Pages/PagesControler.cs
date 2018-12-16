using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagesControler : MonoBehaviour
{

  public ListPageController ListPage;
  public DetailPageController DetailPage;

  private static PagesControler Instance;

  void Awake()
  {
    Instance = this;
  }

  void Start()
  {
    GoToListPage();
  }

  public void GoToListPage()
  {
    ListPage.gameObject.SetActive(true);
    DetailPage.gameObject.SetActive(false);
  }

  public void GoToDetailPage(int placeId)
  {
    ListPage.gameObject.SetActive(false);
    DetailPage.gameObject.SetActive(true);
  }
}
