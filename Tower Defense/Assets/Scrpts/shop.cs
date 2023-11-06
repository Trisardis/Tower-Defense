using UnityEngine;

public class shop : MonoBehaviour
{
    public TowerBlueprint standardCat;
    public TowerBlueprint fastCat;
    public TowerBlueprint fatCat;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectOrangeCat()
    {
        // Debug.Log("Orange Cat Selected");
        buildManager.SelectTowerToBuild(standardCat);
    }

    public void SelectWhiteCat()
    {
        // Debug.Log("White Cat Selected");
        buildManager.SelectTowerToBuild(fastCat);  
    }

    public void SelectFatCat()
    {
        // Debug.Log("Fat Cat Selected");
        buildManager.SelectTowerToBuild(fatCat);
    }
}
