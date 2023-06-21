using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: dotnet run <negara> <hscode> <kdnegara> <pelabuhan>");
            return;
        }

        string negara = args[0];
        string hsCode = args[1];
        string kdnegara = args[2];
        string pelabuhan = args[3];

        string urNegaraUrl = $"https://insw-dev.ilcs.co.id/n/negara?ur_negara={negara}";
        string pelabuhanUrl2 = $"https://insw-dev.ilcs.co.id/n/pelabuhan?kd_negara=SG&ur_pelabuhan=jur";
        string pelabuhanUrl = $"https://insw-dev.ilcs.co.id/n/pelabuhan?kd_negara={kdnegara}&ur_pelabuhan={pelabuhan}";
        string barangUrl = $"https://insw-dev.ilcs.co.id/n/barang?hs_code={hsCode}";
        string tarifUrl = $"https://insw-dev.ilcs.co.id/n/tarif?hs_code={hsCode}";

        using (HttpClient client = new HttpClient())
        {
            // Mengambil data negara
            HttpResponseMessage negaraResponse = await client.GetAsync(urNegaraUrl);
            if (negaraResponse.IsSuccessStatusCode)
            {
                string negaraData = await negaraResponse.Content.ReadAsStringAsync();
                Console.WriteLine("Negara Data:");
                Console.WriteLine(negaraData);
            }
            else
            {
                Console.WriteLine("Failed to retrieve negara data. Status code: " + negaraResponse.StatusCode);
            }

            // Mengambil data pelabuhan
            HttpResponseMessage pelabuhanResponse = await client.GetAsync(pelabuhanUrl);
            if (pelabuhanResponse.IsSuccessStatusCode)
            {
                string pelabuhanData = await pelabuhanResponse.Content.ReadAsStringAsync();
                Console.WriteLine("Pelabuhan Data:");
                Console.WriteLine(pelabuhanData);
            }
            else
            {
                Console.WriteLine("Failed to retrieve pelabuhan data. Status code: " + pelabuhanResponse.StatusCode);
            }

            // Mengambil data barang
            HttpResponseMessage barangResponse = await client.GetAsync(barangUrl);
            if (barangResponse.IsSuccessStatusCode)
            {
                string barangData = await barangResponse.Content.ReadAsStringAsync();
                Console.WriteLine("Barang Data:");
                Console.WriteLine(barangData);
            }
            else
            {
                Console.WriteLine("Failed to retrieve barang data. Status code: " + barangResponse.StatusCode);
            }

            // Mengambil data tarif
            HttpResponseMessage tarifResponse = await client.GetAsync(tarifUrl);
            if (tarifResponse.IsSuccessStatusCode)
            {
                string tarifData = await tarifResponse.Content.ReadAsStringAsync();
                Console.WriteLine("Tarif Data:");
                Console.WriteLine(tarifData);
            }
            else
            {
                Console.WriteLine("Failed to retrieve tarif data. Status code: " + tarifResponse.StatusCode);
            }
        }
    }
}
