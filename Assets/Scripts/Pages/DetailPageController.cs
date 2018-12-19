using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailPageController : MonoBehaviour {

    public int _PlaceID;
    public Image _image;
    public Text _Name, _Addr, _Catalog;    
    public float _Lat, _Lon;
    public Text _Description;

    public Place _LoadPlace;
    
   
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void SetinfoPlace(Place LoadPlace)
    {
        
        Debug.Log("Goi ham Get info:");
        this._LoadPlace = LoadPlace;        
       // yield return _LoadPlace;

        
        /* _PlaceID = LoadPlace.ID;
         _Name.text = LoadPlace.Name;
         _Addr.text = LoadPlace.Addr;
         _Catalog.text = LoadPlace.Catalog;
         _Lat = LoadPlace.Lat;
         _Lon = LoadPlace.Lon;
         _Description.text = LoadPlace.Description;
         WWW www = new WWW(LoadPlace.ImgUrl);
         _image.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
         */
        // Debug.Log("Da load:");

    }
}
