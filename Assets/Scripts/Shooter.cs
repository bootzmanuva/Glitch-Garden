using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
            //TODO change animation state to shooting
        }
        else
        {
            animator.SetBool("isAttacking", false);
            //TODO change animation state to idle
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) 
                <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        //if my lane spawner child count less than or equal to 0
        //return false
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;//no attackers in our lane
        }
        else
        {
            return true;//yes there are attackers in our lane
        }
    }

    public void Fire()
    {
        GameObject newProjectile = 
            Instantiate(projectile, gun.transform.position, gun.transform.rotation)
            as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }

}
