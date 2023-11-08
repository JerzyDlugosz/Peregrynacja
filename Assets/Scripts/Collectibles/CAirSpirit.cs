using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAirSpirit : CollectibleGameObject
{
    void Start()
    {
        foreach (var item in GameManagerScript.instance.player.progressTracker.collectibles)
        {
            if (item.collectibleId == collectibleId)
            {
                Destroy(gameObject);
                return;
            }
        }
        collectEvent.AddListener(OnCollect);
    }

    void OnCollect()
    {
        GameManagerScript.instance.player.playerData.AirSpirit = true;

        GameManagerScript.instance.player.progressTracker.AddCollectilbe(collectibleId, collectiblePositionX, collectiblePositionY, collectibleSpriteID, collectibleType);

        ItemPickupPanel.instance.ShowPanel(collectibleName, collectibleDescription, collectibleSprite);

        

        Destroy(gameObject,0.1f);
    }
}