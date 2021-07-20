using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GunDefault
{
    GunModel model;

    public GunDefault(Magazine mag, Transform obj)
    {
        model = new GunModel(mag, obj);
        timer = new Timer(model.shotDelay);
    }

    Timer timer;

    public bool GunUpdate()
    {
        if (timer.TimerUpdate())
            return true;
        return false;
    }

    public virtual void Shot()
    {
        if (GunUpdate())
        {
            Vector2 transformVec2 = new Vector2(model.gunObj.transform.parent.position.x, model.gunObj.transform.parent.position.y);
            Vector2 moveTo = (SystemManager.Inst.mouse.cursorPos - transformVec2).normalized; 
            GameObject obj = model.mag.Get(model.selectedBullet, model.gunObj.position, moveTo);
            timer.Reset();
        }
    }
    
    public void GetMag(Magazine mag)
    {
        model.mag.Set(mag);
    }


}
