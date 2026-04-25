using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using HttpClientSample.Models;
using Newtonsoft.Json;


namespace HttpClientSample
{
    
    public class RestApiQueries
    {
        private HttpClient _client;

        public RestApiQueries()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // ======= ALL THE ASYNC FUNCTIONS ========

        /// <summary>
        /// Async function to get all the todos
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<List<Todo>> GetTodosAsync(string path)
        {
            HttpResponseMessage response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                List<Todo> todos = JsonConvert.DeserializeObject<List<Todo>>(data);

                return todos;
            }

            return new List<Todo>();
        }

        /// <summary>
        ///  Async function to get a specifique todo
        /// </summary>
        /// <param name="todoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<Todo> GetTodoAsync(int todoId, string path)
        {

            HttpResponseMessage response = await _client.GetAsync($"{path}/{todoId}");

            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                Todo todo = JsonConvert.DeserializeObject<Todo>(data);
                return todo;
            }

            return new Todo();
        }

        /// <summary>
        /// Async function to create a todo
        /// </summary>
        /// <param name="todo"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<bool> AddTodoAsync(Todo todo, string path)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(todo), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(path, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Async function to modify a specific todo
        /// </summary>
        /// <param name="todo"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<bool> CompleteTodoAsync(Todo todo, string path)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(todo), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"{path}/{todo.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Async function to delete s specifique todo
        /// </summary>
        /// <param name="todoId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<bool> RemoveTodoAsync(int todoId, string path)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"{path}/{todoId}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // ====== ALL THE FUNCTIONS THAT WILL BE CALL BY THE UI/Console APP? WPF

        public List<Todo> GetTodos(string path)
        {
            List<Todo> todos = new List<Todo>();

            try
            {
                Task<List<Todo>> task = Task.Run(async () => await GetTodosAsync(path));
                task.Wait();
                todos = task.Result;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return todos;
        }

        public Todo GetTodo(int id,  string path)
        {
            try
            {
                Task<Todo> task = Task.Run(async () => await GetTodoAsync(id, path));
                task.Wait();

                return task.Result;

            }catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            return new Todo();
        }

        public bool AddTodo(Todo todo,  string path)
        {
            try
            {
                Task<bool> task = Task.Run(async () => await AddTodoAsync(todo, path));
                task.Wait();
                return task.Result;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public bool CompleteTodo(Todo newTodo, string path)
        {
            try
            {
                Task<bool> task = Task.Run(async () => await CompleteTodoAsync(newTodo, path));
                task.Wait();
                return task.Result;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public bool DeleteTodo(int  id, string path)
        {
            try
            {

                Task<bool> task = Task.Run(async () => await RemoveTodoAsync(id, path));
                task.Wait();

                return task.Result;

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }
    }

}
