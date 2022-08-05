using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;

public class ObjectInitiator : MonoBehaviour
{

    public GameObject fountain;
    public GameObject metalObj;
    public AbstractMap _map;
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Spawinging object");
            var location = Conversions.StringToLatLon("27.618286, 85.538420");
            var instance = Instantiate(fountain);
            instance.transform.localPosition = _map.GeoToWorldPosition(location, true);
            instance.transform.localPosition = _map.GeoToWorldPosition(location, true);
            var instance1 = Instantiate(metalObj);
            location = Conversions.StringToLatLon("27.620325, 85.537938");
            instance1.transform.localPosition = _map.GeoToWorldPosition(location, true);
            location = Conversions.StringToLatLon("27.620174, 85.538255");
        }
    }
}
