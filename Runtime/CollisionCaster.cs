using System.Collections.Generic;
using UnityEngine;

namespace TSL.PlayerTools {

  #region Interface
  public interface ICollisionCaster {
    /// <summary>
    /// How far the object is from the ground.
    /// </summary>
    /// <returns>The distance between the object's feet and the closest piece of ground.</returns>
    /// <seealso cref="CollisionCaster.DistanceToGround" />
    float DistanceToGround(int numCasts = 5);

    /// <summary>
    /// How far the object is from the closest ceiling.
    /// </summary>
    /// <returns>The distance between the object and the closest ceiling.</returns>
    /// <seealso cref="CollisionCaster.DistanceToCeiling" />
    float DistanceToCeiling(int numCasts = 5);

    /// <summary>
    /// How far the player is from a left-hand wall.
    /// </summary>
    /// <returns>The distance between the player's left side and the closest left-hand wall.</returns>
    /// <seealso cref="CollisionCaster.DistanceToLeftWall" />
    float DistanceToLeftWall(int numCasts = 5);

    /// <summary>
    /// How far the player is from a right-hand wall.
    /// </summary>
    /// <returns>The distance between the player's right side and the closest right-hand wall.</returns>
    /// <seealso cref="CollisionCaster.DistanceToRightWall" />
    float DistanceToRightWall(int numCasts = 5);

    /// <summary>
    /// Whether or not the top right of the collider is close to a wall.
    /// </summary>
    /// <returns>True if the collider's top right corner is by a wall. False otherwise.</returns>
    /// <seealso cref="CollisionCaster.TopDistanceToRightWall" />
    float TopDistanceToRightWall();

    /// <summary>
    /// Whether or not the bottom right of the colllider is close to a wall.
    /// </summary>
    /// <returns>True if the collider's bottom right corner is by a wall. False otherwise.</returns>
    /// <seealso cref="CollisionCaster.BottomDistanceToRightWall" />
    float BottomDistanceToRightWall();

    /// <summary>
    /// Whether or not the top left of the collider is close to a wall.
    /// </summary>
    /// <returns>True if the collider's top left corner is by a wall. False otherwise.</returns>
    /// <seealso cref="CollisionCaster.TopDistanceToLeftWall" />
    float TopDistanceToLeftWall();

    /// <summary>
    /// Whether or not the bottom left of the collider is close to a wall.
    /// </summary>
    /// <returns>True if the collider's bottom left corner is by a wall. False otherwise.</returns>
    /// <seealso cref="CollisionCaster.BottomDistanceToLeftWall" />
    float BottomDistanceToLeftWall();

    /// <summary>
    /// How far the player is from the closest wall.
    /// </summary>
    /// <returns>The distance between the player and the closest wall.</returns>
    /// <seealso cref="CollisionCaster.DistanceToWall" />
    float DistanceToWall(int numCasts = 5);

    /// <summary>
    /// Whether or not the player is touching the ground.
    /// </summary>
    /// <seealso cref="CollisionCaster.IsTouchingGround" />
    bool IsTouchingGround();

    /// <summary>
    /// Whether or not the player is touching a left-hand wall.
    /// </summary>
    /// <seealso cref="CollisionCaster.IsTouchingLeftWall" />
    bool IsTouchingLeftWall();

    /// <summary>
    /// Whether or not the player is touching a right-hand wall.
    /// </summary>
    /// <seealso cref="CollisionCaster.IsTouchingRightWall" />
    bool IsTouchingRightWall();

    /// <summary>
    /// Whether or not the collider is hanging over a left-hand ledge.
    /// </summary>
    /// <returns>True if the bottom left corner of the collider isn't touching
    /// the ground.</returns>
    /// <seealso cref="CollisionCaster.IsOverLeftLedge" />
    bool IsOverLeftLedge();

    /// <summary>
    /// Whether or not the collider is hanging over a right-hand ledge.
    /// </summary>
    /// <returns>True if the bottom right corner of the collider isn't touching
    /// the ground.</returns>
    /// <seealso cref="CollisionCaster.IsOverRightLedge" />
    bool IsOverRightLedge();

    /// <summary>
    /// Whether or not the object is touching the ceiling.
    /// </summary>
    /// <seealso cref="CollisionCaster.IsTouchingCeiling" />
    bool IsTouchingCeiling();

    /// <summary>
    /// Whether or not a box will fit in a position one space below where it
    /// currently is.
    /// </summary>
    /// <returns>Returns true if the box would fit in the space directly below
    /// it's feet.</returns>
    /// <seealso cref="CollisionCaster.FitsDown" />
    bool FitsDown(out Collider2D[] hits);

    /// <summary>
    /// Whether or not a box will fit in a position one space above where it
    /// currently is.
    /// </summary>
    /// <returns>Returns true if the box would fit in the space directly above
    /// it's top.</returns>
    /// <seealso cref="CollisionCaster.FitsUp" />
    bool FitsUp(out Collider2D[] hits);

    /// <summary>
    /// Whether or not a box will fit in a position one space to the left of where it
    /// currently is.
    /// </summary>
    /// <returns>Returns true if the box would fit in the space directly to its left.</returns>
    /// <seealso cref="CollisionCaster.FitsLeft" />
    bool FitsLeft(out Collider2D[] hits);

    /// <summary>
    /// Whether or not a box will fit in a position one space to the right of where it
    /// currently is.
    /// </summary>
    /// <returns>Returns true if the box would fit in the space directly to its right.</returns>
    /// <seealso cref="CollisionCaster.FitsRight" />
    bool FitsRight(out Collider2D[] hits);

    /// <summary>
    /// Whether or not a box will fit in a position one space to the right of where it
    /// currently is.
    /// </summary>
    /// <param name="center">The center of the box.</param>
    /// <param name="size">The dimensions of the box.</param>
    /// <param name="direction">The direction to check</param>
    /// <returns>Returns true if the box would fit in the space directly to its right.</returns>
    /// <seealso cref="CollisionCaster.FitsInDirection" />
    bool FitsInDirection(Vector2 direction, out Collider2D[] hits);

     /// <summary>
    /// Whether or not a collision can be considered a valid collision.
    /// </summary>
    /// <param name="collider">The collider of the other object (i.e., not the
    /// player's collider).</param>
    /// <param name="hitNormal">The normal for the collision.</param>
    /// <param name="checkNormal">The normal expected.</param>
    /// <returns>True if this is a valid hit. False otherwise.</returns>
    /// <seealso cref="CollisionCaster.IsHit" />
    bool IsHit(Collider2D collider, Vector2? hitNormal = null, Vector2? checkNormal = null);
  }
  #endregion

  public class CollisionCaster : ICollisionCaster {
    #region Fields

    /// <summary>
    /// How thick overlap boxes should be when checking for collision direction.
    /// </summary>
    private float colliderWidth = 0.25f;

    /// <summary>
    /// The vertical and horizontal difference between the collider and the box cast.
    /// </summary>
    private float boxCastMargin = 0f;

    /// <summary>
    /// Layer mask that prevents collisions with anything aside from things on the given layer(s).
    /// </summary>
    private LayerMask layerMask;

    /// <summary>
    /// The list of tags the caster should check when checking for a collision.
    /// e.g., if the list is ["Ground"], then only colliders tagged attached to
    /// an object with the tage "Ground" will be considered for collisions.
    /// </summary>
    private List<string> tags;

    /// <summary>
    /// The collider this collision checker is for.
    /// </summary>
    private Collider2D parent;
    #endregion

    #region Constructors
    public CollisionCaster(Collider2D parent) {
      this.parent = parent;
      layerMask = LayerMask.GetMask("Default");
      this.tags = new List<string>();
    }

    public CollisionCaster(Collider2D parent, string[] layerNames, string[] tags) {
      this.parent = parent;
      layerMask = LayerMask.GetMask(layerNames);
      this.tags = new List<string>(tags);
    }

    public CollisionCaster(Collider2D parent, float colliderWidth, float boxCastMargin, string[] layerNames) {
      this.parent = parent;
      this.colliderWidth = colliderWidth;
      this.boxCastMargin = boxCastMargin;
      layerMask = LayerMask.GetMask(layerNames);
    }
    #endregion

    #region Distance Checking
    /// <summary>
    /// How far the player is from the ground.
    /// </summary>
    /// <returns>The distance between the player's feet and the closest piece of ground.</returns>
    public float DistanceToGround(int numCasts = 5) => CheckDistance(
      Vector2.down, 
      parent.bounds.center,
      parent.bounds.size,
      numCasts
    );


    /// <summary>
    /// How far the object is from the closest ceiling.
    /// </summary>
    /// <returns>The distance between the object and the closest ceiling.</returns>
    public float DistanceToCeiling(int numCasts = 5) => CheckDistance(
      Vector2.up,
      parent.bounds.center,
      parent.bounds.size,
      numCasts
    );

    /// <summary>
    /// How far the player is from a left-hand wall.
    /// </summary>
    /// <returns>The distance between the player's left side and the closest left-hand wall.</returns>
    public float DistanceToLeftWall(int numCasts = 5) => CheckDistance(
      Vector2.left,
      parent.bounds.center,
      parent.bounds.size,
      numCasts
    );

    /// <summary>
    /// How far the player is from a right-hand wall.
    /// </summary>
    /// <returns>The distance between the player's right side and the closest right-hand wall.</returns>
    public float DistanceToRightWall(int numCasts = 5) => CheckDistance(
      Vector2.right,
      parent.bounds.center,
      parent.bounds.size,
      numCasts
    );

    private float CheckDistance(Vector2 direction, Vector2 center, Vector2 extents, int checks = 5) {
      // Ready to get mathy, bro?

      // normal = (-direction.y, direction.x)
      Vector2 normal = Vector2.Perpendicular(direction);

      // picks a corner to start from based on which direction we're checking
      // collisions for.
      Vector2 startingPositionOffset = extents*direction + extents*normal; 

      // When using the normal, one of extents.x/extents.y will be zero,
      // so we're basically just grabbing the non-zero value in that vector
      // after the multiply to get the side length.
      // From there we calculate how big each step in our scan will be.
      Vector2 side = (2*extents*normal);
      float sideLength = Mathf.Abs(side.x + side.y); 
      float stepSize = sideLength/(checks-1);

      // scan across the edge we care about to find the closest collider to our own.
      float minDistance = float.PositiveInfinity;
      for (int i = 0; i < checks; i++) {
        float distFromStart = stepSize*i;
        Vector2 checkPosition = center + startingPositionOffset - distFromStart*normal;
        
        RaycastHit2D hit = Physics2D.Raycast(checkPosition, direction, float.PositiveInfinity, layerMask);
  
        if (IsHit(hit.collider, hit.normal, -direction) && minDistance > hit.distance) {
          minDistance = hit.distance;
        }
      }

      // Viola.
      return minDistance;
    }

    /// <summary>
    /// Whether or not the top right of the collider is close to a wall.
    /// </summary>
    /// <returns>True if the collider's top right corner is by a wall. False otherwise.</returns>
    public float TopDistanceToRightWall() {
      Vector2 center = new Vector2(parent.bounds.center.x, parent.bounds.center.y);
      Vector2 startTopRight = center + new Vector2(parent.bounds.extents.x, parent.bounds.extents.y);
      RaycastHit2D hit = Physics2D.Raycast(startTopRight, Vector2.right, float.PositiveInfinity, layerMask);
      return hit.distance;
    }

    /// <summary>
    /// Whether or not the bottom right of the colllider is close to a wall.
    /// </summary>
    /// <returns>True if the collider's bottom right corner is by a wall. False otherwise.</returns>
    public float BottomDistanceToRightWall() {
      Vector2 center = new Vector2(parent.bounds.center.x, parent.bounds.center.y);
      Vector2 startBottomRight = center + new Vector2(parent.bounds.extents.x, -parent.bounds.extents.y);
      RaycastHit2D hit = Physics2D.Raycast(startBottomRight, Vector2.right, float.PositiveInfinity, layerMask);
      return hit.distance;
    }

    /// <summary>
    /// Whether or not the top left of the collider is close to a wall.
    /// </summary>
    /// <returns>True if the collider's top left corner is by a wall. False otherwise.</returns>
    public float TopDistanceToLeftWall() {
      Vector2 center = new Vector2(parent.bounds.center.x, parent.bounds.center.y);
      Vector2 startTopLeft = center + new Vector2(-parent.bounds.extents.x, parent.bounds.extents.y);
      RaycastHit2D hit = Physics2D.Raycast(startTopLeft, Vector2.left, float.PositiveInfinity, layerMask);
      return hit.distance;
    }

    /// <summary>
    /// Whether or not the bottom left of the collider is close to a wall.
    /// </summary>
    /// <returns>True if the collider's bottom left corner is by a wall. False otherwise.</returns>
    public float BottomDistanceToLeftWall() {
      Vector2 center = new Vector2(parent.bounds.center.x, parent.bounds.center.y);
      Vector2 startBottomLeft = center + new Vector2(-parent.bounds.extents.x, -parent.bounds.extents.y);
      RaycastHit2D hit = Physics2D.Raycast(startBottomLeft, Vector2.left, float.PositiveInfinity, layerMask);
      return hit.distance;
    }

    /// <summary>
    /// How far the player is from the closest wall.
    /// </summary>
    /// <returns>The distance between the player and the closest wall.</returns>
    public float DistanceToWall(int numCasts = 5) {
      return Mathf.Min(new float[] {
        DistanceToLeftWall(numCasts),
        DistanceToRightWall(numCasts)
      });
    }
    #endregion

    #region Collision Checking
    /// <summary>
    /// Whether or not the player is touching the ground.
    /// </summary>
    public bool IsTouchingGround() => IsTouchingGround_Inner(parent.bounds.center, parent.bounds.size);
    private bool IsTouchingGround_Inner(Vector2 center, Vector2 size) {
      Vector2 boxCast = size - new Vector2(boxCastMargin, 0);

      Vector2 startLeft = center - new Vector2(center.x, center.y-size.y/2);

      Vector2 startRight = center - new Vector2(-center.x, center.y - size.y/2);

      RaycastHit2D[] hits = Physics2D.BoxCastAll(
        center,
        boxCast,
        0,
        Vector2.down,
        colliderWidth,
        layerMask
      );

      foreach(var hit in hits) {
        if (IsHit(hit.collider, hit.normal, Vector2.up))
        Debug.DrawLine(hit.point, hit.point+hit.normal, Color.red, 0.1f);
      }

      return AnyHits(hits, Vector2.up);
    }

    /// <summary>
    /// Whether or not the player is touching a left-hand wall.
    /// </summary>
    public bool IsTouchingLeftWall() => IsTouchingLeftWall_Inner(parent.bounds.center, parent.bounds.size);
    private bool IsTouchingLeftWall_Inner(Vector2 center, Vector2 size) {
      Vector2 boxCast = size - new Vector2(0, boxCastMargin);

      RaycastHit2D[] hits = Physics2D.BoxCastAll(
        center,
        boxCast,
        0,
        Vector2.left,
        colliderWidth,
        layerMask
      );

      return AnyHits(hits, Vector2.right);
    }

    /// <summary>
    /// Whether or not the player is touching a right-hand wall.
    /// </summary>
    public bool IsTouchingRightWall() => IsTouchingRightWall_Inner(parent.bounds.center, parent.bounds.size);
    private bool IsTouchingRightWall_Inner(Vector2 center, Vector2 size) {
      Vector2 boxCast = size - new Vector2(0, boxCastMargin);


      RaycastHit2D[] hits = Physics2D.BoxCastAll(
        center,
        boxCast,
        0,
        Vector2.right,
        colliderWidth,
        layerMask
      );

      return AnyHits(hits, Vector2.left);
    }

    /// <summary>
    /// Whether or not the collider is hanging over a left-hand ledge.
    /// </summary>
    /// <returns>True if the bottom left corner of the collider isn't touching
    /// the ground.</returns>
    public bool IsOverLeftLedge() => IsOverLeftLedge_Inner(parent.bounds.center, parent.bounds.size);
    private bool IsOverLeftLedge_Inner(Vector2 center, Vector2 size) {
      Vector2 bottomLeftCorner = new Vector2(
        center.x-(size.x/2),
        center.y-(size.y/2)
      );

      RaycastHit2D[] hits = Physics2D.RaycastAll(
        bottomLeftCorner,
        Vector2.down,
        colliderWidth,
        layerMask
      );

      return !AnyHits(hits, Vector2.down);
    }

    /// <summary>
    /// Whether or not the collider is hanging over a right-hand ledge.
    /// </summary>
    /// <returns>True if the bottom right corner of the collider isn't touching
    /// the ground.</returns>
    public bool IsOverRightLedge() => IsOverRightLedge_Inner(parent.bounds.center, parent.bounds.size);
    private bool IsOverRightLedge_Inner(Vector2 center, Vector2 size) {
      Vector2 bottomLeftCorner = new Vector2(
        center.x+(size.x/2),
        center.y+(size.y/2)
      );

      RaycastHit2D[] hits = Physics2D.RaycastAll(
        bottomLeftCorner,
        Vector2.down,
        colliderWidth,
        layerMask
      );

      return !AnyHits(hits, Vector2.down);
    }

    /// <summary>
    /// Whether or not the object is touching the ceiling.
    /// </summary>
    public bool IsTouchingCeiling() => IsTouchingCeiling_Inner(parent.bounds.center, parent.bounds.size);
    private bool IsTouchingCeiling_Inner(Vector2 center, Vector2 size) {
      Vector2 boxCast = size - new Vector2(0, boxCastMargin);

      RaycastHit2D[] hits = Physics2D.BoxCastAll(
        center,
        boxCast,
        0,
        Vector2.up,
        colliderWidth,
        layerMask
      );

      return AnyHits(hits, Vector2.down);
    }


    /// <summary>
    /// Whether or not a list of raycast hits is in the desired direction.
    /// </summary>
    /// <param name="hits">The list of RaycastHits</param>
    /// <param name="normalDirection">The normal of the direction to check hits against.</param>
    /// <returns>Whether or not there are any ground contacts in the desired direction.</returns>
    private bool AnyHits(RaycastHit2D[] hits, Vector2 normalDirection) {
      for (int i = 0; i < hits.Length; i++) {
        if (IsHit(hits[i].collider, hits[i].normal, normalDirection)) {
          return true;
        }
      }

      return false;
    }

    /// <summary>
    /// Whether or not a collision can be considered a valid "ground" collision.
    /// </summary>
    /// <param name="collider">The collider of the other object (i.e., not the
    /// player's collider).</param>
    /// <param name="hitNormal">The normal for the collision.</param>
    /// <param name="checkNormal">The normal expected.</param>
    /// <returns>True if this is a valid "ground" hit. False otherwise.</returns>
    public bool IsHit(Collider2D collider, Vector2? hitNormal = null, Vector2? checkNormal = null) {
      if (collider == null) {
        return false;
      }

      if (hitNormal.HasValue && checkNormal.HasValue) {
        return IsOverlap(collider) && hitNormal?.normalized == checkNormal?.normalized; // Collision is in the right direction.
      } else {
        return IsOverlap(collider);
      }
    }


    /// <summary>
    /// Whether or not a collision can be considered a valid overlap with the ground.
    /// </summary>
    /// <param name="collider">The collider</param>
    /// <returns>True if this is a valid "ground" overlap.</returns>
    private bool IsOverlap(Collider2D collider) {
      if (collider == null) {
        return false;
      }

      return (parent == null || !Physics2D.GetIgnoreCollision(collider, parent)) && // Collision isn't purposefully ignored,
        IsTagged(collider) && // Collider is tagged with something we care about
        !collider.isTrigger; // & Collider isn't a trigger.
    }

    private bool IsTagged(Collider2D collider) {
      foreach (string tag in tags) {
        if (!collider.CompareTag(tag)) {
          return false;
        }
      }

      return true;
    }


    /// <summary>
    /// Whether or not a box will fit in a position one space below where it
    /// currently is.
    /// </summary>
    /// <returns>Returns true if the box would fit in the space directly below
    /// it's feet.</returns>
    public bool FitsDown(out Collider2D[] hits) => FitsDown(parent.bounds.center, parent.bounds.size, out hits);
    private bool FitsDown(Vector2 center, Vector2 size, out Collider2D[] hits) {
      Vector2 newPosition = center - new Vector2(0, size.y);
      Collider2D[] results = Physics2D.OverlapBoxAll(newPosition, size, 0, layerMask);

      List<Collider2D> outList = new List<Collider2D>();
      foreach(Collider2D col in results) {
        if (IsOverlap(col)) {
          outList.Add(col);
        }
      }

      hits = outList.ToArray();
      return hits.Length == 0;
    }

    /// <summary>
    /// Whether or not a box will fit in a position one space above where it
    /// currently is.
    /// </summary>
    /// <returns>Returns true if the box would fit in the space directly above
    /// it's top.</returns>
    public bool FitsUp(out Collider2D[] hits) => FitsUp(parent.bounds.center, parent.bounds.size, out hits);
    private bool FitsUp(Vector2 center, Vector2 size, out Collider2D[] hits) {
      Vector2 newPosition = center + new Vector2(0, size.y);
      hits = Physics2D.OverlapBoxAll(newPosition, size, 0, layerMask);
      return hits.Length == 0;
    }

    /// <summary>
    /// Whether or not a box will fit in a position one space to the left of where it
    /// currently is.
    /// </summary>
    /// <returns>Returns true if the box would fit in the space directly to its left.</returns>
    public bool FitsLeft(out Collider2D[] hits) => FitsLeft(parent.bounds.center, parent.bounds.size, out hits);
    private bool FitsLeft(Vector2 center, Vector2 size, out Collider2D[] hits) {
      Vector2 newPosition = center - new Vector2(size.x, 0);
      hits = Physics2D.OverlapBoxAll(newPosition, size, 0, layerMask);
      return hits.Length == 0;
    }

    /// <summary>
    /// Whether or not a box will fit in a position one space to the right of where it
    /// currently is.
    /// </summary>
    /// <returns>Returns true if the box would fit in the space directly to its right.</returns>
    public bool FitsRight(out Collider2D[] hits) => FitsRight(parent.bounds.center, parent.bounds.size, out hits);
    private bool FitsRight(Vector2 center, Vector2 size, out Collider2D[] hits) {
      Vector2 newPosition = center + new Vector2(size.x, 0);
      hits = Physics2D.OverlapBoxAll(newPosition, size, 0, layerMask);
      return hits.Length == 0;
    }

    /// <summary>
    /// Whether or not a box will fit in a position one space to the right of where it
    /// currently is.
    /// </summary>
    /// <param name="center">The center of the box.</param>
    /// <param name="size">The dimensions of the box.</param>
    /// <param name="direction">The direction to check</param>
    /// <returns>Returns true if the box would fit in the space directly to its right.</returns>
    public bool FitsInDirection(Vector2 direction, out Collider2D[] hits) => FitsInDirection(parent.bounds.center, parent.bounds.size, direction, out hits);
    private bool FitsInDirection(Vector2 center, Vector2 size, Vector2 direction, out Collider2D[] hits) {
      Vector2 newPosition = center + size*direction.normalized;
      hits = Physics2D.OverlapBoxAll(newPosition, size, 0, layerMask);
      return hits.Length == 0;
    }
    #endregion
  }
}