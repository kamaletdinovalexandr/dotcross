using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public static GameController Instance = null;
	[SerializeField] private GameObject CellPrefab;
	[SerializeField] private GameObject[,] BoardCellViews;
	[SerializeField] private BoardCellModel[,] BoardCellModels;
	[SerializeField] private Transform BoardTransform;

	private int boardWidth = 3;
	private int boardHeigh = 3;
	private float _celOffset = 280;
	private float _offsetX = 210;
	private float _offsetY = 130;

	void Awake() {
		if (Instance == null) {
			Instance = this;
		} else
		   if (Instance != this) {
			Destroy(gameObject);
		}
		BoardInit();
	}

	private void BoardInit() {
		BoardCellViews = new GameObject[boardWidth, boardHeigh];
		BoardCellModels = new BoardCellModel[boardWidth, boardHeigh];
		for (int i = 0; i < boardWidth; i++) {
			for (int j = 0; j < boardHeigh; j++) {
				
				var cellObj = Instantiate(CellPrefab, BoardTransform);
				var position = new Vector2(i * _celOffset + _offsetX, j * _celOffset + _offsetY);
				cellObj.GetComponent<RectTransform>().position = position;

				var 




				BoardCellViews[i, j] = cellObj;
				var cellModel = cellObj.GetComponent<>();
				cellModel.Position = new Vector2Int(i, j);
				cellModel.Players = Players.NONE;
				cellModel.ElementType = ElementTypes.NONE;
				BoardCellModels[i, j] = cellModel;
			}
		}
	}

	public void TryMakeMove(BoardCellView targetCell) {
		var
	}
}
