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

        buildManager.SelectTowerToBuild(standardCat);
    }

    public void SelectWhiteCat()
    {
        buildManager.SelectTowerToBuild(fastCat);  
    }

    public void SelectFatCat()
    {
        buildManager.SelectTowerToBuild(fatCat);
    }
}
