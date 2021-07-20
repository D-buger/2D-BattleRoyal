using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class CursorImage
{
    [SerializeField]
    Texture2D[] cursorSprite = new Texture2D[2];
    
    private Vector2 hotSpot = Vector2.zero;
    private bool hotSpotIsCenter = true;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public IEnumerator Click()
    {
        return CursorSet(cursorSprite[1]);
    }

    public IEnumerator Nothing()
    {
        return CursorSet(cursorSprite[0]);
    }

    IEnumerator CursorSet(Texture2D texture)
    {
        //렌더링이 완료될 때까지 대기
        //기기의 성능에 따라서 커서가 표시되지 않을 수 있기 때문
        yield return new WaitForEndOfFrame();

        HotSpotCheck(texture);

        Cursor.SetCursor(texture, hotSpot, CursorMode.Auto);

        yield return null;
    }

    private void HotSpotCheck(Texture2D texture)
    {
        if (hotSpotIsCenter)
        {
            hotSpot.x = texture.width / 2;
            hotSpot.y = texture.height / 2;
        }
    }
}
