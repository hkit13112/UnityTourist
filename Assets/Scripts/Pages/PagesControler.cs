using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;
using Mapbox.Utils;

public class PagesControler : MonoBehaviour
{

  public ListPageController ListPage;
  public DetailPageController DetailPage;

  public static PagesControler Instance;
   

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

  public void GoToDetailPage(Place _loadPlace)
  {        
        ListPage.gameObject.SetActive(false);
        DetailPage.gameObject.SetActive(true);

        DetailPage._Name.text = _loadPlace.Name;
        DetailPage._Addr.text = _loadPlace.Addr;
        DetailPage._Catalog.text = _loadPlace.Catalog;
        DetailPage._Lat = _loadPlace.Lat;
        DetailPage._Lon = _loadPlace.Lon;
        DetailPage._Description.text = _loadPlace.Description;

        Debug.Log("test...." + PlacementDataSource.data.Places[_loadPlace.ID-1].Name);
    /*    Vector2d _myvector2d = new Vector2d();
        _myvector2d.x = _loadPlace.Lat;
        _myvector2d.y = _loadPlace.Lon;

        //  _map.UpdateMap(_myvector2d);
        //DetailPage.GetinfoPlace(_loadPlace);
        _maplocationOptions.latitudeLongitude = _loadPlace.Lat.ToString() + "," + _loadPlace.Lon.ToString();
        _map.Initialize(_myvector2d,1);
        _map.UpdateMap(_myvector2d, 1); */
        Debug.Log("Da load xong:");        
    }
}
