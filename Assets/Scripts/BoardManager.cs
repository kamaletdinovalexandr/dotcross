using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton<BoardManager> {
    [SerializeField] private GameObject CellPrefab;
    [SerializeField] private float CelOffset = 280;
    [SerializeField] private float OffsetX = 200;
    [SerializeField] private float OffsetY = 95;
    [SerializeField] private Transform BoardTransform;
    [SerializeField] private BoardCellView[,] BoardCellViews;
    public int BoardWidth = 3;
    public int BoardHeigh = 3;

    internal override void Init() {
        BoardCellViews = new BoardCellView[BoardWidth, BoardHeigh];
        for (int i = 0; i < BoardWidth; i++) {
            for (int j = 0; j < BoardHeigh; j++) {
                var go = Instantiate(CellPrefab, BoardTransform);
				go.name = "CellView_" + i + "_" + j;
                var position = new Vector2(i * CelOffset + OffsetX, j * CelOffset + OffsetY);
                go.GetComponent<RectTransform>().position = position;
               var cellView = go.GetComponent<BoardCellView>();
                cellView.Position = new Vector2Int(i, j);
                BoardCellViews[i, j] = cellView;
            }
        }
    }

	public BoardCellView GetCellView(int x, int y) {
		return BoardCellViews[x, y];
	}
}
