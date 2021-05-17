using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DASH._Player;
using DASH._Dungeon;

namespace DASH._Units
{
    public class Boss : MobController
    {
        protected override IEnumerator Dead()
        {
            alive = false;
            GameManager.instance.EarnCoins(rewardGold);
            room.MobDied(this);
            animator.PlayDeathAnimation();
            movement.StopAgent();
            collider.enabled = false;
            yield return new WaitForSeconds(4);
            GameManager.instance.LevelCompleted();
        }
    }
}