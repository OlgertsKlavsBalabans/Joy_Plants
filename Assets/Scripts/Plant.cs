using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    enum PlantType
    { Sunflower, Tulip, Peonie, Daffodil, Marigold, Lilie, Iris, Orchid, Rose }
    private PlantType _type;


    [SerializeField]
    PlantType Type 
    {
        get { return this._type; }
        set { this._type = value;
            setValues(this._type);
        }
    }

    private void setValues (PlantType name)
    {
        switch (name)
        {
            case PlantType.Sunflower:
                this.Name = "Sunflower";
                this.Time = 15.0f;
                this.ValuePerHarvest = 100.0f;
                break;
            case PlantType.Tulip:
                this.Name = "Tulip";
                this.Time = 30.0f;
                this.ValuePerHarvest = 500.0f;
                break;
            case PlantType.Daffodil:
                this.Name = "Daffodil";
                this.Time = 60.0f;
                this.ValuePerHarvest = 1000.0f;
                break;
            case PlantType.Peonie:
                this.Name = "Peonie";
                this.Time = 120.0f;
                this.ValuePerHarvest = 2000.0f;
                break;
            case PlantType.Marigold:
                this.Name = "Marigold";
                this.Time = 240.0f;
                this.ValuePerHarvest = 5000.0f;
                break;
            case PlantType.Lilie:
                this.Name = "Lilie";
                this.Time = 480.0f;
                this.ValuePerHarvest = 10000.0f;
                break;
            case PlantType.Iris:
                this.Name = "Iris";
                this.Time = 960.0f;
                this.ValuePerHarvest = 20000.0f;
                break;
            case PlantType.Orchid:
                this.Name = "Orchid";
                this.Time = 1920.0f;
                this.ValuePerHarvest = 50000.0f;
                break;
            case PlantType.Rose:
                this.Name = "Rose";
                this.Time = 3840.0f;
                this.ValuePerHarvest = 100000.0f;
                break;
            default:
                this.Name = "Sunflower";
                this.Time = 3840.0f;
                this.ValuePerHarvest = 100.0f;
                break;
        }
    }
    public string Name;
    public float Time;
    public float ValuePerHarvest;
}
