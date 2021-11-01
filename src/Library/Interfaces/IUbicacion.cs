using System;
using LocationApi;
using System.Threading.Tasks;


namespace Library
{
    public interface IUbicacion
    {
        
        
        async void GetUbicacion(string ubicacion);
        
    }

}