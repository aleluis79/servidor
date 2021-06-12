using System;
using System.IO;
using System.Net;
using System.Text.Json;

namespace servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            using( var listener = new HttpListener() )
            {
                listener.Prefixes.Add("http://localhost:9999/" );

                listener.Start();

                for( ;;)
                {

                    Console.WriteLine( "Listening..." );

                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;

                    string text;
                    using (var reader = new StreamReader(request.InputStream,
                                                        request.ContentEncoding))
                    {
                        text = reader.ReadToEnd();
                    }
                    
                    if (request.HttpMethod == "POST") {
                        Mensaje mensaje = JsonSerializer.Deserialize<Mensaje>(text);
                        Console.WriteLine("RECIBIO: " + text);
                    }

                    using( HttpListenerResponse response = context.Response )
                    {
                        WriteMsg(response, text);
                    }
                }
            }
        }

        private static void WriteMsg(HttpListenerResponse response, string msg)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(msg);
            response.ContentLength64 = buffer.Length;
            response.StatusCode = 200;
            response.StatusDescription = "OK";            
            response.AddHeader("Access-Control-Allow-Origin", "*");
            response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            response.AddHeader("Access-Control-Allow-Headers", "*");
            response.AddHeader("Access-Control-Max-Age", "86400");            
            using (var output = response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
            }
        }
    }
}


public class Mensaje {
    public string Accion { get; set; }

    public string Valor { get; set; }
}