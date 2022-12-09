## **Friday, December 9th, 2022 - v1.0.3**
+ Change assembly definition name to avoid namespace collisions.
## **Tuesday, December 6th, 2022 - v1.0.2**
+ Fixed an issue where collisions were filtered out if colliders didn't belong
  to ALL listed tags, instead of including them if they belonged to ANY listed
  tag.
+ Fixed an issue where colliders could unexpectedly collide with themselves.

## **Wednesday, November 30th, 2022 - v1.0.0**
### *Breaking Changes*
+ center and size no longer need to be passed in. As a trade off, a collider
  must be provided in the constructor
+ layer mask defaults to "Default" layer unless otherwise specified
+ collision checking no longer assumes to CompareTag() against "Ground" tag. a
  list of tags can now be passed into the constructor.

## **Wednesday, November 30th, 2022 - v0.0.1**

### Changes *(Breaking)*
+ initial commit
+ Changed class name from CollisionComponent to CollisionCaster to avoid
  confusion down the road
+ Changed interface name from ICollision to ICollisionCaster for consistency
