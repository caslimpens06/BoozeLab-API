using Npgsql;
using RenderDrinkAPI.Model;

namespace RenderDrinkAPI.DataAccessLayer;
public class SupabaseService
{
	private readonly string connectionString = "User Id=postgres.hbhcuzgskunhlkgfdmgx;Password=APIDRINK@#$%;Server=aws-0-eu-central-1.pooler.supabase.com;Port=6543;Database=postgres;CommandTimeout=10;Timeout=10;Pooling=true;MaxPoolSize=200;MinPoolSize=20;SSL Mode=Disable;";

	public SupabaseService() { }

	public List<Drink> GetDrinks()
	{
		var drinks = new List<Drink>();

		string query = "SELECT \"Name\", \"Type\" FROM public.\"Drink\"";

		using (var connection = new NpgsqlConnection(connectionString))
		{
			connection.Open();

			using (var command = new NpgsqlCommand(query, connection))
			{
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						Drink drink = new Drink(reader.GetString(0), reader.GetString(1));
						drinks.Add(drink);
					}
				}
			}
		}
		return drinks;
	}

}

