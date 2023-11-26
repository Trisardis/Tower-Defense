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
        
        if (GameManager.gamePaused == true)
            return;
            
        buildManager.SelectTowerToBuild(standardCat);
    }

    public void SelectWhiteCat()
    {
        if (GameManager.gamePaused == true)
            return;
            
        buildManager.SelectTowerToBuild(fastCat);  
    }

    public void SelectFatCat()
    {
        if (GameManager.gamePaused == true)
            return;
            
        buildManager.SelectTowerToBuild(fatCat);
    }
}
