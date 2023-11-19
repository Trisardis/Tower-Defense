using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public Text wavesNumber;

	void Update () {
		wavesNumber.text = WaveSpawner.curretnWave.ToString();
	}
}
