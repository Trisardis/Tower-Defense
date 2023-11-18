using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBase : MonoBehaviour
{
    private Renderer rend;

    [HideInInspector]
    public GameObject tower;
    [HideInInspector]
    public TowerBlueprint towerBlueprint;
    public bool isUpgraded = false;

    public Vector3 positionOffset;
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        // Prevents tower placement is mouse is over the ui
        if (EventSystem.current.IsPointerOverGameObject())
          return;

        if (tower != null)
        {
            buildManager.SelectTower(this);
            return;
        }

        // Return if there is no tower selected
        if (!buildManager.CanBuild)
            return;

        if (tower != null)
            return;

        BuildTower(buildManager.GetTowerToBuild());
    }

    void BuildTower (TowerBlueprint blueprint)
    {
        if (PlayerStats.Currancy < blueprint.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.Currancy -= blueprint.cost;
        towerBlueprint = blueprint;

        GameObject _tower = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        Debug.Log("Turret Build");
    }

    public void UpgradeTower ()
    {
        if (PlayerStats.Currancy < towerBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that");
            return;
        }

        PlayerStats.Currancy -= towerBlueprint.upgradeCost;

        // Get rid of original tower and replace it with an upgraded one
        Destroy(tower);
        GameObject _tower = (GameObject)Instantiate(towerBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        tower = _tower;

        isUpgraded = true;

        Debug.Log("Turret Upgraded");
    }

    void OnMouseEnter()
    {
        // Prevents tower placement is mouse is over the ui
        if (EventSystem.current.IsPointerOverGameObject())
          return;
        
        // Return if there is no tower selected
        if (!buildManager.CanBuild)
            return;

        // Choose rock color based on whether the play has enough currency or not
        if (buildManager.HasMoney)
			rend.material.color = hoverColor;
		else
			rend.material.color = notEnoughMoneyColor;

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
