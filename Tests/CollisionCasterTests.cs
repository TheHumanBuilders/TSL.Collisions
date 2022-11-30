using NUnit.Framework;
using UnityEngine;

using TSL.PlayerTools;

namespace TSL.PlayerTools.Tests {
  public class CollisionCasterTests {

    private GameObject go;

    private GameObject otherGo;

    private CollisionCaster Collisions;

    private BoxCollider2D collider;
    private BoxCollider2D otherCollider;

    private void SetupTest() {
      go = new GameObject();
      collider = go.AddComponent<BoxCollider2D>();
      Collisions = new CollisionCaster(
        collider,
        new string[] {"Default"},
        new string[] {"Ground"}
      );

      otherGo = new GameObject();
      otherCollider = otherGo.AddComponent<BoxCollider2D>();
    }

    [Test]
    public void Collisions_Doesnt_Hit_TriggerCollider() {
      SetupTest();

      otherCollider.isTrigger = true;
      otherCollider.tag = "Ground";

      Vector2 hitNormal = Vector2.up;
      Vector2 checkNormal = Vector2.up;
      Assert.False(Collisions.IsHit(otherCollider, hitNormal, checkNormal));
    }

    [Test]
    public void Collisions_Only_Hits_Ground() {
      SetupTest();

      otherCollider.isTrigger = false;
      otherCollider.tag = "Untagged";

      Vector2 hitNormal = Vector2.up;
      Vector2 checkNormal = Vector2.up;
      Assert.False(Collisions.IsHit(otherCollider, hitNormal, checkNormal));
    }

    [Test]
    public void Collisions_Hits_Ground() {
      SetupTest();

      otherCollider.isTrigger = false;
      otherCollider.tag = "Ground";

      Vector2 hitNormal = Vector2.up;
      Vector2 checkNormal = Vector2.up;
      Assert.True(Collisions.IsHit(otherCollider, hitNormal, checkNormal));
    }

    [Test]
    public void Collisions_Hits_Direction_NonNormal() {
      SetupTest();

      otherCollider.isTrigger = false;
      otherCollider.tag = "Ground";

      Vector2 hitNormal = Vector2.up*1.5f;
      Vector2 checkNormal = Vector2.up*2;
      Assert.True(Collisions.IsHit(otherCollider, hitNormal, checkNormal));
    }

    [Test]
    public void Collisions_WrongDirection_NoHit() {
      SetupTest();

      otherCollider.isTrigger = false;
      otherCollider.tag = "Ground";

      Vector2 hitNormal = new Vector2(0, 1);
      Vector2 checkNormal = new Vector2(0.00001f, 1);
      Assert.False(Collisions.IsHit(otherCollider, hitNormal, checkNormal));
    }

  }
}