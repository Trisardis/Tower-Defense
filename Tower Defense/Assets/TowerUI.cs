using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
	public GameObject ui;

	// public Text upgradeCost;
	// public Button upgradeButton;

	// public Text sellAmount;

	private TowerBase target;

	public void SetTarget (TowerBase _target)
	{
		target = _target;

		transform.position = target.GetBuildPosition();
        ui.SetActive(true);

	// 	if (!target.isUpgraded)
	// 	{
	// 		upgradeCost.text = "$" + target.towerBlueprint.upgradeCost;
	// 		upgradeButton.interactable = true;
	// 	} else
	// 	{
	// 		upgradeCost.text = "DONE";
	// 		upgradeButton.interactable = false;
    }

	// 	sellAmount.text = "$" + target.towerBlueprint.GetSellAmount();

	// 	ui.SetActive(true);
    // }

    public void Hide ()
    {
        ui.SetActive(false);
    }

    // public void Upgrade ()
    // {
    //     target.UpgradeTower();
    //     BuildManager.instance.DeselectNode();
    // }

    // public void Sell ()
    // {
    //     target.SellTower();
    //     BuildManager.instance.DeselectNode();
    // }
}
