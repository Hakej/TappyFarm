using System.Collections.Generic;
using Classes;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Tool currentTool = new Tool();
    public List<GameObject> allPlants;
    public GameObject weedPlant;

    public void ClearCurrentTool()
    {
        currentTool = new Tool();
    }
}