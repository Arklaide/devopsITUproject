using Microsoft.AspNetCore.Mvc;
using MInitweetApi.Models;
public interface IUtilityRepository
{
    public int Latest();
    public void PutLatest(int latest);
}