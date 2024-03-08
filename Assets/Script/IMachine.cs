using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//違う装置を対応するためインターフェースを宣言(拡張性)
public interface IMachine
{
    void Activate(bool isActive);
}
