using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotMenuButtonClick : MonoBehaviour

{
    [SerializeField]
   List<GameObject> plantPrefabs;

    public void onBtnClick(int id)
    {
        Debug.Log("Button clicked " + id );
        GameObject boughtPlant;
        Debug.Log(plantPrefabs.Count);

        for (int i = 0; i < plantPrefabs.Count; i++)
        {
           Debug.Log(plantPrefabs[i]);

           Debug.Log(plantPrefabs[i].GetComponent<PlantInfo>().name);

            if (plantPrefabs[i].GetComponent<PlantInfo>().buttonIndex == id)
            {
                Debug.Log("Planting " + plantPrefabs[i].GetComponent<PlantInfo>().name);
                boughtPlant = plantPrefabs[i];
                var position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.3f, this.gameObject.transform.position.z);
                var newPlant = Instantiate(boughtPlant, position, Quaternion.identity);
                newPlant.transform.parent = this.gameObject.transform;
                break;
            }
        }
        
    }
}
