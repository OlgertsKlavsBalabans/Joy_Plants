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

        for (int i = 0; i < plantPrefabs.Count; i++)
        {
            if (plantPrefabs[i].GetComponent<PlantInfo>().buttonIndex == id)
            {
                int price = plantPrefabs[i].GetComponent<PlantInfo>().Price;
                if (price <= GlobalValues.Instance.happiness.happinessScore)
                {
                    for (var j = this.transform.childCount - 1; j >= 0; j--)
                    {
                        Debug.Log(this.transform.GetChild(0).gameObject.name);
                        Debug.Log(this.transform.GetChild(0).gameObject.name.Contains("Clone"));
                        if (this.transform.GetChild(j).gameObject.name.Contains("Clone"))
                        {
                            Destroy(this.transform.GetChild(j).gameObject);
                        }
                    }

                    Debug.Log("Planting " + plantPrefabs[i].GetComponent<PlantInfo>().name);
                    boughtPlant = plantPrefabs[i];
                    var position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.3f, this.gameObject.transform.position.z);
                    var newPlant = Instantiate(boughtPlant, position, Quaternion.identity);
                    newPlant.transform.parent = this.gameObject.transform;
                    GlobalValues.Instance.happiness.decreaseScore(plantPrefabs[i].GetComponent<PlantInfo>().Price);
                    break;
                }
                else
                {
                    Debug.Log("Not enough happiness");
                    break;
                }

            }
        }
        
    }
}
