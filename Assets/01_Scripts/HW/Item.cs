using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public virtual void GetItem(PlayerController player)
    {
        //UI가 있다면 UI랑 연동할 코드를 넣을 수도 있고 아닐 수도 있습니다.
        //그렇기 때문에
    }
}
