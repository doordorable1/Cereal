using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Tags {normal,blockui }
public class Tag : Singleton<Tag>
{
    public Tags tag;
    public int index; //여러개판별용 
    public static List<Tag> tags=new();



    void Awake()
    {
        tags = new();
        tags.Add(this);
    }

    public static Tag Find(Tags _tag)
    {
        for (int i = 0; i < tags.Count; i++)
        {
            if(tags[i].tag == _tag) 
                     return tags[i];
        }

        return null;
    }

    public static List<Tag> Finds(Tags _tag)
    {
        List<Tag> o = new();
        for (int i = 0; i < tags.Count; i++)
        {
            if (tags[i].tag == _tag)
                o.Add(tags[i]);
        }

        return o;
    }
}
