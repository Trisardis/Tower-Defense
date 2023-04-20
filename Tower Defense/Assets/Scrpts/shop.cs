using UnityEngine;

public class shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseFatCat()
    {
        // Debug.Log("Fat Cat Selected");
        buildManager.SetTowerToBuild(buildManager.fatCatPrefab);
    }

    public void PurchaseOrangeCat()
    {
        // Debug.Log("Orange Cat Selected");
        buildManager.SetTowerToBuild(buildManager.orangeCatPrefab);
    }

    public void PurchaseWhiteCat()
    {
        // Debug.Log("White Cat Selected");
        buildManager.SetTowerToBuild(buildManager.whiteCatPrefab);  
    }
}
