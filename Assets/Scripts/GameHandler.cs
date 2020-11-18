using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Classes;
using UnityEditorInternal;
using UnityEngine;

public class GameHandler : Singleton<GameHandler>
{
    public Tool currentTool = new Tool();
    public List<GameObject> allPlants;
    public GameObject weedPlant;

    public void ClearCurrentTool()
    {
        currentTool = new Tool();
    }
}