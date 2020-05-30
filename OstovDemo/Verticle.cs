using System;

public class verticle
{
    private string name;

    public verticle()
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
