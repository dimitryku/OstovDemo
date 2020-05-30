using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Verticle
{
    private string name;
    public static int count;

    public Verticle()
    {
        name = "v" + (count + 1).ToString();
    }

    public Verticle(string _name)
    {
        name = _name;
    }

    public string GetName()
    {
        return this.name;
    }

    public void SetName(string _name)
    {
        this.name = _name;
    }

    public override bool Equals(object obj)
    {
        Verticle newWert = obj as Verticle;
        if (newWert == null)
            return false;
        return this.name.Equals(newWert.GetName());
    }
}