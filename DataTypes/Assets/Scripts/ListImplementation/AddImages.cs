using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddImages : MonoBehaviour
{
    [SerializeField] MyList<GameObject> images;
    // Start is called before the first frame update
    void Start()
    {
        images = new MyList<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Append(){
        GameObject image = new GameObject();
        image.transform.SetParent(transform);
        Image imageComponent = image.AddComponent<Image>();
        imageComponent.color = new Color(Random.value,Random.value,Random.value);
        images.Append(image);
        Instantiate(images.GetLast(),new Vector3(0,0,0),Quaternion.identity);
        
    }

    public void RemoveLast(){
        Destroy(images.GetLast());
        images.RemoveLast();
    }
}
