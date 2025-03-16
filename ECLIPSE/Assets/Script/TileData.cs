using UnityEngine;

[System.Serializable]
public class TileData
{
    public int ID = 0; // 板塊類型
    public int[] Resources = {0, 0, 0, 0, 0, 0}; //三種資源和三種爛地的數量
    public int ancient = 0; //遠古飛船數量
    public bool star = false; // 星星板塊否
    public int prize = 0; //獎勵板塊數量
    public int score = 0; //此板塊的分數
    public int[] Facility = {0, 0, 0}; //(Starbase,人造衛星,方尖碑)的數量
}
