namespace WebApi1.Model
{
	public class Drink
	{
		private int _id;
		private string _name;
		private string _type;
		private string _imageDataBase64;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public string Name
		{
			get { return _name; }
			set	{ _name = value; }
		}

		public string Type
		{
			get { return _type; }
			set { _type = value; }
		}

		public string ImageBinary
		{
			get { return _imageDataBase64; }
			set { _imageDataBase64 = value; }
		}

		public Drink(int id, string name, string type, string imageDataBase64)
		{
			_id = id;
			_name = name;
			_type = type;
			_imageDataBase64 = imageDataBase64;
		}
	}
}
