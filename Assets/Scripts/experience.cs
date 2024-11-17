using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class experience_and_level : MonoBehaviour
{
    public int level;
    public int experience_points;
    public List<int> xpPerLevel;
    [ContextMenu("Add 30 Experience")]
    public void add_xp_demo()
    {
        AddExperience(30);
    }

    [ContextMenu("Init")]
    public void init_demo(){
        init();
    }

    public void init(int level = 0, int experience_points = 0){
        this.level = level;
        this.experience_points = experience_points;
        xpPerLevel = new List<int> {10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65};
    }
    public void AddExperience(int amount){
        experience_points += amount;
        while (level < xpPerLevel.Count && experience_points >= xpPerLevel[level]){
            experience_points -= xpPerLevel[level];
            level ++;
            //Call function to add player stats
        }
    }

}
