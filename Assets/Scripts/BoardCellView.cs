using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardCellView : MonoBehaviour {

	[SerializeField] GameObject dotIcon;
	[SerializeField] GameObject crossIcon;
	private Button button;
	public Vector2Int Position;

	private void Start() {
		button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
		dotIcon.SetActive(false);
		crossIcon.SetActive(false);
    }

	private void SetIcon(Sprite icon) {
		if (icon == null)
			return;

		GetComponent<Image>().sprite = icon;
		button.interactable = false;
	}

	private void OnClick() {
		GameController.Instance.TryMakeMove(this);

	}

}