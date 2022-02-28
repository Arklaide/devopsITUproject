using MInitweetApi.Models;

public class UtilityRepository : IUtilityRepository
{
    
    private readonly DatabaseContext _context;

    public UtilityRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    
    public int Latest()
    {
        var util = _context.Utility.OrderByDescending(i => i.id).FirstOrDefault();
        if (util != null)
        {
            return util.LATEST;
        }
        return -1;
    }

    public void PutLatest(int latest)
    {
        Console.WriteLine("updating latest");
        var util = _context.Utility.OrderByDescending(i => i.id).FirstOrDefault();
        if (util != null) util.LATEST = latest;
        else _context.Utility.Add(new Utility { LATEST = latest });
        
        _context.SaveChanges();
    }
}