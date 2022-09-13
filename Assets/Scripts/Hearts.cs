using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Hearts : MonoBehaviour
{
    //speed that the heart projectile is moving
    public float speed;
    //how many seconds before heart projectile destroy itself
    public float lifeTime = 1;
    //direction that heart projectile is moving (to the right)
    public Vector2 direction = new Vector2(1, 0);
    //hearts animation sprites
    public Sprite[] attackSprites;
    SpriteRenderer sr;
    public float framesPerSecond;
    public float damage = 20;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        // normalize direction so it does not impact the travel speed
        direction.Normalize();
        // make the projectile rotate into the direction it is moving
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        StartCoroutine(ShootHearts());
    }

    // Update is called once per frame.This moves the GameObject to the right at speed and kills the object after lifeTime expires
    /// </summary>
    void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
    }

    private IEnumerator ShootHearts()
    {
        for (int i = 0; i < attackSprites.Length; i++)
        {
            sr.sprite = attackSprites[i];
            lifeTime = 1 / framesPerSecond;
            yield return new WaitForSeconds(lifeTime);
        }
        Destroy(gameObject);
    }

        /// <summary>
        /// This is called by Unity when the object collides with another object. It is only called, when both objects have any 2D Collider attached, none them is a trigger and at least one of
        /// the two colliding GameObjects has a Rigidbody2D attached. If one of the two 2D Colliders is a trigger, OnTriggerEnter2D(Collider other) is called instead. 
     void OnTriggerEnter2D(Collider2D col)
    {
            if (col.gameObject.CompareTag("Evil Ghost"))
            { // This checks if we hit the evil ghost. The evil ghost needs the "Evil Ghost" tag for this to work
                EvilGhost evilGhost = col.gameObject.GetComponent<EvilGhost>(); // Grab the evil ghost script
                evilGhost.loseHealth(damage); // notify the evil ghost it got hit (loseHealth should be reducing evil ghost health)
                Destroy(gameObject); // Destory this projectile
            }
        }
 }