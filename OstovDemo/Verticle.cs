using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Verticle
{
    private string name;

    public Verticle()
    {

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
        return base.Equals(obj);
    }
}