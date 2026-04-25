using System;
using System.Linq;
using HttpClientSample.Models;

namespace HttpClientSample
{
    class Program
    {
        static void Main(string[] args)
        {
            RestApiQueries api = new RestApiQueries();
            const string endpoint = "todos";

            // 1) GET all
            var todos = api.GetTodos(endpoint);
            Console.WriteLine($"GET /{endpoint} -> {todos.Count} éléments");
            foreach (var t in todos.Take(20))
            {
                Console.WriteLine($"#{t.Id} | User:{t.UserId} | Done:{t.Completed} | {t.Title}");
            }

            Console.WriteLine();

            // 2) GET one
            var one = api.GetTodo(1, endpoint);
            Console.WriteLine($"GET /{endpoint}/1 -> #{one.Id} | {one.Title}");

            Console.WriteLine();

            // 3) POST
            var newTodo = new Todo
            {
                UserId = 1,
                Title = "Todo créé depuis console",
                Completed = false
            };

            bool created = api.AddTodo(newTodo, endpoint);
            Console.WriteLine($"POST /{endpoint} -> {(created ? "OK" : "KO")}");

            // 4) PUT
            var updatedTodo = new Todo
            {
                Id = 1,
                UserId = 1,
                Title = "Todo modifié depuis console",
                Completed = true
            };

            bool updated = api.CompleteTodo(updatedTodo, endpoint);
            Console.WriteLine($"PUT /{endpoint}/1 -> {(updated ? "OK" : "KO")}");

            // 5) DELETE
            bool deleted = api.DeleteTodo(1, endpoint);
            Console.WriteLine($"DELETE /{endpoint}/1 -> {(deleted ? "OK" : "KO")}");
        }
    }
}