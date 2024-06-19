using rest_api.Models;

namespace rest_api.Services;

public static class PastelService
{
    static List<Pastel> Pasteis { get; }
    static int nextId = 3;
    static PastelService()
    {
        Pasteis = new List<Pastel>{
            new Pastel{Id = 1, Nome = "Bomba atômica", LivreDeGluten = false},
            new Pastel{Id = 2, Nome = "Drible de vaca Vegano", LivreDeGluten = true}
        };
    }
    public static List<Pastel> GetAll() => Pasteis;

    public static Pastel? Get(int id) => Pasteis.FirstOrDefault(p => p.Id == id);

    public static void Add(Pastel pastel)
    {
        pastel.Id = nextId++;
        Pasteis.Add(pastel);
    }

    public static void Delete(int id)
    {
        var pastel = Get(id);
        if (pastel is null) return;
        Pasteis.Remove(pastel);
    }

    public static void Update(Pastel pastel)
    {
        var index = Pasteis.IndexOf(pastel);
        if (index == -1) return;

        Pasteis[index] = pastel;
    }
}