using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardCellView : MonoBehaviour {

	[SerializeField] GameObject dotIcon;
	[SerializeField] GameObject crossIcon;
	private Button button;
	public Vector2Int Position { get; set; }

	private void Start() {
		button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
		dotIcon.SetActive(false);
		crossIcon.SetActive(false);
    }

	public void SetElement(ElementTypes element) {
		switch (element) {
            case ElementTypes.cross:
                dotIcon.SetActive(false);
                crossIcon.SetActive(true);
                break;
            case ElementTypes.dot:
                dotIcon.SetActive(true);
                crossIcon.SetActive(false);
                break;
            default:
                return;
        }
        button.interactable = false;
	}

	private void OnClick() {
		GameController.Instance.TryMakeMove(this);
	}

}