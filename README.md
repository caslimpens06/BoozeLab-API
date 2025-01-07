**Web API for retrieving data about alcoholic drinks.**

**Includes**
Name of the drink (for example: Heineken, Desperados) and Type (for example: beer, wine, mixed drinks, booze)

**How does it work**
Do a HTTP GET request to the following adress: https://truthordrinkapi.onrender.com/api/myapi/drinks

You can also open this link in your browser. The request will take about 5-15 seconds, depending on the server availability.
Sometimes the API will throw "Internal server error: Exception while reading from stream" if there are too many requests. In that case, simply try again.

**How to use in code**

Below is an example on how to do this HTTP GET request in C#.

```csharp
using System.Text.Json;
using TruthOrDrink.Model;

namespace TruthOrDrink.DataAccessLayer
{
	public class APIService
	{
		private static readonly HttpClient client = new HttpClient();

		public APIService() { }

		public async static Task<List<Drink>> GetDrinksData()
		{
			string apiUrl = "https://truthordrinkapi.onrender.com/api/myapi/drinks";

			try
			{
				HttpResponseMessage response = await client.GetAsync(apiUrl);

				if (response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();

					var drinks = JsonSerializer.Deserialize<List<Drink>>(responseBody);

					if (drinks != null && drinks.Count > 0)
					{
						Console.WriteLine($"Successfully fetched {drinks.Count} drinks.");
						return drinks;
					}
					else
					{
						Console.WriteLine("No drinks found or failed to deserialize.");
					}
				}
				else
				{
					Console.WriteLine($"API request failed with status code: {response.StatusCode}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error occurred: {ex.Message}");
			}

			return null;
		}
	}
}
```

**Reponse**
Reponse is in JSON format and will look something like this:
[{"name":"Heineken","type":"Bier"},{"name":"Amstel","type":"Bier"},{"name":"Brand","type":"Bier"}]

**-- The API response is in Dutch --**
