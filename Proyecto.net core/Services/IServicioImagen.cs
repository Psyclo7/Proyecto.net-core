﻿using Microsoft.AspNetCore.Mvc;

namespace Proyecto.net_core.Services
{
    public interface IServicioImagen 
    {
        Task<string> SubirImagen (string archivo,string nombre);
        Task<string> SubirImagen(Stream image, string fileName);
    }
}
