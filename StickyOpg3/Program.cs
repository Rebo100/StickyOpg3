
using global::System;

public class Program
{
    public static Commissie[] commisies;
    public static UFO[] ufos;
    
    public static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int c = int.Parse(input[0]);
        int u = int.Parse(input[1]);

        commisies = new Commissie[c];
        for (int i = 0; i < c; i++)
        {
            string[] s = Console.ReadLine().Split();
            commisies[i] = new Commissie(s[0], s[1]);
        }

        ufos = new UFO[u];
        for (int i = 0; i < u; i++)
        {
            string[] s = Console.ReadLine().Split();
            ufos[i] = new UFO(int.Parse(s[0]), s[1], s[2], int.Parse(s[3]));
        }

        Simulatie();
        for (int i = 0; i < commisies.Length; i++)
        {
            Console.WriteLine(commisies[i].distance);
        }
    }

    private static void Simulatie()
    {
        foreach (UFO u in ufos)
        {
            foreach (Commissie c in commisies)
            {
                if (c.location == u.startLocation)
                {
                    if (c.code % ConvertPlace(u.startLocation) == u.key)
                    {
                        c.location = u.endLocation;
                        c.distance += u.distance;
                    }
                }
            }
        }
    }

    private static long ConvertPlace(String s)
    {
        long code = 1;
        foreach (Char c in s)
        {
            code *= c - 96;
        }

        return code;
    }
}

public class Commissie
{
    public string location;
    public long code;
    public long distance;

    public Commissie(string name, string location)
    {
        code = 1;
        foreach (Char c in name)
        {
            code *= c - 96;
        } 
        this.location = location;
        distance = 0;
    }
}

public class UFO
{
    public int key;
    public string startLocation;
    public string endLocation;
    public int distance;

    public UFO(int key, string startLocation, string endLocation, int distance)
    {
        this.key = key;
        this.startLocation = startLocation;
        this.endLocation = endLocation;
        this.distance = distance;
    }
}