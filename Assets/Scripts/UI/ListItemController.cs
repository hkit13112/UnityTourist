using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ListItemController : MonoBehaviour, IPointerClickHandler
{
    public Image image;
    public Text _Name, _Addr, _Descripton, _Catalog;
    public float _Lat, _Lon;

    private Place loadedPlace;

  void Start()
  {
    Debug.Assert(image != null, "Image ref missing");
    Debug.Assert(_Name != null, "Content ref missing");
  }

  public IEnumerator LoadItem(Place place)
  {
        _Name.text = place.Name;
        _Addr.text = place.Addr;
        _Descripton.text = place.Description;
        _Catalog.text = place.Catalog;       

        if (place.ImgUrl != null)
        {
        WWW www = new WWW(place.ImgUrl);
        yield return www;
        image.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
        }
        this.loadedPlace = place;
  }

  public void OnPointerClick(PointerEventData eventData)
  {
    Debug.Log("On Click" + this.loadedPlace.Name);
  }
}
