using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto.net_core.Services
{
    public class ServicioImagen : IServicioImagen
    {
        public async Task<string> SubirImagen(Stream archivo,
            string nombre)
        {
            string email = "patricio.celi@itq.edu.ec";
            string clave = "Itq2023*";
            string ruta = "proyectoclaselibreria.appspot.com";
            string api_key = "AIzaSyBYn994EANCSJOn2ZXaRr5u-ROMtzlWWZE";

            var auth = new FirebaseAuthProvider
                (new FirebaseConfig(api_key));
            var a = await auth.SignInWithEmailAndPasswordAsync(email, clave);

            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
              ruta,
              new FirebaseStorageOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                  ThrowOnCancel = true
              })

               .Child("Fotos_Perfil")
               .Child(nombre)
               .PutAsync(archivo, cancellation.Token);

            var downloadURL = await task;
            return downloadURL;
        }

        public Task<string> SubirImagen(string archivo, string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
