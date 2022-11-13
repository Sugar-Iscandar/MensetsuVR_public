using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalResult
{
    /* 最終的な結果(リザルト画面に表示する)を保存する型 */

    public int IncorrectNum { get; set; }
    public int MissNum { get; set; }
    public bool IsPass { get; set; }
}
