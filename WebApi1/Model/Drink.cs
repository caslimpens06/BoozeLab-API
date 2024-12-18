namespace RenderDrinkAPI.Model;

public class Drink
{
	private string _name;
	private string _type;
	private string _link;

	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}

	public string Type
	{
		get { return _type; }
		set { _type = value; }
	}

	public string Link
	{
		get { return _link; }
		set { _link = value; }
	}

	public Drink(string name, string type, string link)
	{
		_name = name;
		_type = type;
		_link = link;
	}
	public Drink(string name, string type)
	{
		_name = name;
		_type = type;
		_link = "";
	}
}

