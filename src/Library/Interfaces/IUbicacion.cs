using System;
using LocationApi;
using System.Threading.Tasks;


namespace Library
{
    public interface IUbicacion
    {
        
        
        Task <Location> GetUbicacion(string ubicacion);
        
    }

}