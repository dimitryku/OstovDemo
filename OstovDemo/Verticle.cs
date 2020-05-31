using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


public class Verticle
{
    private string name;
    private Point point;
    
    public void SetPosition(int a, int b)
    {
        point = new Point(a, b);
    }

    public Point GetPosition()
    {
        return point;
    }


    public Verticle()
    {
        name = "v" + (1).ToString(); //добавить номер
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

    public override int GetHashCode()
    {
        int code = 0;
        foreach (char c in name)
            code += (int)c;
        return code;
    }
}