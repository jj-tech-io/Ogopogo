using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
public class TourObject : MonoBehaviour
{
    [SerializeField] ParticleSystem explode = null;
    [SerializeField] private string itemNameTxt;
    [SerializeField] private TextMeshProUGUI itemNameTM = null;
    [SerializeField] private string itemDescriptionTxt;
    [SerializeField] private TextMeshProUGUI itemDescriptionTM = null;
    [SerializeField] private AudioClip infoClip;

    [SerializeField] private GameObject parent;
    [SerializeField] private MeshRenderer meshRenderer;
    private Material material;

    private void Awake() {
            
            meshRenderer = parent.GetComponent<MeshRenderer>();
            material = meshRenderer.material;
            itemNameTM.text = itemNameTxt;
            

    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            itemNameTM.text = "";
            explode.Play(); 
            //samar play the information audio
            AudioSource.PlayClipAtPoint(infoClip, transform.position);
            // pointsText.text = map.Any() ? map[tourItem] : "No data";
            // itemDescriptionTM.text = map.Any() ? map[itemNameTxt] : "No data";
            itemDescriptionTM.text = itemDescriptionTxt;
            StartCoroutine(objectExplodeDestroy());         
           
        }
    }


    IEnumerator objectExplodeDestroy() {
        
        for(int i = 0; i < 10; i++) {
            Color color = material.color;
            color.a = (10f-(float)i )/10f;

            Debug.Log(color.a.ToString());
            material.color = color;
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(10f);
        itemDescriptionTM.text = "";
        Destroy(parent, 1.5f);
    }
}
