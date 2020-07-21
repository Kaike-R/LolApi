using System;
using static System.Console;

namespace LolTeste2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Acessando a Web API, aguarde um momento...");

            var repositorio = new UsuarioRepositorio();

            var usuariosTask = repositorio.GetUsuariosAsync();

            usuariosTask.ContinueWith(task =>{
                var usuarios = task.Result;
                WriteLine(usuarios.name);
                Environment.Exit(0);
            });

            ReadLine();   
        }
    }
}
