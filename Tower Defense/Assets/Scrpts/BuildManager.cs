using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject fatCatPrefab;
    public GameObject orangeCatPrefab;
    public GameObject whiteCatPrefab;

    private TowerBlueprint towerToBuild;
    private TowerBase selectedTower;

	public TowerUI towerUI;

    public bool CanBuild { get { return towerToBuild != null; }}
    public bool HasMoney { get { return PlayerStats.Currancy >= towerToBuild.cost; } }

    void Start() 
    {
        towerUI.Hide();
    }

    public void BuildTowerOn(TowerBase rock)
    {
        if (PlayerStats.Currancy < towerToBuild.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.Currancy -= towerToBuild.cost;

        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, rock.GetBuildPosition(), Quaternion.identity);
        rock.tower = tower;

        Debug.Log("Turret build. money left " + PlayerStats.Currancy);
    }

	public void SelectTower (TowerBase tower)
	{
		if (selectedTower == tower)
		{
			DeselectTower();
			return;
		}
        
		selectedTower = tower;
		towerToBuild = null;

		towerUI.SetTarget(tower);
	}

	public void DeselectTower()
	{
		selectedTower = null;
		towerUI.Hide();
	}

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
        selectedTower = null;
        DeselectTower();
    }
}
