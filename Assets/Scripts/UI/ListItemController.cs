using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ListItemController : MonoBehaviour, IPointerClickHandler
{
    public int _ID;
    public Image image;
    public Text _Name, _Addr, _Catalog;
    public TextTruncExt _Description;
    public float _Lat, _Lon;

    public Place loadedPlace;
    RectTransform area;   

  void Start()
  {
    Debug.Assert(image != null, "Image ref missing");
    Debug.Assert(_Name != null, "Content ref missing");
  }

  public IEnumerator LoadItem(Place place)
  {
        _ID = place.ID;
        _Name.text = place.Name;
        _Addr.text = place.Addr;
        /*  if (place.Description.Length > 80)
              _Descripton.text = place.Description.Remove(80) + "...";
          else
              _Descripton.text = place.Description;*/
        // _Destmp.text = place.Description;
        _Description.text = place.Description;
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
        Debug.Log("On Click" + this.loadedPlace.ID);
        PagesControler.Instance.GoToDetailPage(this.loadedPlace);
        
  } 
}