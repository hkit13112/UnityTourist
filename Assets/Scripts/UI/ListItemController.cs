using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ListItemController : MonoBehaviour, IPointerClickHandler
{
  public Image image;
  public Text content;

  private Place loadedPlace;

  void Start()
  {
    Debug.Assert(image != null, "Image ref missing");
    Debug.Assert(content != null, "Content ref missing");
  }

  public IEnumerator LoadItem(Place place)
  {
    content.text = place.Name;
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
